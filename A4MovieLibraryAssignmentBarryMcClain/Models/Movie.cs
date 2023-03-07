using System;
using System.Collections.Generic;
using System.Threading.Channels;
using A4MovieLibraryAssignmentBarryMcClain;
using CsvHelper.Configuration.Attributes;

namespace A4MovieLibraryAssignmentBarryMcClain
{
    public class Movie : Media
    {
        

        public string [] genres { get; set; }

        public override void Display()
        {
            Console.WriteLine($"{Id}, {Title}, {string.Join("|",genres)}");
        }
        
        public override string ToString()
        {
            return $"{Id}, {Title}, {string.Join("|",genres)}";
        }


   
        
        
        
        
        
    }
}