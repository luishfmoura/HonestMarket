using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Application.DTO
{
    public class BaseDto
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
