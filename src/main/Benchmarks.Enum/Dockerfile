FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Benchmark.Enum/Benchmark.Enum.csproj", "Benchmark.Enum/"]
RUN dotnet restore "Benchmark.Enum/Benchmark.Enum.csproj"
COPY . .
WORKDIR "/src/Benchmark.Enum"
RUN dotnet build "Benchmark.Enum.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Benchmark.Enum.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Benchmark.Enum.dll"]
