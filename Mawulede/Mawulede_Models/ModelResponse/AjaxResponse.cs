using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawulede_Models.ModelResponse
{
    public class AjaxResponse
    {
        public bool Success { get; set; }
        public string Response { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
