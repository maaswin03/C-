class Calculator
{
    // creating and event with the func delegate
    public event Func<int, int, int?>? CalculatorOp;

    //method to invoke the event
    public void Process(int a, int b)
    {
        CalculatorOp?.Invoke(a, b);
    }
}

class Program
{
    //method for addition

    public static int? Add(int a, int b)
    {
        try
        {
            //TODO
            Console.WriteLine($"RESULT FOR ADDITION : {a + b}");
            return a + b;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    //method for subtraction
    public static int? Sub(int a, int b)
    {
        try
        {
            //TODO
            Console.WriteLine($"RESULT FOR SUBTRACTION : {a - b}");
            return a - b;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    //method for multiplication
    public static int? Mul(int a, int b)
    {
        try
        {
            //TODO
            Console.WriteLine($"RESULT FOR MULTIPLICATION : {a * b}");
            return a * b;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public static void Main(String[] args)
    {
        Calculator c = new();

        c.CalculatorOp += Add;
        c.CalculatorOp += Sub;
        c.CalculatorOp += Mul;

        c.Process(10, 12);

        //predicate delegate to check value is 0 or not
        Predicate<int> Compare = (a) => a == 0;
        Console.WriteLine(Compare(10));
    }
}
