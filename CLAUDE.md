# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

**MWR AMS Backend** - A microservices-based .NET 8.0 backend system for Bank Management System (BMS). The solution follows Clean Architecture principles with CQRS pattern, using MediatR for command/query handling and Entity Framework Core with PostgreSQL.

## Build and Run Commands

### Building Services

Each service has its own solution file. Build from the service directory:

```bash
# Build AutoPark service
cd services/autopark-service
dotnet build AutoParkApi.sln

# Build ServiceDesk service
cd services/service-desk-service
dotnet build ServiceDesk.sln.sln

# Build BMS Web BFF
cd services/bms-web-bff
dotnet build Bms.Bff.Web.sln
```

### Running Services

Run WebApi or MobileApi projects:

```bash
# Run AutoPark WebApi (HTTP/1.1 on port 5006, HTTP/2 on port 5007)
cd services/autopark-service/AutoPark.WebApi
dotnet run

# Run AutoPark MobileApi
cd services/autopark-service/AutoPark.MobileApi
dotnet run

# Run background jobs
cd services/autopark-service/AutoPark.Jobs
dotnet run
```

### Testing

Tests use xUnit with FluentAssertions:

```bash
# Run all tests in AutoPark service
cd services/autopark-service/AutoPark.Tests/AutoPark.XUnitTest
dotnet test

# Run specific test class
dotnet test --filter "FullyQualifiedName~ValidatorTest"

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## Architecture

### Microservices Structure

Three main services, each following Clean Architecture layers:

```
services/
├── autopark-service/       # Vehicle fleet management
│   ├── AutoPark.Domain     # Entities, value objects, domain events
│   ├── AutoPark.Application # Use cases (CQRS commands/queries), validators
│   ├── AutoPark.Infrastructure # EF Core DbContext, repositories
│   ├── AutoPark.WebApi     # HTTP/1.1 REST API (port 5006)
│   ├── AutoPark.MobileApi  # Mobile-specific API endpoints
│   ├── AutoPark.Jobs       # Quartz.NET background jobs
│   └── AutoPark.Integration # External service integrations
├── service-desk-service/   # Service desk operations
└── bms-web-bff/           # Backend-for-Frontend for web clients
```

### Shared Libraries

```
libs/dotnet/
├── common/                 # Shared across all services
│   ├── Bms.Common.Domain
│   ├── Bms.Common.Application
│   ├── Bms.Common.Infrastructure
│   ├── WEBASE.Jaeger      # Distributed tracing (OpenTelemetry + Jaeger)
│   ├── WEBASE.LogSdk      # Custom logging with DB persistence
│   └── WEBASE.MediatR     # MediatR pipeline extensions
└── core/                   # Core business abstractions
    ├── Bms.Core.Domain     # Base Entity, DomainEvent, Error types
    ├── Bms.Core.Application # ValidationBehaviour, mapping profiles
    ├── Bms.Core.Infrastructure # AuditableDbContext base class
    └── Bms.Core.Presentation # API controller base classes
