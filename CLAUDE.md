# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

MAD ERP Backend is a microservices-based Enterprise Resource Planning system built with .NET 8.0 and Clean Architecture principles. The system manages various domains including Administration (ADM), Human Resources (HRM), Organization (ORG), Students (STD), Finance (FIN), Commissions (COM), and others.

## Architecture

### Clean Architecture Layers

Each service follows Clean Architecture with strict layer separation:

- **Domain Layer** (`*.Domain.csproj`): Core business entities, value objects, domain events, and business rules
- **Application Layer** (`*.Application.csproj`): Use cases, CQRS handlers (MediatR), DTOs, validation (FluentValidation), and interface definitions
- **Infrastructure Layer** (`*.Infrastructure.csproj`): Database access (EF Core + PostgreSQL), external integrations, repositories
- **WebApi Layer** (`*.WebApi.csproj`): REST API endpoints, controllers, authentication/authorization (Keycloak), middleware

**Dependency Flow (Strictly Enforced):**
```
WebApi → Infrastructure → Application → Domain
         (references up, never down)
```

### Project Structure

```
├── libs/dotnet/                      # Shared libraries
│   ├── Erp.Core                      # Core utilities and extensions
│   ├── Erp.Core.Sdk                  # SDK components
│   ├── Erp.Core.Service.Application  # Base application layer components
│   ├── Erp.Core.Service.Domain       # Base domain layer components
│   ├── Erp.Core.Service.Infrastructure # Base infrastructure components (centralized DbContext)
│   └── Gov.Core                      # Government system integrations
├── services/erp/                     # Microservices (24 total)
│   ├── erp-{domain}-service/         # Backend services (e.g., erp-adm-service)
│   │   └── src/
│   │       ├── Erp.Service.{Domain}.WebApi/
│   │       └── libs/
│   │           ├── Erp.Service.{Domain}.Application/
│   │           ├── Erp.Service.{Domain}.Domain/
│   │           ├── Erp.Service.{Domain}.Infrastructure/
│   │           └── shared/
│   │               ├── Erp.Service.{Domain}.Models/  # DTOs, Commands, Queries (SHARED)
│   │               └── Erp.Service.{Domain}.Sdk/     # Refit HTTP clients
│   ├── erp-{domain}-bff-web/         # Backend-for-Frontend for web clients (13 services)
│   ├── erp-itg-service/              # Integration service (gateway & proxy)
│   └── erp-adm-job-service/          # Background job processing
├── code-review/                      # Code review documentation
│   ├── README.md                     # Code review guidelines and conventions
│   ├── templates/                    # Code review templates
│   └── {domain}/                     # Reviews organized by domain (hrm, adm, org, etc.)
├── docs/                             # Project documentation
│   └── database-naming-conventions.md # Comprehensive database design rules
├── scripts/                          # PostgreSQL migration scripts (688 executed)
│   └── executed/                     # Numbered SQL scripts
├── shell/cmd/                        # Build and deployment scripts
├── build/docker/                     # Docker configurations
└── devops/                          # DevOps configs (RabbitMQ, etc.)
```

### Per-Service Structure (Clean Architecture)

Each microservice follows this identical structure:

