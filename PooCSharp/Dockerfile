FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PooCSharp/PooCSharp.csproj", "PooCSharp/"]
RUN dotnet restore "PooCSharp/PooCSharp.csproj"
COPY . .
WORKDIR "/src/PooCSharp"
RUN dotnet build "PooCSharp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PooCSharp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PooCSharp.dll"]
