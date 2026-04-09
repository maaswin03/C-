// class Box<T> where T : class
// {
//     private T? _storage;

//     public T? GetValue()
//     {
//         return _storage;
//     }

//     public void SetValue(T value)
//     {
//         _storage = value;
//     }

//     public bool IsEmpty()
//     {
//         return _storage == null;
//     }
// }

// class Program
// {
//     public static void Main(String[] args)
//     {
//         Box<string> b1 = new();

//         Console.WriteLine(b1.IsEmpty());
//         b1.SetValue("hello");
//         Console.WriteLine(b1.GetValue());
//         Console.WriteLine(b1.IsEmpty());
//     }
// }

// class Pair<T> where T : IComparable<T>
// {
//     private T _variable1;
//     private T _variable2;

//     public Pair(T a, T b)
//     {
//         _variable1 = a;
//         _variable2 = b;
//     }

//     public void Print()
//     {
//         Console.WriteLine($"VALUES ARE {_variable1} and {_variable2}");
//     }

//     public T GetMax()
//     {
//         if((_variable1).CompareTo(_variable2) > 0)
//         {
//             return _variable1;
//         }
//         return _variable2;
//     }

//     public bool IsEqual()
//     {
//         return (_variable1).CompareTo(_variable2) == 0;
//     }

// }

// class Program
// {
//     public static void Main(String[] args)
//     {
//         Pair<int> p1 = new Pair<int>(10, 20);

//         p1.Print();
//         Console.WriteLine(p1.GetMax());
//         Console.WriteLine(p1.IsEqual());
//     }
// }

// class Mystack<T>
// {
//     readonly Stack<T> storage = new();

//     public void Push(T item)
//     {
//         storage.Push(item);
//     }

//     public T Peek()
//     {
//         return storage.Peek();
//     }

//     public T Pop()
//     {
//         return storage.Pop();
//     }

//     public bool IsEmpty()
//     {
//         return storage.Count == 0;
//     }
// }

// class Program
// {
//     public static void Main(String[] args)
//     {
//         Mystack<int> stack = new Mystack<int>();

//         stack.Push(10);
//         stack.Push(20);

//         Console.WriteLine(stack.Peek());
//         Console.WriteLine(stack.Pop());
//     }
// }


class Filter<T>
{
    List<T> storage = new List<T> { };

    public void Add(T item)
    {
        storage.Add(item);
    }

    public List<T> GetAll()
    {
        return storage;
    }

    public List<T> FilterAll(Predicate<T> condition)
    {
        return storage.FindAll(condition);
    }

    public T Find(Predicate<T> condition)
    {
        return storage.Find(condition);
    }

}

class Program
{
    public static void Main()
    {
        Filter<int> f = new Filter<int>();

        f.Add(10);
        f.Add(20);
        f.Add(30);

        var result = f.FilterAll(x => x > 20);

        foreach (var r in result)
        {
            Console.WriteLine(r);
        }
    }
}