```
erp-{domain}-service/
├── Erp.Service.{Domain}.sln                      # Root solution file
├── src/
│   ├── Erp.Service.{Domain}.WebApi/              # Layer 4: REST API
│   │   ├── Program.cs                            # Startup configuration
│   │   ├── appsettings.*.json                    # Environment configs
│   │   ├── Controllers/                          # API endpoints
│   │   ├── Middlewares/                          # Custom middleware
│   │   ├── DependencyInjection.cs                # WebApi DI registration
│   │   └── Dockerfile                            # Container image
│   │
│   └── libs/
│       ├── Erp.Service.{Domain}.Domain/          # Layer 1: Core entities
│       │   ├── Entities/                         # Domain entities
│       │   └── DependencyInjection.cs            # Domain DI (if any)
│       │
│       ├── Erp.Service.{Domain}.Application/     # Layer 2: Use cases/CQRS
│       │   ├── UseCases/                         # Organized by entity
│       │   │   └── {Entity}/
│       │   │       ├── Commands/                 # MediatR command handlers
│       │   │       ├── Queries/                  # MediatR query handlers
│       │   │       └── {Entity}Handler.cs        # Handler implementations
│       │   ├── Services/                         # Application services
│       │   ├── Mappings/                         # AutoMapper profiles
│       │   ├── Interfaces/                       # Service contracts
│       │   └── DependencyInjection.cs            # Application DI (MediatR, AutoMapper, FluentValidation)
│       │
│       ├── Erp.Service.{Domain}.Infrastructure/  # Layer 3: Data access
│       │   ├── Repositories/                     # Repository implementations
│       │   ├── Services/                         # External service integrations
│       │   └── DependencyInjection.cs            # Infrastructure DI (DbContext, repositories)
│       │
│       └── shared/
│           ├── Erp.Service.{Domain}.Models/      # DTOs and requests/responses (SHARED)
│           │   ├── {Entity}/
│           │   │   ├── Commands/                 # Command request objects
│           │   │   ├── Queries/                  # Query request objects
│           │   │   └── Dtos/                     # Data Transfer Objects
│           │   └── (Shared across all consumers of this service)
│           │
│           └── Erp.Service.{Domain}.Sdk/         # Type-safe HTTP client (Refit)
│               └── (Used by other services to call this service)
│
└── test/
    └── Erp.Service.{Domain}.UnitTest/            # xUnit + NSubstitute tests
        └── UseCases/
            └── {Entity}/Commands|Queries/
```

### Service Ports

Services are assigned specific ports:
- **5001-5009**: Backend API Services (5001=ADM, 5004=ORG, 5005=HRM, 5006=STD, 5007=MY, 5008=COM, 5009=FIN)
- **5002-5003**: Integration Gateway (5002) & Proxy (5003)
- **5101+**: Background Jobs
- **5201-5209**: Web BFF Services
- **5301+**: Mobile BFF Services

## Database

- **Database**: PostgreSQL
- **ORM**: Entity Framework Core 8.0
- **Schemas**: Each domain has its own schema (adm, hrm, org, std, com, my, fin, lms, app, itg)
- **Migrations**: SQL scripts in `/scripts/executed/` directory, numbered sequentially (e.g., `0001. ADM create schema.sql`)
- **Centralized DbContext**: `ApplicationDbContext` in `Erp.Core.Service.Infrastructure` contains 100+ DbSet properties
- **Interface**: All services use `IApplicationDbContext` interface for data access abstraction

### Database Naming Conventions

**📚 IMPORTANT:** For comprehensive database design rules, table prefixes, field requirements, and examples, see [docs/database-naming-conventions.md](docs/database-naming-conventions.md)

**Quick Reference - Table Prefixes:**

- **`enum_`**: Static enumerations with fixed IDs (e.g., `enum_language`, `enum_status`, `enum_state`)
  - NO auto-increment ID, NO `created_by`/`last_modified_by`, NO `organization_id`

- **`info_`**: Global reference data (e.g., `info_country`, `info_currency`, `info_organization`)
  - Has `state_id`, NO `organization_id` (global data)

- **`hl_`**: Tenant-specific reference data (e.g., `hl_person`, `hl_employee`, `hl_position`)
  - Has `state_id` + **REQUIRED** `organization_id` (tenant isolation)

- **`doc_`**: Business documents with lifecycle (e.g., `doc_cadastre`, `doc_appointment_employee`)
  - Has `status_id` + `table_id` + `doc_on` + `doc_number` + **REQUIRED** `organization_id`

- **`sys_`**: System infrastructure (e.g., `sys_user`, `sys_role`, `sys_table`)
  - Context-dependent: global `sys_` (in `adm` schema) have NO `organization_id`, domain-specific `sys_` have `organization_id`
  - Special pattern: `sys_*_manage` tables track entity lifecycle (e.g., `sys_employee_manage`)

