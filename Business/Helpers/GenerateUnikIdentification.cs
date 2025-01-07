namespace Business.Helpers;

public static class GenerateUnikIdentification
{
    public static string GenerateUniquekId()
    {
        return Guid.NewGuid().ToString();
    }
}
