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

        public List<Order> GetAllOrders()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        SELECT
                                            Id, UserId, Total, CardNum, Expiration, NameOnCard, BillingZip, Address, phone, date, weight
                                        FROM [Order]
                                        ";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Order> orders = new List<Order>();
                    while (reader.Read())
                    {
                        Order order = new Order()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetString(reader.GetOrdinal("UserId")),
                            Total = (int)reader.GetInt64(reader.GetOrdinal("Total")),
                            CardNum = reader.GetString(reader.GetOrdinal("CardNum")),
                            Expiration = reader.GetString(reader.GetOrdinal("Expiration")),
                            NameOnCard = reader.GetString(reader.GetOrdinal("NameOnCard")),
                            BillingZip = reader.GetString(reader.GetOrdinal("BillingZip")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Date = reader.GetString(reader.GetOrdinal("Date")),
                            Weight = (int)reader.GetDecimal(reader.GetOrdinal("Weight")),
                        };
                        orders.Add(order);
                    }
                    reader.Close();

                    return orders;
                }
            }
        }
    }
}
