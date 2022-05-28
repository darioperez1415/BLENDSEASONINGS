using BLENDSEASONINGS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BLENDSEASONINGS.Repos
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _config;

        public OrderRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection 
        { 
            get 
            { 
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            } 
        }
    }
}
