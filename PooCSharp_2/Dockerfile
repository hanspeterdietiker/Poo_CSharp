FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PooCSharp_2/PooCSharp_2.csproj", "PooCSharp_2/"]
RUN dotnet restore "PooCSharp_2/PooCSharp_2.csproj"
COPY . .
WORKDIR "/src/PooCSharp_2"
RUN dotnet build "PooCSharp_2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PooCSharp_2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PooCSharp_2.dll"]
