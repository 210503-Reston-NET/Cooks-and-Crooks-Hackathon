using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRModels
{
    public class Reservation
    {
        public Reservation() { }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }

        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }

    }
}
