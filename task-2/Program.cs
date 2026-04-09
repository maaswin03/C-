using System;
class Person
{
    private string _category;
    private int _age;
    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value.Length > 0)
            {
                _name = value;
            }
        }
    }

    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            if (value > 0 && value <= 16)
            {
                _category = "Child";
                _age = value;
            }
            else if (value > 16 && value <= 27)
            {
                _category = "Adult";
                _age = value;
            }
            else if (value > 27)
            {
                _category = "Senior";
                _age = value;
            }
        }
    }

    public Person(string name_value, int age_value)
    {
        Name = name_value;
        Age = age_value;
    }

    public void Introduce()
    {
        if (_category == "Child")
        {
            Console.WriteLine($"Hey {_name}! Keep smiling and enjoy every moment of your amazing childhood!");
        }
        else if (_category == "Adult")
        {
            Console.WriteLine($"Hello {_name}! Wishing you success, happiness, and a fantastic year ahead!");
        }
        else
        {
            Console.WriteLine($"Respected {_name}, wishing you good health, happiness, and peace always.");

        }

    }
}

class Program
{
    public static void Main(String[] args)
    {
        Person person1 = new("Rohit", 8);
        Person person2 = new("Kholi", 27);
        Person person3 = new("Dhoni", 43);

        person1.Introduce();
        person2.Introduce();
        person3.Introduce();
    }
}