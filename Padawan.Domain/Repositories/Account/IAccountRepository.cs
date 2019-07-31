using Padawan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Padawan.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task Create(Account account);
        Task Update(Account account);
        Task Delete(Account account);

        Task<Account> GetById(long id);
        Task<List<Account>> GetList(int page, int pageSize);
        Task<Account> GetBy(Expression<Func<Account, bool>> expression);
        Task<List<Account>> GetListBy(Expression<Func<Account, bool>> expression, int page, int pageSize);
    }
}
