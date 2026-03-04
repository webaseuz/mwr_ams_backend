@echo off
:: Get datetime in guaranteed format regardless of locale
for /f "tokens=1-6" %%a in ('powershell -command "Get-Date -Format 'yyyy MM dd HH mm ss'"') do (
    set yy=%%a
    set mm=%%b
    set dd=%%c
    set hh=%%d
    set nn=%%e
    set ss=%%f
)
:: Create tag: YYYYMMDDHHMMSS + random number
set /a rand=%RANDOM%*9999/32768+1000
set tag=%yy%%mm%%dd%_%rand%
echo %tag%

SET shell_folder=%CD%
SET build_root_folder="c:\mad-build\mad-erp-adm-job-service"
SET build_folder="%build_root_folder%\app"
SET image=registry.webase.uz/madaniyat/mad-erp-adm-job-service
if not exist "%build_root_folder%" mkdir "%build_root_folder%"
cd /D %build_root_folder%
if exist app rmdir /s /q app

cd /D "%shell_folder%"
echo %CD%
cd ..
cd ..
cd services\erp\erp-adm-job-service\src\Erp.Service.Adm.Job.WebApi

Echo ---- Building service... 
dotnet publish Erp.Service.Adm.Job.WebApi.csproj -c Release -o %build_folder%
copy Dockerfile "%build_root_folder%\Dockerfile"

Echo ---- service successfully builded.
Echo.

cd /D "%build_root_folder%"
Echo ---- Docker Building ... %image%
docker build -t %image% .
Echo ---- docker successfully builded.

Echo ----- docker logout stage.
docker logout

Echo ----- docker login stage.
docker login -u webaseuz -p glpat-p2huFzGxLy2FEstLNP6X registry.webase.uz


Echo ---- Docker push image... 
docker push %image%
Echo ---- docker successfully push image.

Echo ---- prepare docker image for production ...
docker image tag %image% %image%:%tag%

Echo ---- Docker push image for production... 
docker push %image%:%tag%
Echo ---- docker successfully push image.

cd /D "%shell_folder%"
echo %image%
echo %image%:%tag%
pause