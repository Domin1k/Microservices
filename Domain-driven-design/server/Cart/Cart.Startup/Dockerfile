#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Cart/Cart.Startup/Cart.Startup.csproj", "Cart/Cart.Startup/"]
COPY ["Cart/Cart.Web/Cart.Web.csproj", "Cart/Cart.Web/"]
COPY ["Common/Common.Web/Common.Web.csproj", "Common/Common.Web/"]
COPY ["Common/Common.Application/Common.Application.csproj", "Common/Common.Application/"]
COPY ["Common/Common.Domain/Common.Domain.csproj", "Common/Common.Domain/"]
COPY ["Cart/Cart.Application/Cart.Application.csproj", "Cart/Cart.Application/"]
COPY ["Cart/Cart.Domain/Cart.Domain.csproj", "Cart/Cart.Domain/"]
COPY ["Common/Common.Startup/Common.Startup.csproj", "Common/Common.Startup/"]
COPY ["Common/Common.Infrastructure/Common.Infrastructure.csproj", "Common/Common.Infrastructure/"]
COPY ["Cart/Cart.Infrastructure/Cart.Infrastructure.csproj", "Cart/Cart.Infrastructure/"]
RUN dotnet restore "Cart/Cart.Startup/Cart.Startup.csproj"
COPY . .
WORKDIR "/src/Cart/Cart.Startup"
RUN dotnet build "Cart.Startup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cart.Startup.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFoodShop.Cart.Startup.dll"]