#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Gateway/Gateway.Startup/Gateway.Startup.csproj", "Gateway/Gateway.Startup/"]
COPY ["Common/Common.Web/Common.Web.csproj", "Common/Common.Web/"]
COPY ["Common/Common.Application/Common.Application.csproj", "Common/Common.Application/"]
COPY ["Common/Common.Domain/Common.Domain.csproj", "Common/Common.Domain/"]
COPY ["Common/Common.Startup/Common.Startup.csproj", "Common/Common.Startup/"]
COPY ["Common/Common.Infrastructure/Common.Infrastructure.csproj", "Common/Common.Infrastructure/"]
RUN dotnet restore "Gateway/Gateway.Startup/Gateway.Startup.csproj"
COPY . .
WORKDIR "/src/Gateway/Gateway.Startup"
RUN dotnet build "Gateway.Startup.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Gateway.Startup.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFoodShop.Gateway.Startup.dll"]