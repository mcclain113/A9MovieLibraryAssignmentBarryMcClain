namespace A4MovieLibraryAssignmentBarryMcClain.Dao;

public class Context
{
    public List<Movie> listOfMovieObjects { get; set; }
    public List<Show> listOfShowObjects { get; set; }
    public List<Video> listOfVideoObjects { get; set; }

    public Context()
    {
    listOfMovieObjects = new List<Movie>();
    listOfMovieObjects.Add(new Movie() {Id = 0, Title = "Mission Impossible", genres = new[] {"Action", "Adventure"}});
    listOfMovieObjects.Add(new Movie() {Id = 1, Title = "Toy Story (1995)", genres = new[] {"Action", "Horror"}});
    listOfMovieObjects.Add(new Movie() {Id = 2, Title = "Jumanji (1995)", genres = new[] {"Adventure", "Children"}});
    listOfMovieObjects.Add(new Movie() {Id = 3, Title = "Grumpier Old Men (1995)", genres = new[] {"Comedy", "Romance"}});
    listOfMovieObjects.Add(new Movie() {Id = 4, Title = "Waiting to Exhale (1995)", genres = new[] {"Comedy", "Fantasy", "Drama"}});
    listOfMovieObjects.Add(new Movie() {Id = 5, Title = "Father of the Bride Part II (1995)", genres = new[] {"Comedy"}});
    
    listOfVideoObjects = new List<Video>();
    listOfVideoObjects.Add(new Video() { Id= 0, Title = "Coding",format = "YouTube, DVD, BluRay",length = 30,regions =new[] {0,1}});
    listOfVideoObjects.Add(new Video() {Id = 1, Title = "Lethal Weapon 2",format = "VHS, DVD, BluRay",length = 100,regions =new[] {0,2}  });
    listOfVideoObjects.Add(new Video() {Id = 2, Title = "Lethal Weapon 3",format = "VHS, DVD, BluRay",length = 123,regions =new[] {0,2}});
    
    listOfShowObjects = new List<Show>();
    listOfShowObjects.Add(new Show() { Id= 0, Title = "Law & Order", Season = 5,Episode = 35,Writers = new[] {"Wolf"}});
    listOfShowObjects.Add(new Show() {Id = 1, Title = "Supernatural", Season = 2,Episode = 12,Writers = new[] {"Kripke"} });
    
    }
}