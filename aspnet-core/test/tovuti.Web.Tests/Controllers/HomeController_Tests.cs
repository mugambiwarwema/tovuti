using System.Threading.Tasks;
using tovuti.Models.TokenAuth;
using tovuti.Web.Controllers;
using Shouldly;
using Xunit;

namespace tovuti.Web.Tests.Controllers
{
    public class HomeController_Tests: tovutiWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}