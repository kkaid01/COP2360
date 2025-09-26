using System;

class Program
{
    static void Main()
    {
        // Ask user for input
        Console.Write("Enter first number: ");
        string input1 = Console.ReadLine();

        Console.Write("Enter second number: ");
        string input2 = Console.ReadLine();

        try
        {
            // Try to convert inputs to integers
            int num1 = Convert.ToInt32(input1);
            int num2 = Convert.ToInt32(input2);

            // Perform division
            int result = num1 / num2;
            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid integers.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Number is too large or too small.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
