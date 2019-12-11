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
            // create public getters and setters that will allow users to set a name
            get;
            set;
        }
    }

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

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {                
                writer.WriteLine(grade);

                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
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