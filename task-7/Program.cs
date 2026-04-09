//requirements
//1. application that perform multiple asynchronous operations
class Program
{
    //method which acts as fetch
    static async Task<string> Fetch(string name, int delay)
    {
        await Task.Delay(delay);
        return "Hello " + name;
    }

    //Main method
    static async Task Main()
    {
        try
        {
            double start_time = DateTime.Now.TimeOfDay.TotalSeconds;
            var API_1 = Fetch("Aswin", 2000);
            var API_2 = Fetch("Rahul", 2000);
            var API_3 = Fetch("Virat", 2000);

            string[] result = await Task.WhenAll(API_1, API_2, API_3);


            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
            double end_time = (DateTime.Now.TimeOfDay.TotalSeconds) - start_time;
            Console.WriteLine($"OVERALL TIME TAKEN : {end_time}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}