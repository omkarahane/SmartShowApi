using AutoMapper;
using SmartShow.Service.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/v1/allowedfiletype")]
    public class AllowedFileTypeController : ApiController
    {
        IAllowedFileTypesService allowedFileTypesService;
        public AllowedFileTypeController(IAllowedFileTypesService AllowedFileTypesService)
        {
            this.allowedFileTypesService = AllowedFileTypesService;
        }

        [HttpGet]
        public IHttpActionResult GetAllowedFileTypes()
        {
            try
            {
                return Ok(Mapper.Map<IEnumerable<AllowedFileTypeViewModel>>(allowedFileTypesService.GetAllowedFileTypes()).ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
    }
}
