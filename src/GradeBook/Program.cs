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
            

            // subscribe to the event listener
            book.GradeAdded += OnGradeAdded; 

            
            while (true)
            {
                Console.WriteLine ("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    Console.WriteLine("**");
                }
            }

            var stats = book.GetStatistics();
            book.Name = "";

            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        // invoke a static method for handling the gradeAdded event to be invoked
        // when the book class raises the event; grade added to the gradebook

        // -----**static methods can only be touched by other members that are static**-----
        // -----**per the delegate signature, it must be void and contain the name and parameters in order to subscribe to the event
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }   
}

//----------------------------------------***** Pillars of OOP *****------------------------------------------

// encapsulation - allows to hide details about code via methods, properties and access modifiers 
// inheritance - reusable code across similar classes
// polymorphism - allows for having objects of the same type yet behave differently

