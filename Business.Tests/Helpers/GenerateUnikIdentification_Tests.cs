
using Business.Helpers;

namespace Business.Tests.Helpers;

public class GenerateUnikIdentification_Tests
{
    [Fact]
    public void GenerateUniquekId_ShouldReturnGuidAsString()
    {
        var result = GenerateUnikIdentification.GenerateUniquekId();
        Assert.True(Guid.TryParse(result, out _));

    }
}
