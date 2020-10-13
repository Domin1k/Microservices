FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PetFoodShop.Notifications/PetFoodShop.Notifications.csproj", "PetFoodShop.Notifications/"]
COPY ["PetFoodShop/PetFoodShop.csproj", "PetFoodShop/"]
RUN dotnet restore "PetFoodShop.Notifications/PetFoodShop.Notifications.csproj"
COPY . .
WORKDIR "/src/PetFoodShop.Notifications"
RUN dotnet build "PetFoodShop.Notifications.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "PetFoodShop.Notifications.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFoodShop.Notifications.dll"]