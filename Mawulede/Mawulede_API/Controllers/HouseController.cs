using Mawulede_Helpers;
using Mawulede_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mawulede_API.Controllers
{
    public class HouseController : ApiController
    {

        DBHelper _helper;
        HttpRequestMessage req;

        public HouseController()
        {
            _helper = new Mawulede_Helpers.DBHelper();
        }
        public HouseController(DBHelper helper)
        {
            _helper = helper;
        }


        //[HttpGet]
        //public List<House> GetAllCustomers(int houseId)
        //{
        //    var results = new List<House>();
        //    try
        //    {
        //        results = _helper.GetAllHouses(houseId);
        //        if (results != null || results.Count > 0)
        //        {
        //            return results;
        //        }
        //        else { return null; }

        //    }
        //    catch (Exception x)
        //    {
        //        return null;
        //    }
        //}

        [HttpGet]
        public List<House> GetOneHouseDetails(int houseId)
        {
            var results = new List<House>();
            try
            {
                results = _helper.GetHouseDetail(houseId);
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
