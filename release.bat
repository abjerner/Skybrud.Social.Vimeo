@echo off
dotnet build src/Skybrud.Social.Vimeo --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget