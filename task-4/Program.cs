using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    private int _id;
    private string _name;

    private int _age;

    private int _grade;

    public int Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }

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
            if (value > 0)
            {
                _age = value;
            }
        }
    }

    public int Grade
    {
        get
        {
            return _grade;
        }
        set
        {
            if (value >= 0 && value <= 100)
            {
                _grade = value;
            }
        }
    }

    public Student(string para_1, int para_2, int para_3, int para_4)
    {
        Name = para_1;
        Age = para_2;
        Grade = para_3;
        Id = para_4;
    }
}


class Program
{
    public static void AddDetails(List<Student> students, string name, int age, int grade, int id)
    {
        var value = students.FirstOrDefault(s => s.Id == id);
        if (value == null)
        {
            students.Add(new Student(name, age, grade, id));
            Console.WriteLine("STUDENT DETAILS ADDED SUCCESSFULLY !");
        }
        else
        {
            Console.WriteLine("STUDENT ID ALREADY EXISTS ENTER UNIQUE ID !");
        }
    }

    public static void DeleteDetails(List<Student> students, int id)
    {
        var value = students.FirstOrDefault(s => s.Id == id);
        if (value != null)
        {
            students.Remove(value);
            Console.WriteLine("STUDENT DETAIL DELETED SUCCESSFULLY !");
        }
        else
        {
            Console.WriteLine("STUDENT WITH THIS ID NOT EXISTS!");
        }
    }

    public static void ShowDetails(List<Student> students)
    {
        if (students.Count > 0)
        {
            var result = students.Where(s => s.Grade >= 40).OrderBy(s => s.Grade);

            if (result.Any())
            {
                Console.WriteLine("THE BELOW ARE THE STUDENTS ABOVE 40 MARKS : ");
                int i = 1;
                foreach (var s in result)
                {
                    Console.WriteLine($"{i} - {s.Name} - {s.Age} - {s.Grade}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("NO STUDENTS SCORED ABOVE 40 MARKS");
            }
        }
        else
        {
            Console.WriteLine("NO DATA IS PRESENT ADD STUDENT DETAILS FIRST");
        }
    }
    public static void Main(String[] args)
    {
        try
        {
            List<Student> students = new List<Student>() { };



            string name;
            int id;
            int grade;
            int age;

            while (true)
            {
                Console.WriteLine("ENTER 1 FOR ADDING DETAILS ");
                Console.WriteLine("ENTER 2 FOR REMOVING DETAILS ");
                Console.WriteLine("ENTER 3 FOR DISPLAYING DETAILS ");
                Console.WriteLine("ENTER 0 FOR CLOSE ");
                Console.WriteLine();

                Console.Write("ENTER VALUE : ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (n == 1)
                {
                    Console.Write("ENTER THE STUDENT NAME : ");
                    name = Console.ReadLine().Trim();

                    Console.Write("ENTER THE STUDENT ID : ");
                    id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("ENTER THE STUDENT GRADE : ");
                    grade = Convert.ToInt32(Console.ReadLine());

                    Console.Write("ENTER THE STUDENT AGE : ");
                    age = Convert.ToInt32(Console.ReadLine());

                    AddDetails(students, name.ToUpper(), age, grade, id);
                    Console.WriteLine();
                }
                else if (n == 2)
                {
                    Console.Write("ENTER THE STUDENT ID : ");
                    id = Convert.ToInt32(Console.ReadLine());

                    DeleteDetails(students, id);
                    Console.WriteLine();
                }
                else if (n == 3)
                {
                    ShowDetails(students);
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