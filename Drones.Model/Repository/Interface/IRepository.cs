using System.Linq.Expressions;

namespace Drones.Model.Repository.Interface;

public interface IRepository<T> where T : EntityBase
{
    Task AddAsync(T data);
    T Update(T data);
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAllAsync(IEnumerable<int> ids);
    IEnumerable<T> Where(Func<T, bool> filter, List<string> includes = default);
}

