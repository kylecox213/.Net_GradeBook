using System;

namespace GradeBook
{
    class Program
    {
        //inside of the main method
                static void Main(string[] args)
        {
            //interpolation
           // Console.WriteLine("Hello " + args[0] + "!");
           if(args.Length > 0)
           {
             Console.WriteLine($"Hello, {args[0]}!");
           }
           else
           {
               Console.WriteLine("What up, playa?!");
           }
        }
    }
}
