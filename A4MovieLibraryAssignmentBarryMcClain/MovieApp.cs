using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace A4MovieLibraryAssignmentBarryMcClain
{
    public class MovieApp
    {
        public List<string> movieList = new List<string>();
        public List<Movie> listOfMovieObjects = new List<Movie>();


        public MovieApp(){}
        
        public void AddMovie(String movieId, String title, String genres)
        {
            Movie newMovie = new Movie(movieId, title, genres);
            listOfMovieObjects.Add(newMovie);
            movieList.Add(newMovie.ToString());
        }

        public void displayList()
        {
            string controller = "";
            int movieCount = 0;

            while (controller != "q" && movieCount < movieList.Count)
            {
                List<string> output = movieList.GetRange(movieCount, 100);
                foreach( string movie in output )
                {
                    Console.WriteLine(movie);
                }
                Console.WriteLine($"To show next 100, press Enter. To quit, press q.");
                movieCount += 100;
                
                controller = Console.ReadLine().ToLower();
            }
            
        }


        public void NewMovie()
        {
            FileStream movieFile= new FileStream("Files/movies.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                  StreamReader sr = new StreamReader(movieFile);
                  string line = sr.ReadLine();  
                  //To get last ID
                    var lastLine = "";
                    while (sr.EndOfStream == false)
                    {
                        lastLine = sr.ReadLine();
                    }
                    var columnSplitForId = Regex.Split(lastLine, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");;
                    string movieId = columnSplitForId[0];
                    int nextMovieId = Convert.ToInt32(movieId) + 1;
                    
                    sr.Close();
                    movieFile.Close();

                    
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Enter Title: ");
                    string title = Console.ReadLine();
                    string titleFormat = title;
                    if (title.Contains(","))
                    {
                        titleFormat = $"\"{title}\"";
                    }
                    else
                    {
                        titleFormat = title;
                    }
                    
                    while (listOfMovieObjects.FirstOrDefault(o => o.title == titleFormat) != null)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine("Duplicate Movie. Enter Title: ");
                         title = Console.ReadLine();
                         titleFormat = title;
                        if (title.Contains(","))
                        {
                            titleFormat = $"\"{title}\"";
                        }
                        else
                        {
                            titleFormat = title;
                        }  
                    }
                    
                    string genreList = "";
                    string genre = "";
                    Console.WriteLine("Enter genre: ");
                    genreList = Console.ReadLine().ToLower();
                    genre = genre + genreList;

                    while (genreList != "done")
                    {
                        Console.WriteLine("Enter genre. Type done to quit: ");
                         genreList = Console.ReadLine().ToLower();
                         if (genreList != "done")
                         {
                             genre =  genre +"|"+ genreList;
                         }
                         else
                         {

                         }
                    }
                    
                    string newMovie = nextMovieId + "," + titleFormat + "," + genre;
                    
                    try
                    {
                        File.AppendAllText("Files/movies.csv",newMovie);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error with writing file");
                        throw;
                    }
                    //  FileStream file = new FileStream("Files/movies.csv", FileMode.Append, FileAccess.Write);
                   //
                   //  //write file
                   // StreamWriter sw = new StreamWriter(file);
                   //
                   // string newMovie = nextMovieId + "," + titleFormat + "," + genre;
                   //
                   //  
                   //
                   //  
                   //  sw.WriteLine(newMovie);
                   //  sw.Flush();
                   //  sw.Close();
                   //  file.Close();
        }
        
        
        
        
        
        
    }
}