using CsvHelper.Configuration.Attributes;

namespace A4MovieLibraryAssignmentBarryMcClain;

public class Show : Media
{
    /*public int Id { get; set; }
    public string Title { get; set; }*/
    
   public int Season { get; set; } 
   public int Episode { get; set; }
    public string[] Writers { get; set; }
    public override void Display()
    {
        Console.WriteLine($"{Id}, {Title}, {Season}, {Episode}, {string.Join("|",Writers)}");
    }
    
    public override string ToString()
    {
        return $"{Id}, {Title}, {Season}, {Episode}, {string.Join("|",Writers)}";
    }
    
}