- **Translation tables**: `{table_name}_translate` (e.g., `enum_language_translate`, `info_country_translate`)

**⚠️ Critical Rule:** ALL tables MUST have `organization_id` for tenant isolation, EXCEPT `enum_*`, `info_*`, and global `sys_*` tables in `adm` schema.

**Field Naming Conventions:**
- Use `_at` suffix for timestamps (e.g., `created_at`, `last_modified_at`)
- Use `_on` suffix for dates (e.g., `doc_on`, `birth_on`, `start_on`, `end_on`)
- Use `_by` suffix for user references (e.g., `created_by`, `last_modified_by`)
- Use `_id` suffix for foreign keys (e.g., `user_id`, `organization_id`)

## Common Development Commands

### Build a Service

```bash
# From repository root
cd services/erp/erp-{domain}-service/src/Erp.Service.{Domain}.WebApi
dotnet build

# Example: Build ADM service
cd services/erp/erp-adm-service/src/Erp.Service.Adm.WebApi
dotnet build
```

### Run a Service

```bash
cd services/erp/erp-{domain}-service/src/Erp.Service.{Domain}.WebApi
dotnet run

# Service will start on its assigned port (see appsettings.json)
# Swagger UI available at: https://localhost:{port}/swagger
```

### Run Tests

```bash
# Run all tests in a service
cd services/erp/erp-{domain}-service
dotnet test

# Run specific test project
cd services/erp/erp-adm-service/test/Erp.Service.Adm.UnitTest
dotnet test

# Run a single test class
dotnet test --filter "FullyQualifiedName~AppGetByIdQueryHandlerTests"

# Run a specific test method
dotnet test --filter "FullyQualifiedName~AppGetByIdQueryHandlerTests.Handle_ValidId_ReturnsAppDto"
```

### Build Docker Image

```bash
# From repository root, use the provided batch scripts
cd shell/cmd
./build-mad-erp-{domain}-service.bat

# Example: Build and push ADM service
./build-mad-erp-adm-service.bat
```

### Publish a Service

```bash
cd services/erp/erp-{domain}-service/src/Erp.Service.{Domain}.WebApi
dotnet publish -c Release -o ./publish
```

## Key Technologies & Patterns

### Core Stack
- **.NET 8.0**: Target framework
- **ASP.NET Core**: Web API framework
- **Entity Framework Core 8.0**: ORM with PostgreSQL (Npgsql)
- **MediatR 13.0**: CQRS pattern implementation
- **AutoMapper 13.0**: Object-to-object mapping
- **FluentValidation 11.11**: Request validation
- **Swashbuckle 9.0**: OpenAPI/Swagger documentation

### Authentication & Authorization
- **Keycloak**: Identity and access management via OpenID Connect
- **JWT Bearer**: Token-based authentication
- **Keycloak.AuthServices.Sdk 2.6.0**: SDK for Keycloak operations

### Messaging & Caching
- **RabbitMQ**: Asynchronous messaging (via WEBASE.Standard.MessageBroker.RabbitMQ)
- **Redis**: Caching (StackExchange.Redis 2.9.32)

### Additional Libraries
- **YARP (Yarp.ReverseProxy)**: Reverse proxy for BFF pattern
- **WEBASE Libraries**: Custom organizational libraries for standards, i18n, error handling
  - `WEBASE.Standard.AppError.PostgreSQL`: Error logging
  - `WEBASE.Standard.i18n`: Internationalization
  - `WEBASE.Standard.AspNet`: ASP.NET standards
  - `WEBASE.Standard.Storage.MinIO`: File storage
- **EPPlus 7.7.3 / ClosedXML 0.105.0**: Excel generation and processing
- **Refit 8.0.0**: Type-safe REST client
- **Serilog**: Structured logging
- **AspNetCoreRateLimit 5.0.0**: Rate limiting

