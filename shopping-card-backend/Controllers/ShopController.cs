using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using shopping_card_backend.Models;
using System.Data;

namespace shopping_card_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ShopController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("ProductList")]

        public Response GetAllProduct() {

            List<Products> lstproducts = new List<Products>();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ShopingCon").ToString());
            SqlDataAdapter da=new SqlDataAdapter("SELECT * FROM tblProducts;", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Response response = new Response();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Products products = new Products();
                    products.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    products.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    products.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    products.ActualPrice = Convert.ToDecimal(dt.Rows[i]["ActualPrice"]);
                    products.DiscountPice = Convert.ToDecimal(dt.Rows[i]["DiscountPice"]);
                    lstproducts.Add(products);
                }
                if(lstproducts.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessge = "Data found";
                    response.listproducts = lstproducts;
                }
                else
                {

                    response.StatusCode = 100;
                    response.StatusMessge = "Data found";
                    response.listproducts = null;

                }
            }
            else {

                response.StatusCode = 100;
                response.StatusMessge = "Data found";
                response.listproducts = null;

            }
            return response;
        }
    }
}
