![image](https://user-images.githubusercontent.com/6599653/114456558-032e2200-9bab-11eb-88bc-a19897f417ba.png)


# Inertia.js ASP.Net Core Adapter

## Prerequisite
1. .NET Core v5 and later
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
    services.AddControllersWithViews().AddInertia();
}
```
2. In your controller
````c#
using Inertia.AspNetCore;

public class HomeController : InertiaController {
    public IActionResult Index()
    {
       return Inertia("Index", new
       {
           UserId = 1
       });
    }
}
````

Visit [inertiajs.com](https://inertiajs.com/) to learn more.