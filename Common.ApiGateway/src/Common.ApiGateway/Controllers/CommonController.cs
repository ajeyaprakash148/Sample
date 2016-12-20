namespace Common.ApiGateway.Controllers
{
    using Common.ApiGateway.Helpers;
    using Common.ApiGateway.Models;
    using Common.ApiGateway.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    public class CommonController : Controller
    {
        private MasterRepository masterRepository;

        public CommonController(MasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }
        [HttpGet]
        public async Task<AjaxModel<List<ShortcutsModel>>> ShortcutsGet()
        {
            return await AjaxHelper.GetAsync(m => this.masterRepository.ShortcutsGet());
        }
        [HttpPost]
        public async Task<AjaxModel<DataModel>> ShortcutsSave([FromBody] ShortcutsModel model)
        {
            return await AjaxHelper.SaveAsync(m => this.masterRepository.ShortcutsSave(model), "Shortcuts Saved Successfully");
        }

        [HttpGet]
        public async Task<AjaxModel<List<OrganizationsModel>>> OrganizationsGet()
        {
            return await AjaxHelper.GetAsync(m => this.masterRepository.OrganizationsGet());
        }
        [HttpPost]
        public async Task<AjaxModel<DataModel>> OrganizationsSave([FromBody] OrganizationsModel model)
        {
            return await AjaxHelper.SaveAsync(m => this.masterRepository.OrganizationsSave(model), "OrganizationsSave Saved Successfully");
        }

        [HttpGet]
        public async Task<AjaxModel<List<RolesModel>>> RolesGet()
        {
            return await AjaxHelper.GetAsync(m => this.masterRepository.RolesGet());
        }
        [HttpPost]
        public async Task<AjaxModel<DataModel>> RolesSave([FromBody] RolesModel model)
        {
            return await AjaxHelper.SaveAsync(m => this.masterRepository.RolesSave(model), "Shortcuts Saved Successfully");
        }

        [HttpGet]
        public async Task<AjaxModel<List<UserRolesModel>>> UserRolesGet()
        {
            return await AjaxHelper.GetAsync(m => this.masterRepository.UserRolesGet());
        }
        [HttpPost]
        public async Task<AjaxModel<DataModel>> UserRolesSave([FromBody] UserRolesModel model)
        {
            return await AjaxHelper.SaveAsync(m => this.masterRepository.UserRolesSave(model), "UserRoles Saved Successfully");
        }

        [HttpGet]
        public HttpResponseMessage Generate()
        {
            StringBuilder the_stringbuilder = new StringBuilder();
            the_stringbuilder.Append("Dictionary jsonsaved");
            byte[] the_array = System.Text.Encoding.UTF8.GetBytes(the_stringbuilder.ToString());
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(the_array)
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = "ara.json"
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/json");

            return result;
        }
        public FileResult DictionaryJsonDownload()
        {
            StringBuilder the_stringbuilder = new StringBuilder();
            the_stringbuilder.Append("{'dictionary':[{'entry':{ 'Departments':{'ara':'الإدارات','eng':'Departments','id':'Departments','section_Id':'0'}}}]}");
            byte[] the_array = System.Text.Encoding.UTF8.GetBytes(the_stringbuilder.ToString());
            HttpContext.Response.ContentType = "application/json";
            FileContentResult result = new FileContentResult(the_array, "application/json")
            {
                FileDownloadName = "ara.json"
            };

            return result;
        }
    }
}
