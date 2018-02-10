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


        public User Login(Object a,string returnUrl)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new User();

                var cmd = new NpgsqlCommand("\"login\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new User
                    {
                        UserId = reader.GetFieldValue<int>(0),
                        username = reader.GetFieldValue<string>(1),
                        password = reader.GetFieldValue<string>(2),
                        LastLogon = reader.GetFieldValue<DateTime>(3),
                        HouseId = reader.GetFieldValue<int>(4)
                    };
                }
                con.Close(); con.Dispose();
                return results;

            }
        }


        public int PostMovie(PostMovie movie)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                int result;

                movie.Title = movie.Title;
                movie.GenreId = movie.GenreId;
                //movie.Synopsis = movie.Synopsis;

                movie.Synopsis = movie.Synopsis;
                movie.PosterUrl = movie.PosterUrl;
                movie.TrailerUrl = movie.TrailerUrl;
                movie.Amount = movie.Amount;
                movie.HouseId = movie.HouseId;

                var cmd = new NpgsqlCommand("\"submitmovie\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqTitle", NpgsqlTypes.NpgsqlDbType.Varchar));
                cmd.Parameters[0].Value = movie.Title;

                cmd.Parameters.Add(new NpgsqlParameter("reqGenreId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[1].Value = movie.GenreId;

                cmd.Parameters.Add(new NpgsqlParameter("reqSynopsis", NpgsqlTypes.NpgsqlDbType.Varchar));
                cmd.Parameters[2].Value = movie.Synopsis;

                cmd.Parameters.Add(new NpgsqlParameter("reqPosterUrl", NpgsqlTypes.NpgsqlDbType.Varchar));
                cmd.Parameters[3].Value = movie.PosterUrl;

                cmd.Parameters.Add(new NpgsqlParameter("reqTrailerUrl", NpgsqlTypes.NpgsqlDbType.Varchar));
                cmd.Parameters[4].Value = movie.TrailerUrl;

                cmd.Parameters.Add(new NpgsqlParameter("reqAmount", NpgsqlTypes.NpgsqlDbType.Varchar));
                cmd.Parameters[5].Value = movie.Amount;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[6].Value = movie.HouseId;

                
                con.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                con.Dispose();
                return result;
            }
        }


        public List<Movie> GetAllMovie(int houseId)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<Movie>();

                var cmd = new NpgsqlCommand("\"getallmovies\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = houseId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new Movie
                    {
                        MovieId = reader.GetFieldValue<int>(0),
                        Title = reader.GetFieldValue<string>(1),
                        GenreName = reader.GetFieldValue<string>(2),
                        Synopsis = reader.GetFieldValue<string>(3),
                        PosterUrl = reader.GetFieldValue<string>(4),
                        TrailerUrl = reader.GetFieldValue<string>(5),
                        Amount = reader.GetFieldValue<string>(6),
                        HouseName = reader.GetFieldValue<string>(7),
                        ReleaseDate = reader.GetFieldValue<DateTime>(8)
                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }



        public List<Booking> GetAllBooking(int houseId)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<Booking>();

                var cmd = new NpgsqlCommand("\"getbookingforhouse\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = houseId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new Booking
                    {
                        BookingId = reader.GetFieldValue<int>(0),
                        Title = reader.GetFieldValue<string>(1),
                        FullName = reader.GetFieldValue<string>(2),
                        BookingDate = reader.GetFieldValue<DateTime>(3),
                        HouseId = reader.GetFieldValue<int>(4),
                        PaymentName = reader.GetFieldValue<string>(5),
                        Amount = reader.GetFieldValue<string>(6),
                        HouseName = reader.GetFieldValue<string>(7),
                        Day = reader.GetFieldValue<string>(8),
                        Time = reader.GetFieldValue<string>(9)

                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }


        public List<Customer> GetAllCustomers(int houseId)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<Customer>();

                var cmd = new NpgsqlCommand("\"getcustomers\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = houseId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new Customer
                    {
                        CustomerId = reader.GetFieldValue<int>(0),
                        FullName = reader.GetFieldValue<string>(1),
                        Phone = reader.GetFieldValue<string>(2),
                        Address = reader.GetFieldValue<string>(3),
                        Email = reader.GetFieldValue<string>(4),
                        HouseId = reader.GetFieldValue<int>(5)
                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }

        public List<House> GetAllHouses(int houseId)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<House>();

                var cmd = new NpgsqlCommand("\"gethouse\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = houseId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new House
                    {
                        HouseId = reader.GetFieldValue<int>(0),
                        HouseName = reader.GetFieldValue<string>(1),
                        LocationName = reader.GetFieldValue<string>(2),
                        logoFilePath = reader.GetFieldValue<string>(3)
                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }


    }
}
