using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShow.DTO
{
    internal sealed class Configuration: System.Data.Entity.Migrations.DbMigrationsConfiguration<DataContext>
    {
        private DataContext context;

        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = false;
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {

            if (!AutomaticMigrationsEnabled)
            {
                return;
            }
            else
            {
                this.context = context;

                //code for seed

                context.SaveChanges();
            }
        }
    }
}
