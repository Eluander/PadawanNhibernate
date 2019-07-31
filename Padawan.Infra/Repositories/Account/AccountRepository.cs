using NHibernate;
using NHibernate.Linq;
using Padawan.Domain.Entities;
using Padawan.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Padawan.Infra.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ISession _session;

        public AccountRepository(ISession session)
        {
            _session = session;
        }

        public async Task Create(Account account)
        {
            await _session.SaveAsync(account);
            await _session.FlushAsync();
        }

        public async Task Update(Account account)
        {
            await _session.UpdateAsync(account);
            await _session.FlushAsync();
        }

        public async Task Delete(Account account)
        {
            await _session.DeleteAsync(account);
            await _session.FlushAsync();
        }

        public async Task<List<Account>> GetListBy(Expression<Func<Account, bool>> expression, int page, int pageSize)
        {
            return await _session.Query<Account>().Skip(page).Take(pageSize).Where(expression).ToListAsync();
        }

        public async Task<List<Account>> GetList(int page, int pageSize)
        {
            return await _session.Query<Account>().Skip(page).Take(pageSize).ToListAsync(); ;
        }

        public async Task<Account> GetById(long id)
        {
            _session.CacheMode = CacheMode.Normal;
            return await _session.GetAsync<Account>(id);
        }

        public Task<Account> GetBy(Expression<Func<Account, bool>> expression)
        {
            return _session.Query<Account>().Where(expression).AsQueryable().FirstOrDefaultAsync();
        }
    }
}