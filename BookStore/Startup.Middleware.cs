using DbUp;
using DbUp.Engine.Output;
using DbUp.Helpers;

namespace BookStore
{
    public static partial class Startup
    {
        public static WebApplication ConfigureMiddleware(this WebApplication app)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
            TableMigrationScript(app);
            //StoredProcedureMigrationScript(app);
            app.UseHttpsRedirection();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }

        /// <summary>
        /// Sql migration for table Schema
        /// </summary>
        public static void TableMigrationScript(this WebApplication app)
        {
            string dbConnStr = app.Configuration.GetConnectionString("Default");
            EnsureDatabase.For.SqlDatabase(dbConnStr);

            var upgrader = DeployChanges.To.SqlDatabase(dbConnStr)
            .WithScriptsFromFileSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sql", "Tables"))
            .WithTransactionPerScript()
            .JournalToSqlTable("dbo", "TableMigration")
             .LogToConsole()
            .LogTo(new SerilogDbUpLog(app.Logger))
            .WithVariablesDisabled()
            .Build();

            upgrader.PerformUpgrade();
        }

        /// <summary>
        /// Sql migration for stored procedure
        /// </summary>
        //public static void StoredProcedureMigrationScript(this WebApplication app)
        //{
        //    string dbConnStr = app.Configuration.GetConnectionString("Default");
        //    EnsureDatabase.For.SqlDatabase(dbConnStr);

        //    var upgrader = DeployChanges.To.SqlDatabase(dbConnStr)
        //    .WithScriptsFromFileSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sql", "Sprocs"))
        //    .WithTransactionPerScript()
        //    .JournalTo(new NullJournal())
        //    .JournalToSqlTable("dbo", "SprocsMigration")
        //    .LogTo(new SerilogDbUpLog(app.Logger))
        //    .LogToConsole()
        //    .Build();

        //    upgrader.PerformUpgrade();
        //}


        private class SerilogDbUpLog : IUpgradeLog
        {

            private readonly ILogger _logger;
            public SerilogDbUpLog(ILogger logger)
            {
                _logger = logger;
            }

            public void WriteError(string format, params object[] args)
            {
                _logger.LogError(format, args);
            }

            public void WriteInformation(string format, params object[] args)
            {
                _logger.LogInformation(format, args);
            }

            public void WriteWarning(string format, params object[] args)
            {
                _logger.LogWarning(format, args);
            }
        }
    }
}
