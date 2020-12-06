FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

COPY *.sln .
COPY RecipeMd.Api/RecipeMd.Api.csproj RecipeMd.Api/
COPY RecipeMd.Domain/RecipeMd.Domain.csproj RecipeMd.Domain/
COPY RecipeMd.Backend/RecipeMd.Backend.csproj RecipeMd.Backend/

RUN dotnet restore

COPY . .
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim

WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .

ENTRYPOINT ["dotnet", "RecipeMd.Api.dll"]