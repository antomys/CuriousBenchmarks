FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/main/Benchmark.CollectionSize/Benchmark.CollectionSize.csproj", "src/main/Benchmark.CollectionSize/"]
RUN dotnet restore "src/main/Benchmark.CollectionSize/Benchmark.CollectionSize.csproj"
COPY . .
WORKDIR "/src/src/main/Benchmark.CollectionSize"
RUN dotnet build "Benchmark.CollectionSize.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Benchmark.CollectionSize.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Benchmark.CollectionSize.dll"]
