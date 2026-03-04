@echo off
chcp 65001 >nul
setlocal
cd /d "%~dp0"

:: ============================================================
:: MAD ERP Backend - Automated Deploy Script
:: Usage: deploy.bat [test|prod] [service-name]
:: Example: deploy.bat test erp-org-service
::          deploy.bat prod erp-adm-service
:: ============================================================

echo.
echo +----------------------------------------------------------+
echo     MAD ERP Backend - Automated Deploy Script
echo +----------------------------------------------------------+
echo.

:: === Parse Arguments ===
set "ENV=%~1"
set "SERVICE=%~2"

:: === Validate Environment ===
if /i "%ENV%"=="test" (
    set "MODE=test"
) else if /i "%ENV%"=="prod" (
    set "MODE=prod"
) else (
    echo [ERROR] Invalid environment
    echo.
    echo Usage: deploy.bat [test / prod] [service-name]
    echo.
    echo Environments:
    echo   test  - Deploy to TEST server
    echo   prod  - Deploy to PROD server
    echo.
    call :show_services
    exit /b 1
)

:: === Validate Service ===
if "%SERVICE%"=="" (
    echo [ERROR] Service name is required
    echo.
    call :show_services
    exit /b 1
)

:: === Map Service to Build Script and Jenkins Service Name ===
call :map_service "%SERVICE%"
if "%BUILD_SCRIPT%"=="" (
    echo [ERROR] Unknown service: %SERVICE%
    echo.
    call :show_services
    exit /b 1
)

echo [INFO] Environment: %MODE%
echo [INFO] Service: %SERVICE%
echo [INFO] Jenkins Service: %JENKINS_SERVICE%
echo.

:: === Check .env file exists ===
set "ENV_FILE=%~dp0.env"
if not exist "%ENV_FILE%" (
    echo [ERROR] .env file not found at: %ENV_FILE%
    echo Please create .env file with required credentials.
    exit /b 1
)

:: === Load Environment Variables from .env ===
echo [INFO] Loading credentials from .env...

for /f "usebackq tokens=1,* delims==" %%a in ("%ENV_FILE%") do (
    if /i "%%a"=="DOCKER_REGISTRY_PASSWORD" set "DOCKER_REGISTRY_PASSWORD=%%b"
    if /i "%%a"=="JENKINS_TEST_URL" set "JENKINS_TEST_URL=%%b"
    if /i "%%a"=="JENKINS_TEST_JOB" set "JENKINS_TEST_JOB=%%b"
    if /i "%%a"=="JENKINS_TEST_LOGIN" set "JENKINS_TEST_LOGIN=%%b"
    if /i "%%a"=="JENKINS_TEST_TOKEN" set "JENKINS_TEST_TOKEN=%%b"
    if /i "%%a"=="JENKINS_PROD_URL" set "JENKINS_PROD_URL=%%b"
    if /i "%%a"=="JENKINS_PROD_JOB" set "JENKINS_PROD_JOB=%%b"
    if /i "%%a"=="JENKINS_PROD_LOGIN" set "JENKINS_PROD_LOGIN=%%b"
    if /i "%%a"=="JENKINS_PROD_TOKEN" set "JENKINS_PROD_TOKEN=%%b"
)

if "%DOCKER_REGISTRY_PASSWORD%"=="" (
    echo [ERROR] DOCKER_REGISTRY_PASSWORD not found in .env
    exit /b 1
)

:: === Set Jenkins credentials based on environment ===
if /i "%MODE%"=="test" (
    set "JENKINS_URL=%JENKINS_TEST_URL%"
    set "JENKINS_JOB=%JENKINS_TEST_JOB%"
    set "JENKINS_USER=%JENKINS_TEST_LOGIN%"
    set "JENKINS_TOKEN=%JENKINS_TEST_TOKEN%"
) else (
    set "JENKINS_URL=%JENKINS_PROD_URL%"
    set "JENKINS_JOB=%JENKINS_PROD_JOB%"
    set "JENKINS_USER=%JENKINS_PROD_LOGIN%"
    set "JENKINS_TOKEN=%JENKINS_PROD_TOKEN%"
)

