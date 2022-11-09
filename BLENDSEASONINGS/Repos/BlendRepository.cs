using BLENDSEASONINGS.Models;
using Microsoft.Data.SqlClient;

namespace BLENDSEASONINGS.Repos
{
    public class BlendRepository : IBlendRepository
    {
        private readonly IConfiguration _config;
        public BlendRepository(IConfiguration config)
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

        public List<Blend> GetAllBlends()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id,
                                                Name, 
                                                Ingredients, 
                                                Price, 
                                                ImageUrl
                                        FROM Blend";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Blend> blends = new List<Blend>();
                    while (reader.Read())
                    {
                        Blend blend = new Blend()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Ingredients = reader.GetString(reader.GetOrdinal("Ingredients")),
                            Price =(int)reader.GetDecimal(reader.GetOrdinal("Price")),
                            ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                        };
                        blends.Add(blend);
                    }
                    reader.Close();
                    return blends;
                }
            }
        }

        public Blend GetBlendById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                Blend blend = null;

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id,
                                                Name, 
                                                Ingredients, 
                                                Price, 
                                                ImageUrl
                                        FROM Blend
                                        WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        blend = new Blend()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Ingredients = reader.GetString(reader.GetOrdinal("Ingredients")),
                            Price = (int)reader.GetDecimal(reader.GetOrdinal("Price")),
                            ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                        };
                    }
                    reader.Close();
                }
                return blend;
            }
        }
    }
}