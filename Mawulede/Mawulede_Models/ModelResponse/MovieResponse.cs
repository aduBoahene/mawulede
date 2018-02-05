using Mawulede_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mawulede_Models.ModelResponse
{
    public class MovieResponse:AjaxResponse
    {
        public List<Movie> data { get; set; }
    }
}
