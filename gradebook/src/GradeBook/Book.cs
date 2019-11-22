using System;
using System.Collections.Generic;

namespace GradeBook
{
    // add state to the class Book definition using a field definition
    class Book
    {
        // add a constructor parameter that will require a string name when invoking the new book constructor
        public Book(string name)
        {
            grades = new List<double>();
            // use the this variable to make the distinction between the field name on the left and the parameter on the right
            this.name = name;
        }
        public void AddGrade(double grade)
        // declare a list of double named grades outside of the addGrade method to make a field instead of a local variable
        {
            grades.Add(grade);
        }
        public void ShowStatistics()
        {
            // create a var result and set it to 0
            var result = 0.0;
            // create a variable for storing the maximum potential value 
            var highGrade = double.MinValue;
            // create a variable for storing the minimum potential value
            var lowGrade = double.MaxValue;
            // create a foreach loop to iterate through the grades array
            foreach (var number in grades)
            {
                // add the total number of numbers within the array to the result variable

                // if(number > highGrade) {
                //     highGrade = number;
                // }

                // set the lowGrade and highGrade variables to the MathMin/Max method
                // pass in parameters number and lowgrade/highGrade
                lowGrade = Math.Min(number, lowGrade);
                highGrade = Math.Max(number, highGrade);
                result += number;
            }
            // use the Count property to total the number of grades
            // divide the total number of grades by the sum; which is stored in the result variable
            result /= grades.Count;
            // write the the result to the console
            Console.WriteLine($"The lowest grade is {lowGrade}");
            Console.WriteLine($"The highest grade is {highGrade}");
            Console.WriteLine($"The average grade is {result:N1}");
        }
        // add the private access modifer to render the grades field and name field 
        // best practices recommend separating the public accessible items from the private accessible items 
        private List<double> grades;
        private string name;
    }
}