using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject 
    {
        //create a base class for building other types (student class, school class, employee class)
        public NamedObject(string name)
        {
            // (Crtl + .) and create a contructor for the named object
            Name = name;
        }

        // create a property with the name Name
        public string Name
        {
            // create public getter and setter accessors for returning and setting property values
            get;
            set;
        }
    }

    // .net framework convention dictates that interface nomenclature begins with I
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    // add state to the class Book definition using a field definition
    // add the public acces modifier to the book class

    // add a semi colon followed by the name of the base class to allow for inheriting the getter and setter to the book class
    // public class Book : NamedObject

    public abstract class Book : NamedObject, IBook
    {
        // add a constructor parameter that will require a string name when invoking the new book constructor
        // include a semicolon, base, and paranthesis to access a contructor on the base class
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        // public method named GetStatistics with an object return type "Statistics"
        public abstract Statistics GetStatistics();
    }

        // create diskbook class that will implement the ibook interface
        public class DiskBook : Book
        {

        }
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {   
            // implement file class and appendtext method to open a txt file
            // utilizing $"{Name} is string interpolation to apply it to Book;
            // then returns an object and writes to the end of the file (append)
            using(var writer = File.AppendText($"{Name}.txt"))
            {                
                // pass a grade into the writer variable via the WriteLine method
                writer.WriteLine(grade);
                

                //if the gradeAdded is not null...
                if(GradeAdded != null)
                {
                    // add grade to DiskBook and create a new instance of event arguments 
                    GradeAdded(this, new EventArgs());
                }
                // ---** the using keyword is overloaded and will close files once the code block is complete
            }
        }

        // the get statistics method will read all of the grades that have been written into the DiskBook
        public override Statistics GetStatistics()
        {
            // implement getStatistics ans store in var result
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {            
            grades = new List<double>();
            Name = name;
        }
         
        public override void AddGrade(double grade)
        {            
            if(grade <= 100 && grade >= 0)
            {                
                grades.Add(grade);  
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
               throw new ArgumentException($"Invalid {nameof(grade)}");
            }            
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            
            for(var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);                            
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