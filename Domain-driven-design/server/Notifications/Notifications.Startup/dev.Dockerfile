#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Notifications/Notifications.Startup/Notifications.Startup.csproj", "Notifications/Notifications.Startup/"]
COPY ["Common/Common.Startup/Common.Startup.csproj", "Common/Common.Startup/"]
COPY ["Common/Common.Infrastructure/Common.Infrastructure.csproj", "Common/Common.Infrastructure/"]
COPY ["Common/Common.Application/Common.Application.csproj", "Common/Common.Application/"]
COPY ["Common/Common.Domain/Common.Domain.csproj", "Common/Common.Domain/"]
COPY ["Common/Common.Web/Common.Web.csproj", "Common/Common.Web/"]
RUN dotnet restore "Notifications/Notifications.Startup/Notifications.Startup.csproj"
COPY . .
WORKDIR "/src/Notifications/Notifications.Startup"
RUN dotnet build "Notifications.Startup.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Notifications.Startup.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFoodShop.Notifications.Startup.dll"]