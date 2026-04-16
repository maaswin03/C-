using System.Reflection;
//requirements
//1.Application that discovers and execute methods based on custom attributes

//creating a custom attribute Runnable
[AttributeUsage(AttributeTargets.Method)]
class Runnable : Attribute
{
    public string Name { get; set; }

    public Runnable(string name)
    {
        Name = name;
    }
}

//class Operation with methods with attribute 
class Operation
{
    [Runnable("add")]
    public static void Add(int a, int b)
    {
        //TODO - future we can store the values in database
        try
        {
            Console.WriteLine($"ADDITION : {a + b}\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    [Runnable("sub")]
    public static void Sub(int a, int b)
    {
        try
        {
            //TODO - future we can store the values in database
            Console.WriteLine($"SUBTRACTION : {a - b}\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    [Runnable("mul")]
    public static void Mul(int a, int b)
    {
        try
        {
            //TODO - future we can store the values in database
            Console.WriteLine($"MULTIPLICATION : {a * b}\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    [Runnable("div")]
    public static void Div(int a, int b)
    {
        try
        {
            //used exception to overcome zero division error
            Console.WriteLine($"DIVIDE : {a / b}\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}


//class AdvancedOperation with methods with attribute 
class AdvancedOperation
{
    [Runnable("mod")]
    public static void Mod(int a, int b)
    {
        try
        {
            //TODO - future we can store the values in database
            Console.WriteLine($"MODULUS : {a % b}\n");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

class Program
{
    public static void Main(String[] args)
    {
        try
        {
            //getting all the class present in the code
            var types = Assembly.GetExecutingAssembly().GetTypes();

            while (true)
            {
                //getting the command from the user
                Console.Write("ENTER YOUR COMMAND : ");
                string? input = Console.ReadLine();
                bool found = false;

                //check the input is null or have white space
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                //looping through all the classes
                foreach (var type in types)
                {
                    //getting all method from the class
                    var methods = type.GetMethods();

                    //looping through all the methods
                    foreach (var method in methods)
                    {
                        //getting the custom attribute for the method
                        var attribute = method.GetCustomAttribute<Runnable>();

                        //checking the attribute is not null
                        if (attribute != null && attribute.Name.Equals(input.ToLower()))
                        {
                            Console.Write("ENTER VALUE OF A : ");
                            int a = Convert.ToInt32(Console.ReadLine());

                            Console.Write("ENTER VALUE OF B : ");
                            int b = Convert.ToInt32(Console.ReadLine());

                            found = true;
                            method.Invoke(null, [a, b]);
                        }
                    }
                }
                if (!found)
                {
                    Console.WriteLine("ENTER A VALID COMMAND\n");
                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}