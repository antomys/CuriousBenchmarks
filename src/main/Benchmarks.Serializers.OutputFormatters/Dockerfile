FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/main/Benchmarks.Serializers.OutputFormatters/Benchmarks.Serializers.OutputFormatters.csproj", "src/main/Benchmarks.Serializers.OutputFormatters/"]
RUN dotnet restore "src/main/Benchmarks.Serializers.OutputFormatters/Benchmarks.Serializers.OutputFormatters.csproj"
COPY . .
WORKDIR "/src/src/main/Benchmarks.Serializers.OutputFormatters"
RUN dotnet build "Benchmarks.Serializers.OutputFormatters.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Benchmarks.Serializers.OutputFormatters.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Benchmarks.Serializers.OutputFormatters.dll"]
