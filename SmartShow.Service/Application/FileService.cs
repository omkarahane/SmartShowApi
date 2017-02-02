using SmartShow.DTO;
using SmartShow.DTO.Models;
using SmartShow.DTO.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartShow.Service.Application
{
   public class FileService: IFileService
    {
        private IFileRepository fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        public void UploadFile(DTO.Models.File fileUploadModel)
        {
            try
            {
                fileUploadModel.UploadedAt = DateTime.Now;
                fileRepository.Add(fileUploadModel);
                SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<DTO.Models.File> GetAll()
        {
            return fileRepository.GetAll();
        }
        public void SaveChanges()
        {
            fileRepository.SaveChanges();
        }
    }

    public interface IFileService
    {
        void UploadFile(DTO.Models.File fileUploadViewModel);
        IEnumerable<DTO.Models.File> GetAll();
        void SaveChanges();
    }
}
