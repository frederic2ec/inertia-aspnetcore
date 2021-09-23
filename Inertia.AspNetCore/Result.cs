using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Inertia.AspNetCore
{
    internal class InertiaData
    {
        public string component { get; set; }
        public string url { get; set; }
        public string version { get; set; }
        public object props { get; set; }
    }
    
    internal class InertiaResult : IActionResult
    {
        private readonly string _component;
        private readonly object _props;
        
        public InertiaResult(string component, object props)
        {
            _component = component;
            _props = props;
        }
        
        public async Task ExecuteResultAsync(ActionContext context)
        {
            InertiaData data = new InertiaData
            {
                component = _component,
                props = _props,
                url = context.HttpContext.Request.Path.Value + context.HttpContext.Request.QueryString.Value,
                version = Guid.NewGuid().ToString().Replace("-", string.Empty)
            };
            
            if (context.HttpContext.Request.Headers.ContainsKey("X-Inertia"))
            {
                if (context.HttpContext.Request.Headers["X-Inertia"].ToString() == "true")
                {
                    context.HttpContext.Response.Headers["Vary"] = "Accept";
                    context.HttpContext.Response.Headers["X-Inertia"] = "True";
                    await new JsonResult(data).ExecuteResultAsync(context);
                    return;
                }
            }
            
            var render = new ViewResult
            {
                ViewName = "inertia",
                ViewData = new ViewDataDictionary(new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(), new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary()) { { "Data", JsonSerializer.Serialize<InertiaData>(data) } }
            };
            
            await render.ExecuteResultAsync(context);
        }
    }
}