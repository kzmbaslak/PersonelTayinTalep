# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

WORKDIR /src/WebAPI
RUN dotnet restore
RUN dotnet publish -c Release -o /app
WORKDIR /src/DataAccess
ENTRYPOINT [ "dotnet", "ef","database","update" ]

# Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "WebAPI.dll"]

# Giriş noktası: migration ve app
# ENTRYPOINT ["sh", "-c", "dotnet ef database update --project ../DataAccess --startup-project . && dotnet WebAPI.dll"]
