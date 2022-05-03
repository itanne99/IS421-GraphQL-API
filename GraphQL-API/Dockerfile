FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src
COPY ["GraphQL-API.csproj", "./"]
RUN dotnet restore "./GraphQL-API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "GraphQL-API.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "GraphQL-API.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphQL-API.dll"]