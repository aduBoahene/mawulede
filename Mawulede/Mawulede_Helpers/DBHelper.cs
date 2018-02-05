using Mawulede_Models.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawulede_Helpers
{
    public class DBHelper
    {
        private static string _Ycon = ConfigurationManager.AppSettings["WRITE_CON_STR"];
        public static DBHelper Instance = new DBHelper();
        public static readonly object instance;



        public List<Movie> GetAllMovie()
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<Movie>();

                var cmd = new NpgsqlCommand("\"GetAllMovies\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new Movie
                    {
                        MovieId = reader.GetFieldValue<int>(0),
                        Title = reader.GetFieldValue<string>(1),
                        GenreId = reader.GetFieldValue<string>(2),
                        Synopsis = reader.GetFieldValue<string>(3),
                        PosterUrl = reader.GetFieldValue<string>(4),
                        TrailerUrl = reader.GetFieldValue<string>(5),
                        Amount = reader.GetFieldValue<string>(6),
                        ShowMomentId = reader.GetFieldValue<string>(7),
                        HouseId = reader.GetFieldValue<string>(8)

                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }



    }
}