if "%JENKINS_URL%"=="" (
    echo [ERROR] Jenkins URL not found in .env
    exit /b 1
)
if "%JENKINS_USER%"=="" (
    echo [ERROR] Jenkins login not found in .env
    exit /b 1
)
if "%JENKINS_TOKEN%"=="" (
    echo [ERROR] Jenkins token not found in .env
    exit /b 1
)

echo [OK] Credentials loaded successfully.
echo.

:: === Generate Tag ===
for /f %%a in ('powershell -command "Get-Date -Format yyyyMMdd"') do set "DATESTAMP=%%a"
set /a RAND=%RANDOM% %% 9000 + 1000
set "TAG=%DATESTAMP%_%RAND%"
echo [INFO] Generated Tag: %TAG%
echo.

:: === Get Build Paths ===
call :get_build_paths

:: === Confirm Deployment ===
echo +----------------------------------------------------------+
echo   DEPLOYMENT SUMMARY
echo +----------------------------------------------------------+
echo   Environment:    %MODE%
echo   Service:        %SERVICE%
echo   Jenkins Job:    %JENKINS_JOB%
echo   Jenkins URL:    %JENKINS_URL%
echo   Tag:            %TAG%
echo +----------------------------------------------------------+
echo.
echo Press any key to start deployment or Ctrl+C to cancel...
pause >nul

:: === Step 1: Build and Push Docker Image ===
echo.
echo ============================================================
echo STEP 1: Building and pushing Docker image...
echo ============================================================
echo.

:: Create build directory
set "BUILD_ROOT_FOLDER=c:\mad-build\%SERVICE%"
set "BUILD_FOLDER=%BUILD_ROOT_FOLDER%\app"

if not exist "%BUILD_ROOT_FOLDER%" mkdir "%BUILD_ROOT_FOLDER%"
cd /D "%BUILD_ROOT_FOLDER%"
if exist app rmdir /s /q app

:: Navigate to source and build
set "SCRIPT_DIR=%~dp0"
cd /D "%SCRIPT_DIR%"
cd ..
cd ..
cd ..
cd "%SOURCE_PATH%"

echo [INFO] Building .NET project...
dotnet publish %PROJECT_FILE% -c Release -o "%BUILD_FOLDER%"
if %ERRORLEVEL% neq 0 (
    echo [ERROR] dotnet publish failed
    cd /D "%SCRIPT_DIR%"
    exit /b 1
)

copy Dockerfile "%BUILD_ROOT_FOLDER%\Dockerfile" >nul
echo [OK] .NET build completed.

:: Docker build
cd /D "%BUILD_ROOT_FOLDER%"
echo [INFO] Building Docker image: %IMAGE%
docker build -t %IMAGE% .
if %ERRORLEVEL% neq 0 (
    echo [ERROR] Docker build failed
    cd /D "%SCRIPT_DIR%"
    exit /b 1
)

:: Docker login and push
echo [INFO] Logging into Docker registry...
docker logout >nul 2>&1
docker login -u webaseuz -p "%DOCKER_REGISTRY_PASSWORD%" registry.webase.uz
if %ERRORLEVEL% neq 0 (
    echo [ERROR] Docker login failed
    cd /D "%SCRIPT_DIR%"
    exit /b 1
)

echo [INFO] Pushing Docker image (latest)...
docker push %IMAGE%
if %ERRORLEVEL% neq 0 (
    echo [ERROR] Docker push failed
    cd /D "%SCRIPT_DIR%"
    exit /b 1
)

echo [INFO] Tagging image: %IMAGE%:%TAG%
docker image tag %IMAGE% %IMAGE%:%TAG%

echo [INFO] Pushing Docker image (tagged)...
docker push %IMAGE%:%TAG%
if %ERRORLEVEL% neq 0 (
    echo [ERROR] Docker push tagged failed
    cd /D "%SCRIPT_DIR%"
    exit /b 1
)

cd /D "%SCRIPT_DIR%"

echo.
echo [OK] Docker image built and pushed successfully.
echo.

:: === Step 2: Trigger Jenkins Build ===
echo ============================================================
echo STEP 2: Triggering Jenkins deployment...
echo ============================================================
echo.
echo [INFO] Jenkins URL: %JENKINS_URL%/job/%JENKINS_JOB%
echo [INFO] Service: %JENKINS_SERVICE%
echo [INFO] Tag: %TAG%
echo.

