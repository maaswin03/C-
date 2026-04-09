using System;

namespace Program
{
    class Factorial
    {
        //
        public static int isfactorial(int num)
        {
            if(num < 0)
            {
                return num;
            }
            if (num == 0)
            {
                return 1;
            }
            return num * isfactorial(num - 1);
        }
        public static void Main(String[] args)
        {
            try
            {
                Console.Write("ENTER THE NUMBER : ");
                int num = Convert.ToInt32(Console.ReadLine());
                int output = isfactorial(num);
                Console.WriteLine($"THE FACTORIAL OF THE GIVEN NUMBER {num} IS {output}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}