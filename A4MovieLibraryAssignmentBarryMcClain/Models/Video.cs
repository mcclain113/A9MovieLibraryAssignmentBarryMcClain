namespace A4MovieLibraryAssignmentBarryMcClain;

public class Video : Media
{
    /*public int Id { get; set; }
    public string Title { get; set; }*/
   public string format { get; set; }
    public int length { get; set; }
    public int[] regions { get; set; }
    
    public override void Display()
    {
        Console.WriteLine($"{Id}, {Title}, {format}, {length}, {string.Join("|",regions)}");
    }
    public override string ToString()
    {
        return $"{Id}, {Title}, {format}, {length}, {string.Join("|",regions)}";
    }
}