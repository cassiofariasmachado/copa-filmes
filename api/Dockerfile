FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

HEALTHCHECK --interval=3s --timeout=5s --retries=5 CMD [ "curl --fail http://localhost:80/health || exit" ]

COPY CopaFilmes.sln CopaFilmes.sln
COPY src/CopaFilmes.Api/*.csproj src/CopaFilmes.Api/
COPY src/CopaFilmes.Domain/*.csproj src/CopaFilmes.Domain/
COPY src/CopaFilmes.Infra/*.csproj src/CopaFilmes.Infra/
COPY test/CopaFilmes.Domain.Test/*.csproj test/CopaFilmes.Domain.Test/
COPY CopaFilmes.sln CopaFilmes.sln

RUN dotnet restore

COPY src ./src
COPY test ./test

RUN dotnet publish -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CopaFilmes.Api.dll"]
