#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Source/AlertService/Alert.API/Alerts.API.csproj", "Source/AlertService/Alert.API/"]
RUN dotnet restore "Source/AlertService/Alert.API/Alerts.API.csproj"
COPY . .
WORKDIR "/src/Source/AlertService/Alert.API"
RUN dotnet build "Alerts.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Alerts.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Alerts.API.dll"]
