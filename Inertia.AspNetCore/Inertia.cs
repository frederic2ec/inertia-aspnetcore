using Microsoft.AspNetCore.Mvc;

namespace Inertia.AspNetCore
{
    public static class InertiaView
    {
        public static IActionResult Render(string component, object props) => new InertiaResult(component, props);
    }
}