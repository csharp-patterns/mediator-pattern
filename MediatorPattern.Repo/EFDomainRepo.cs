

using MediatorPattern.Domains;
using Microsoft.EntityFrameworkCore;

namespace MediatorPattern.Repo
{
    public class EFDomainRepo : IDomainRepo
    {
        protected readonly EFDbContext _dbContext;

        public EFDomainRepo(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> GetAsync<T>(int id) where T: BaseDb
        {
            var allRecords = _dbContext.Set<T>().AsNoTracking();

            return await allRecords.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}