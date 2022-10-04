namespace HonestMarket.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Creation { get; set; } = DateTime.Now;
    }
}