namespace HonestMarket.Web.Models.Responses;

public class ProductResponse : ResponseBase
{
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime Creation { get; set; }
}
