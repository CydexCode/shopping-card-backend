namespace shopping_card_backend.Models
{
    public class Products
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  string Image { get; set; }
        public decimal ActualPrice { get; set; }

        public decimal DiscoutPice { get; set; }
        public decimal DiscountPice { get; internal set; }
    }
}