### Testing Stack
- **xUnit 2.5.3**: Test framework
- **NSubstitute 5.3.0**: Mocking framework
- **FluentAssertions 6.12.0**: Assertion library
- **MockQueryable.NSubstitute**: Queryable mocking for EF Core
- **Respawn 6.2.1**: Database cleanup between tests

### Patterns in Use
- **CQRS**: Command Query Responsibility Segregation with MediatR
- **Repository Pattern**: Data access abstraction
- **BFF (Backend for Frontend)**: Separate backends for web/mobile clients
- **Clean Architecture**: Dependency rule enforced through project references
- **Translation Pattern**: Multi-language support via `*_translate` tables
- **SDK Pattern**: Refit-based typed HTTP clients for inter-service communication

## CQRS Pattern Examples

### Query Definition (in Models project - shared across services)

```csharp
// Erp.Service.Adm.Models/App/Queries/AppGetByIdQuery.cs
public class AppGetByIdQuery : IRequest<AppDto>
{
    public int Id { get; set; }
}

// Erp.Service.Adm.Models/App/Dtos/AppDto.cs
public class AppDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public List<AppTranslateDto> Translates { get; set; }
}
```

### Query Handler (in Application layer)

```csharp
// Erp.Service.Adm.Application/UseCases/App/Queries/AppGetByIdQueryHandler.cs
public class AppGetByIdQueryHandler : IRequestHandler<AppGetByIdQuery, AppDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public async Task<AppDto> Handle(AppGetByIdQuery request, CancellationToken ct)
    {
        var entity = await _context.Apps
            .Include(x => x.Translates)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        return _mapper.Map<AppDto>(entity);
    }
}
```

### Controller Usage (in WebApi layer)

```csharp
// Erp.Service.Adm.WebApi/Controllers/AppController.cs
[HttpGet("{id}")]
public async Task<AppDto> GetById(int id)
{
    return await Mediator.Send(new AppGetByIdQuery { Id = id });
}
```

**Key Patterns:**
- Queries end with `Query` suffix and return data without side effects
- Commands end with `Command` suffix and perform write operations
- Handlers implement `IRequestHandler<TRequest, TResponse>`
- AutoMapper transforms entities → DTOs
- FluentValidation validates commands/queries automatically via MediatR pipeline behaviors

## Project-Specific Conventions

### Centralized Package Management
The repository uses **Central Package Management**:
- Package versions defined in `Directory.Packages.props` (root)
- Projects reference packages WITHOUT version numbers: `<PackageReference Include="MediatR" />`
- Common build properties in `Directory.Build.props`

### Solution Organization
Each service has TWO solution files:
1. Root level: `Erp.{Domain}.{Type}.sln` (full solution)
2. In `src/`: Nested solution for easier development

### Code Standards
- **C# 12** with implicit usings enabled
- **Nullable reference types**: Disabled (`<Nullable>disable</Nullable>`)
- **Treat warnings as errors**: Enabled (except NuGet security warnings NU1901-NU1904)
- **.editorconfig**: Present at root for consistent formatting

### Dependency Injection Pattern

Each layer has a `DependencyInjection.cs` extension class:

```csharp
// WebApi/DependencyInjection.cs
public static IServiceCollection ConfigureAdmWebApi(this IServiceCollection services)
{
    // Register controllers, filters, middleware
    return services;
}

// Application/DependencyInjection.cs
public static IServiceCollection ConfigureAdmApplication(this IServiceCollection services)
{
    // Register MediatR, AutoMapper, FluentValidation
    return services;
}

// Infrastructure/DependencyInjection.cs
public static IServiceCollection ConfigureAdmInfrastructure(this IServiceCollection services, IConfiguration config)
{
    // Register DbContext, repositories, external clients
    return services;
}
```

Called in `Program.cs`:
```csharp
builder.Services
    .ConfigureAdmInfrastructure(builder.Configuration)
    .ConfigureAdmApplication()
    .ConfigureAdmWebApi();
```

### Configuration Structure

Each service uses layered `appsettings.json` files:
- `appsettings.json` - Base configuration
- `appsettings.Development.json` - Local development
- `appsettings.Local.json` - Machine-specific overrides (not in source control)
- `appsettings.Production.json` - Production environment

