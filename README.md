# Magical-Imagery 

This repository contains a Blazor .NET 8 project set up to be deployed using Docker.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Engine]([https://docs.docker.com/engine/install/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (optional)

## Getting Started (CLI)

To get started with this project, follow these steps:

1. Clone this repository to your local machine:
2. Open the MagicalImagery.sln project file
3. Build the Docker Containers:
  3.1 Set "docker-compose" as start project.
  3.2 Run "Db only" as "Start without Debugging"  
4. Set-up Database
  4.1 Open Paket-Manager-Console
  4.2 Apply Server.UI als start project.
  4.2 Apply Infrastructure as standard project in Paket-Manager-Console
  4.3 Type `Update-Database` and run it
5. Run application in Debug (F5) or Normal Mode (Ctrl + F5)
6. If it's the first time starting the project, you'll be asked to install a HTTPS certificate. Accept / Install it.

## Getting Started (CMD)

...

## Project Structure

...

## License

This project is licensed under the Apache License 2.0 License. See the [LICENSE](LICENSE) file for details.
