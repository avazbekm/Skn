using Skn.Domain.Commons;

namespace Skn.DataAccess.IRepositories;

public interface IRepository<T> where T : Auditable
{
     Task<T> GetAsync();
}
