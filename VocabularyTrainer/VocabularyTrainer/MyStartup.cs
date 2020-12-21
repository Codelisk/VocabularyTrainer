using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Shiny.Logging;
using SQLiteModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyTrainer
{
    public partial class MyStartup : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            Log.UseConsole();
            Log.UseDebug();
            services.AddSingleton<ILogger, Shiny.Logging.ConsoleLogger>();
            //services.UseTestMotionActivity(Shiny.Locations.MotionActivityType.Automotive);

            //services.UseAppCenterLogging(Constants.AppCenterTokens, true, false);

            services.UseSqliteLogging(true, false);
            services.UseSqliteSettings();
            services.UseSqliteStorage();
            //services.UseSqliteSettings();
            //services.UseSqliteStorage();

            // your infrastructure
            services.AddSingleton<VocabularySqliteConnection>();
        }
    }
}