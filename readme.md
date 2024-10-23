# Wargame Tracker

## Dev Environment Set up

Install Nodejs (curently using version 20.16.0): https://nodejs.org/dist/v20.16.0/node-v20.16.0-x64.msi

Install the dotnet SDK 8: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

Install either Visual Studio or Visual Studio Code (this project was built with Visual Studio)

### Optional

#### Install and Configure Seq for logging

Install Seq: https://datalust.co/download

> [!NOTE]
> Make sure to note the endpoint that Seq is set up to (for example, `http://localhost:5341`). 
> This will be needed to set up the API project to write with OpenTelemetry.
> You would set the endpoint in the OpenTelemetry config to `http://localhost:5341/ingest/otlp/v1/logs`

## Projects

### Vue Web App (ui)

Change the directory to the `ui` folder

Use `npm run dev` to run the development environment

Navigate to http://localhost:4200 to access the web page

### .NET Core 8 Web Api (api)

Open the `api/TheBattleLibraryWebApi.sln` solution file in Visual Studio

Make a copy of `appsettings.json` called `appsettings.development.json` and fill out all of the fields

> [!WARNING]
> appsettings.json is a template file and should not be updated in the repository. appsettings.development.json is 
> configured to be ignored by git. 