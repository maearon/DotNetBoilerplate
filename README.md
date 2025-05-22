### .NET Implementation of Rails Tutorial Sample App

I'll create a .NET application that replicates the functionality of the Ruby on Rails tutorial sample app. Let's start by setting up the .NET project structure and implementing the core features.

IDE: https://visualstudio.microsoft.com/vs/community/

```
dotnet tool install --global dotnet-ef
dotnet ef
dotnet ef migrations add InitOrFixModel
dotnet ef database update
PS C:\Users\manhn\code\DotNetBoilerplate> dotnet --list-sdks
9.0.300 [C:\Program Files\dotnet\sdk]
```