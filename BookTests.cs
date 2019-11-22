using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        // fact attribute added by default when building unit tests
        [Fact]
        public void Test1()
        {
            // the arrange section of a unit test: arrangement of test data objects and values
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // the act section of a unit test: where a computation of the test data objects is performed

            // var actual = x * y;
            var actual = x + y;

            // the assert section of a unit test: where assertions are made against the dta values that are to be computed
            Assert.Equal(expected, actual);
        }
    }
}
