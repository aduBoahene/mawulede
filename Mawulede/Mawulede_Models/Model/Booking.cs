using System;
using System.Collections.Generic;
using System.Text;

namespace Mawulede_Models.Model
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int MovieId { get; set; }
        public DateTime BookingDate { get; set; }
        public String PaymentMethod { get; set; }
        public int AmountPaid { get; set; }
        public int HouseId { get; set; }
    }
}
