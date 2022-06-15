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
                                                Spice.id as SpiceId, Spice.imageUrl, Spice.name as SpiceName, Spice.price, Spice.weight as SpiceWeight
                                                FROM Blend
                                                INNER JOIN Ingredient
                                                On Blend.id = Ingredient.blendId
                                                INNER JOIN Spice
                                                ON Ingredient.spiceId = Spice.id
                                                Order by Blend.id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Blend> blends = new List<Blend>();

                    Blend currentBlend = null;

                    while (reader.Read())
                    {
                        if (currentBlend == null || currentBlend.Name != reader.GetString(reader.GetOrdinal("Name")))
                        {
                            // Get by single remove 48 - 51 
                            if (currentBlend != null)
                            {
                                blends.Add(currentBlend);
                            }
                            currentBlend = new Blend()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Weight = reader.GetDecimal(reader.GetOrdinal("Weight")),
                                Ingredients = new List<Spice> ()
                            };
                        }
                        Spice Ingredient = new Spice()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("SpiceId")),
                            Name = reader.GetString(reader.GetOrdinal("SpiceName")),
                            Weight = reader.GetDecimal(reader.GetOrdinal("SpiceWeight")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                        };
                        currentBlend.Ingredients.Add(Ingredient);
                    }
                    blends.Add(currentBlend);
                    reader.Close();
                    return blends;
                }
            }
        }
        public List<Blend> GetSingleBlend(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Blend.name, Blend.weight, Blend.id, Ingredient.blendId, Ingredient.spiceId, 
                                                Spice.id as SpiceId, Spice.imageUrl, Spice.name as SpiceName, Spice.price, Spice.weight as SpiceWeight
                                                FROM Blend
                                                INNER JOIN Ingredient
                                                On Blend.id = Ingredient.blendId
                                                INNER JOIN Spice
                                                ON Ingredient.spiceId = Spice.id
                                                WHERE Blend.id = 1";

                    cmd.Parameters.AddWithValue("Blend.id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Blend> blend = new List<Blend>();

                    Blend currentBlend = null;

                    while (reader.Read())
                    {
                        if (currentBlend == null || currentBlend.Name != reader.GetString(reader.GetOrdinal("Name")))
                        {
                            currentBlend = new Blend()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Weight = reader.GetDecimal(reader.GetOrdinal("Weight")),
                                Ingredients = new List<Spice>()
                            };
                        }
                        Spice Ingredient = new Spice()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("SpiceId")),
                            Name = reader.GetString(reader.GetOrdinal("SpiceName")),
                            Weight = reader.GetDecimal(reader.GetOrdinal("SpiceWeight")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                        };
                        currentBlend.Ingredients.Add(Ingredient);
                    }
                    blend.Add(currentBlend);
                    reader.Close();
                    return blend;
                }
            }
        }
        public void CreateBlendOrder(Blend blendOrder)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Blend
                    (Name, Weight)
                    OUTPUT INSERTED.ID
                    VALUES (@Name, @Weight);
                    ";

                    cmd.Parameters.AddWithValue("@Name", blendOrder.Name);
                    cmd.Parameters.AddWithValue("@Weight", blendOrder.Weight); ;

                    int id = (int)cmd.ExecuteScalar();

                    blendOrder.Id = id;
                }
            }
        }

        //public void UpdateBlendOrder(Blend blend)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                    UPDATE [BLEND]
        //                    SET 
        //                         Name = @name,
        //                         weight = @weight
        //                    WHERE ID = @id;                           
                                   
        //                ";
        //            cmd.Parameters.AddWithValue("@name", blend.Name);
        //            cmd.Parameters.AddWithValue("@weight", blend.Weight);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}
