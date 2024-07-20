FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/main/Benchmarks.DynamicPredicateParser/Benchmarks.DynamicPredicateParser.csproj", "src/main/Benchmarks.DynamicPredicateParser/"]
RUN dotnet restore "src/main/Benchmarks.DynamicPredicateParser/Benchmarks.DynamicPredicateParser.csproj"
COPY . .
WORKDIR "/src/src/main/Benchmarks.DynamicPredicateParser"
RUN dotnet build "Benchmarks.DynamicPredicateParser.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Benchmarks.DynamicPredicateParser.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Benchmarks.DynamicPredicateParser.dll"]
