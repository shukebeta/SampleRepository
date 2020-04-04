#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY SampleRepository/AccountOwnerServer.csproj SampleRepository/
COPY Contracts/Contracts.csproj Contracts/
COPY Entities/Entities.csproj Entities/
COPY Repository/Repository.csproj Repository/
RUN dotnet restore "SampleRepository/AccountOwnerServer.csproj"
COPY . .
WORKDIR "/src/SampleRepository"
RUN dotnet build "AccountOwnerServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccountOwnerServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountOwnerServer.dll"]
