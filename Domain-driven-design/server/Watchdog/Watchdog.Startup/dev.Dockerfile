#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Watchdog/Watchdog.Startup/Watchdog.Startup.csproj", "Watchdog/Watchdog.Startup/"]
RUN dotnet restore "Watchdog/Watchdog.Startup/Watchdog.Startup.csproj"
COPY . .
WORKDIR "/src/Watchdog/Watchdog.Startup"
RUN dotnet build "Watchdog.Startup.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Watchdog.Startup.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFoodShop.Watchdog.Startup.dll"]