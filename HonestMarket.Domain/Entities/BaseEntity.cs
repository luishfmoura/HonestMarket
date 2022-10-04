using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Domain.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public Guid Guid { get; set; } = Guid.NewGuid();
}
