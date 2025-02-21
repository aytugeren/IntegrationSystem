#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductMicroService/Presentation/ProductMicroservice.API/ProductMicroservice.API.csproj", "ProductMicroService/Presentation/ProductMicroservice.API/"]
COPY ["ProductMicroService/Libraries/ProductMicroservice.Business/ProductMicroservice.Business.csproj", "ProductMicroService/Libraries/ProductMicroservice.Business/"]
COPY ["ProductMicroService/Libraries/ProductMicroservice.Data/ProductMicroservice.Data.csproj", "ProductMicroService/Libraries/ProductMicroservice.Data/"]
COPY ["Libraries/ProductMicroservice.Helper/ProductMicroservice.Helper.csproj", "Libraries/ProductMicroservice.Helper/"]
COPY ["ProductMicroService/Libraries/ProductMicroservice.Entities/ProductMicroservice.Entities.csproj", "ProductMicroService/Libraries/ProductMicroservice.Entities/"]
RUN dotnet restore "./ProductMicroService/Presentation/ProductMicroservice.API/ProductMicroservice.API.csproj"
COPY . .
WORKDIR "/src/ProductMicroService/Presentation/ProductMicroservice.API"
RUN dotnet build "./ProductMicroservice.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProductMicroservice.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroservice.API.dll"]