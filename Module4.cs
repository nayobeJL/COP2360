using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number:");
        string? input1 = Console.ReadLine();

        Console.WriteLine("Enter the second number:");
        string? input2 = Console.ReadLine();

        try
        {
            int number1 = Convert.ToInt32(input1);
            int number2 = Convert.ToInt32(input2);

            int result = Divide(number1, number2);
            Console.WriteLine($"The result of {number1} ÷ {number2} is: {result}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: One or both inputs are not valid numbers.");
            Console.WriteLine($"Debug Info: {ex.Message}");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Error: The number entered is too large or too small for an integer.");
            Console.WriteLine($"Debug Info: {ex.Message}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            Console.WriteLine($"Debug Info: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error occurred.");
            Console.WriteLine($"Debug Info: {ex.Message}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static int Divide(int a, int b)
    {
        return a / b;
    }
}
