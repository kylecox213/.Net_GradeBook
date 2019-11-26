using System;
using System.Collections.Generic;

namespace GradeBook
{
    // add state to the class Book definition using a field definition
    // add the public acces modifier to the book class
    public class Book
    {
        // add a constructor parameter that will require a string name when invoking the new book constructor
        public Book(string name)
        {
            grades = new List<double>();
            // use the this variable to make the distinction between the field name on the left and the parameter on the right
            Name = name;
        }
        public void AddGrade(double grade)
        // declare a list of double named grades outside of the addGrade method to make a field instead of a local variable
        {
            grades.Add(grade);
        }
        // public method named GetStatistics with an object return type "Statistics"
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            // create a var result and set it to 0
            result.Average = 0.0;
            // create a variable for storing the maximum potential value 
            result.High = double.MinValue;
            // create a variable for storing the minimum potential value
            result.Low = double.MaxValue;
            // create a foreach loop to iterate through the grades array
            foreach (var grade in grades)
            {
                // add the total number of numbers within the array to the result variable

                // if(number > highGrade) {
                //     highGrade = number;
                // }

                // set the lowGrade and highGrade variables to the MathMin/Max method
                // pass in parameters grade and result.low/high
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            
            // use the Count property to total the number of grades
            // divide the total number of grades by the sum; which is stored in the result variable
            result.Average /= grades.Count;

            // write the the result to the console
            return result;
        }
        // add the private access modifer to render the grades field and name field 
        // best practices recommend separating the public accessible items from the private accessible items 
        private List<double> grades;
        public string Name;
    }
}