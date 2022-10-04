using AutoMapper;
using HonestMarket.Application.DTO;
using HonestMarket.Application.Exceptions;
using HonestMarket.Application.Interfaces;
using HonestMarket.Domain.Entities;
using HonestMarket.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Application;

public class ApplicationServiceBase<T, Z> : IApplicationServiceBase<T, Z> where T : BaseEntity where Z : BaseDto
{
    private readonly IServiceBase<T> _service;
    private readonly IMapper _mapper;
    public ApplicationServiceBase(IServiceBase<T> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public bool Add(Z dTO)
    {
        var entity = _mapper.Map<Z, T>(dTO);
        return _service.Add(entity);
    }

    public ICollection<Z>? Get()
    {
        var entity = _service.Get();
        if (entity is null || !entity.Any())
        {
            throw new HonestMarketNocontentException();
        }

        return _mapper.Map<ICollection<T>, ICollection<Z>>(entity);
    }

    public Z? Get(int id)
    {
        var entity = _service.Get(id);
        if (entity is null)
        {
            throw new HonestMarketNocontentException();
        }

        return _mapper.Map<T, Z>(entity);
    }

    public Z? Get(string guid)
    {
        var entity = _service.Get(guid);
        if (entity is null)
        {
            throw new HonestMarketNocontentException();
        }

        return _mapper.Map<T, Z>(entity);
    }

    public ICollection<Z>? Get(Func<T, bool> lambda)
    {
        var entity = _service.Get(lambda);
        if (entity is null || !entity.Any())
        {
            throw new HonestMarketNocontentException();
        }

        return _mapper.Map<ICollection<T>, ICollection<Z>>(entity);
    }

    public bool Update(Z dTO)
    {
        var entity = _mapper.Map<Z, T>(dTO);
        return _service.Update(entity);
    }

    public bool Remove(int id)
    {
        var entity = _service.Get(id);
        if (entity is null)
        {
            throw new HonestMarketNotFoundException();
        }

        return _service.Remove(entity);
    }

    public bool Remove(string guid)
    {
        var entity = _service.Get(guid);
        if (entity is null)
        {
            throw new HonestMarketNotFoundException();
        }

        return _service.Remove(entity);
    }
}
