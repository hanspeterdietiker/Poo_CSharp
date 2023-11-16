FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Lambda_CSharp/Lambda_CSharp.csproj", "Lambda_CSharp/"]
RUN dotnet restore "Lambda_CSharp/Lambda_CSharp.csproj"
COPY . .
WORKDIR "/src/Lambda_CSharp"
RUN dotnet build "Lambda_CSharp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lambda_CSharp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lambda_CSharp.dll"]
