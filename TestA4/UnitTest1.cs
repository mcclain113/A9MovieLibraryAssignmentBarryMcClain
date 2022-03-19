using System;
using A4MovieLibraryAssignmentBarryMcClain;
using Xunit;

namespace TestA4
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            MovieApp movieApp = new MovieApp();
            movieApp.AddMovie("test","hi","test");
            Assert.Contains(movieApp.listOfMovieObjects,movie =>movie.title == "hi");

        }
        [Fact]
        public void FailingTest()
        {
            MovieApp movieApp = new MovieApp();
            movieApp.AddMovie("test","hi","test");
            Assert.Contains(movieApp.listOfMovieObjects,movie =>movie.title != "no");

        }
    }
}