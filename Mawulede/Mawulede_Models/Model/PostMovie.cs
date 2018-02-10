﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawulede_Models.Model
{
    public class PostMovie
    {

        public int MovieId { get; set; }
        public String Title { get; set; }
        public int GenreId { get; set; }
        public String Synopsis { get; set; }
        public String PosterUrl { get; set; }
        public String TrailerUrl { get; set; }
        public String Amount { get; set; }
        public int HouseId { get; set; }
    }
}
