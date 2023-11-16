FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Lambda_CSharp2/Lambda_CSharp2.csproj", "Lambda_CSharp2/"]
RUN dotnet restore "Lambda_CSharp2/Lambda_CSharp2.csproj"
COPY . .
WORKDIR "/src/Lambda_CSharp2"
RUN dotnet build "Lambda_CSharp2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lambda_CSharp2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lambda_CSharp2.dll"]
