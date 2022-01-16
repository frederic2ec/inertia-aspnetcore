using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Inertia.AspNetCore.Tests
{
    public class InertiaTest
    {
        [Fact]
        public void Inertia_Inertia_ReturnsInertiaResult()
        {
            Mock<InertiaController> mock = new Mock<InertiaController>
            {
                CallBase = true
            };
            
            IActionResult result = mock.Object.Inertia("abc", new { });

            Assert.IsType<InertiaResult>(result);
        }
    }
}