using BLENDSEASONINGS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BLENDSEASONINGS.Repos
{
    public class SpiceRepository : ISpiceRepository
    {
        private readonly IConfiguration _config;

        public SpiceRepository(IConfiguration config)
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
        public List<Spice> GetAllSpices()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id,
                                               Name,
                                               Weight,
                                               Price,
                                               ImageUrl
                                        FROM[Spice]";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Spice> spices = new List<Spice>();
                    while (reader.Read())
                    {
                        Spice spice = new Spice()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Weight = reader.GetDecimal(reader.GetOrdinal("Weight")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                        };
                        spices.Add(spice);
                    }
                    reader.Close();
                    return spices;
                }
            }
        }

        public Spice GetSpiceById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                Spice spice = null;

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id,
                                               Name,
                                               Weight, 
                                               Price, 
                                               ImageUrl
                                        FROM Spice
                                        WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        spice = new Spice()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Weight = reader.GetDecimal(reader.GetOrdinal("Weight")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"))
                        };
                    }
                    reader.Close();
                }
                return spice;
            }
        }
    }
}
