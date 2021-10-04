using Microsoft.AspNetCore.Mvc;

namespace Inertia.AspNetCore
{
    public abstract class InertiaController : Controller
    {
        public virtual IActionResult Inertia(string component, object props) => new InertiaResult(component, props, ViewData, TempData);
    }
}