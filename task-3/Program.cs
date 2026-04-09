using System;
using System.Collections.Generic;

class Program
{
    public static void AddName(List<string> NameList, string name, int pos)
    {
        if (pos == 0)
        {
            NameList.Add(name);
            Console.WriteLine("NAME ADDED SUCCESSFULLY !");
        }

        else if (pos - 1 >= 0 && pos - 1 < NameList.Count)
        {
            NameList.Insert(pos - 1, name);
            Console.WriteLine($"NAME ADDED SUCCESSFULLY AT POSITION {pos}!");
        }

        else
        {
            Console.WriteLine("WE ARE FACING ISSUE IN ADDING TRY AGAIN LATER !");
        }
    }

    public static void DeleteName(List<string> NameList, string name)
    {
        if (NameList.Contains(name))
        {
            NameList.Remove(name);
            Console.WriteLine("NAME DELETED SUCCESSFULLY !");
        }
        else
        {
            Console.WriteLine("WE ARE FACING ISSUE IN DELETING TRY AGAIN LATER !");
        }
    }

    public static void DisplayName(List<string> NameList)
    {
        if (NameList.Count > 0)
        {
            Console.WriteLine("THE BELOW ARE THE AVAILABLE NAMES : ");
            for (int i = 0; i < NameList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {NameList[i]}");
            }
        }
        else
        {
            Console.WriteLine("NO NAMES AVAILABLE NOW !");
        }
    }

    public static void Main(String[] args)
    {
        try
        {
            List<string> NameList = new List<string>() { "ROHIT", "KHOLI", "DHONI" };

            Console.WriteLine("ENTER 1 FOR ADDING NAME ");
            Console.WriteLine("ENTER 2 FOR ADD NAME AT POSITION");
            Console.WriteLine("ENTER 3 FOR REMOVE NAME ");
            Console.WriteLine("ENTER 4 FOR DISPLAY NAME ");
            Console.WriteLine("ENTER 0 FOR CLOSE ");
            Console.WriteLine();

            string name = "";
            int pos = 0;

            while (true)
            {
                Console.Write("ENTER VALUE : ");
                int n = Convert.ToInt32(Console.ReadLine());

                if (n == 1)
                {
                    Console.Write("ENTER NAME TO BE ADDED : ");
                    name = Console.ReadLine().Trim();
                    pos = 0;

                    AddName(NameList, name.ToUpper(), pos);
                    Console.WriteLine();
                }
                else if (n == 2)
                {
                    Console.Write("ENTER NAME TO BE ADDED : ");
                    name = Console.ReadLine().Trim();

                    Console.Write($"ENTER POSITION ({1} to {NameList.Count}) : ");
                    pos = Convert.ToInt32(Console.ReadLine());

                    AddName(NameList, name.ToUpper(), pos);
                    Console.WriteLine();
                }
                else if (n == 3)
                {
                    Console.Write("ENTER NAME TO BE DELETED : ");
                    name = Console.ReadLine().Trim();

                    DeleteName(NameList, name.ToUpper());
                    Console.WriteLine();
                }
                else if (n == 4)
                {
                    DisplayName(NameList);
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
            }
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
