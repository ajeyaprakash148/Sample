using Common.ApiGateway.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Repositories
{
    public class MasterDbContext : BaseDbContext<MasterDbContext>
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
        { }
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<TasksEntity> Tasks { get; set; }
        public DbSet<TagsEntity> Tags { get; set; }
        public DbSet<TagsMasterEntity> TagsMaster { get; set; }
        public DbSet<InvoiceEntity> Invoice { get; set; }
        public DbSet<ServiceEntity> Service { get; set; }
        public DbSet<ClientEntity> Client { get; set; }

        public DbSet<ShortcutsEntity> Shortcuts { get; set; }

        public DbSet<ContactsEntity> Contacts { get; set; }

        public DbSet<GroupsEntity> Groups { get; set; }


        public DbSet<RolesEntity> Roles { get; set; }

        public DbSet<UserRolesEntity> UserRoles { get; set; }

        public DbSet<ContactGroupsEntity> ContactGroups { get; set; }

        public DbSet<OrganizationsEntity> Organizations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagsEntity>()
                .HasOne(p => p.Tasks)
                .WithMany(b => b.Tags)
                .HasForeignKey(p => p.TasksId);

            modelBuilder.Entity<ServiceEntity>()
                .HasOne(i => i.Invoice)
                .WithMany(s => s.Services)
                .HasForeignKey(i => i.InvoiceId);

            modelBuilder.Entity<ContactGroupsEntity>().HasKey(t => new { t.ContactId, t.GroupId });

            modelBuilder.Entity<ContactGroupsEntity>()
                .HasOne(c => c.Contacts)
                .WithMany(p => p.ContactGroups)
                .HasForeignKey(pt => pt.ContactId);

            modelBuilder.Entity<ContactGroupsEntity>()
                .HasOne(pt => pt.Groups)
                .WithMany(t => t.ContactGroups)
                .HasForeignKey(pt => pt.GroupId);

            modelBuilder.Entity<UserRolesEntity>().HasKey(t => new { t.RoleId, t.UserId });

            modelBuilder.Entity<UserRolesEntity>()
                .HasOne(u => u.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserRolesEntity>()
                .HasOne(r => r.Role)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(pt => pt.RoleId);
        }
    }
}
