using A4MovieLibraryAssignmentBarryMcClain.Dao;

namespace A4MovieLibraryAssignmentBarryMcClain;

public class MediaMenuGenerator : IMenuGenerator
{
    public void Menu(IRepository app)
    {

        char menuAnswer = 'a';

        while (menuAnswer != 'q')
        {

            app.Run();
            Console.WriteLine("Welcome to the Movie Library Menu");
            Console.WriteLine("1. Enter 1 to display movies by type");
           // Console.WriteLine("2. Add Movie to the File");
            Console.WriteLine(".........................................");
            Console.Write("Please Enter Menu Number (q for quit): ");
            

                    try
                    {
                        menuAnswer = Console.ReadLine().ToLower()[0];
                        if (menuAnswer == '1')
                        {
                            app.Get();
                        }

                        else if (menuAnswer == '2')
                        {
                            app.Exit();
                
                        }
                        else if (menuAnswer == 'q')
                        {
                            app.Exit();
                        }
                        else
                        {
                            Console.WriteLine("\n\n");
                            Console.WriteLine("Try again\n\n");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine($"Pick a valid key");
                        
                    }
                    
                    
        }
    }
    
}