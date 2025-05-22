### Vue + .NET Social App

I'll create a .NET application that replicates the functionality of the Ruby on Rails tutorial sample app. Let's start by setting up the .NET project structure and implementing the core features.

### Vue 3 Frontend
```
cd vue-boilerplate
npm i
npm run dev
http://localhost:5173/
```

### .NET Backend

IDE: https://visualstudio.microsoft.com/vs/community/

```
https://localhost:7217/swagger/index.html
/
localhost:7217   api/
localhost:7217   swagger Auth/
localhost:7217   |   swagger POST    login               (Login)
localhost:7217   |   swagger POST    register            (Register)
localhost:7217
localhost:7217   swagger Microposts/
localhost:7217   |   swagger GET     /                   (Get all microposts)
localhost:7217   |   swagger POST    /                   (Create a new micropost)
localhost:7217   |   swagger GET     /{id}               (Get micropost by ID)
localhost:7217   |   swagger DELETE  /{id}               (Delete micropost by ID)
localhost:7217
localhost:7217   swagger Relationships/
localhost:7217   |   swagger POST    /                   (Follow a user)
localhost:7217   |   swagger DELETE  /{id}               (Unfollow a user)
localhost:7217
localhost:7217   swagger Users/
localhost:7217   |   swagger GET     /                   (Get all users)
localhost:7217   |   swagger GET     /{id}               (Get user by ID)
localhost:7217   |   swagger GET     /{id}/microposts    (Get microposts by user)
localhost:7217   |   swagger GET     /{id}/following     (Get users this user is following)
localhost:7217   |   swagger GET     /{id}/followers     (Get this user's followers)
localhost:7217   |   swagger GET     /me                 (??Get current authenticated user) ?

```

```
maearon@maearon:~$ wget https://builds.dotnet.microsoft.com/dotnet/Sdk/9.0.300/dotnet-sdk-9.0.300-linux-x64.tar.gz
--2025-05-22 12:17:18--  https://builds.dotnet.microsoft.com/dotnet/Sdk/9.0.300/dotnet-sdk-9.0.300-linux-x64.tar.gz
Resolving builds.dotnet.microsoft.com (builds.dotnet.microsoft.com)... 2600:1417:4400:3::1731:68cb, 2600:1417:4400:3::1731:68d6, 23.200.143.11, ...
Connecting to builds.dotnet.microsoft.com (builds.dotnet.microsoft.com)|2600:1417:4400:3::1731:68cb|:443... connected.
HTTP request sent, awaiting response... 200 OK
Length: 217847129 (208M) [application/octet-stream]
Saving to: ‘dotnet-sdk-9.0.300-linux-x64.tar.gz’

dotnet-sdk-9.0.300- 100%[===================>] 207.75M  1.51MB/s    in 1m 47s  

2025-05-22 12:19:05 (1.94 MB/s) - ‘dotnet-sdk-9.0.300-linux-x64.tar.gz’ saved [217847129/217847129]

maearon@maearon:~$ mkdir -p $HOME/dotnet
maearon@maearon:~$ tar -zxf dotnet-sdk-9.0.300-linux-x64.tar.gz -C $HOME/dotnet
maearon@maearon:~$ export DOTNET_ROOT=$HOME/dotnet
maearon@maearon:~$ export PATH=$PATH:$HOME/dotnet
maearon@maearon:~$ dotnet --version
9.0.300
dotnet dev-certs https --trust, https://localhost:7214 (May be only work on Windows OS)
maearon@maearon:~/code/DotNetBoilerplate$ dotnet watch run
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