@echo off
dotnet build src/Skybrud.Social.Vimeo --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:/nuget