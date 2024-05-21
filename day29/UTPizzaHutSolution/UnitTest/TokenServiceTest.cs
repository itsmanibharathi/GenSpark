using Microsoft.Extensions.Configuration;
using Moq;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;
using PizzaHutAPI.Services;

namespace UnitTest
{
    public class TokenServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            //Mock<IConfigurationSection> configurationJWTSection = new Mock<IConfigurationSection>();
            //configurationJWTSection.Setup(x => x.Value).Returns("This is the dummy key which has to be a bit long for the 512. which should be even more longer for the passing");
            //Mock<IConfigurationSection> congigTokenSection = new Mock<IConfigurationSection>();
            //congigTokenSection.Setup(x => x.GetSection("Secret")).Returns(configurationJWTSection.Object);
            //Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            //mockConfig.Setup(x => x.GetSection("JWT")).Returns(congigTokenSection.Object);

            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x["JWT:Secret"]).Returns("This is the dummy key which has to be a bit long for the 512. which should be even more longer for the passing");

            ITokenService service = new TokenService(configuration.Object);

            //Action
            var token = service.GenerateToken(new User { Id = 103 , Role = UserRole.Admin });

            //Assert
            Assert.IsNotNull(token);
            
        }
    }
}