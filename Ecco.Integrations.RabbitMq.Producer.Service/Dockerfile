#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ecco.Integrations.RabbitMq.Producer.Service/Ecco.Integrations.RabbitMq.Producer.Service.csproj", "Ecco.Integrations.RabbitMq.Producer.Service/"]
COPY ./Ecco.Integrations.RabbitMq.Producer.Service/nuget.config .
RUN dotnet restore "./Ecco.Integrations.RabbitMq.Producer.Service/./Ecco.Integrations.RabbitMq.Producer.Service.csproj"

COPY . .
WORKDIR "/src/Ecco.Integrations.RabbitMq.Producer.Service"
RUN dotnet build "./Ecco.Integrations.RabbitMq.Producer.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ecco.Integrations.RabbitMq.Producer.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecco.Integrations.RabbitMq.Producer.Service.dll"]