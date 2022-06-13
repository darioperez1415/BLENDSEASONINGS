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
                    cmd.CommandText = @"SELECT Blend.name, Blend.weight, Blend.id, Ingredient.blendId, Ingredient.spiceId, 
                                                Spice.id, Spice.imageUrl, Spice.name, Spice.price, Spice.weight
                                                FROM Blend
                                                INNER JOIN Ingredient
                                                On Blend.id = Ingredient.blendId
                                                INNER JOIN Spice
                                                ON Ingredient.spiceId = Spice.id
                                                Order by Blend.id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Blend> blends = new List<Blend>();
                    while (reader.Read())
                    {
                        Blend blend = new Blend()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Weight = reader.GetDecimal(reader.GetOrdinal("Weight")),
                          //  Ingredients = reader.(reader.GetOrdinal("Ingredients"))
                        };
                        blends.Add(blend);
                    }
                    reader.Close();
                    return blends;
                }
            }
        }
    }
}
