using System;
using System.Linq;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception();
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        char firstChar = input.First();

        if (Char.IsNumber(firstChar))
            return firstChar - '0';
        else
            return null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        char firstChar = input.First();

        if (Char.IsNumber(firstChar))
        {
            result = firstChar - '0';
            return true;
        }
        else
        {
            result = 0;
            return false;
        }
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        using (disposableObject) throw new Exception();
    }
}
