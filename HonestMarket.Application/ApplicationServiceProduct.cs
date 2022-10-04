using AutoMapper;
using HonestMarket.Application.DTO;
using HonestMarket.Application.Interfaces;
using HonestMarket.Domain.Entities;
using HonestMarket.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Application;

public class ApplicationServiceProduct : ApplicationServiceBase<Product,ProductDto> , IApplicationServiceProduct
{
    public ApplicationServiceProduct(IServiceBase<Product> service, IMapper mapper) : base(service, mapper) { }
}
