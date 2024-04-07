FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/main/Benchmark.String/Benchmark.String.csproj", "src/main/Benchmark.String/"]
RUN dotnet restore "src/main/Benchmark.String/Benchmark.String.csproj"
COPY . .
WORKDIR "/src/src/main/Benchmark.String"
RUN dotnet build "Benchmark.String.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Benchmark.String.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Benchmark.String.dll"]
