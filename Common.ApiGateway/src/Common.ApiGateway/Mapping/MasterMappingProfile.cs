
using Common.ApiGateway.Entities;
using Common.ApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace Common.ApiGateway.Mapping
{
    public class MasterMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "MasterMappingProfile"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<UserEntity, UserModel>().ReverseMap();
            Mapper.CreateMap<RolesEntity, RolesModel>().ReverseMap();
            Mapper.CreateMap<UserRolesEntity, UserRolesModel>().ReverseMap();
            Mapper.CreateMap<TasksEntity, TasksModel>().ReverseMap();
            Mapper.CreateMap<TagsEntity, TagsModel>().ReverseMap();
            Mapper.CreateMap<TagsMasterEntity, TagsMasterModel>().ReverseMap();
            Mapper.CreateMap<InvoiceEntity, InvoiceModel>().ReverseMap()
                .ForMember(vm => vm.Client, map => map.MapFrom(s => s.Client))
                .ForMember(vm => vm.From, map => map.MapFrom(s => s.From));
            Mapper.CreateMap<ClientEntity, ClientModel>().ReverseMap();
            Mapper.CreateMap<ServiceEntity, ServiceModel>().ReverseMap();
            Mapper.CreateMap<ShortcutsEntity, ShortcutsModel>().ReverseMap();
            Mapper.CreateMap<ContactsEntity, ContactsModel>().ReverseMap();
            Mapper.CreateMap<GroupsEntity, GroupsModel>().ReverseMap();
            Mapper.CreateMap<ContactGroupsEntity, ContactGroupsModel>().ReverseMap();
            Mapper.CreateMap<OrganizationsEntity, OrganizationsModel>().ReverseMap();
        }
    }
}