**Key configuration sections:**
```json
{
  "Database": {
    "AppDatabase": { "ConnectionString": "..." }
  },
  "Idp": {
    "BaseUrl": "https://auth-server",
    "Realm": "oauth",
    "ClientId": "service-name",
    "ClientSecret": "..."
  },
  "Sdks": {
    "ItgProxySdk": { "BaseUrl": "http://erp-itg-service-proxy" }
  },
  "RabbitMQ": {
    "Host": "...",
    "Consumers": { "CustomJob": { ... } }
  },
  "AppError": {
    "ApplicationName": "service-name",
    "ConnectionString": "..."  // Separate logging database
  },
  "Kestrel": {
    "EndPoints": { "Http": { "Url": "http://0.0.0.0:80" } }
  }
}
```

### Service Communication

**Internal Service-to-Service:**
- HTTP REST APIs using Refit-generated typed clients
- SDKs distributed via `Erp.Service.{Domain}.Sdk` projects
- Configuration in `appsettings.json` under `Sdks` section

**Integration Service (ITG):**
- **Gateway** (port 5002): Routes internal service requests
- **Proxy** (port 5003): Handles external system communication

**SDK Pattern Example:**
```csharp
// In Erp.Service.Adm.Sdk/IAdmServiceClient.cs
public interface IAdmServiceClient
{
    [Get("/api/app/{id}")]
    Task<AppDto> GetAppByIdAsync(int id);
}

// Registered in another service's Infrastructure/DependencyInjection.cs
services.AddRefitClient<IAdmServiceClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(config["Sdks:AdmService:BaseUrl"]));
```

### Backend-for-Frontend (BFF) Pattern

**BFF Services** (13 total) provide aggregated/customized APIs for web clients:

```
erp-{domain}-bff-web/
├── src/Erp.{Domain}.Bff.Web.WebApi/
│   ├── Controllers/                  # Aggregated endpoints
│   └── appsettings.json              # YARP routing configs
├── src/libs/
│   ├── Erp.{Domain}.Bff.Web.Application/     # Aggregation logic
│   └── Erp.{Domain}.Bff.Web.Infrastructure/  # SDK clients to backend services
```

**Purpose:**
- Aggregate data from multiple backend services
- Transform/filter data for specific client needs
- Handle cross-service authentication
- Provide simplified APIs tailored to UI requirements
- Use YARP for reverse proxy to backend services

## Important Notes

### When Adding New Features

Follow Clean Architecture layer-by-layer:

1. **Start in Domain layer**: Define entities and business rules
   ```csharp
   // Erp.Service.Adm.Domain/Entities/MyEntity.cs
   public class MyEntity : AuditableEntity
   {
       public int Id { get; set; }
       public string Name { get; set; }
   }
   ```

2. **Move to Models layer** (shared): Create DTOs, commands, queries
   ```csharp
   // Erp.Service.Adm.Models/MyEntity/Commands/CreateMyEntityCommand.cs
   public class CreateMyEntityCommand : IRequest<int>
   {
       public string Name { get; set; }
   }
   ```

3. **Implement in Application layer**: Create handlers and mappings
   ```csharp
   // Erp.Service.Adm.Application/UseCases/MyEntity/Commands/CreateMyEntityCommandHandler.cs
   public class CreateMyEntityCommandHandler : IRequestHandler<CreateMyEntityCommand, int>
   {
       // Handler implementation
   }

   // Erp.Service.Adm.Application/Mappings/MyEntityMappingProfile.cs
   public class MyEntityMappingProfile : Profile
   {
       public MyEntityMappingProfile()
       {
           CreateMap<MyEntity, MyEntityDto>();
       }
   }
   ```

4. **Add to Infrastructure layer** (if needed): Repositories, external integrations
   ```csharp
   // Usually not needed - use IApplicationDbContext directly
   ```

