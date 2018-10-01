FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 49534
EXPOSE 44303

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY Matchmaking.Engine/Matchmaking.Engine.csproj Matchmaking.Engine/
RUN dotnet restore Matchmaking.Engine/Matchmaking.Engine.csproj
COPY . .
WORKDIR /src/Matchmaking.Engine
RUN dotnet build Matchmaking.Engine.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Matchmaking.Engine.csproj -c Release -o /app

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Matchmaking.Engine.dll"]
