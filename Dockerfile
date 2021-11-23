FROM php:7.4-apache
RUN docker-php-ext-install mysqli pdo_mysql
RUN apt-get update \
    && apt-get install -y libzip-dev \
    && apt-get install -y zlib1g-dev \
    && rm -rf /var/lib/apt/lists/* \
    && docker-php-ext-install zip
RUN a2enmod headers
WORKDIR /var/log
RUN mkdir xteori && chown www-data /var/log/xteori/

# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

# Copy everything else and build
COPY . ./
RUN dotnet publish ./Quiz.sln --output /app/out --configuration Release

#Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Quiz.Api.dll"]


