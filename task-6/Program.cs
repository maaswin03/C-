//Requirements
//1. Application that triggers and event when the counter reaches threshold
//2. Implementation of Exception handling
class Counter
{
    //creating an event
    public event Action? CounterTrigger;

    private int _count = 0;
    private int _threshold;

    //setting up the threshold
    public int Threshold
    {
        get
        {
            return _threshold;
        }
        set
        {
            _threshold = value;
        }
    }

    //constructor to set threshold value
    public Counter(int threshold_value)
    {
        Threshold = threshold_value;
    }

    //Process method to invoke events when threshold is reached
    public void Process()
    {
        _count++;

        if (_count >= _threshold)
        {
            Console.WriteLine("PROCESSING....");
            CounterTrigger?.Invoke();
            _count = 0;
        }
    }
}


class Program
{

    public static void UpdateDashboard()
    {
        Console.WriteLine("COUNTER REACHED THRESHOLD VALUE UPDATING DASHBOARD");
    }

    public static void UpdateAdmin()
    {
        Console.WriteLine("COUNTER REACHED THRESHOLD VALUE . MANAGE CROWD !");
    }

    public static void UpdateCustomers()
    {
        Console.WriteLine("COUNTER IS OVERFLOWING PLEASE WAIT PATIENTLY FOR SOME TIME !");
    }
    public static void Main(String[] args)
    {
        //object for class Counter
        Counter counter = new(100);

        //multicast delegate 
        counter.CounterTrigger += UpdateDashboard;
        counter.CounterTrigger += UpdateAdmin;
        counter.CounterTrigger += UpdateCustomers;

        // Func<int,int,int,int,int> name = (a,b,c,d) => 

        for (int i = 0; i <= 1000; i++)
        {
            counter.Process();
        }
    }
}