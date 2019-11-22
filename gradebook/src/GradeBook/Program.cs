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
            book.AddGrade(89.1);
            book.AddGrade(90.1);
            book.AddGrade(77.5);
            book.ShowStatistics();
        }
    }
}
