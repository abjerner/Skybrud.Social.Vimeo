@echo off
cd src/Skybrud.Social.Vimeo
"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\msbuild.exe" /t:pack /p:Configuration=Release /p:PackageOutputPath=../../releases/nuget /p:RunBuildTargets=false
cd ../../
grunt