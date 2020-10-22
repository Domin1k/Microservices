FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PetFoodShop.Admin/PetFoodShop.Admin.csproj", "PetFoodShop.Admin/"]
COPY ["PetFoodShop/PetFoodShop.csproj", "PetFoodShop/"]
RUN dotnet restore "PetFoodShop.Admin/PetFoodShop.Admin.csproj"
COPY . .
WORKDIR "/src/PetFoodShop.Admin"
RUN dotnet build "PetFoodShop.Admin.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "PetFoodShop.Admin.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFoodShop.Admin.dll"]