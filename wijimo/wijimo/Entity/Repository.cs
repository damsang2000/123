using wijimo.Data;
using wijimo.Model;
using System;
namespace wijimo.Entity
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private wijimoContext context;
        public Repository(wijimoContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            context.Add(entity);
            await context.SaveChangesAsync();
        }
    }
}
