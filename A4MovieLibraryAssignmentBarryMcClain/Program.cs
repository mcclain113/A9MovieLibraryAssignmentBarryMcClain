using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using CsvHelper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Linq;
using A4MovieLibraryAssignmentBarryMcClain.Services;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace A4MovieLibraryAssignmentBarryMcClain
{
    class Program
    {

        
        static void Main(string[] args)
        {
            
            //What I am moving to dependency injection:
            /*MovieApp movieapp = new MovieApp();
            MenuGenerator generator = new MenuGenerator();
            generator.MovieGenerator(movieapp);*/

            var startup = new Startup();
            var serviceProvider = startup.ConfigureServices();
            var service = serviceProvider.GetService<IMainService>();
            service?.Invoke();
            

        }

    }
}   