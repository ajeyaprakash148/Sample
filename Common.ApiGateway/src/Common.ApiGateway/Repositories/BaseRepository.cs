using AutoMapper;
using Common.ApiGateway.Entities;
using Common.ApiGateway.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Common.ApiGateway.Repositories
{
    public class BaseRepository<TContext>
        where TContext : DbContext
    {
        private TContext dbContext;
        //private FxContextModel context;

        public BaseRepository()
        {
            //this.context = FxContext.Context;
        }

        public TContext DbContext
        {
            get
            {
                return dbContext;
            }

            protected set
            {
                dbContext = value;
            }
        }

        //public FxContextModel AppContext
        //{
        //    get
        //    {
        //        return this.context;
        //    }
        //}

        protected async Task<TEntity> SaveEntity<TEntity, TModel>(TModel model, bool commit = true)
            where TEntity : BaseEntity
        {
            // checking for add or update
            string keyName = this.GetKeyName<TEntity>();

            int primaryKey = Convert.ToInt32(typeof(TModel).GetProperty(keyName).GetValue(model));

            if (primaryKey == 0)
            {
                return await this.AddEntity<TEntity, TModel>(model, commit);
            }
            else
            {
                return await this.UpdateEntity<TEntity, TModel>(model, commit);
            }
        }

        protected async Task<TEntity> SaveEntityWithoutBaseEntity<TEntity, TModel>(TModel model, bool commit = true)
            where TEntity : class
        {
            // checking for add or update
            string keyName = this.GetKeyName<TEntity>();
            int primaryKey = Convert.ToInt32(typeof(TModel).GetProperty(keyName).GetValue(model));

            if (primaryKey == 0)
            {
                return await this.AddEntityWithoutBaseEntity<TEntity, TModel>(model, commit);
            }
            else
            {
                return await this.UpdateEntityWithoutBaseEntity<TEntity, TModel>(model, commit);
            }
        }

        protected async Task<TEntity> AddEntity<TEntity, TModel>(TModel model, bool commit = true)
            where TEntity : BaseEntity
        {
            TEntity entity = Mapper.Map<TModel, TEntity>(model);
            dbContext.Add<TEntity>(entity);

            if (commit)
            {
                await dbContext.SaveChangesAsync();
            }

            return entity;
        }

        protected async Task<TEntity> AddEntityWithoutBaseEntity<TEntity, TModel>(TModel model, bool commit = true)
             where TEntity : class
        {
            TEntity entity = Mapper.Map<TModel, TEntity>(model);
            dbContext.Add<TEntity>(entity);

            if (commit)
            {
                await dbContext.SaveChangesAsync();
            }

            return entity;
        }

        protected async Task<TEntity> UpdateEntity<TEntity, TModel>(TModel model, bool commit = true)
            where TEntity : BaseEntity
        {
            TEntity entity = Mapper.Map<TModel, TEntity>(model);

            return await this.UpdateEntity<TEntity>(entity, false, commit);
        }

        protected async Task<TEntity> AddEntityWithoutModel<TEntity>(TEntity entity, bool commit = true)
            where TEntity : BaseEntity
        {
            dbContext.Add<TEntity>(entity);

            if (commit)
            {
                await dbContext.SaveChangesAsync();
            }

            return entity;
        }

        protected async Task<TEntity> UpdateEntityWithoutBaseEntity<TEntity, TModel>(TModel model, bool commit = true)
            where TEntity : class
        {
            TEntity entity = Mapper.Map<TModel, TEntity>(model);
            return await this.UpdateEntityWithoutBaseEntity<TEntity>(entity, commit);
        }

        protected async Task<TEntity> UpdateEntityWithoutBaseEntity<TEntity>(TEntity entity, bool commit)
            where TEntity : class
        {
            dbContext.Update<TEntity>(entity);
            if (commit)
            {
                await dbContext.SaveChangesAsync();
            }

            return entity;
        }

        protected async Task<TEntity> UpdateEntityWithoutModel<TEntity>(TEntity entity, bool commit = true)
            where TEntity : BaseEntity
        {
            return await this.UpdateEntity<TEntity>(entity, false, commit);
        }

        protected async Task<TEntity> UpdateEntity<TEntity>(TEntity entity, bool updateAuditFields, bool commit)
            where TEntity : BaseEntity
        {
            dbContext.Update<TEntity>(entity);

            if (updateAuditFields)
            {
                entity.UpdateAuditFields();
            }

            if (commit)
            {
                await dbContext.SaveChangesAsync();
            }

            return entity;
        }

        protected async Task DeleteEntity<TEntity>(object entityId, bool commit = true)
            where TEntity : BaseEntity
        {
            var entity = await this.GetSingleAsync<TEntity>(entityId);
            await this.DeleteEntity(entity, commit);
        }

        protected async Task DeleteEntity<TEntity>(Expression<Func<TEntity, bool>> whereExpression, bool commit = true)
            where TEntity : BaseEntity
        {
            var entity = await this.dbContext.Set<TEntity>().Where(whereExpression).Select(ent => ent).SingleAsync();
            await this.DeleteEntity(entity, commit);
        }

        protected async Task DeleteEntity<TEntity>(TEntity entity, bool commit = true)
            where TEntity : BaseEntity
        {
            entity.DeletedInd = true;
            entity.UpdateAuditFields();
            this.dbContext.Set<TEntity>().Update(entity);

            if (commit)
            {
                await this.dbContext.SaveChangesAsync();
            }
        }

        protected async Task<List<TModel>> GetListAsync<TEntity, TModel>(Expression<Func<TEntity, string>> sortExpression)
            where TEntity : BaseEntity
        {
            var query = this.dbContext.Set<TEntity>().Where(e => e.DeletedInd == false)// && e.OwnerOrgId == this.context.OrganizationId)
                                .OrderBy(sortExpression)
                                .Select(ent => Mapper.Map<TEntity, TModel>(ent));

            return await query.ToListAsync();
        }

        protected async Task<List<TModel>> GetListAsync<TEntity, TModel>(Expression<Func<TEntity, bool>> whereExpression, bool noAdditionalCheck, Expression<Func<TEntity, string>> sortExpression)
            where TEntity : BaseEntity
        {
            if (!noAdditionalCheck)
            {
                return await this.GetListAsync<TEntity, TModel>(whereExpression, sortExpression);
            }
            else
            {
                var query = this.dbContext.Set<TEntity>().Where(whereExpression)
                                    .OrderBy(sortExpression)
                                    .Select(ent => Mapper.Map<TEntity, TModel>(ent));

                return await query.ToListAsync();
            }
        }

        protected async Task<List<TModel>> GetListAsync<TEntity, TModel>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, string>> sortExpression)
            where TEntity : BaseEntity
        {
            return await this.GetListAsync<TEntity, TModel, string>(whereExpression, sortExpression);
        }

        protected async Task<List<TEntity>> GetListAsyncWithoutModel<TEntity>(Expression<Func<TEntity, bool>> whereExpression)
            where TEntity : class
        {
            var query = this.dbContext.Set<TEntity>().Where(whereExpression)
                                .Select(ent => ent);

            return await query.ToListAsync();
        }

        protected async Task<List<TModel>> GetListAsync<TEntity, TModel, TSort>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TSort>> sortExpression)
            where TEntity : BaseEntity
        {
            var query = this.dbContext.Set<TEntity>().Where(whereExpression).Where(e => e.DeletedInd == false)// && e.OwnerOrgId == this.context.OrganizationId)
                                .OrderBy(sortExpression)
                                .Select(ent => Mapper.Map<TEntity, TModel>(ent));

            return await query.ToListAsync();
        }

        protected async Task<List<TModel>> GetListAsyncWithoutBaseEntity<TEntity, TModel>(Expression<Func<TEntity, bool>> whereExpression)
            where TEntity : class
        {
            var query = this.dbContext.Set<TEntity>().Where(whereExpression)
                                .Select(ent => Mapper.Map<TEntity, TModel>(ent));

            return await query.ToListAsync();
        }

        protected async Task<List<ListItem<int, string>>> GetListItemsAsync<TEntity>(Expression<Func<TEntity, ListItem<int, string>>> selectExpression, Expression<Func<TEntity, string>> sortExpression)
            where TEntity : BaseEntity
        {
            return await this.GetListItemsAsync<TEntity, int, string>(selectExpression, sortExpression);
        }

        protected async Task<List<ListItem<TKey, TItem>>> GetListItemsAsync<TEntity, TKey, TItem>(Expression<Func<TEntity, ListItem<TKey, TItem>>> selectExpression, Expression<Func<TEntity, string>> sortExpression)
            where TEntity : BaseEntity
        {
            var query = this.dbContext.Set<TEntity>().Where(e => e.DeletedInd == false)// && e.OwnerOrgId == this.context.OrganizationId)
                        .OrderBy(sortExpression)
                        .Select(selectExpression);

            return await query.ToListAsync();
        }

        protected async Task<TEntity> GetSingleAsync<TEntity>(Expression<Func<TEntity, bool>> whereExpression)
            where TEntity : class
        {
            return await this.dbContext.Set<TEntity>().Where(whereExpression).Select(ent => ent).SingleAsync();
        }

        protected async Task<TEntity> GetSingleOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> whereExpression)
            where TEntity : class
        {
            return await this.dbContext.Set<TEntity>().Where(whereExpression).Select(ent => ent).SingleOrDefaultAsync();
        }

        protected async Task<TEntity> GetSingleAsync<TEntity>(object id)
            where TEntity : BaseEntity
        {
            IQueryable<TEntity> query = this.BuidQuery<TEntity>(id);
            return await query.SingleAsync();
        }

        protected async Task<TEntity> GetSingleOrDefaultAsync<TEntity>(object id)
            where TEntity : BaseEntity
        {
            IQueryable<TEntity> query = this.BuidQuery<TEntity>(id);
            return await query.SingleOrDefaultAsync();
        }

        private IQueryable<TEntity> BuidQuery<TEntity>(object id)
            where TEntity : BaseEntity
        {
            var entity = this.dbContext.Set<TEntity>().AsQueryable();

            // building where clause
            string keyName = this.GetKeyName<TEntity>();
            var aliasParam = Expression.Parameter(typeof(TEntity), "e");
            var whereExpression = Expression.Lambda(
            Expression.MakeBinary(
                    ExpressionType.Equal,
                    Expression.PropertyOrField(aliasParam, keyName),
                    Expression.Constant(id)),
                    aliasParam);

            var whereQuery = (IQueryable<TEntity>)entity.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    "Where",
                    new Type[] { entity.ElementType },
                    entity.Expression,
                    Expression.Quote(whereExpression)));

            var query = whereQuery.Select(e => e);
            return query;
        }

        private string GetKeyName<TEntity>()
        {
            IEntityType entityType = this.dbContext.Model.FindEntityType(typeof(TEntity));
            IKey key = entityType.FindPrimaryKey();
            return key.Properties.First().Name;
        }
    }
}
