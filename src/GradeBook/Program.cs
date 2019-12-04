using System;
using System.Collections.Generic;

// using the namespace GradeBook isn't necessary but is recommended to avoid conflict if other
// programmers utilize the Program class within the global namespace (microsoft class libraries)
namespace GradeBook
{


    class Program
    {
        static void Main(string[] args)
        {
            //create a new instance of book and pass in a string name parameter
            var book = new Book("Jimmy's Book");
            // pass in grades using the addGrade method and call the showStats method defined in the book.cs file
            
            
            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if(input =="q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }

                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
