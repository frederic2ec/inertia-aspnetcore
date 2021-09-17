using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inertia.AspNetCore
{
    
    internal class InertiaData
    {
        public string component { get; set; }
        public string url { get; set; }
        public string version { get; set; }
        public object props { get; set; }
    }
    public class Inertia : Controller
    {
        public IActionResult Render(HttpRequest request, HttpResponse response ,string component, object props)
        {
            InertiaData data = new InertiaData
            {
                component = component,
                props = props,
                url = request.Path.Value,
                version = Guid.NewGuid().ToString().Replace("-", string.Empty)
            };
            
            if (request.Headers.ContainsKey("X-Inertia"))
            {
                if (request.Headers["X-Inertia"].ToString() == "true")
                {
                    response.Headers["Vary"] = "Accept";
                    response.Headers["X-Inertia"] = "True";
                    return Json(data);
                }
            }
            
            ViewBag.Data = JsonSerializer.Serialize<InertiaData>(data);
            return View("inertia");
        }
    }
}