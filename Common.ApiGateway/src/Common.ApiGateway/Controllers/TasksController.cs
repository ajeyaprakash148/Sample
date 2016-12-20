using Common.ApiGateway.Helpers;
using Common.ApiGateway.Models;
using Common.ApiGateway.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Common.ApiGateway.Controllers
{
    public class TasksController : Controller
    {
        private MasterRepository masterRepository;

        public TasksController(MasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }
        [HttpGet]
        public async Task<AjaxModel<List<TagsModel>>> TagsGet()
        {
            return await AjaxHelper.GetAsync(m => this.masterRepository.TagsGet());
        }
        [HttpGet]
        public async Task<AjaxModel<List<TagsMasterModel>>> TagsMasterGet()
        {
            return await AjaxHelper.GetAsync(m => this.masterRepository.TagsMasterGet());
        }
        [HttpPost]
        public async Task<AjaxModel<DataModel>> TagsSave([FromBody] TagsModel model)
        {
            return await AjaxHelper.SaveAsync(m => this.masterRepository.TagsSave(model), "Tags Saved Successfully");
        }
        
        public async Task<AjaxModel<DataModel>> TaskActions(int taskId, string taskAction)
        {
            return await AjaxHelper.SaveAsync(m => this.masterRepository.TaskActions(taskId, taskAction), "Tasks updated Successfully");
        }

        [HttpGet]
        public async Task<AjaxModel<List<TasksModel>>> TasksGet()
        {
            var pagination = Request.Headers["Pagination"];

            
            return await AjaxHelper.GetAsync(m => this.masterRepository.TasksGet(pagination));
        }
        [HttpPost]
        public async Task<AjaxModel<DataModel>> TasksSave([FromBody] TasksModel model)
        {
            return await AjaxHelper.SaveAsync(m => this.masterRepository.TasksSave(model), "Tasks Saved Successfully");
        }
    }
}
