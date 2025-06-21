namespace TestingDemo.Core;

public static class ExceptionUtils
{
    public static void RzucCustomException(string message)
    {
        throw new CustomException(message);
    }
} 