#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["InfoJobs.csproj", "."]
RUN dotnet restore "InfoJobs.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "InfoJobs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InfoJobs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .



CMD ASPNETCORE_URLS=http://*:$PORT dotnet InfoJobs.dll

