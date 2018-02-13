using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mawulede_WEB.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddMovie()
        {
            return View();
        }

        public ActionResult EditMovie(int? id)
        {

            if (id == null)
            {
                ViewBag.Id = 0;
            }
            else
            {
                ViewBag.Id = id.Value;
            }
            return View();
        }
    }
}