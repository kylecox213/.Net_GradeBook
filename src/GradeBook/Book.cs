using System;
using System.Collections.Generic;

namespace GradeBook

{   // define a delegate for adding grades that takes object sender and event arguments parameters 
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    //create a base class for building other types (student class, school class, employee class)
    public class NamedObject
    {
        // (Crtl + .) and create a contructor for the named object
        public NamedObject(string name)
        {
            Name = name;
        }

        // create a propery with the name Name
        public string Name
        {
            // create public getters and setters that will allow users to set a name
            get;
            set;
        }
    }

    // add state to the class Book definition using a field definition
    // add the public acces modifier to the book class

    // add a semi colon followed by the name of the base class to allow for inheriting the getter and setter to the book class
    // public class Book : NamedObject

    public class Book : NamedObject

    {
        // add a constructor parameter that will require a string name when invoking the new book constructor
        // add a semicolon, base, and paranthesis to access a contructor on the base class
        public Book(string name) : base("")
        {
            grades = new List<double>();
            // use the this variable to make the distinction between the field name on the left and the parameter on the right
            Name = name;
        }

        // create a method that takes a char and letter parameter
        public void AddLetterGrade (char letter)
        {
            // create a switch case statement that assigns a letter grade relative to the grade score
            switch(letter)
                {
                    case 'A':
                        AddGrade(90);
                        break;

                    case 'B':
                        AddGrade(80);
                        break;

                    case 'C':
                        AddGrade(70);
                        break;

                    case 'D':
                        AddGrade(60);
                        break;

                    default:
                        AddGrade(0);
                        break;

                }
        }
        public void AddGrade(double grade)
        // declare a list of double named grades outside of the addGrade method to make a field instead of a local variable
        {
            if(grade <= 100 && grade >= 0)
                {   // add the grades to this instance of gradebook
                    grades.Add(grade);
                    // if the grade added is not null...
                    if(GradeAdded != null)
                    {
                        // call the event listener to announce a grade has been added 
                        GradeAdded(this, new EventArgs());
                    }
                }
                else
                {
                    // throw an error indicating an invalid....
                    throw new ArgumentException($"Invalid {nameof(grade)}");
                }
        }

        // define a delegate for an event for publishing a grade; the event will be considered a member of the field type GradeAddedDelegate
        public event GradeAddedDelegate GradeAdded;

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
            for (var i = 0; i < grades.Count; i++)
            {
                if(grades[i] == 42.1)
                    {
                        break;
                    }
            
                result.Low = Math.Min(grades[i], result.Low);
                result.High = Math.Max(grades[i], result.High);
                result.Average += grades[i];
            };
     
            // use the Count property to total the number of grades
            // divide the total number of grades by the sum; which is stored in the result variable
            
            switch(result.Average)
                {
                  case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                  case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                  case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                  case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                  default:
                    result.Letter = 'F';
                    break;
                }
            // write the the result to the console
            // done:
            return result;
        }
        // add the private access modifer to render the grades field and name field 
        // best practices recommend separating the public accessible items from the private accessible items 
        private List<double> grades;

        public const string CATEGORY = "Science";
    }
}