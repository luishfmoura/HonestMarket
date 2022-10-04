using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonestMarket.Application.DTO
{
    public class ProductDto : BaseDto
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Creation { get; set; } = DateTime.Now;
    }
}
