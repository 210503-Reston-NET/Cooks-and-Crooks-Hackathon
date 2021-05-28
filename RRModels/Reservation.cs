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

        public Reservation(int customerId, int restaurantId, DateTime resDateTime, int size) {
            CustomerId = customerId;
            RestaurantId = restaurantId;
            ReservationDate = resDateTime;
            PartySize = size;
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }

        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }

    }
}
