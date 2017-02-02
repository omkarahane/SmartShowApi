using SmartShow.DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShow.DTO
{
    public class DataContext: DbContext
    {
        static DataContext()
        {
            try
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
                var migrator = new System.Data.Entity.Migrations.DbMigrator(new Configuration());
                if (migrator.GetPendingMigrations().Any())
                {
                    migrator.Update();
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        public static DataContext GetInstance()
        {
            var context = new DataContext();

            if (context.Database.Connection.State == System.Data.ConnectionState.Closed)
            {
                context.Database.Connection.Open();
            }
            return context;
        }


        public DbSet<AllowedFileType> AllowedFileTypes { get; set; }

        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
