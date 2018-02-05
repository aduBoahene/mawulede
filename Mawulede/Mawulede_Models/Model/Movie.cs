using System;
using System.Collections.Generic;
using System.Text;

namespace Mawulede_Models.Model
{
    public class Movie
    {
        public int MovieId { get; set; }
        public String Title { get; set; }
        public String GenreId { get; set; }
        public String Synopsis { get; set; }
        public String PosterUrl { get; set; }
        public String TrailerUrl { get; set; }
        public String Amount { get; set; }
        public String ShowMomentId { get; set; }
        public String HouseId { get; set; }
    }
}
