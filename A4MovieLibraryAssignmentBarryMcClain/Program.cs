using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace A4MovieLibraryAssignmentBarryMcClain
{
    class Program
    {

        
        static void Main(string[] args)
        {
            MenuGenerator();

            IServiceCollection serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection
                .AddLogging(x=>x.AddConsole())
                .BuildServiceProvider();
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            
            logger.Log(LogLevel.Information, ":)");
            

            
        }
        
        public static void MenuGenerator()
        {

            char menuAnswer = 'a';

            while (menuAnswer != 'q')
            {
                
                Console.WriteLine("Welcome to the Movie Library Menu");
                Console.WriteLine("1. List All Movies in the File");
                Console.WriteLine("2. Add Movie to the File");
                Console.WriteLine(".........................................");
                Console.Write("Please Enter Menu Number (q for quit): ");
                menuAnswer = Console.ReadLine().ToLower()[0];

                if (menuAnswer == '1')
                {
                    ReadMovieFile();
                }

                else if (menuAnswer == '2')
                {
                    NewMovie();
                }
                else if (menuAnswer == 'q')
                {
                    Exit();
                }
                else
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Try again\n\n");
                }
                    
            }
        }

        public static void ReadMovieFile()
        {
            MovieApp movieapp = new MovieApp();
              //C:/Users/051686/RiderProjects/A4MovieLibraryAssignmentBarryMcClain/A4MovieLibraryAssignmentBarryMcClain/Files/movies.csv"
            string fs = "Files/movies.csv";
            if (true)
                //(File.Exists(fs))
            {
                FileStream file = new FileStream("Files/movies.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(file);
                string line = sr.ReadLine();
                line.Split(',');
                
                while (!sr.EndOfStream)

                {
                    line = sr.ReadLine();
                    var column = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    //var column = line.Split(',');

                    movieapp.AddMovie(column[0],column[1],column[2]);
                  
                }

                      
                sr.Close();
                file.Close();
                
                
                movieapp.displayList();
            }
            else
            {
                Console.WriteLine("No List.");
            }

            
        }
        
        public static void NewMovie()
        {
            MovieApp movieapp = new MovieApp();
            string fs =
                "Files/movies.csv";
            if (true)
                //(File.Exists(fs))
            {
                FileStream file = new FileStream("Files/movies.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(file);
                string line = sr.ReadLine();
                line.Split(',');
                
                while (!sr.EndOfStream)

                {
                    line = sr.ReadLine();
                    var column = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    //var column = line.Split(',');

                    movieapp.AddMovie(column[0],column[1],column[2]);
                  
                }

                      
                sr.Close();
                file.Close();
            }
            else
            {
                Console.WriteLine("No List.");
            }

            movieapp.NewMovie();
        }
        public static void Exit()
        {
            
        }
        
    }
}   