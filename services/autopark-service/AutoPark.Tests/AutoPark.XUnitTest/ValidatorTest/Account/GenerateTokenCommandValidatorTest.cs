using AutoPark.Application.UseCases.Accounts;

namespace AutoPark.XUnitTests;

public class GenerateTokenCommandValidatorTest
{
    [Theory]
    [InlineData("sadsaw", "asAS@#%123")]
    [InlineData("adsawqec", "Abcd123!@#")]
    [InlineData("admin", "123456")]
    [InlineData("sdv4323", "Qwerty!123")]
    [InlineData("dfgbvdf", "Hello123!")]
    [InlineData("43wsedfs", "MyP@ssw0rd")]
    [InlineData("sdf324w", "GreenSale!")]
    [InlineData("werwer43", "Welcome123")]
    [InlineData("34efses", "Security#1")]

    public void CheckRightValid(string userIdentity, string password)
    {
        var dto = new GenerateTokenCommand()
        {
            UserIdentity = userIdentity,
            Password = password
        };

        GenerateTokenCommandValidator userLoginDto = new GenerateTokenCommandValidator();
        var result = userLoginDto.Validate(dto);

        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("dfgs", "asAS@#%123")]
    [InlineData("   ", "   ")]
    [InlineData("xdkjfghkidfhglkdfijghxzidlfjhgvzkisdjghzlisdjhglkidsgfjhkdifguhkzxiduhgfvzksdihfgkzisduhfglkaushefalosuhgfasloegfuhaofuyhgzsdfgkjzsdlgfohnlsdzgojzhsdlgohjlzsdgiojuhszehljguise",
        "asAS@#%123")]
    [InlineData("xsderts43e", "      ")]
    [InlineData("serdt43", "12345sdergasw3erfesa789")]
    [InlineData("dttr", "trfhdrthdrthdrthdrthdrthdrt")]

    public void checkWrongTest(string userIdentity, string password)
    {
        var dto = new GenerateTokenCommand()
        {
            UserIdentity = userIdentity,
            Password = password
        };

        var validator = new GenerateTokenCommandValidator();
        var result = validator.Validate(dto);

        Assert.False(result.IsValid);
    }
}
