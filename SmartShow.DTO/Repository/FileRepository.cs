using SmartShow.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShow.DTO.Repository
{
    public class FileRepository : RepositoryBase<File>,IFileRepository
    {
        public FileRepository(IDataBaseFactory dbFactory) : base(dbFactory)
        {

        }
    }

    public interface IFileRepository : IRepositoryBase<File>
    {

    }
}
