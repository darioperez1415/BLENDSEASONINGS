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
                                            Id,
                                            UserId,
                                            Total,
                                            CardNum,
                                            Expiration,
                                            NameOnCard,
                                            BillingZip,
                                            Address,
                                            Phone,
                                            Date,
                                            Weight
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
        public Order GetOrderById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT
                                            Id,
                                            UserId,
                                            Total,
                                            CardNum,
                                            Expiration,
                                            NameOnCard,
                                            BillingZip,
                                            Address,
                                            Phone,
                                            Date,
                                            Weight
                                        FROM [Order]
                                        WHERE Id = @Id
                                      ";
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
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

                        reader.Close();
                        return order;
                    }
                    reader.Close();
                    return null;
                }
            }
        }

        public void CreateOrder(Order order)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [Order] 
                                           (UserId,
                                            Total,
                                            CardNum,
                                            Expiration,
                                            NameOnCard,
                                            BillingZip,
                                            Address,
                                            Phone,
                                            Date,
                                            Weight)
                                        OUTPUT INSERTED.ID
                                        VALUES (
                                            @UserId,
                                            @Total,
                                            @CardNum,
                                            @Expiration,
                                            @NameOnCard,
                                            @BillingZip,
                                            @Address,
                                            @Phone,
                                            @Date,
                                            @Weight)";

                    cmd.Parameters.AddWithValue("@UserId", order.UserId);
                    cmd.Parameters.AddWithValue("@Total", order.Total);
                    cmd.Parameters.AddWithValue("@CardNum", order.CardNum);
                    cmd.Parameters.AddWithValue("@Expiration", order.Expiration);
                    cmd.Parameters.AddWithValue("@NameOnCard", order.NameOnCard);
                    cmd.Parameters.AddWithValue("@BillingZip", order.BillingZip);
                    cmd.Parameters.AddWithValue("@Address", order.Address);
                    cmd.Parameters.AddWithValue("@Phone", order.Phone);
                    cmd.Parameters.AddWithValue("@Date", order.Date);
                    cmd.Parameters.AddWithValue("@Weight", order.Weight);

                    int id = (int)cmd.ExecuteScalar();

                    order.Id = id;
                }
            }
        }
        public void CreateOrderTransaction(OrderTransaction transaction)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [OrderTransaction] 
                                            (
                                            blendId,
                                            orderId
                                            )
                                        OUTPUT INSERTED.ID
                                        VALUES (
                                            @blendId,
                                            @orderId
                                            )";
                    cmd.Parameters.AddWithValue("@blendId", transaction.BlendId);
                    cmd.Parameters.AddWithValue("@orderId", transaction.OrderId);

                    int id = (int)cmd.ExecuteScalar();

                    transaction.Id = id;
                }
            }
        }
        public void DeleteOrderTrasaction(int id)
        {
            using (SqlConnection conn= Connection)
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        DELETE FROM [OrderTransaction]
                                        WHERE ID = @id
                                        ";
                    cmd.Parameters.AddWithValue("@id",id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        //Delete FROM Cart -- dont need update
        public void UpdateOrder(Order order)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    UPDATE [Order]
                    SET
                        CardNum = @cardNum,
                        Expiration = @expiration,
                        NameOnCard = @nameOnCard,
                        BillingZip = @billingZip,
                        Address = @address,
                        Phone = @phone
                    WHERE Id = @id;
                    ";

                    cmd.Parameters.AddWithValue("@id", order.Id);
                    cmd.Parameters.AddWithValue("@cardNum", order.CardNum);
                    cmd.Parameters.AddWithValue("@expiration", order.Expiration);
                    cmd.Parameters.AddWithValue("@nameOnCard", order.NameOnCard);
                    cmd.Parameters.AddWithValue("@billingZip", order.BillingZip);
                    cmd.Parameters.AddWithValue("@address", order.Address);
                    cmd.Parameters.AddWithValue("@phone", order.Phone);


                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteOrder(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
				DELETE FROM [Order]
				WHERE Id = @id
				";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Order> GetOrdersByUserId(string userId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
			                         SELECT Id,
                                            UserId,
                                            Total,
                                            CardNum,
                                            Expiration,
                                            NameOnCard,
                                            BillingZip,
                                            Address,
                                            Phone,
                                            Date,
                                            Weight
                                      FROM [Order]
                                      WHERE UserId = @userId
			                            ";
                    cmd.Parameters.AddWithValue("@userId", userId);
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
