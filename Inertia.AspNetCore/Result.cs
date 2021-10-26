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
        public object props { get; set; }
        public string url { get; set; }
        public string version { get; set; }
        
    }
    
    internal class InertiaResult : IActionResult
    {
        private readonly string _component;
        private readonly object _props;
        private readonly ViewDataDictionary _viewData;
        private readonly ITempDataDictionary _tempData;
        
        public InertiaResult(string component, object props, ViewDataDictionary viewData, ITempDataDictionary tempData)
        {
            _component = component;
            _props = props;
            _viewData = viewData;
            _tempData = tempData;
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
            
            _viewData["Data"] = JsonSerializer.Serialize<InertiaData>(data);
            
            var render = new ViewResult
            {
                ViewName = "inertia",
                ViewData = _viewData,
                TempData = _tempData
            };
            
            await render.ExecuteResultAsync(context);
        }
    }
}