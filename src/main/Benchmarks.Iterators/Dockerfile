FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/main/Benchmark.Iterators/Benchmark.Iterators.csproj", "src/main/Benchmark.Iterators/"]
RUN dotnet restore "src/main/Benchmark.Iterators/Benchmark.Iterators.csproj"
COPY . .
WORKDIR "/src/src/main/Benchmark.Iterators"
RUN dotnet build "Benchmark.Iterators.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Benchmark.Iterators.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Benchmark.Iterators.dll"]
