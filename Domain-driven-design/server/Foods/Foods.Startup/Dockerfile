FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PetFoodShop.Foods/PetFoodShop.Foods.csproj", "PetFoodShop.Foods/"]
COPY ["PetFoodShop/PetFoodShop.csproj", "PetFoodShop/"]
RUN dotnet restore "PetFoodShop.Foods/PetFoodShop.Foods.csproj"
COPY . .
WORKDIR "/src/PetFoodShop.Foods"
RUN dotnet build "PetFoodShop.Foods.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetFoodShop.Foods.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFoodShop.Foods.dll"]