5. **Expose via WebApi layer**: Add controllers and endpoints
   ```csharp
   // Erp.Service.Adm.WebApi/Controllers/MyEntityController.cs
   [HttpPost]
   public async Task<int> Create([FromBody] CreateMyEntityCommand command)
   {
       return await Mediator.Send(command);
   }
   ```

6. **Update database**: Create new migration script in `/scripts/` with next sequential number
   ```sql
   -- scripts/NNNN. ADM create my_entity table.sql
   CREATE TABLE adm.my_entity (
       id SERIAL PRIMARY KEY,
       name VARCHAR(255) NOT NULL
   );
   ```

### When Working with Translations

Many tables have corresponding `*_translate` tables for multi-language support. Always include translations when querying reference data:

```csharp
var apps = await _context.Apps
    .Include(x => x.Translates)
    .AsNoTracking()
    .ToListAsync(ct);
```

### When Adding Dependencies

Add package versions to `Directory.Packages.props` at the repository root:

```xml
<!-- Directory.Packages.props -->
<ItemGroup>
  <PackageReference Update="NewPackage" Version="1.0.0" />
</ItemGroup>
```

Then reference in project files WITHOUT version:

```xml
<!-- Project.csproj -->
<ItemGroup>
  <PackageReference Include="NewPackage" />
</ItemGroup>
```

### Database Scripts

SQL migration scripts follow naming convention: `{number}. {SCHEMA} {description}.sql`
- Scripts are executed in numerical order
- Schema abbreviation indicates which domain (ADM, HRM, ORG, STD, COM, MY, FIN, LMS, APP, ITG)
- Example: `0688. HRM add employee performance table.sql`

### Service Relationships

- **ADM (Administration)**: Core system management, users, permissions, roles, organizations, applications
- **HRM (Human Resources)**: Employee management, positions, staffing, payroll calculations
- **ORG (Organization)**: Organizational structure, buildings, facilities
- **STD (Students)**: Student management, admissions, grades, school structure
- **COM (Commissions)**: Commission management and workflows
- **MY (My)**: User-specific applications and workflows
- **FIN (Finance)**: Financial operations and accounting
- **APP (Applications)**: Workflow and application processing
- **LMS (Learning Management)**: Learning and course management
- **LINK (Integration/Linking)**: Cross-system data linking
- **DASH (Dashboard)**: Dashboard aggregation and analytics
- **ITG (Integration)**: Gateway and proxy for internal/external integrations
- **MTB (Material-Technical Base)**: Assets and inventory management

### Error Handling & Logging

- **WEBASE.AppError.PostgreSQL**: Centralized error logging to separate database
- **Serilog**: Structured logging with file sinks
- **Custom Exception Filters**: `WbClientExceptionFilter` for consistent error responses
- Configuration in `appsettings.json` under `AppError` section

### File & Excel Handling

- **Templates**: Stored in `AppData/Templates/{language}/` within WebApi projects
- **Excel Generation**: EPPlus and ClosedXML for creating/reading Excel files
- **Multi-language**: Template files support multiple languages (uz, ru, en)
- **File Storage**: MinIO for distributed file storage (WEBASE.Standard.Storage.MinIO)

### Asynchronous Processing

- **RabbitMQ**: Used for async operations (audit logging, background jobs)
- **Publishers**: Services publish messages to RabbitMQ queues
- **Consumers**: Job services (e.g., `erp-adm-job-service`) consume and process messages
- **Dead Letter Queues**: Failed messages automatically routed to DLQ
- Configuration in `appsettings.json` under `RabbitMQ` section

### Health Checks

Each service exposes custom health check endpoints:
- Backend services: `/{Domain}ServiceHealth`
- BFF services: `/{Domain}WebBffHealth`
- Swagger UI: `/swagger`

### Registry & Deployment

Docker images are pushed to: `registry.webase.uz/madaniyat/mad-erp-{domain}-{type}`

Examples:
- `registry.webase.uz/madaniyat/mad-erp-adm-service`
- `registry.webase.uz/madaniyat/mad-erp-adm-bff-web`

## Code Review Process

