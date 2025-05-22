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
```
POST https://localhost:7217/api/auth/register
{
  "name": "Test User",
  "email": "test@example.com",
  "password": "Abcd1234!",
  "confirmPassword": "Abcd1234!"
}
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjI3MTBhMmI4LTFiZGMtNGZiNy1iY2FhLTIyNGJlMzM3ZTVmMiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJ0ZXN0QGV4YW1wbGUuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoidGVzdEBleGFtcGxlLmNvbSIsImp0aSI6IjA0ODczYTI3LTA2NjktNDcyNi1hNzUwLTc1N2ZjYWVmZTFmMSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE3NDg0ODM2ODAsImlzcyI6IlNhbXBsZUFwcCIsImF1ZCI6IlNhbXBsZUFwcFVzZXJzIn0.Rf-P-X1v_BGSzB1PIZyftK2WUipiEQ6J1Cq5RfMdpkQ",
    "user": {
        "id": "2710a2b8-1bdc-4fb7-bcaa-224be337e5f2",
        "name": "Test User",
        "email": "test@example.com"
    }
}
POST https://localhost:7217/api/auth/login
{"email":"test@example.com","password":"Abcd1234!","remember_me":true}
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjI3MTBhMmI4LTFiZGMtNGZiNy1iY2FhLTIyNGJlMzM3ZTVmMiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJ0ZXN0QGV4YW1wbGUuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoidGVzdEBleGFtcGxlLmNvbSIsImp0aSI6IjIwY2M3ZjU3LWQxNDQtNDY4OS1hNjhhLTg5MWZmODVkMzhmOCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE3NDg0ODQwNzYsImlzcyI6IlNhbXBsZUFwcCIsImF1ZCI6IlNhbXBsZUFwcFVzZXJzIn0.YsPUR_d8UM4Nmkl8PWz-m29d5_03Wk0s0k7CqOqc7co",
    "user": {
        "id": "2710a2b8-1bdc-4fb7-bcaa-224be337e5f2",
        "name": "Test User",
        "email": "test@example.com"
    }
}
```
```
dotnet add package Swashbuckle.AspNetCore
https://localhost:7217/swagger/index.html
```