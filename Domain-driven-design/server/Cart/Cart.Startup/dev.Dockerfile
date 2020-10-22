FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PetFoodShop.Cart/PetFoodShop.Cart.csproj", "PetFoodShop.Cart/"]
COPY ["PetFoodShop/PetFoodShop.csproj", "PetFoodShop/"]
RUN dotnet restore "PetFoodShop.Cart/PetFoodShop.Cart.csproj"
COPY . .
WORKDIR "/src/PetFoodShop.Cart"
RUN dotnet build "PetFoodShop.Cart.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "PetFoodShop.Cart.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFoodShop.Cart.dll"]