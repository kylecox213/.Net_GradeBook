using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        //inside of the main method
                static void Main(string[] args)
        {
            // var x = 34.1;
            // var y = 10.3;
            // var result = x + y;
            // Console.WriteLine(result);

            //---------------------------------------------
            //-------no need to explicitly define the number of items within the array; nor the data type
            //-------utilize shortcut operator (+=)

            // var numbers = new double[3] { 12.7, 10.3, 6.11};
            // numbers[0] = 12.4;
            // numbers[1] = 98.6;
            // numbers[2] = 6.11;

            //---------------------------------------------
            // var result = numbers[0];
            // result += numbers[1];
            // result += numbers[2];
            // Console.WriteLine(result);


            // classes are in namespaces---ctrl+(.) on the red squiggly to add the necessary namespace for utilizing a list
            // list syntax requires <>------initialize grades with new

            // var numbers = new[] { 12.7, 10.3, 6.11, 4.1};
            
            List<double> grades = new List<double>() {12.7, 10.3, 6.11, 4.1};
            grades.Add(56.1);
            
            var result = 0.0;
            foreach(double number in grades)
            {
                result += number;
            }
            result /= grades.Count;
            Console.WriteLine(result);



            //interpolation
           // Console.WriteLine("Hello " + args[0] + "!");
           if(args.Length > 0)
           {
               // use a number formatting specifier inside of the brackets to format the average result
             Console.WriteLine($"The average grade is {result:N1}");
           }
           else
           {
               Console.WriteLine("What up, playa?!");
           }
        }
    }
}
