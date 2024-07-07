using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListener.Application.Contract.IRepositories.ICommon
{
    public interface IBaseRepository<T>
    {
        Task AddAsync(T entity);
    }
}
