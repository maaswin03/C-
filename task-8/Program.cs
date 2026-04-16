//requirements
//1. application that demonstrate repository with student entity

//interface for Repository
interface IRepository<T>
{
    void Add(T item);
    void Delete(T item);
    List<T> Get();

    void Update(T item);
}

//interface for class and acts as constraint
interface IStructure
{
    public int Id { get; set; }
}

//class for doing crud operations
class Repository<T> : IRepository<T> where T : IStructure
{
    readonly List<T> storage = [];

    public void Add(T item)
    {
        //TODO - using database for adding data
        try
        {
            if (!storage.Any(x => x.Id == item.Id))
            {
                storage.Add(item);
                Console.WriteLine("DETAILS ADDED SUCCESSFULLY!");
            }
            else
            {
                Console.WriteLine("DETAILS ALREADY EXISTS");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Delete(T item)
    {
        //TODO - using database for deleting data
        try
        {
            if (storage.Any(x => x.Id == item.Id))
            {
                storage.Remove(storage.Find(x => x.Id == item.Id));
                Console.WriteLine("DETAILS DELETED SUCCESSFULLY!");
            }
            else
            {
                Console.WriteLine("DETAILS DOESN'T EXISTS");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    public List<T> Get()
    {
        //TODO - using database for getting data
        try
        {
            return [.. storage];
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return [];
        }
    }


    public void Update(T item)
    {
        //TODO - using database for updating data
        try
        {
            int index = storage.FindIndex(x => x.Id == item.Id);
            if (index != -1)
            {
                storage[index] = item;
                Console.WriteLine("DETAILS UPDATED SUCCESSFULLY");
            }
            else
            {
                Console.WriteLine("DETAILS WITH THE MENTIONED ID NOT EXISTS ");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

}

//student entity to get and set value
class Student : IStructure
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int Age { get; set; }
}


class Program
{
    public static void Main(String[] args)
    {

        try
        {
            Repository<Student> obj = new();
            string Name = "";
            int Id;
            int Age;

            while (true)
            {
                Console.WriteLine("ENTER 1 FOR ADDING DETAILS ");
                Console.WriteLine("ENTER 2 FOR REMOVING DETAILS ");
                Console.WriteLine("ENTER 3 UPDATING DETAILS ");
                Console.WriteLine("ENTER 4 DISPLAYING ALL DETAILS ");
                Console.WriteLine("ENTER 0 FOR CLOSE ");
                Console.WriteLine();

                Console.Write("ENTER VALUE : ");
                int n = Convert.ToInt32(Console.ReadLine());

                //condition for adding data
                if (n == 1)
                {
                    Console.Write("ENTER NAME TO BE ADDED : ");
                    Name = Console.ReadLine().Trim();

                    Console.Write("ENTER ID TO BE ADDED (UNIQUE) : ");
                    Id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("ENTER AGE TO BE ADDED : ");
                    Age = Convert.ToInt32(Console.ReadLine());

                    obj.Add(new Student
                    {
                        Id = Id,
                        Name = Name,
                        Age = Age
                    });
                    Console.WriteLine();
                }
                //condition for deleting details
                else if (n == 2)
                {
                    Console.Write("ENTER ID TO BE DELETED : ");
                    Id = Convert.ToInt32(Console.ReadLine());

                    obj.Delete(new Student
                    {
                        Id = Id
                    });
                    Console.WriteLine();
                }
                //condition for updating details
                else if (n == 3)
                {
                    Console.Write("ENTER ID OF EXISTING DETAILS : ");
                    Id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("ENTER UPDATED NAME : ");
                    Name = Console.ReadLine().Trim();

                    Console.Write("ENTER UPDATED AGE : ");
                    Age = Convert.ToInt32(Console.ReadLine());

                    obj.Update(new Student
                    {
                        Id = Id,
                        Name = Name,
                        Age = Age
                    });
                    Console.WriteLine();
                }
                //condition for displaying details
                else if (n == 4)
                {
                    var result = obj.Get();
                    if (result.Count > 0)
                    {
                        Console.WriteLine("THE BELOW ARE THE DETAILS OF EXISTING STUDENTS : ");
                        foreach (var r in result)
                        {
                            Console.WriteLine($"{r.Id} - {r.Name} - {r.Age}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO DATA PRESENT IN DATABASE");
                    }
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}