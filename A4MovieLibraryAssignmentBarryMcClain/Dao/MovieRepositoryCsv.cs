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





        //public List<string> movieList = new List<string>();
        public List<Movie> listOfMovieObjects = new List<Movie>();
        public List<Video> listOfVideoObjects = new List<Video>();
        public List<Show> listOfShowObjects = new List<Show>();

        public void Run()
        {

            listOfMovieObjects.Add(new Movie() {Id = 0, Title = "Mission Impossible", genres = new[] {"Action", "Adventure"}});
            listOfMovieObjects.Add(new Movie() {Id = 1, Title = "Toy Story (1995)", genres = new[] {"Action", "Horror"}});
            listOfMovieObjects.Add(new Movie() {Id = 2, Title = "Jumanji (1995)", genres = new[] {"Adventure", "Children"}});
            listOfMovieObjects.Add(new Movie() {Id = 3, Title = "Grumpier Old Men (1995)", genres = new[] {"Comedy", "Romance"}});
            listOfMovieObjects.Add(new Movie() {Id = 4, Title = "Waiting to Exhale (1995)", genres = new[] {"Comedy", "Fantasy", "Drama"}});
            listOfMovieObjects.Add(new Movie() {Id = 5, Title = "Father of the Bride Part II (1995)", genres = new[] {"Comedy"}});
        
            
            listOfShowObjects.Add(new Show() { Id= 0, Title = "Law & Order", Season = 5,Episode = 35,Writers = new[] {"Wolf"}});
            listOfShowObjects.Add(new Show() {Id = 1, Title = "Supernatural", Season = 2,Episode = 12,Writers = new[] {"Kripke"} });

            listOfVideoObjects.Add(new Video() { Id= 0, Title = "Coding",format = "YouTube, DVD, BluRay",length = 30,regions =new[] {0,1}});
            listOfVideoObjects.Add(new Video() {Id = 1, Title = "Lethal Weapon 2",format = "VHS, DVD, BluRay",length = 100,regions =new[] {0,2}  });
            listOfVideoObjects.Add(new Video() {Id = 2, Title = "Lethal Weapon 3",format = "VHS, DVD, BluRay",length = 123,regions =new[] {0,2}});
            
            StreamWriter sw = new StreamWriter("Files/movies.csv", true);
            foreach (Movie movie in listOfMovieObjects)
            {
                sw.WriteLine(movie.ToString());
            }
            sw.Close();
            sw = new StreamWriter("Files/shows.csv", true);
            foreach (Show show in listOfShowObjects)
            {
                sw.WriteLine(show.ToString());
            }
            sw.Close();   
            
            sw = new StreamWriter("Files/videos.csv", true);
            foreach (Video video in listOfVideoObjects)
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


            char addMovie = 'a';
            char addShow = 'a';
            var addVideo = 'a';
            
            Console.WriteLine("Answer the Following prompts for media display");
            Console.WriteLine("Please enter y if you want to include movies");
            Console.WriteLine("Otherwise enter n to skip");
            try
            {
                addMovie = Console.ReadLine().ToLower()[0];
                if (addMovie == 'y')
                {
                    media.AddRange(listOfMovieObjects);
                }

            }
            catch (Exception e)
            {
               
            }

            
        
            Console.WriteLine("Please enter y if you want to include shows");
            Console.WriteLine("Otherwise enter n to skip");
            try
            {
                addShow = Console.ReadLine().ToLower()[0];
                if (addShow == 'y')
                {
                    media.AddRange(listOfShowObjects);
                }
            }
            catch (Exception e)
            {
                
            }

            
      
            Console.WriteLine("Please enter y if you want to include videos");
            Console.WriteLine("Otherwise enter n to skip");
            try
            {
                addVideo = Console.ReadLine().ToLower()[0];
                if (addVideo == 'y')
                {
                    media.AddRange(listOfVideoObjects);
                }
            }
            catch (Exception e)
            {
                
            }
 
            
            
            while (controller != "q" && mediaCount < media.Count-count)
            {
                List<Media> output = media.GetRange(mediaCount, count);
                foreach (Media mediaItem in output)
                {
                    Console.WriteLine(mediaItem);
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

                    mediaItem.Display();

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

            while (listOfMovieObjects.FirstOrDefault(o => o.Title == titleFormat) != null)
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