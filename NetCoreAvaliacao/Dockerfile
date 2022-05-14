#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetCoreAvaliacao/NetCoreAvaliacao.Api.csproj", "NetCoreAvaliacao/"]
COPY ["NetCoreAvaliacao.Infra.IoC/NetCoreAvaliacao.Infra.IoC.csproj", "NetCoreAvaliacao.Infra.IoC/"]
COPY ["NetCoreAvaliacao.Domain/NetCoreAvaliacao.Domain.csproj", "NetCoreAvaliacao.Domain/"]
COPY ["NetCoreAvaliacao.Infra.Data/NetCoreAvaliacao.Infra.Data.csproj", "NetCoreAvaliacao.Infra.Data/"]
COPY ["NetCoreAvaliacao.Application/NetCoreAvaliacao.Application.csproj", "NetCoreAvaliacao.Application/"]
RUN dotnet restore "NetCoreAvaliacao/NetCoreAvaliacao.Api.csproj"
COPY . .
WORKDIR "/src/NetCoreAvaliacao"
RUN dotnet build "NetCoreAvaliacao.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCoreAvaliacao.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreAvaliacao.Api.dll"]