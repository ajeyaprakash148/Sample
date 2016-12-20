using Common.ApiGateway.Entities;
using Common.ApiGateway.Helpers;
using Common.ApiGateway.Models;
using Common.ApiGateway.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Controllers
{
    public class InvoiceController : Controller
    {
        private MasterRepository masterRepository;
        private IHostingEnvironment _environment;

        public InvoiceController(MasterRepository masterRepository, IHostingEnvironment environment)
        {
            this.masterRepository = masterRepository;
        }
        [HttpGet]
        public async Task<AjaxModel<List<InvoiceModel>>> InvoiceGet(int? InvoiceId)
        {
            var pagination = Request.Headers["Pagination"];
            return await AjaxHelper.GetAsync(m => this.masterRepository.InvoiceGet(pagination, InvoiceId));
        }

        //[HttpGet]
        //public async Task<AjaxModel<List<ServiceModel>>> ServiceGet(int ServiceId)
        //{
        //    return await AjaxHelper.GetAsync(m => this.masterRepository.ServiceGet(ServiceId));
        //}

        public FileResult Download()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"c:\folder\myfile.pdf");
            string fileName = "myfile.ext";
            return File(fileBytes, "application/pdf", fileName);
        }

        [HttpPost]
        public async Task<bool> Index(ICollection<IFormFile> files)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return true;
        }
    }
}
