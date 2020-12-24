FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

COPY *.sln .
COPY RecipeMd.Api/*.csproj RecipeMd.Api/
COPY RecipeMd.Domain/*.csproj RecipeMd.Domain/
COPY RecipeMd.Backend/*.csproj RecipeMd.Backend/
COPY RecipeMd.Client/*.csproj RecipeMd.Client/
COPY RecipeMd.Api.Test/*.csproj RecipeMd.Api.Test/

RUN dotnet restore

COPY . .

ENV SNAPSHOOTER_STRICT_MODE=true
RUN dotnet test -c release --no-restore

RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim

WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .

ENTRYPOINT ["dotnet", "RecipeMd.Api.dll"]
