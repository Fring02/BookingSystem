using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.API.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
<<<<<<< HEAD
            CreateHostBuilder(args).Build()/*.ApplyDatabaseMigrations().SeedData()*/.Run();
=======
            CreateHostBuilder(args).Build().Run();
>>>>>>> f3337821cdfc417096ac2cc0c77929f7fb77bbb4
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}