FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY CleanArchitectureTemplate.Core/*.csproj ./CleanArchitectureTemplate.Core/
COPY CleanArchitectureTemplate.Infrastructure/*.csproj ./CleanArchitectureTemplate.Infrastructure/ 
COPY CleanArchitectureTemplate.Api/*.csproj ./CleanArchitectureTemplate.Api/
COPY CleanArchitectureTemplate.UnitTest/*.csproj ./CleanArchitectureTemplate.UnitTest/ 

RUN dotnet restore

# Copy everything else and build
COPY CleanArchitectureTemplate.Core/. ./CleanArchitectureTemplate.Core/
COPY CleanArchitectureTemplate.Infrastructure/. ./CleanArchitectureTemplate.Infrastructure/
COPY CleanArchitectureTemplate.Api/. ./CleanArchitectureTemplate.Api/ 

WORKDIR /app/CleanArchitectureTemplate.Api

RUN dotnet publish -c Release -o out

# Build runtime image
#### FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
FROM mcr.microsoft.com/dotnet/core/runtime:3.1-focal AS runtime
ENV ASPNETCORE_URLS http://+:51898
WORKDIR /app
COPY --from=build-env /app/CleanArchitectureTemplate.Api/out .
ENTRYPOINT ["dotnet", "CleanArchitectureTemplate.Api.dll"]
EXPOSE 51898
