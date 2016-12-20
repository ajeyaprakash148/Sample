using Common.ApiGateway.Helpers;
using Common.ApiGateway.Models;
using Common.ApiGateway.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.ApiGateway.Controllers
{
    public class AccountController : Controller
    {
        private MasterRepository masterRepository;
        Base64EncodeDecode encodeDecode = new Base64EncodeDecode();
        public AccountController(MasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }
        [HttpGet]
        public async Task<AjaxModel<List<UserModel>>> UsersGet()
        {
            return await AjaxHelper.GetAsync(m => this.masterRepository.UsersGet());
        }
        [HttpGet]
        public async Task<AjaxModel<UserModel>> UsersGetById(string userId)
        {
            return await AjaxHelper.GetAsync(m => this.masterRepository.UsersGetById(userId));
        }
        [HttpPost]
        public async Task<AjaxModel<DataModel>> UserSave([FromBody] UserModel model)
        {
            if (model!=null)
            {
                model.Password = encodeDecode.base64Encode(model.Password);
                return await AjaxHelper.SaveAsync(m => this.masterRepository.UserSave(model), "User Saved Successfully");
            }
            else return new AjaxModel<DataModel>() { Data = null, Message = "Please provide valid user" };
        }
        [HttpPost]
        public async Task<AjaxModel<UserModel>> Login([FromBody] UserModel model)
        {
            UserModel users = new UserModel();
            users = await this.masterRepository.UsersGetById(model.UserId);
            if (users != null && users.AccountStatus)
            {
                if (model.Password == encodeDecode.base64Decode2(users.Password))
                {
                    return new AjaxModel<UserModel>() { Data = users };
                }
                else return new AjaxModel<UserModel>() { Data = null, Message = "Please provide a valid password" };
            }
            else return new AjaxModel<UserModel>() { Data = null, Message = "User is in inActive state" };
        }
    }
}
