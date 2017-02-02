using Microsoft.Owin;
using Owin;
using SmartShow.DTO;
using SmartShow.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.ViewModel;

[assembly: OwinStartup(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public class Startup
    {


        public void Configuration(IAppBuilder app)
        {
           // app.UseWebApi(WebApiConfig.Register());

            AutoMapper.Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<FileUploadViewModel, File>();
                mapper.CreateMap<AllowedFileType, AllowedFileTypeViewModel>();
            });

        }
    }
}