curl -X POST "%JENKINS_URL%/job/%JENKINS_JOB%/buildWithParameters" ^
  --user %JENKINS_USER%:%JENKINS_TOKEN% ^
  --data-urlencode "SERVICES=%JENKINS_SERVICE%" ^
  --data-urlencode "TAG=%TAG%" ^
  -s -o nul -w "HTTP Status: %%{http_code}\n"

if %ERRORLEVEL% neq 0 (
    echo [ERROR] Jenkins trigger failed
    exit /b 1
)

echo.
echo +----------------------------------------------------------+
echo   DEPLOYMENT SUCCESSFUL
echo +----------------------------------------------------------+
echo   Service:     %SERVICE%
echo   Tag:         %TAG%
echo   Environment: %MODE%
echo   Jenkins:     %JENKINS_URL%/job/%JENKINS_JOB%
echo +----------------------------------------------------------+
echo.
echo Check Jenkins for build status.
echo.
goto :eof

:: ============================================================
:: FUNCTIONS
:: ============================================================

:show_services
echo Available Services:
echo.
echo   Backend Services:
echo     erp-adm-service          erp-hrm-service
echo     erp-org-service          erp-std-service
echo     erp-com-service          erp-fin-service
echo     erp-my-service           erp-dash-service
echo     erp-app-service          erp-link-service
echo     erp-lms-service          erp-itg-service-gateway
echo     erp-itg-service-proxy    erp-adm-job-service
echo     erp-logger-job-service
echo.
echo   BFF Services:
echo     erp-adm-web-bff          erp-hrm-web-bff
echo     erp-org-web-bff          erp-std-bff-web
echo     erp-com-bff-web          erp-fin-bff-web
echo     erp-dash-bff-web         erp-app-bff-web
echo     erp-link-bff-web         erp-lms-bff-web
echo.
goto :eof

:map_service
set "INPUT_SERVICE=%~1"
set "BUILD_SCRIPT="
set "JENKINS_SERVICE="

