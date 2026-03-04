```
📦weberp_backend
 ┗ 📂services
   ┗ 📂{service_name}-service
     ┗ 📂src
       ┣ 📂libs
       │ ┣ 📂shared
       │ │ ┣ 📂WebErp.Service.{service_name}.Models
       │ │ │ ┣ 📂App
       │ │ │ ┣ 📂Gender
       │ │ │ ┗ 📜WebErp.Service.{service_name}.Models.csproj
       │ │ ┗ 📂WebErp.Service.{service_name}.Sdk
       │ │   ┗ 📜WebErp.Service.{service_name}.Sdk.csproj
       │ ┣ 📂WebErp.Service.{service_name}.Application
       │ │ ┣ 📂Interfaces
       │ │ ┣ 📂UseCases
       │ │ ┣ 📜DependencyInjection.cs
       │ │ ┗ 📜WebErp.Service.{service_name}.Application.csproj
       │ ┣ 📂WebErp.Service.{service_name}.Domain
       │ │ ┗ 📜WebErp.Service.{service_name}.Domain.csproj
       │ ┗ 📂WebErp.Service.{service_name}.Infrastructure
       │   ┣ 📂i18n
       │   ┣ 📂Idp
       │   ┣ 📂Security
       │   ┣ 📜DependencyInjection.cs
       │   ┣ 📜InfrastructureSettings.cs
       │   ┗ 📜WebErp.Service.{service_name}.Infrastructure.csproj
       ┗ 📂WebErp.Service.{service_name}.WebApi
         ┣ 📂Controllers
         │ ┣ 📂Base
         │ │ ┗ 📜BaseController.cs
         │ ┣ 📜ManualController.cs
         ┣ 📂Extensions
         │ ┗ 📜SwaggerServiceExtentions.cs
         ┣ 📂Properties
         │ ┗ 📜launchSettings.json
         ┣ 📜AppSettings.cs
         ┣ 📜appsettings.Development.json
         ┣ 📜appsettings.Production.json
         ┣ 📜appsettings.Staging.json
         ┣ 📜appsettings.json
         ┣ 📜DependencyInjection.cs
         ┣ 📜Program.cs
         ┗ 📜WebErp.Service.{service_name}.WebApi.csproj
```