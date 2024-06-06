# Magical-Imagery

The main goal of this project is to create a webshop for selling high-quality images, catering to both private and business needs. Magical Imagery aims to address customer concerns regarding legal issues amidst the surge in AI-generated images, offering artists the freedom to pursue their passion for drawing without constraints. The webshop can be deployed either via a cloud provider or on a self-hosted server.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Engine](https://docs.docker.com/engine/install/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (optional)

## Getting Started (GUI)

To get started with this project, follow these steps:

1. Clone this repository to your local machine.
2. Open the `Magical.sln` project file
3. Build the Docker Containers:
    1. Set `docker-compose` as start project.
    2. Run `Db only` as `Start without Debugging`  
4. Set-up Database
    1. Open Paket-Manager-Console
    2. Apply `Web` als start project.
    3. Apply `Data` as standard project in Paket-Manager-Console
    4. Type `Update-Database` and run it
5. Run application in Debug (F5) or Normal Mode (Ctrl + F5)
6. If it's the first time starting the project, you'll be asked to install a HTTPS certificate. Accept / Install it.

## Getting Started (CLI)

To get started with this project, follow these steps:

1. Clone this repository to your local machine.
2. Open the `Magical.sln` project file.
3. Build the Docker Containers:
    1. Open a terminal of your choice in the `docker-compose` directory.
    2. Run `docker-compose up --build` to build the containers.
4. Set-up Database:
    1. Open Paket-Manager-Console.
    2. Type `dotnet ef database update` and run it.
5. Run application in Debug or Normal Mode:
    1. Open a terminal of your choice in the `Web` directory.
    2. Run `dotnet run` to start the application.
6. If it's the first time starting the project, you'll be asked to install an HTTPS certificate. Accept / Install it.

## Project Structure

| Directory         | Description                                                               |
|-------------------|---------------------------------------------------------------------------|
| `Data`            | Contains the models, interfaces and database context for the application. |
| `docker-compose`  | Contains the configuration for the Docker containers.                     |
| `Web`             | Contains the UI / Frontend of the application.                            |
| `Tests`           | Contains the unit and integration tests for the project.                  |

## Contribute

Please create an branch copy from `main` branch, named after the feature or user story you work on and submit a stable version per Pull-request.

## Test Users

### Admin

| Login    | Data                |
|----------|---------------------|
| Email    | <admin@example.com> |
| Password | *Asdf123            |
| Role     | Admin               |

### Artists

| Login    | Data                 |
|----------|----------------------|
| Email    | <artist@example.com> |
| Password | *Asdf123             |
| Role     | Artist               |

## License

This project is licensed under the Apache License 2.0 License. See the [LICENSE](LICENSE) file for details.
