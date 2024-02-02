#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["YelpAgainstCompanies.Api/YelpAgainstCompanies.Api.csproj", "YelpAgainstCompanies.Api/"]
COPY ["YelpAgainstCompanies.Business/YelpAgainstCompanies.Business.csproj", "YelpAgainstCompanies.Business/"]
COPY ["YelpAgainstCompanies.Data/YelpAgainstCompanies.Data.csproj", "YelpAgainstCompanies.Data/"]
COPY ["YelpAgainstCompanies.Domain/YelpAgainstCompanies.Domain.csproj", "YelpAgainstCompanies.Domain/"]
RUN dotnet restore "./YelpAgainstCompanies.Api/./YelpAgainstCompanies.Api.csproj"
COPY . .
WORKDIR "/src/YelpAgainstCompanies.Api"
RUN dotnet build "./YelpAgainstCompanies.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./YelpAgainstCompanies.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YelpAgainstCompanies.Api.dll"]