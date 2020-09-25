FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["GameManagement/GameManagement.csproj", "GameManagement/"]
COPY ["GameManagement.Repositories/GameManagement.Repositories.csproj", "GameManagement.Repositories/"]
COPY ["GameManagement.Infra/GameManagement.Infra.csproj", "GameManagement.Infra/"]
COPY ["GameManagement.Domain/GameManagement.Domain.csproj", "GameManagement.Domain/"]
COPY ["GameManagement.Repositories.Interfaces/GameManagement.Repositories.Interfaces.csproj", "GameManagement.Repositories.Interfaces/"]
COPY ["GameManagement.Services/GameManagement.Services.csproj", "GameManagement.Services/"]
COPY ["GameManagement.services.interfaces/GameManagement.Services.Interfaces.csproj", "GameManagement.services.interfaces/"]
RUN dotnet restore "GameManagement/GameManagement.csproj"
COPY . .
WORKDIR "/src/GameManagement"
RUN apt update
RUN apt install npm
RUN dotnet build "GameManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameManagement.dll"]
