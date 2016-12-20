using Common.ApiGateway.Helpers;
using Common.ApiGateway.Models;
using Common.ApiGateway.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Controllers
{
    public class ContactsController : Controller
    {
        private MasterRepository masterRepository;

        public ContactsController(MasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }
        [HttpPost]
        public async Task<AjaxModel<DataModel>> ContactsSave([FromBody] ContactsModel model)
        {
            return await AjaxHelper.SaveAsync(m => this.masterRepository.ContactsSave(model), "Contacts Saved Successfully");
        }
        [HttpGet]
        public async Task<List<ContactsModel>> ContactsGet()
        {
            return await this.masterRepository.ContactsGet();
        }

        [HttpPost]
        public async Task<AjaxModel<DataModel>> GroupsSave([FromBody] GroupsModel model)
        {
            return await AjaxHelper.SaveAsync(m => this.masterRepository.GroupsSave(model), "Groups Saved Successfully");
        }
        [HttpGet]
        public async Task<AjaxModel<List<GroupsModel>>> GroupsGet()
        {
            AjaxModel<List<GroupsModel>> result =  await AjaxHelper.GetAsync(m => this.masterRepository.GroupsGet());
            return result;

        }
        [HttpGet]
        public async Task<AjaxModel<List<ContactGroupsModel>>> ContactGroupsGet()
        {
            return await AjaxHelper.GetAsync(m => this.masterRepository.ContactGroupsGet());
        }
    }
}
