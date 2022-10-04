using HonestMarket.Domain.Core.Repositories;
using HonestMarket.Domain.Entities;
using HonestMarket.Domain.Services;

namespace HonestMarket.Domain.Core.Services;

public class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
{
    private readonly IRepositoryBase<T> _repository;

    public ServiceBase(IRepositoryBase<T> repository)
    {
        _repository = repository;
    }

    public bool Add(T entity) => _repository.Add(entity);

    public ICollection<T>? Get() => _repository.Get();

    public T? Get(int id) => _repository.Get(id);

    public T? Get(string guid) => _repository.Get(guid);

    public ICollection<T>? Get(Func<T, bool> lambda) => _repository.Get(lambda);

    public bool Update(T entity) => _repository.Update(entity);

    public bool Remove(T entity) => _repository.Remove(entity);
}