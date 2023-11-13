
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Restaraunt.WebApi/Restaraunt.WebApi.csproj", "Restaraunt.WebApi/"]
COPY ["Restaraunt.Application/Restaraunt.Application.csproj", "Restaraunt.Application/"]
COPY ["Restaraunt.Domain/Restaraunt.Domain.csproj", "Restaraunt.Domain/"]
COPY ["Restaraunt.Persistence/Restaraunt.Persistence.csproj", "Restaraunt.Persistence/"]
RUN dotnet restore "Restaraunt.WebApi/Restaraunt.WebApi.csproj"
COPY . .
WORKDIR "/src/Restaraunt.WebApi"
RUN dotnet build "Restaraunt.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Restaraunt.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Restaraunt.WebApi.dll"]