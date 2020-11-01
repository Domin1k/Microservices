#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Foods/Foods.Startup/Foods.Startup.csproj", "Foods/Foods.Startup/"]
COPY ["Foods/Foods.Infrastructure/Foods.Infrastructure.csproj", "Foods/Foods.Infrastructure/"]
COPY ["Foods/Foods.Application/Foods.Application.csproj", "Foods/Foods.Application/"]
COPY ["Common/Common.Application/Common.Application.csproj", "Common/Common.Application/"]
COPY ["Common/Common.Domain/Common.Domain.csproj", "Common/Common.Domain/"]
COPY ["Foods/Foods.Domain/Foods.Domain.csproj", "Foods/Foods.Domain/"]
COPY ["Common/Common.Infrastructure/Common.Infrastructure.csproj", "Common/Common.Infrastructure/"]
COPY ["Common/Common.Startup/Common.Startup.csproj", "Common/Common.Startup/"]
COPY ["Common/Common.Web/Common.Web.csproj", "Common/Common.Web/"]
COPY ["Foods/Foods.Web/Foods.Web.csproj", "Foods/Foods.Web/"]
RUN dotnet restore "Foods/Foods.Startup/Foods.Startup.csproj"
COPY . .
WORKDIR "/src/Foods/Foods.Startup"
RUN dotnet build "Foods.Startup.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Foods.Startup.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetFoodShop.Foods.Startup.dll"]