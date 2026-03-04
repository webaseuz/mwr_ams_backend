@echo off
cd /d "%~dp0"
powershell -ExecutionPolicy Bypass -File "%~dp0quick-deploy.ps1"
