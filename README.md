# SearchInspectionTool

Repository: https://github.com/planMyName/SearchInspectionTool

# Assumptions:
- We are trying to only look for google result index not line numbers

# Build

## Prerequisite

Install Cake tool
 run the following two commands
    dotnet new tool-manifest
    dotnet tool install Cake.Tool --version 2.2.0

## Compile and build
1. Open powershell
2. navigate to {solutionDirectory}\build directory
3. run the following command ".\build.ps1"

# Run Program

## Prerequisite 

Install .Net 6.0.5 Desktop runtime x64 from
https://dotnet.microsoft.com/en-us/download/dotnet/6.0

## Run

Go to directory {solutionDirectory}\bin\Debug\package\
Execute Sit.App.exe


# Possible Enhancement
- WPF turn into MVVM
- WPF presentation
- More Error catching
- Inject Logging element
- More Fault Tolerant Requests, like Poly


# Design Overview

Projects contain mainly the client logic
- Sit.App
- Sit.App.Core 

Projects contain the business logic
- Sit.Core
- Sit.Core.Abstractions

Projects contain any data retrieve logic
- Sit.Data
- Sit.Data.Abstractions

Folder contain all the unit tests organized by {project name}.Tests using the same folder structure as the original project it is testing.
- \tests

