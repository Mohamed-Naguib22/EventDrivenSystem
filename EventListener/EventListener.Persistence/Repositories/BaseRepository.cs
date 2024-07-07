using EventListener.Application.Contract.IRepositories.ICommon;
using EventListener.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListener.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private DbSet<T> Entities;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            Entities = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await Entities.AddAsync(entity);
        }
    }
}
