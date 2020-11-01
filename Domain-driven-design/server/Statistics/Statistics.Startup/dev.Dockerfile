#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Statistics/Statistics.Startup/Statistics.Startup.csproj", "Statistics/Statistics.Startup/"]
COPY ["Statistics/Statistics.Web/Statistics.Web.csproj", "Statistics/Statistics.Web/"]
COPY ["Common/Common.Web/Common.Web.csproj", "Common/Common.Web/"]
COPY ["Common/Common.Application/Common.Application.csproj", "Common/Common.Application/"]
COPY ["Common/Common.Domain/Common.Domain.csproj", "Common/Common.Domain/"]
COPY ["Statistics/Statistics.Application/Statistics.Application.csproj", "Statistics/Statistics.Application/"]
COPY ["Statistics/Statistics.Domain/Statistics.Domain.csproj", "Statistics/Statistics.Domain/"]
COPY ["Statistics/Statistics.Infrastructure/Statistics.Infrastructure.csproj", "Statistics/Statistics.Infrastructure/"]
COPY ["Common/Common.Infrastructure/Common.Infrastructure.csproj", "Common/Common.Infrastructure/"]
COPY ["Common/Common.Startup/Common.Startup.csproj", "Common/Common.Startup/"]
RUN dotnet restore "Statistics/Statistics.Startup/Statistics.Startup.csproj"
COPY . .
WORKDIR "/src/Statistics/Statistics.Startup"
RUN dotnet build "Statistics.Startup.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Statistics.Startup.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFoodShop.Foods.Startup.dll"]