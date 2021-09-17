![image](https://user-images.githubusercontent.com/6599653/114456558-032e2200-9bab-11eb-88bc-a19897f417ba.png)


# Inertia.js ASP.Net Core Adapter

## Prerequisite
1. .NET Core v5
2. A ASP.NET Core MVC project
3. Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation installed via .NET CLI or Package Manger
    1. Package Manager: PM> Install-Package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
    2. .NET CLI: dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation

## Install
1. Package Manager: PM> Install-Package Inertia.AspNetCore
2. .NET CLI: dotnet add package Inertia.AspNetCore

## Usage
1. Setup Startup.cs
```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews().AddRazorRuntimeCompilation(opts =>
    {
        opts.FileProviders.Add(new EmbeddedFileProvider(typeof(Inertia.AspNetCore.Inertia).GetTypeInfo().Assembly));
    })
}
```
2. In your controller
````c#
private readonly Inertia.AspNetCore.Inertia _inertia = new Inertia.AspNetCore.Inertia();

public IActionResult Index()
{
   return _inertia.Render(Request, Response, "Index", new
   {
       UserId = 1
   });
}

````

Visit [inertiajs.com](https://inertiajs.com/) to learn more.