if /i "%INPUT_SERVICE%"=="erp-adm-service" (
    set "BUILD_SCRIPT=build-mad-erp-adm-service.bat"
    set "JENKINS_SERVICE=erp-adm-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-hrm-service" (
    set "BUILD_SCRIPT=build-mad-erp-hrm-service.bat"
    set "JENKINS_SERVICE=erp-hrm-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-org-service" (
    set "BUILD_SCRIPT=build-mad-erp-org-service.bat"
    set "JENKINS_SERVICE=erp-org-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-std-service" (
    set "BUILD_SCRIPT=build-mad-erp-std-service.bat"
    set "JENKINS_SERVICE=erp-std-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-com-service" (
    set "BUILD_SCRIPT=build-mad-erp-com-service.bat"
    set "JENKINS_SERVICE=erp-com-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-fin-service" (
    set "BUILD_SCRIPT=build-mad-erp-fin-service.bat"
    set "JENKINS_SERVICE=erp-fin-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-my-service" (
    set "BUILD_SCRIPT=build-mad-erp-my-service.bat"
    set "JENKINS_SERVICE=erp-my-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-dash-service" (
    set "BUILD_SCRIPT=build-mad-erp-dash-service.bat"
    set "JENKINS_SERVICE=erp-dash-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-app-service" (
    set "BUILD_SCRIPT=build-mad-erp-app-service.bat"
    set "JENKINS_SERVICE=erp-app-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-link-service" (
    set "BUILD_SCRIPT=build-mad-erp-link-service.bat"
    set "JENKINS_SERVICE=erp-link-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-lms-service" (
    set "BUILD_SCRIPT=build-mad-erp-lms-service.bat"
    set "JENKINS_SERVICE=erp-lms-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-itg-service-gateway" (
    set "BUILD_SCRIPT=build-mad-erp-itg-service-gateway.bat"
    set "JENKINS_SERVICE=erp-itg-service-gateway"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-itg-service-proxy" (
    set "BUILD_SCRIPT=build-mad-erp-itg-service-proxy.bat"
    set "JENKINS_SERVICE=erp-itg-service-proxy"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-adm-job-service" (
    set "BUILD_SCRIPT=build-mad-erp-adm-job-service.bat"
    set "JENKINS_SERVICE=erp-adm-job-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-logger-job-service" (
    set "BUILD_SCRIPT=build-mad-erp-logger-job-service.bat"
    set "JENKINS_SERVICE=erp-logger-job-service"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-adm-web-bff" (
    set "BUILD_SCRIPT=build-mad-erp-adm-bff-web.bat"
    set "JENKINS_SERVICE=erp-adm-web-bff"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-hrm-web-bff" (
    set "BUILD_SCRIPT=build-mad-erp-hrm-bff-web.bat"
    set "JENKINS_SERVICE=erp-hrm-web-bff"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-org-web-bff" (
    set "BUILD_SCRIPT=build-mad-erp-org-bff-web.bat"
    set "JENKINS_SERVICE=erp-org-web-bff"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-std-bff-web" (
    set "BUILD_SCRIPT=build-mad-erp-std-bff-web.bat"
    set "JENKINS_SERVICE=erp-std-bff-web"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-com-bff-web" (
    set "BUILD_SCRIPT=build-mad-erp-com-bff-web.bat"
    set "JENKINS_SERVICE=erp-com-bff-web"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-fin-bff-web" (
    set "BUILD_SCRIPT=build-mad-erp-fin-bff-web.bat"
    set "JENKINS_SERVICE=erp-fin-bff-web"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-dash-bff-web" (
    set "BUILD_SCRIPT=build-mad-erp-dash-bff-web.bat"
    set "JENKINS_SERVICE=erp-dash-bff-web"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-app-bff-web" (
    set "BUILD_SCRIPT=build-mad-erp-app-bff-web.bat"
    set "JENKINS_SERVICE=erp-app-bff-web"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-link-bff-web" (
    set "BUILD_SCRIPT=build-mad-erp-link-bff-web.bat"
    set "JENKINS_SERVICE=erp-link-bff-web"
    goto :eof
)
if /i "%INPUT_SERVICE%"=="erp-lms-bff-web" (
    set "BUILD_SCRIPT=build-mad-erp-lms-bff-web.bat"
    set "JENKINS_SERVICE=erp-lms-bff-web"
    goto :eof
)
goto :eof

:get_build_paths
if /i "%SERVICE%"=="erp-adm-service" (
    set "SOURCE_PATH=services\erp\erp-adm-service\src\Erp.Service.Adm.WebApi"
    set "PROJECT_FILE=Erp.Service.Adm.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-adm-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-hrm-service" (
    set "SOURCE_PATH=services\erp\erp-hrm-service\src\Erp.Service.Hrm.WebApi"
    set "PROJECT_FILE=Erp.Service.Hrm.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-hrm-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-org-service" (
    set "SOURCE_PATH=services\erp\erp-org-service\src\Erp.Service.Org.WebApi"
    set "PROJECT_FILE=Erp.Service.Org.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-org-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-std-service" (
    set "SOURCE_PATH=services\erp\erp-std-service\src\Erp.Service.Std.WebApi"
    set "PROJECT_FILE=Erp.Service.Std.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-std-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-com-service" (
    set "SOURCE_PATH=services\erp\erp-com-service\src\Erp.Service.Com.WebApi"
    set "PROJECT_FILE=Erp.Service.Com.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-com-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-fin-service" (
    set "SOURCE_PATH=services\erp\erp-fin-service\src\Erp.Service.Fin.WebApi"
    set "PROJECT_FILE=Erp.Service.Fin.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-fin-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-my-service" (
    set "SOURCE_PATH=services\erp\erp-my-service\src\Erp.Service.My.WebApi"
    set "PROJECT_FILE=Erp.Service.My.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-my-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-dash-service" (
    set "SOURCE_PATH=services\erp\erp-dash-service\src\Erp.Service.Dash.WebApi"
    set "PROJECT_FILE=Erp.Service.Dash.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-dash-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-app-service" (
    set "SOURCE_PATH=services\erp\erp-app-service\src\Erp.Service.App.WebApi"
    set "PROJECT_FILE=Erp.Service.App.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-app-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-link-service" (
    set "SOURCE_PATH=services\erp\erp-link-service\src\Erp.Service.Link.WebApi"
    set "PROJECT_FILE=Erp.Service.Link.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-link-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-lms-service" (
    set "SOURCE_PATH=services\erp\erp-lms-service\src\Erp.Service.Lms.WebApi"
    set "PROJECT_FILE=Erp.Service.Lms.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-lms-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-itg-service-gateway" (
    set "SOURCE_PATH=services\erp\erp-itg-service\src\gateway\Erp.Service.Itg.Gateway.WebApi"
    set "PROJECT_FILE=Erp.Service.Itg.Gateway.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-itg-service-gateway"
    goto :eof
)
if /i "%SERVICE%"=="erp-itg-service-proxy" (
    set "SOURCE_PATH=services\erp\erp-itg-service\src\proxy\Erp.Service.Itg.Proxy.WebApi"
    set "PROJECT_FILE=Erp.Service.Itg.Proxy.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-itg-service-proxy"
    goto :eof
)
if /i "%SERVICE%"=="erp-adm-job-service" (
    set "SOURCE_PATH=services\erp\erp-adm-job-service\src\Erp.Service.Adm.Job.WebApi"
    set "PROJECT_FILE=Erp.Service.Adm.Job.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-adm-job-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-logger-job-service" (
    set "SOURCE_PATH=services\erp\erp-logger-job-service\src\Erp.Service.Logger.Job.WebApi"
    set "PROJECT_FILE=Erp.Service.Logger.Job.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-logger-job-service"
    goto :eof
)
if /i "%SERVICE%"=="erp-adm-web-bff" (
    set "SOURCE_PATH=services\erp\erp-adm-bff-web\src\Erp.Adm.Bff.Web.WebApi"
    set "PROJECT_FILE=Erp.Adm.Bff.Web.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-adm-web-bff"
    goto :eof
)
if /i "%SERVICE%"=="erp-hrm-web-bff" (
    set "SOURCE_PATH=services\erp\erp-hrm-bff-web\src\Erp.Hrm.Bff.Web.WebApi"
    set "PROJECT_FILE=Erp.Hrm.Bff.Web.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-hrm-web-bff"
    goto :eof
)
if /i "%SERVICE%"=="erp-org-web-bff" (
    set "SOURCE_PATH=services\erp\erp-org-bff-web\src\Erp.Org.Bff.Web.WebApi"
    set "PROJECT_FILE=Erp.Org.Bff.Web.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-org-web-bff"
    goto :eof
)
if /i "%SERVICE%"=="erp-std-bff-web" (
    set "SOURCE_PATH=services\erp\erp-std-bff-web\src\Erp.Std.Bff.Web.WebApi"
    set "PROJECT_FILE=Erp.Std.Bff.Web.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-std-bff-web"
    goto :eof
)
if /i "%SERVICE%"=="erp-com-bff-web" (
    set "SOURCE_PATH=services\erp\erp-com-bff-web\src\Erp.Com.Bff.Web.WebApi"
    set "PROJECT_FILE=Erp.Com.Bff.Web.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-com-bff-web"
    goto :eof
)
if /i "%SERVICE%"=="erp-fin-bff-web" (
    set "SOURCE_PATH=services\erp\erp-fin-bff-web\src\Erp.Fin.Bff.Web.WebApi"
    set "PROJECT_FILE=Erp.Fin.Bff.Web.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-fin-bff-web"
    goto :eof
)
if /i "%SERVICE%"=="erp-dash-bff-web" (
    set "SOURCE_PATH=services\erp\erp-dash-bff-web\src\Erp.Dash.Bff.Web.WebApi"
    set "PROJECT_FILE=Erp.Dash.Bff.Web.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-dash-bff-web"
    goto :eof
)
if /i "%SERVICE%"=="erp-app-bff-web" (
    set "SOURCE_PATH=services\erp\erp-app-bff-web\src\Erp.App.Bff.Web.WebApi"
    set "PROJECT_FILE=Erp.App.Bff.Web.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-app-bff-web"
    goto :eof
)
if /i "%SERVICE%"=="erp-link-bff-web" (
    set "SOURCE_PATH=services\erp\erp-link-bff-web\src\Erp.Link.Bff.Web.WebApi"
    set "PROJECT_FILE=Erp.Link.Bff.Web.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-link-bff-web"
    goto :eof
)
if /i "%SERVICE%"=="erp-lms-bff-web" (
    set "SOURCE_PATH=services\erp\erp-lms-bff-web\src\Erp.Lms.Bff.Web.WebApi"
    set "PROJECT_FILE=Erp.Lms.Bff.Web.WebApi.csproj"
    set "IMAGE=registry.webase.uz/madaniyat/mad-erp-lms-bff-web"
    goto :eof
)
goto :eof
