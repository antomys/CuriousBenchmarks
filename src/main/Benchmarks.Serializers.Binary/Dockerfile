FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/main/Benchmark.Serializers.Binary/Benchmark.Serializers.Binary.csproj", "src/main/Benchmark.Serializers.Binary/"]
RUN dotnet restore "src/main/Benchmark.Serializers.Binary/Benchmark.Serializers.Binary.csproj"
COPY . .
WORKDIR "/src/src/main/Benchmark.Serializers.Binary"
RUN dotnet build "Benchmark.Serializers.Binary.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Benchmark.Serializers.Binary.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Benchmark.Serializers.Binary.dll"]
