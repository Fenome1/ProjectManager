FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ProjectManager.API/ProjectManager.API.csproj", "ProjectManager.API/"]
RUN dotnet restore "ProjectManager.API/ProjectManager.API.csproj"
COPY . .
WORKDIR "/src/ProjectManager.API"
RUN dotnet build "ProjectManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectManager.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectManager.API.dll"]
