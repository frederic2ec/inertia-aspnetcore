![image](https://user-images.githubusercontent.com/6599653/114456558-032e2200-9bab-11eb-88bc-a19897f417ba.png)


# Inertia.js ASP.Net Core Adapter

## Prerequisite
1. .NET Core v5
2. An ASP.NET Core MVC project

## Install
1. Package Manager: PM> Install-Package Inertia.AspNetCore
2. .NET CLI: dotnet add package Inertia.AspNetCore

## Usage
1. Setup Startup.cs
```c#
using Inertia.AspNetCore;

public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews().UserInertia();
}
```
2. In your controller
````c#
using Inertia.AspNetCore;

public IActionResult Index()
{
   return InertiaView.Render("Index", new
   {
       UserId = 1
   });
}

````

Visit [inertiajs.com](https://inertiajs.com/) to learn more.