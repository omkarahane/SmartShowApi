using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShow.DTO
{
    public class DataBaseFactory : IDataBaseFactory
    {
        public DataContext context;
        public DataBaseFactory()
        { }

        public DataBaseFactory(DataContext context)
        {
            this.context= context;
        }

        public DataContext GetInstance()
        {
               return context = new DataContext();
        }
    }

    public interface IDataBaseFactory
    {
        DataContext GetInstance();
    }
}
