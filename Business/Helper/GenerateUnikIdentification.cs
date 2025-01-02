namespace Business.Helper;

public static class GenerateUnikIdentification
{
    public static string GenerateUnikId()
    {
        return Guid.NewGuid().ToString();
    }
}
