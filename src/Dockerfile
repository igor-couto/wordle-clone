# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy-arm64v8 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./src/WordleClone.csproj" --disable-parallel --runtime linux-arm64
RUN dotnet publish "./src/WordleClone.csproj" -c Release -o /app --no-restore --runtime linux-arm64 --self-contained true

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-arm64v8 AS run
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_URLS="http://+:50010;https://+:50011"
ENV ASPNETCORE_HTTPS_PORT=50010
ENV ASPNETCORE_HTTP_PORT=50011
RUN adduser --disabled-password --home /app dotnetuser
WORKDIR /app
COPY --from=build /app .
RUN chown -R dotnetuser:dotnetuser /app
USER dotnetuser
EXPOSE 50010 50011

ENTRYPOINT ["./WordleClone"]