using SmartShow.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShow.DTO.Repository
{
    public class AllowedFileTypeRepository : RepositoryBase<AllowedFileType>, IAllowedFileTypeRepository
    {
        public AllowedFileTypeRepository(IDataBaseFactory factory) : base(factory)
        {

        }
    }

    public interface IAllowedFileTypeRepository : IRepositoryBase<AllowedFileType>
    {

    }
}
