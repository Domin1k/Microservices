FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PetFoodShop.Identity/PetFoodShop.Identity.csproj", "PetFoodShop.Identity/"]
COPY ["PetFoodShop/PetFoodShop.csproj", "PetFoodShop/"]
RUN dotnet restore "PetFoodShop.Identity/PetFoodShop.Identity.csproj"
COPY . .
WORKDIR "/src/PetFoodShop.Identity"
RUN dotnet build "PetFoodShop.Identity.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "PetFoodShop.Identity.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFoodShop.Identity.dll"]