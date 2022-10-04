using HonestMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Domain.Core.Repositories;

public interface IRepositoryBase<T> where T : BaseEntity
{
    public ICollection<T>? Get();
    public T? Get(int id);
    public T? Get(string guid);
    public ICollection<T>? Get(Func<T, bool> lambda);
    public bool Add(T entity);
    public bool Update(T entity);
    public bool Remove(T entity);
}
