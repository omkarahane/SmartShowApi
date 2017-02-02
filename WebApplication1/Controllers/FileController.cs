using AutoMapper;
using Newtonsoft.Json.Linq;
using SmartShow.DTO;
using SmartShow.Service.Application;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/v1/file")]
    public class FileController : ApiController
    {
        private IFileService fileService;
        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }



        [HttpGet]
        public IHttpActionResult GetUploadedFiles()
        {
            try
            {
                return Ok(fileService.GetAll());
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult UploadFile([FromBody] FileUploadViewModel fileUploadViewModel)
        {

            try
            {
                
                if (!ModelState.IsValid)
                    return BadRequest();
                fileService.UploadFile(Mapper.Map<SmartShow.DTO.Models.File>(fileUploadViewModel));
                return Ok();

            }
            catch (Exception ex)
            {

                return InternalServerError();
            }
        }
    }
}
