# Stage 1: Restore
# This stage is optimized for Docker's layer caching. It only re-runs if
# your project files (*.csproj or *.sln) change.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY *.sln .

# Copy .csproj files
COPY OrderManagment.API/*.csproj ./OrderManagment.API/
COPY OrderManagment.Contracts/*.csproj ./OrderManagment.Contracts/
COPY OrderManagment.DataAccess/*.csproj ./OrderManagment.DataAccess/
COPY OrderManagment.BusinessLogic/*.csproj ./OrderManagment.BusinessLogic/
COPY OrderManagment.Tests/*.csproj ./OrderManagment.Tests/

# Restore dependencies
RUN dotnet restore

# Copy remaining code
COPY . .

# Run tests
FROM build AS test
WORKDIR /src/OrderManagment.Tests
RUN dotnet test

# Publish app for deployment
FROM test AS publish
WORKDIR /src/OrderManagment.API
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=publish /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "OrderManagment.API.dll"]
