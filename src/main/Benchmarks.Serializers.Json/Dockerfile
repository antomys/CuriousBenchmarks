FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/main/Benchmarks.Json/Benchmarks.Json.csproj", "src/main/Benchmarks.Json/"]
RUN dotnet restore "src/main/Benchmarks.Json/Benchmarks.Json.csproj"
COPY . .
WORKDIR "/src/src/main/Benchmarks.Json"
RUN dotnet build "Benchmarks.Json.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Benchmarks.Json.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Benchmarks.Json.dll"]
