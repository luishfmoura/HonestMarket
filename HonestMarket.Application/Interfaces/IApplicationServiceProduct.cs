using HonestMarket.Application.DTO;
using HonestMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Application.Interfaces;

public interface IApplicationServiceProduct : IApplicationServiceBase<Product,ProductDto> { }
