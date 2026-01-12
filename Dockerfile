# 1. SDK Aşaması (Derleme)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyalarını kopyala
COPY ["WebAPI/WebAPI.csproj", "WebAPI/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["Repository/Repository.csproj", "Repository/"]
COPY ["Entity/Entity.csproj", "Entity/"]

# Restore et
RUN dotnet restore "WebAPI/WebAPI.csproj"

# Geri kalan her şeyi kopyala ve yayınla
COPY . .
WORKDIR "/src/WebAPI"
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish

# 2. Runtime Aşaması (Çalıştırma)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Port ayarı (DigitalOcean için 8080 standarttır)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "WebAPI.dll"]