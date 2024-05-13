#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

ARG DOTNET_RUNTIME=mcr.microsoft.com/dotnet/aspnet:6.0
ARG DOTNET_SDK=mcr.microsoft.com/dotnet/sdk:6.0

FROM ${DOTNET_RUNTIME} AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM ${DOTNET_SDK} AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["manage-tasks-backend.sln", "./"]
COPY ["ManageTasks.API/ManageTasks.API.csproj", "ManageTasks.API/"]
COPY ["ManageTasks.Contracts/ManageTasks.Contracts.csproj", "ManageTasks.Contracts/"]
COPY ["ManageTasks.Domain.Entities/ManageTasks.Domain.Entities.csproj", "ManageTasks.Domain.Entities/"]
COPY ["ManageTasks.Domain/ManageTasks.Domain.csproj", "ManageTasks.Domain/"]
COPY ["ManageTasks.Infrastructure/ManageTasks.Infrastructure.csproj", "ManageTasks.Infrastructure/"]

COPY ["ManageTasks.Tests/ManageTasks.Tests.csproj" "ManageTasks.Tests/"]

RUN dotnet restore "./ManageTasks.API/ManageTasks.API.csproj"
COPY . .
WORKDIR "/src/ManageTasks.API"
RUN dotnet build "./ManageTasks.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ManageTasks.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManageTasks.API.dll"]
