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
                                        Id, UserId, Total, CardNum, Expiration, NameOnCard, BillingZip, Address, Phone, Date, Status
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
                            Total = (int)reader.GetDecimal(reader.GetOrdinal("Total")),
                            CardNum = reader.GetString(reader.GetOrdinal("CardNum")),
                            Expiration = reader.GetString(reader.GetOrdinal("Expiration")),
                            NameOnCard = reader.GetString(reader.GetOrdinal("NameOnCard")),
                            BillingZip = reader.GetString(reader.GetOrdinal("BillingZip")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Date = reader.GetString(reader.GetOrdinal("Date")),
                            Status = reader.GetBoolean(reader.GetOrdinal("Status")),
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
                                        Id, UserId, Total, CardNum, Expiration, NameOnCard, BillingZip,Address, Phone, Date, Status
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
                            Total = (int)reader.GetDecimal(reader.GetOrdinal("Total")),
                            CardNum = reader.GetString(reader.GetOrdinal("CardNum")),
                            Expiration = reader.GetString(reader.GetOrdinal("Expiration")),
                            NameOnCard = reader.GetString(reader.GetOrdinal("NameOnCard")),
                            BillingZip = reader.GetString(reader.GetOrdinal("BillingZip")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Date = reader.GetString(reader.GetOrdinal("Date")),
                            Status = reader.GetBoolean(reader.GetOrdinal("Status")),
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
                    cmd.CommandText = @"
                    INSERT INTO [Order] 
                    (UserId, Total, CardNum, Expiration, NameOnCard, BillingZip, Address, Phone, Date, Status)
                    OUTPUT INSERTED.ID
                    VALUES (@userId, @total, @cardNum, @expiration, @nameOnCard, @billingZip, @address, @phone, @date, @status);
                    ";

                    cmd.Parameters.AddWithValue("@userId", order.UserId);
                    cmd.Parameters.AddWithValue("@total", order.Total);
                    cmd.Parameters.AddWithValue("@cardNum", order.CardNum);
                    cmd.Parameters.AddWithValue("@expiration", order.Expiration);
                    cmd.Parameters.AddWithValue("@nameOnCard", order.NameOnCard);
                    cmd.Parameters.AddWithValue("@billingZip", order.BillingZip);
                    cmd.Parameters.AddWithValue("@address", order.Address);
                    cmd.Parameters.AddWithValue("@phone", order.Phone);
                    cmd.Parameters.AddWithValue("@date", order.Date);
                    cmd.Parameters.AddWithValue("@status", true);


                    int id = (int)cmd.ExecuteScalar();

                    order.Id = id;
                }
            }
        }

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
			    SELECT Id, UserId, Total, cardNum,
				       Expiration, NameOnCard, BillingZip,
				        Address, Phone, Date, Status
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
                            Total = (int)reader.GetDecimal(reader.GetOrdinal("Total")),
                            CardNum = reader.GetString(reader.GetOrdinal("CardNum")),
                            Expiration = reader.GetString(reader.GetOrdinal("Expiration")),
                            NameOnCard = reader.GetString(reader.GetOrdinal("NameOnCard")),
                            BillingZip = reader.GetString(reader.GetOrdinal("BillingZip")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            Phone = reader.GetString(reader.GetOrdinal("Phone")),
                            Date = reader.GetString(reader.GetOrdinal("Date")),
                            Status = reader.GetBoolean(reader.GetOrdinal("Status")),
                        };
                        orders.Add(order);
                    }
                    reader.Close();
                    return orders;
                }
            }

        }



        public List<BlendOrder> GetBlendOrderByOrderId(int orderId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
			    SELECT Blend.id AS BlendId, BlendOrder.id as BlendOrderId, Blend.[name] as Name,BlendOrder.orderId,
[Order].nameOnCard, [Order].id
FROM BlendOrder
LEFT JOIN Blend ON Blend.id = BlendOrder.blendId
LEFT JOIN [Order] ON [Order].id = BlendOrder.orderId
WHERE BlendOrder.OrderId = @orderId
			    ";
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<BlendOrder> blendOrders = new List<BlendOrder>();
                    while (reader.Read())
                    {
                        BlendOrder blendOrder = new BlendOrder()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("BlendId")),
                            OrderId = reader.GetInt32(reader.GetOrdinal("OrderId")),
                            BlendId = reader.GetInt32(reader.GetOrdinal("BlendOrderId")),
                            BlendName = reader.GetString(reader.GetOrdinal("Name")),
                        };
                        blendOrders.Add(blendOrder);
                    }
                    return blendOrders;
                }
            }
        }

        public void CreateBlendOrder(BlendOrder blendOrder)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO BlendOrder
                    (OrderId, BlendId)
                    OUTPUT INSERTED.ID
                    VALUES (@orderId, @BlendId);
                    ";

                    cmd.Parameters.AddWithValue("@orderId", blendOrder.OrderId);
                    cmd.Parameters.AddWithValue("@BlendId", blendOrder.BlendId);

                    int id = (int)cmd.ExecuteScalar();

                    blendOrder.Id = id;
                }
            }
        }


        public void UpdateBlendOrder(BlendOrder blendOrder)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    UPDATE BlendOrder
                    SET
                        BlendId = @blendId
                    WHERE Id = @id;
                    ";

                    cmd.Parameters.AddWithValue("@id", blendOrder.Id);
                    cmd.Parameters.AddWithValue("@blendId", blendOrder.BlendId);



                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void DeleteBlendOrder(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    DELETE FROM BlendOrder
                    WHERE Id = @id
                    ";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public BlendOrder GetBlendOrderById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      SELECT 
                                        Id, BlendId, OrderId
                                      FROM [BlendOrder]
                                      WHERE Id = @Id
                                      ";
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        BlendOrder blendOrder = new BlendOrder()
                        {

                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                           BlendId = reader.GetInt32(reader.GetOrdinal("BlendId")),
                            OrderId = (int)reader.GetInt32(reader.GetOrdinal("OrderId")),

                        };

                        reader.Close();
                        return blendOrder;
                    }
                    reader.Close();
                    return null;
                }
            }

        }
    }
}