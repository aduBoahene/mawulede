using Mawulede_Helpers;
using Mawulede_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Mawulede_API.Controllers
{
    public class BookingController : ApiController
    {
        DBHelper _helper;
        HttpRequestMessage req;

        public BookingController()
        {
            _helper = new Mawulede_Helpers.DBHelper();
        }
        public BookingController(DBHelper helper)
        {
            _helper = helper;
        }

        [HttpGet]
        public List<Booking> GetAllBooking(int houseId)
        {
            var results = new List<Booking>();
            try
            {
                results = _helper.GetAllBooking(houseId);
                if (results != null || results.Count > 0)
                {
                    return results;
                }
                else { return null; }

            }
            catch (Exception x)
            {
                return null;
            }
        }

       

    }
}
