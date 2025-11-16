using MediatorPattern.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern.Repo
{
    public interface IDomainRepo
    {
        Task<T?> GetAsync<T>(int id) where T: BaseDb;
    }
}
