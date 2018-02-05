using Mawulede_Helpers;
using Mawulede_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Mawulede_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class MovieController : ApiController
    {
        DBHelper _helper;
        HttpRequestMessage req;

        public MovieController()
        {
            _helper = new Mawulede_Helpers.DBHelper();
        }
        public MovieController(DBHelper helper)
        {
            _helper = helper;
        }

        [HttpGet]
        public List<Movie> GetAllMovie()
        {
            var results = new List<Movie>();
            try
            {
                results = _helper.GetAllMovie();
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
