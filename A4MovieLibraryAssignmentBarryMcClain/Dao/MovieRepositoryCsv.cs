using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using A4MovieLibraryAssignmentBarryMcClain.Dao;
using CsvHelper;
using CsvHelper.Configuration;

namespace A4MovieLibraryAssignmentBarryMcClain
{
    public class MovieRepositoryCsv : IRepository
    {

        

        public void Exit()
        {
            Console.WriteLine($"Good-Bye!");
        }





        public List<string> movieList = new List<string>();
        public List<Movie> listOfMovieObjects = new List<Movie>();

        public void Run()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            using (var streamReader = new StreamReader("Files/movies.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, config))
                {
                    listOfMovieObjects = csvReader.GetRecords<Movie>().ToList();
                    streamReader.Close();
                }
            }
        }
        

        public void AddMovie(String movieId, String title, String genres)
        {
            Movie newMovie = new Movie(movieId, title, genres);
            listOfMovieObjects.Add(newMovie);
            movieList.Add(newMovie.ToString());
        }

        public void Get()
        {
            string controller = "";
            int movieCount = 0;
            int count = 100;

            while (controller != "q" && movieCount < listOfMovieObjects.Count-count)
            {
                List<Movie> output = listOfMovieObjects.GetRange(movieCount, count);
                foreach (Movie movie in output)
                {
                    Console.WriteLine(movie);
                }

                Console.WriteLine($"To show next 100, press Enter. To quit, press q.");
                movieCount += 100;

                controller = Console.ReadLine().ToLower();
            }

            if (listOfMovieObjects.Count-movieCount < count)
            {
                List<Movie> lastoutput = listOfMovieObjects.GetRange(movieCount, listOfMovieObjects.Count-movieCount);
                foreach (Movie movie in lastoutput)
                {
                    Console.WriteLine(movie);
                }
                Console.WriteLine($"End of List");
            }
            
        }


        public void Add()
        {
            FileStream movieFile = new FileStream("Files/movies.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(movieFile);
            string line = sr.ReadLine();
            //To get last ID
            var lastLine = "";
            while (sr.EndOfStream == false)
            {
                lastLine = sr.ReadLine();
            }

            var columnSplitForId = Regex.Split(lastLine, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            ;
            string movieId = columnSplitForId[0];
            int nextMovieId = Convert.ToInt32(movieId) + 1;
            string nextMovieIdString = nextMovieId.ToString();

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
                    genre = genre + "|" + genreList;
                }
                else
                {

                }
            }

            string newMovie = nextMovieId + "," + titleFormat + "," + genre;
            AddMovie(nextMovieIdString, titleFormat, genre);
            /*Movie writeMovie = new Movie( nextMovieIdString,  titleFormat, genre);
            var writeMovieList = new List<Movie>();
            writeMovieList.Add(writeMovie);*/
            string path = "Files/movies.csv";
            StreamWriter sw = File.AppendText(path);
            try
            {

                using (sw)
                {
                    sw.WriteLine(newMovie);

                }

                /*using (var writer = new StreamWriter("Files/movies.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(writeMovieList);
                    
                }*/

                /*FileStream file = new FileStream("Files/movies.csv", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);
           
                newMovie = nextMovieId + "," + titleFormat + "," + genre;q

*/


            }
            catch (Exception e)
            {
                Console.WriteLine("Error with writing file");
                throw;
            }
            finally
            {
                sw.Flush();
                sw.Close();
                //file.Close();
            }

            Console.WriteLine($"New Movie Add: {newMovie}");



        }


    }
}