
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV TZ="Asia/Tashkent"

# Expose port 80 for incoming HTTP traffic
EXPOSE 80

COPY app/ app/
WORKDIR /app
ENTRYPOINT ["dotnet", "Erp.Service.Adm.WebApi.dll"]
