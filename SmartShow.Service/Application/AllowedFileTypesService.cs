using SmartShow.DTO.Models;
using SmartShow.DTO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShow.Service.Application
{
    public class AllowedFileTypesService : IAllowedFileTypesService
    {
        IAllowedFileTypeRepository allowedFileTypeRepository;

        public AllowedFileTypesService(IAllowedFileTypeRepository allowedFileTypeRepository)
        {
            this.allowedFileTypeRepository = allowedFileTypeRepository; ;
        }

        public IEnumerable<AllowedFileType> GetAllowedFileTypes()
        {
            try
            {
                return allowedFileTypeRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    public interface IAllowedFileTypesService
    {
        IEnumerable<AllowedFileType> GetAllowedFileTypes();
    }

}
