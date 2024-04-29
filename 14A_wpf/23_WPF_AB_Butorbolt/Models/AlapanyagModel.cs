using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace _23_WPF_AB_Butorbolt.Models
{
    public class AlapanyagModel
    {
        public int? id { get; set; }
        public string megnevezes { get; set; }

        public AlapanyagModel(MySqlDataReader reader)
        {
            this.id = (int?)Convert.ToInt32(reader["id"]);
            this.megnevezes = reader["megnevezes"].ToString();
        }

        public AlapanyagModel(int? id, string megnevezes)
        {
            this.id = id;
            this.megnevezes = megnevezes;
        }

        public static List<AlapanyagModel> select()
        {
            var lista = new List<AlapanyagModel>();
            using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                con.Open();
                var sql = "SELECT * FROM alapanyag";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AlapanyagModel(reader));
                        }
                    }
                }
                con.Close();
            }
            return lista;
        }
    }
}
