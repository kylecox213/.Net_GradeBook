using System;
using Xunit;

namespace GradeBook.Tests

// press f12 to navigate to a metaview that displays whether or not a data type is a value, or reference type,
// as well as displaying their shortcuts and commonly utilized their keywords, shortcuts, and parameters
{
    public delegate string WriteLogDelegate( string logMessage);

    public class TypeTests
    {
        // declare a private field to track the frequency of method invocation
        int count = 0;
        [Fact]
        // create a new type by defining a new delegate 
                // class=methods, properties, fields.....delegates define the return type, parameter --->
                // types and numbers of parameters that can be passed in to the method; method structure definition

        // define a delegate that permits the user to log messages
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;
            log += ReturnMessage;
            log += IncrementCount;
            
            var result = log("Error 909");
            Assert.Equal(3, Count);
            // invoking the log method will call ReturnMessage twice and IncrementCount once
        }

        string IncrementCount(string message)
            {
                // increment the method frequency tracker
                count++;
                //return the log message in lowercase 
                return message.ToLower();        
            }

        string returnMessage(string message)
            {
                // increment the method frequency tracker
                count++;
                //return the log message
                return message;        
            }


        [Fact]
        // test to demonstrate that strings are immutable; regardless of the modifcations to a string parameter;
        // the string is copied and no change can be made to the underlying string parameter
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Alex";
            var upper = MakeUppercase(name);

            Assert.Equal("Alex", name);
            Assert.Equal("ALEX", name);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        // remember! Set the data type if there is a value being returned
        private int GetInt()
        {
            return 3;
        }

        [Fact]
        // setting the variable to reference the book object to demonstrate a "pass by value"
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        // test to demonstrate the pass by reference capability; not a common practice but some API's demand it
        public void CSharpIsPassByRef()
        {
            var book1 = GetBook("Book 1");
            // GetBookSetName(ref book1, "New Name");
            GetBookSetName(out book1, "New Name");


            Assert.Equal("New Name", book1.Name);
        }
        // private void GetBookSetName(ref Book book, string name)

        // can use "out" instead of ref; requires a slightly different appraoch to referencing the object in the same fashion
        private void GetBookSetName(out Book book, string name)


        {
            book = new Book(name);
        }
        [Fact]
        // setting the variable to reference the book object to demonstrate a "pass by value"
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        private void GetBookSetName(Book book, string name)
        {
            // construct a new instance of book and setting the name by passing the name into the constructor
            book = new Book(name);
        }

        // fact attribute added by default when building unit tests
        [Fact]
        // function that accepts string parameters for new instances of book and tests assertions of equality/inequality
        public void GetBookReturnsDifferentObjects()
        {
            // series of variables that envoke the getbook method specfic to the book name
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            var book3 = GetBook("Book 3");
            var book4 = GetBook("Book 4");

            // series of assertion statements that test whether the book retreived is equal to the book variable
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.Equal("Book 3", book3.Name);
            Assert.Equal("Book 4", book4.Name);
            // assertion statement to test whether two string parameters are not equal

            // Assert.NotSame(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

        // This test demonstrates that two variables can reference the same object 
        // The assertion can validate whether or not the two variables are equal
        [Fact]

        // function for two variables set to reference the same object; one envokes the get book method, 
        // the other is set to equal the string name of the preceding variable; rendering the two variables equal
        public void TwoVarsCanReferenceSameObject()
        {
            // create a variable and set equal to getbook method; pass in string parameter
            var book1 = GetBook("Book 1");
            // create variables and set equal to the preceding book names; setting all books to equal the value of string passed into "book 1"
            var book2 = book1;
            var book3 = book2;
            var book4 = book3;

            // assert statement comparing the value stored in the two variables
            Assert.Same(book1, book2);

        }

        // create a method for book named getbook that takes a string parameter
        Book GetBook(string name)
        {
            // create new instance of book and return the string name passed into the book
            return new Book(name);
        }
    }
}
