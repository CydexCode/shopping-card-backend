namespace shopping_card_backend.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessge { get; set; }
        public List<Products> listproducts { get; set; }
    }
}
