FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app
COPY ./src/*.csproj WordleClone/
RUN dotnet restore "WordleClone/WordleClone.csproj" --disable-parallel --runtime linux-musl-x64
COPY . ./
RUN dotnet publish ./src/ -c Release -o out --runtime linux-musl-x64 --self-contained true
RUN apk add --no-cache openssl
RUN mkdir /tmp/certs && \
    openssl req -x509 -newkey rsa:4096 -keyout /tmp/certs/certificate.key -out /tmp/certs/certificate.crt -days 365 -nodes -subj "/CN=localhost"  && \
    openssl pkcs12 -export -out /tmp/certs/certificate.pfx -inkey /tmp/certs/certificate.key -in /tmp/certs/certificate.crt -passout pass:yourpassword

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0-alpine
RUN apk upgrade musl
RUN apk add --no-cache openssl
WORKDIR /app
COPY --from=build /app/out .
COPY --from=build /tmp/certs ./certs
RUN adduser --disabled-password \
  --home /app \
  --gecos '' dotnetuser

RUN chown -R dotnetuser:dotnetuser /app
RUN chmod 644 /app/certs/certificate.pfx
RUN mkdir -p /app/wwwroot && chown -R dotnetuser:dotnetuser /app/wwwroot
USER dotnetuser
ENV ASPNETCORE_URLS=http://+:53120;https://+:53121
EXPOSE 53120 53121

ENTRYPOINT ["./WordleClone"]
