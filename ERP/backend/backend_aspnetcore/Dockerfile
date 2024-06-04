
# ERP/backend/backend_aspnetcore/Dockerfile

# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o arquivo de projeto e restaurar dependências
COPY backend/backend_aspnetcore/API/*.csproj ./API/
RUN dotnet restore ./API/API.csproj

# Copiar todos os arquivos e construir a aplicação
COPY backend/backend_aspnetcore/. ./
WORKDIR /src/API
RUN dotnet publish -c Release -o /app

# Use a imagem runtime do ASP.NET Core para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "API.dll"]