### Code Review Documentation

All code reviews are documented in the `code-review/` folder, organized by domain.

**Location:** `code-review/{domain}/CODE_REVIEW_{Entity}.md`

Examples:
- `code-review/hrm/CODE_REVIEW_Staffing.md`
- `code-review/adm/CODE_REVIEW_User.md`
- `code-review/org/CODE_REVIEW_Organization.md`

### Code Review Templates

Two templates are available in `code-review/templates/`:

1. **CODE_REVIEW_TEMPLATE.md** - Standard template for quick reviews
2. **CODE_REVIEW_TEMPLATE_DETAILED.md** - Comprehensive checklist covering:
   - Architecture & Structure
   - Domain Layer compliance
   - Models Layer (DTOs, Commands, Queries)
   - Application Layer (Handlers, Validators, Mappings)
   - WebApi Layer (Controllers)
   - Common issues checklist

### Code Review Workflow

1. **Create Review File**
   - Copy appropriate template from `code-review/templates/`
   - Name: `CODE_REVIEW_{EntityName}.md`
   - Place in domain folder: `code-review/{domain}/`

2. **Conduct Review**
   - Check all Clean Architecture layers
   - Verify CQRS pattern implementation
   - Review security (OrganizationId filters, status transitions)
   - Validate error handling and null safety
   - Check validators (FluentValidation rules)
   - Review AutoMapper configurations
   - Test build and verify no errors

3. **Document Issues**
   - **Critical** (❌): Security, NullReference, Type mismatches
   - **Major** (⚠️): Missing validations, business logic gaps
   - **Minor** (ℹ️): Code quality, unused code, performance

4. **Fix and Verify**
   - Fix all critical issues before merge
   - Update review document as fixes are applied
   - Mark fixed items with ✅
   - Re-build and verify all tests pass

5. **Final Sign-off**
   - Update score (Initial → Final)
   - Change status to ✅ Approved or ❌ Needs Rework
   - List all modified files
   - Note build status and readiness for deployment

### Code Review Checklist

**Security:**
- [ ] All queries filter by `OrganizationId` from `_authService.CurrentOrganizationId`
- [ ] Update/Delete handlers check ownership before modification
- [ ] Status transitions validated with `StatusIdConst.CanApplyStatus()`
- [ ] No hardcoded credentials or sensitive data

**Clean Architecture:**
- [ ] No downward dependencies (Domain never references Application/Infrastructure)
- [ ] Commands/Queries in Models (shared) project
- [ ] Handlers in Application project
- [ ] Controllers in WebApi project

**CQRS & Validation:**
- [ ] All commands have validators with proper rules
- [ ] Handlers use `IRequestHandler<TRequest, TResponse>`
- [ ] Required fields validated (NotEmpty, MaxLength)
- [ ] Collections validated (NotEmpty, no duplicates)
- [ ] Date validations use `DateTime.UtcNow.Date`

**Error Handling:**
- [ ] Uses `WbClientException` with `CLIENT_VISIBLE` for user errors
- [ ] Uses `WbNotFoundException` for missing entities
- [ ] Error messages in local language (Uzbek)
- [ ] Clear, contextual error messages with IDs

**Type Safety:**
- [ ] Controller parameter types match entity ID types (int vs long)
- [ ] DTO property types match entity types
- [ ] No type mismatches in return types
- [ ] Proper async/await patterns (no `.Result`)

**Code Quality:**
- [ ] No unused imports or variables
- [ ] No commented-out code
- [ ] Uses constants (StatusIdConst, TableIdConst)
- [ ] No hardcoded values (culture IDs, magic numbers)
- [ ] AutoMapper uses `CultureId` property, not hardcoded values

### Example Review Score

**Initial Score:** 5.5/10
**Final Score:** 9.5/10

**Breakdown:**
- Architecture & Structure: 10/10
- Security: 10/10 (after fixes)
- Validation: 9/10
- Error Handling: 10/10
- Code Quality: 9/10

**Status:** ✅ Approved / ❌ Needs Rework
