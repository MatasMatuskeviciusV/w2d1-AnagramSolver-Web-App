# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore AnagramSolver.WebApp/AnagramSolver.WebApp.csproj
RUN dotnet publish AnagramSolver.WebApp/AnagramSolver.WebApp.csproj -c Release -o /app --no-restore
# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
COPY "zodynas.txt" .
EXPOSE 8080
ENTRYPOINT ["dotnet", "AnagramSolver.WebApp.dll"]
