# Wargame Tracker

## Dev Environment Set up

Install Nodejs (curently using version 20.16.0): https://nodejs.org/dist/v20.16.0/node-v20.16.0-x64.msi

Install Serverless as a global framework: run `npm i serverless -g` in a terminal

Install AWSCLIv2: https://aws.amazon.com/cli/
- This is used to provide command-line access to AWS Tools

## Projects

### Vue Web App (ui)

Change the directory to the `ui` folder

Use `npm run dev` to run the development environment

Navigate to http://localhost:4200 to access the web page

### AWS Backend (api/wargame-tracker-api)

Change the directory to the `api` folder

Run `npm install` to install dependencies

Use `serverless offline` in the terminal to start the project

It may ask you to login/register, select "login/register" to open a browser

Sign into your serverless account (create one if you don't have it)

If you get an error about not having access, the admin for the battle library must add in for you.
