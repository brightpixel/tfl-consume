# TfL Consume

This is an app designed to consume data for Road Status from the TfL public API
# 	Configuration

To use this app you will need an AppId and DeveloperKey. This can be obtained from the [Tfl API Portal](https://api-portal.tfl.gov.uk/).

The appSettings.json file requires the AppId and DeveloperKey values mentioned above.

#		Usage
This app is written in .NET Core 2.1. You can either publish to DLL or wrap publish to EXE by using the following statement (depending on what platform you want to run it on):

    dotnet publish -c Release -r win10-x64
    dotnet publish -c Release -r ubuntu.16.10-x64

The application is called in the following way:

    dotnet TflConsume.App.exe A2

or

     .\TflConsume.App.exe A2

with A2 being the road name that is being requested.
