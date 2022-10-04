using HonestMarket.Domain.Entities;

namespace HonestMarket.Domain.Services;

public interface IServiceBase<T> where T : BaseEntity
{
    public ICollection<T>? Get();
    public T? Get(int id);
    public T? Get(string guid);
    public ICollection<T>? Get(Func<T, bool> lambda);
    public bool Add(T entity);
    public bool Update(T entity);
    public bool Remove(T entity);
}