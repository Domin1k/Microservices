#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Admin/Admin.Startup/Admin.Startup.csproj", "Admin/Admin.Startup/"]
COPY ["Common/Common.Web/Common.Web.csproj", "Common/Common.Web/"]
COPY ["Common/Common.Application/Common.Application.csproj", "Common/Common.Application/"]
COPY ["Common/Common.Domain/Common.Domain.csproj", "Common/Common.Domain/"]
COPY ["Common/Common.Startup/Common.Startup.csproj", "Common/Common.Startup/"]
COPY ["Common/Common.Infrastructure/Common.Infrastructure.csproj", "Common/Common.Infrastructure/"]
RUN dotnet restore "Admin/Admin.Startup/Admin.Startup.csproj"
COPY . .
WORKDIR "/src/Admin/Admin.Startup"
RUN dotnet build "Admin.Startup.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Admin.Startup.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFoodShop.Admin.Startup.dll"]