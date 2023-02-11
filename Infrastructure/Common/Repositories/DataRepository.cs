using Domain.Common.Entities;
using Domain.Common.Entities.Models;
using Domain.Common.Repositories;
using Infrastructure.Common.Persistence;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Repositories
{
    internal abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
        where TDbContext : IDbContext
        where TEntity : class, IEntity, IAggregateRoot

    {
        protected DataRepository(
            TDbContext data, 
            IMapper mapper)
        {
            Data = data;
            Mapper = mapper;
        }

        protected TDbContext Data { get; }
        protected IMapper Mapper { get; }
        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        protected IQueryable<TEntity> AllAsNoTracking() => this.All().AsNoTracking();
        public async Task Save(TEntity entity, 
            CancellationToken cancellationToken)
        {
            this.Data.Update(entity);

            //await this.DispatchEvents(entity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
