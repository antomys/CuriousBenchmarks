FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CuriousBenchmarks.Common/CuriousBenchmarks.Common.csproj", "CuriousBenchmarks.Common/"]
COPY ["Json/Json.Benchmarks.Server/Json.Benchmarks.Server.csproj", "Json.Benchmarks.Server/"]
COPY ["Json/Json.Benchmarks/Json.Benchmarks.csproj", "Json.Benchmarks/"]
COPY ["Json/Libraries/Maverick.Json/Maverick.Json.csproj", "Libraries/Maverick.Json/"]
RUN dotnet restore "Json.Benchmarks.Server/Json.Benchmarks.Server.csproj"
COPY . .
WORKDIR "/src/Json.Benchmarks.Server"
RUN dotnet build "Json.Benchmarks.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Json.Benchmarks.Server.csproj" -c Release -o  /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Json.Benchmarks.Server.dll"]
