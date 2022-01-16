using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Inertia.AspNetCore.Tests
{
    public class ConfigureTest
    {
        [Fact]
        public void Configure_AddInertia_ReturnIMvcBuilder()
        {
            Mock<IMvcBuilder> mock = new Mock<IMvcBuilder>
            {
                DefaultValue = DefaultValue.Mock
            };
            
            IMvcBuilder result = mock.Object.AddInertia();

            Assert.IsAssignableFrom<IMvcBuilder>(result);
        }
    }
}

