using A4MovieLibraryAssignmentBarryMcClain.Dao;
using A4MovieLibraryAssignmentBarryMcClain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace A4MovieLibraryAssignmentBarryMcClain;

public class Startup
{
    public ServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();
        //services.AddSingleton<>();
        services.AddSingleton<IMainService, MainServices>();
        services.AddSingleton<IRepository, MovieRepositoryJson>();
        //services.AddSingleton<IRepository, MovieRepositoryCsv>();
        services.AddSingleton<IMenuGenerator,MovieMenuGenerator >();
        return services.BuildServiceProvider();
    }
}