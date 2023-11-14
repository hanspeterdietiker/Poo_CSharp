FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PooCSharp_3/PooCSharp_3.csproj", "PooCSharp_3/"]
RUN dotnet restore "PooCSharp_3/PooCSharp_3.csproj"
COPY . .
WORKDIR "/src/PooCSharp_3"
RUN dotnet build "PooCSharp_3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PooCSharp_3.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PooCSharp_3.dll"]
