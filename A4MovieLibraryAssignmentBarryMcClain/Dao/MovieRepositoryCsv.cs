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

        Context context = new Context();

        public void Exit()
        {
            Console.WriteLine($"Good-Bye!");
        }







        public void Run()
        {

            
            
            StreamWriter sw = new StreamWriter("Files/movies.csv", true);
            foreach (Movie movie in context.listOfMovieObjects)
            {
                sw.WriteLine(movie.ToString());
            }
            sw.Close();
            sw = new StreamWriter("Files/shows.csv", true);
            foreach (Show show in context.listOfShowObjects)
            {
                sw.WriteLine(show.ToString());
            }
            sw.Close();   
            
            sw = new StreamWriter("Files/videos.csv", true);
            foreach (Video video in context.listOfVideoObjects)
            {
                sw.WriteLine(video.ToString());
            }
            sw.Close();
            
            
            
            /*var config = new CsvConfiguration(CultureInfo.InvariantCulture)
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
            }*/
        }
        

        public void AddMovie(int movieId, string title, string[] genres)
        {
            //Movie newMovie = new Movie(movieId, title, genres);
            //listOfMovieObjects.Add(newMovie);
            //movieList.Add(newMovie.ToString());
        }

        public void Get()
        {
            string controller = "";
            int mediaCount = 0;
            int count = 100;

            List<Media> media = new List<Media>();

            Console.WriteLine("Enter what title are you searching for");
            var searchString = Console.ReadLine();
            List<Movie> movies = context.listOfMovieObjects.Where(movie =>
                movie.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            List<Show> shows = context.listOfShowObjects
                .Where(show => show.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            List<Video> videos = context.listOfVideoObjects.Where(video =>
                video.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
 
            media.AddRange(movies);
            media.AddRange(shows);
            media.AddRange(videos);
            
            while (controller != "q" && mediaCount < media.Count-count)
            {
                List<Media> output = media.GetRange(mediaCount, count);
                foreach (Media mediaItem in output)
                {
                    Console.WriteLine($"Your {mediaItem.GetType().Name}: {mediaItem.Title}");
                }

                Console.WriteLine($"To show next 100, press Enter. To quit, press q.");
                mediaCount += 100;

                controller = Console.ReadLine().ToLower();
            }

            if (media.Count-mediaCount < count)
            {
                List<Media> lastoutput = media.GetRange(mediaCount, media.Count-mediaCount);
                foreach (var mediaItem in lastoutput)
                {

                    Console.WriteLine($"Your {mediaItem.GetType().Name}: {mediaItem.Title}");

                }
                Console.WriteLine($"End of List(s)");
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

            while (context.listOfMovieObjects.FirstOrDefault(o => o.Title == titleFormat) != null)
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
            //AddMovie(nextMovieIdString, titleFormat, genre);
            /*Movie writeMovie = new Movie( nextMovieIdString,  titleFormat, genre);
            var writeMovieList = new List<Movie>();
            writeMovieList.Add(writeMovie);*/
            /*string path = "Files/movies.csv";
            StreamWriter sw = File.AppendText(path);*/
            try
            {

                StreamWriter sw = new StreamWriter("Files/movies.csv", true);
                newMovie = nextMovieId + "," + titleFormat + "," + genre;
                sw.WriteLine(newMovie);
                sw.Close();
                        
            }
            catch (Exception e)
            {
                Console.WriteLine("Error with writing file");
                throw;
            }

            Console.WriteLine($"New Movie Add: {newMovie}");



        }


    }
}