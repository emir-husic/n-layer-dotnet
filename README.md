
Introduction

Project dividing the code into projects & "layers" following the N-Layer Architecture

Here we can see how we solve Dependency Injection for multiple projects.

Logging used: Log4Net
Testing: xUnit & Moq
Architecture: N-Layer

We use MySQL database and PhPMyadmin through docker.
You either run the full application through docker or just the database.

Per default, everything is in docker, if you want to run through local set-up, edit `appsettings.json`

PS: You do not need docker run the code, it just simplifies the server set-up.

# Prerequisites
  - Dotnet Core 3.1
  - Docker

# Getting Started

    docker network create quiz-backend_default

    docker-compose up

    try and hit http://localhost:8080/weatherForecast

    http://localhost:8080/api/questions

    http://localhost:8080/api/questions/category/1

# Data SQL script for MYSQL are found in:

/dump folder

phpmyadmin: http://localhost:8000/

username and pass can be found in the `docker-compose.yml` file
 