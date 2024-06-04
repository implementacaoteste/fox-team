# ERP/backend/backend_aspnetcore/Dockerfile

# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY backend/backend_aspnetcore/*.csproj ./
RUN dotnet restore

COPY backend/backend_aspnetcore/. ./
WORKDIR /src
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "aspnetcore.dll"]
