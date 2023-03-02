using A4MovieLibraryAssignmentBarryMcClain.Dao;

namespace A4MovieLibraryAssignmentBarryMcClain.Services;

public class MainServices : IMainService
{
    private IRepository _repository;
    private IMenuGenerator _menuGenerator;
    public MainServices(IMenuGenerator menuGenerator, IRepository repository) 
    {
        _menuGenerator = menuGenerator;
        _repository = repository;
        
    }

    
    public void Invoke()
    {
        _menuGenerator.Menu(_repository); 
    }
}