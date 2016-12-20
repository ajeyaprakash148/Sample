using AutoMapper;
using Common.ApiGateway.Entities;
using Common.ApiGateway.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Repositories
{
    public class MasterRepository : BaseRepository<MasterDbContext>
    {
        int page = 1;
        int pageSize = 100;
        //private AppSettings appSettings;
        public MasterRepository(MasterDbContext masterDbContext)//, IOptions<AppSettings> options)
        {
            this.DbContext = masterDbContext;
            //this.appSettings = options.Value;
        }
        public async Task<UserModel> UsersGetById(string userId)
        {
            UserEntity entites = await GetSingleOrDefaultAsync<UserEntity>(s => s.UserId == userId);
            return Mapper.Map<UserEntity, UserModel>(entites);
        }
        public async Task<List<UserModel>> UsersGet()
        {
            return await GetListAsync<UserEntity, UserModel>(s => s.Name);
        }
        public async Task UserSave(UserModel model)
        {
            UserModel alreadyExists = await this.UsersGetById(model.UserId);
            if (alreadyExists == null)
                await AddEntity<UserEntity, UserModel>(model);
            else {
                await UpdateEntity<UserEntity, UserModel>(model);
            }
        }

        public async Task<List<TagsModel>> TagsGet()
        {
            return await GetListAsync<TagsEntity, TagsModel>(s => s.Name);
        }

        public async Task<List<ShortcutsModel>> ShortcutsGet()
        {
            return await GetListAsync<ShortcutsEntity, ShortcutsModel>(s => s.Title);
        }
        public async Task ShortcutsSave(ShortcutsModel model)
        {
            ShortcutsModel alreadyExists = await this.ShortcutsGetById(model.ShortcutId);
            if (alreadyExists == null)
                await AddEntity<ShortcutsEntity, ShortcutsModel>(model);
        }
        public async Task<ShortcutsModel> ShortcutsGetById(int ShortcutId)
        {
            ShortcutsEntity entites = await GetSingleOrDefaultAsync<ShortcutsEntity>(s => s.ShortcutId == ShortcutId);
            return Mapper.Map<ShortcutsEntity, ShortcutsModel>(entites);
        }
        public async Task<ContactsModel> ContactsGetById(int Id)
        {
            ContactsEntity entites = await GetSingleOrDefaultAsync<ContactsEntity>(s => s.Id == Id);
            return Mapper.Map<ContactsEntity, ContactsModel>(entites);
        }
        public async Task<List<TagsMasterModel>> TagsMasterGet()
        {
            return await GetListAsync<TagsMasterEntity, TagsMasterModel>(s => s.Name);
        }
        public async Task OrganizationsSave(OrganizationsModel model)
        {
            await SaveEntity<OrganizationsEntity, OrganizationsModel>(model);
        }

        public async Task<List<OrganizationsModel>> OrganizationsGet()
        {
            return await GetListAsync<OrganizationsEntity, OrganizationsModel>(s => s.OrganizationCode);
        }
        public async Task TagsSave(TagsModel model)
        {
            await AddEntity<TagsEntity, TagsModel>(model);
        }
        public async Task<List<ContactsModel>> ContactsGet()
        {
            var query = from c in this.DbContext.Contacts
                        .Include(cg => cg.ContactGroups)
                        select c;

            List<ContactsEntity> entites = await query.ToListAsync();

            List<ContactsModel> listContactsModel = new List<ContactsModel>();
            AutoMapper.Mapper.Map(entites, listContactsModel);

            for (int i = 0; i < entites.Count(); i++)
            {
                foreach (ContactGroupsEntity cgEntity in entites[i].ContactGroups)
                    AutoMapper.Mapper.Map<ContactGroupsEntity, ContactGroupsModel>(cgEntity);
            }
            return listContactsModel;
            //return Mapper.Map<List<ContactsEntity>, List<ContactsModel>>(entites);
        }
        public async Task ContactsSave(ContactsModel model)
        {
            ContactsModel alreadyExists = await this.ContactsGetById(model.Id);
            if (alreadyExists == null)
            {
                await AddEntity<ContactsEntity, ContactsModel>(model);
            }
            else
            {
                await this.SaveEntity<ContactsEntity, ContactsModel>(model);
            }

        }
        public async Task<List<RolesModel>> RolesGet()
        {
            return await GetListAsync<RolesEntity, RolesModel>(s => s.Name);
        }
        public async Task RolesSave(RolesModel model)
        {
            if (model.RoleId == null)
            {
                await AddEntity<RolesEntity, RolesModel>(model);
            }
            else
            {
                await this.SaveEntity<RolesEntity, RolesModel>(model);
            }
        }




        public async Task<List<UserRolesModel>> UserRolesGet()
        {
            var query = from cg in this.DbContext.UserRoles
                        .Include(w => w.User)
                        .Include(w => w.Role)
                        select cg;


            List<UserRolesEntity> entites = await query.ToListAsync();
            return Mapper.Map<List<UserRolesEntity>, List<UserRolesModel>>(entites);

            //return await GetListAsync<UserRolesEntity, UserRolesModel>(s => s.UserId);
        }

        public async Task UserRolesSave(UserRolesModel model)
        {
            if (model.Id == 0)
            {
                await AddEntity<UserRolesEntity, UserRolesModel>(model);
            }
            else
            {
                await this.SaveEntity<UserRolesEntity, UserRolesModel>(model);
            }
        }
        public async Task<List<GroupsModel>> GroupsGet()
        {
            var query = from cg in this.DbContext.Groups
                        .Include(w => w.ContactGroups)
                        select cg;

            List<GroupsEntity> entites = await query.ToListAsync();
            return Mapper.Map<List<GroupsEntity>, List<GroupsModel>>(entites);
        }
        public async Task<List<ContactGroupsModel>> ContactGroupsGet()
        {
            var query = from cg in this.DbContext.ContactGroups
                        .Include(w => w.Contacts)
                        .Include(w => w.Groups)
                        select cg;

            List<ContactGroupsEntity> entites = await query.ToListAsync();
            return Mapper.Map<List<ContactGroupsEntity>, List<ContactGroupsModel>>(entites);
        }
        public async Task GroupsSave(GroupsModel model)
        {
            ContactsModel alreadyExists = await this.ContactsGetById(model.Id);
            if (alreadyExists == null)
            {
                await AddEntity<GroupsEntity, GroupsModel>(model);
            }
            else
            {
                await this.SaveEntity<GroupsEntity, GroupsModel>(model);
            }

        }
        public async Task TaskActions(int taskId, string action)
        {
            TasksEntity tasksEntity = await this.GetSingleAsync<TasksEntity>(taskId);
            if (tasksEntity != null)
            {
                if (action == "Star")
                    tasksEntity.Starred = !tasksEntity.Starred;
                else if (action == "Important")
                    tasksEntity.Important = !tasksEntity.Important;
                else if (action == "Completed")
                    tasksEntity.Completed = !tasksEntity.Completed;
                else if (action == "Deleted")
                {
                    tasksEntity.Deleted = true;
                    tasksEntity.DeletedInd = true;
                }
                await UpdateEntityWithoutModel<TasksEntity>(tasksEntity);
            }
        }
        public async Task<List<TasksModel>> TasksGet(string pagination)
        {
            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            int currentPage = page;
            int currentPageSize = pageSize;
            var totalTasks = this.DbContext.Tasks.Count();
            var totalPages = (int)Math.Ceiling((double)totalTasks / pageSize);

            var tasks = this.DbContext.Tasks
                .Include(task => task.Tags)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            List<TasksEntity> entites = tasks.ToList();
            return Mapper.Map<List<TasksEntity>, List<TasksModel>>(entites);
        }

        public async Task<List<InvoiceModel>> InvoiceGet(string pagination, int? InvoiceId)
        {
            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            int currentPage = page;
            int currentPageSize = pageSize;
            var totalInvoices = this.DbContext.Invoice.Count();
            var totalPages = (int)Math.Ceiling((double)totalInvoices / pageSize);

            var invoice = this.DbContext.Invoice
                .Include(inv => inv.Services)
                .Include(cli => cli.From)
                .Include(f => f.Client)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            List<InvoiceEntity> entites = invoice.ToList();
            return Mapper.Map<List<InvoiceEntity>, List<InvoiceModel>>(entites);
        }
        //public async Task<List<ServiceModel>> ServiceGet(int serviceId)
        //{
        //    var query = from s in this.DbContext.Service
        //                .Include(i => i.Invoice)
        //                .SingleOrDefaultAsync(x => x.ServiceId == serviceId);

        //    List<ServiceEntity> entites = await query.ToListAsync();
        //    return Mapper.Map<List<ServiceEntity>, List<ServiceModel>>(entites);
        //}
        public async Task TasksSave(TasksModel model)
        {
            if (model.TasksId <= 0)
            {
                await AddEntity<TasksEntity, TasksModel>(model);
            }
            else
            {
                await this.SaveEntity<TasksEntity, TasksModel>(model);
            }
        }
    }
}
