FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["LIB.API.csproj", "./"]
RUN dotnet restore "LIB.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "LIB.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LIB.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LIB.API.dll"]
