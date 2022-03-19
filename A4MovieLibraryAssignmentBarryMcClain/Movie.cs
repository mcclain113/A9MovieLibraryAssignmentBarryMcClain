using System;
using System.Collections.Generic;
using A4MovieLibraryAssignmentBarryMcClain;

namespace A4MovieLibraryAssignmentBarryMcClain
{
    public class Movie
    {

        private string movieId;

        public string title; 


        private string genres;


        public Movie(string x, string y, string z)
        {
            movieId = x;
            title = y;
            genres = z;
        }

        public override string ToString()
        {
            return $"{movieId}, {title}, {genres}";
        }

   
        
        
        
        
        
    }
}