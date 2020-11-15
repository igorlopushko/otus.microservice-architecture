FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY UserService-Migrations.sln ./
COPY UserService.DataAccess/*.csproj ./UserService.DataAccess/
COPY UserService.DataAccess.Migrations/*.csproj ./UserService.DataAccess.Migrations/

RUN dotnet restore
COPY . ./
WORKDIR /src/UserService.DataAccess
RUN dotnet build -c Release -o /app/build

WORKDIR /src/UserService.DataAccess.Migrations
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .