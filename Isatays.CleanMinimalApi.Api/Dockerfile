#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Isatays.CleanMinimalApi.Api/Isatays.CleanMinimalApi.Api.csproj", "Isatays.CleanMinimalApi.Api/"]
RUN dotnet restore "Isatays.CleanMinimalApi.Api/Isatays.CleanMinimalApi.Api.csproj"
COPY . .
WORKDIR "/src/Isatays.CleanMinimalApi.Api"
RUN dotnet build "Isatays.CleanMinimalApi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Isatays.CleanMinimalApi.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Isatays.CleanMinimalApi.Api.dll"]