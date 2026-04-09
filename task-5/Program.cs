//Requirements
//1. Application that reads and right files
//2. Implementation of Exception handling

using System;
using System.IO;

class Program
{
    public static void Main(String[] args)
    {
        try
        {
            //getting input from the user
            Console.Write("ENTER THE FILE NAME OR PATH (EX : demo.txt) : ");
            string? input_file = Console.ReadLine();

            //Edge case to check the input is not null
            if (string.IsNullOrWhiteSpace(input_file))
            {
                Console.Write("INVALID INPUT");
                return;
            }

            //Edge Case to handle file not found
            if (!File.Exists(input_file))
            {
                throw new FileNotFoundException($"{input_file} FILE DOESN'T EXISTS !");
            }
            else
            {
                string file_content = File.ReadAllText(input_file);
                string[] file_lines = File.ReadAllLines(input_file);
                string clean_text = file_content.Replace("\n", " ");
                int word_count = clean_text.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;

                //Edge case to handle file is empty
                if (file_content.Trim().Length == 0)
                {
                    Console.WriteLine("THE INPUT FILE IS EMPTY");
                    return;
                }

                //declaring output file and storing output file data  
                string output_file = "output_log.txt";
                string output = $"TOTAL NUMBER OF WORD : {word_count} \nTOTAL NUMBER OF CHARACTERS : {file_content.Length} \nTOTAL NUMBER OF Lines : {file_lines.Length}";

                //checking whether the output file exists already and writing the output data 
                bool output_file_status = File.Exists(output_file);
                File.WriteAllText(output_file, output);

                if (!output_file_status)
                {
                    Console.WriteLine("OUTPUT FILE IS CREATED AND ADDED DATA !");
                }
                else
                {
                    Console.WriteLine("OUTPUT FILE HAS BEEN MODIFIED !");
                }
            }
        }

        //catch block if the if the file not found
        catch (FileNotFoundException e)
        {
            Console.WriteLine("FILE NOT FOUND : "+e.Message);
        }

        //catch block if error happens while reading or writing
        catch (IOException e)
        {
            Console.WriteLine("IO EXCEPTION : "+e.Message);
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}