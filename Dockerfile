#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApiUsers/WebApiUsers.csproj", "WebApiUsers/"]
COPY ["WebApiUsers.Application/WebApiUsers.Application.csproj", "WebApiUsers.Application/"]
COPY ["WebApiUsers.Domain/WebApiUsers.Domain.csproj", "WebApiUsers.Domain/"]
COPY ["WebApiUsers.EFCore/WebApiUsers.EFCore.csproj", "WebApiUsers.EFCore/"]
COPY ["WebApiUsers.Services/WebApiUsers.Services.csproj", "WebApiUsers.Services/"]
RUN dotnet restore "./WebApiUsers/./WebApiUsers.csproj"
COPY . .
WORKDIR "/src/WebApiUsers"
RUN dotnet build "./WebApiUsers.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApiUsers.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiUsers.dll"]