```

### CQRS Pattern with MediatR

All business logic organized as Commands (writes) and Queries (reads):

**Command Structure:**
```
Application/UseCases/{Feature}/Command/{Action}/
├── {Action}Command.cs           # The command DTO
├── {Action}CommandHandler.cs    # Business logic handler
└── {Action}CommandValidator.cs  # FluentValidation rules
```

**Query Structure:**
```
Application/UseCases/{Feature}/Query/{Action}/
├── {Action}Query.cs         # The query DTO
└── {Action}QueryHandler.cs  # Data retrieval logic
```

**Use Case Categories:**
- `Account/` - Authentication (GenerateToken, RefreshToken, UserInfo)
- `Document/` - Business documents (Expense, Refuel, TransportSetting)
- `Enum/` - Enumeration lookups
- `Hl/` - High-level entities (Branch, Driver, Transport)
- `Info/` - Reference data
- `Report/` - Reporting
- `Sys/` - System administration (User, Role, Permission)

### Domain-Driven Design

**Core DDD Concepts:**
- Entities inherit from `Bms.Core.Domain.Domains.Entity` which supports domain events
- Domain events (e.g., `StatusChangedEvent`) are raised within aggregates
- `AuditableDbContext` automatically handles audit fields (CreatedAt, CreatedBy, ModifiedAt, ModifiedBy, StateId)

### Pipeline Behaviors

MediatR pipeline automatically applies cross-cutting concerns:

1. **ValidationBehaviour** - Validates all commands/queries using FluentValidation, throws `ClientException` on failure
2. Logging and tracing via OpenTelemetry integration

## Database

**Primary Database:** PostgreSQL (via Npgsql.EntityFrameworkCore.PostgreSQL 8.0.11)

**Connection Configuration:**
Located in `{Service}.WebApi/appsettings.json`:
```json
"Database": {
  "PgSql": {
    "ConnectionString": "Host=127.0.0.1;Port=6529;Username=postgres;Password=postgres123;Database=autopark_db;..."
  }
}
```

**Migration Scripts:**
SQL-based migrations in `assets/scripts/{Service}.PgSql/Scripts/`:
- Numbered sequentially (0001, 0002, etc.)
- Table naming conventions: `ENUM_*`, `INFO_*`, `HL_*`, `DOC_*`, `SYS_*`
- Schema: `QR` for QR code functionality

**Entity Framework Usage:**
- All DbContexts inherit from `AuditableDbContext` in `libs/dotnet/common/Bms.Common.Infrastructure/WEBASE/EF/`
- Database-first approach with auto-generated DbContexts in `assets/scripts/{Service}.PgSql/`

## Configuration

### Key appsettings.json Sections

**Kestrel Endpoints:**
```json
"KestrelCustom": {
  "Endpoints": {
    "Http1": { "Port": 5006 },  // REST API
    "Http2": { "Port": 5007 }   // gRPC-ready
  }
}
```

**Observability:**
- **Jaeger Tracing**: Distributed tracing via OpenTelemetry to Jaeger (localhost:5775)
- **LogSdk**: Custom logging framework with PostgreSQL persistence, captures request/response bodies for errors
- **Health Checks**: Available at `/health` endpoint

**File Storage:**
- **MinIO**: Object storage for file uploads (localhost:9000)
- Separate buckets for production and temporary files

**Authentication:**
- JWT Bearer tokens with refresh token mechanism
- Basic Auth for internal service-to-service communication

## Development Guidelines

### Package Management

**Central Package Management (CPM)** is enabled:
- All package versions defined in `Directory.Packages.props` at repository root
- Projects reference packages WITHOUT version numbers
- Ensures version consistency across all projects

**NuGet Sources:**
1. `nuget.org` - Official packages
2. `Webase` (`https://package.webase.uz/v3/index.json`) - Internal company packages
3. `local` (`packages/build`) - Local development packages

### Code Standards

From `Directory.Build.props`:
- Target Framework: .NET 8.0
- **TreatWarningsAsErrors**: true (all warnings are errors)
- **Nullable**: disabled globally
- **ImplicitUsings**: enabled
- .NET Analyzers enabled with latest analysis level

### Adding New Use Cases

1. Create folder structure in `{Service}.Application/UseCases/{Feature}/{Command|Query}/{Action}/`
2. Implement `{Action}Command.cs` or `{Action}Query.cs` implementing `IRequest<TResponse>`
3. Implement `{Action}CommandHandler.cs` or `{Action}QueryHandler.cs` implementing `IRequestHandler<TRequest, TResponse>`
4. For commands, add `{Action}CommandValidator.cs` inheriting from `AbstractValidator<{Action}Command>`
5. Validators are automatically discovered and executed via `ValidationBehaviour` pipeline

### Testing

**Test Organization:**
- `IntegrationTest/` - Full API integration tests using `WebApplicationFactory`
- `ValidatorTest/` - FluentValidation rule tests

**Test Database:**
- Use `Microsoft.EntityFrameworkCore.InMemory` for unit tests
- Integration tests can use Docker PostgreSQL containers

### Working with Domain Events

Entities can raise domain events:
```csharp
// In an entity
AddDomainEvent(new StatusChangedEvent(...));
```

Domain events are automatically published after SaveChanges by infrastructure layer.

### Authentication Flow

1. **Login**: Call `Account/Command/GenerateToken` with credentials
2. **Access**: Use JWT token in `Authorization: Bearer {token}` header
3. **Refresh**: Call `Account/Command/RefreshToken` when token expires
4. **User Info**: Call `Account/Query/UserInfo` to get current user details

### Background Jobs

Quartz.NET jobs located in `{Service}.Jobs` project:
- Jobs run on a schedule defined in `appsettings.json`
- Use dependency injection for DbContext and services
- Jobs project is a separate executable host

## Technology Stack

**Core:**
- .NET 8.0, ASP.NET Core, Entity Framework Core 8.0.11

**Patterns:**
- MediatR 12.4.1 (CQRS), FluentValidation 11.9.2, AutoMapper 14.0.0

**Data:**
- PostgreSQL (Npgsql.EntityFrameworkCore.PostgreSQL 8.0.11)
- Oracle, SQL Server support available

**Observability:**
- OpenTelemetry 1.11.2, Jaeger, Serilog 4.2.0, Application Insights

**API:**
- Swashbuckle.AspNetCore 6.5.0 (Swagger), SignalR (real-time), Refit 8.0.0 (HTTP clients)

**Files:**
- MinIO 6.0.5 (object storage), MiniExcel 1.41.3, EPPlus 7.1.1

**Background Processing:**
- Quartz.NET 3.14.0

**Testing:**
- xUnit 2.5.3, FluentAssertions 6.12.0, NSubstitute 5.3.0, coverlet.collector 6.0.0
