using HonestMarket.Application.DTO;
using HonestMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Application.Interfaces;

public interface IApplicationServiceBase<T,Z> where T : BaseEntity where Z : BaseDto
{
    public ICollection<Z>? Get();
    public Z? Get(int id);
    public Z? Get(string guid);
    public ICollection<Z>? Get(Func<T, bool> lambda);
    public bool Add(Z dTO);
    public bool Update(Z dTO);
    public bool Remove(int id);
    public bool Remove(string guid);
}
