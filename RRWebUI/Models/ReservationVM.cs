using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRWebUI.Models
{
    public class ReservationVM
    {
        public ReservationVM()
        {
        }

        public ReservationVM(Reservation reservation)
        {
            Id = reservation.Id;
            CustomerId = reservation.CustomerId;
            RestaurantId = reservation.RestaurantId;
            ReservationDate = reservation.ReservationDate;
            PartySize = reservation.PartySize;
        }

        public ReservationVM(int restaurantId, int customerId)
        {
            RestaurantId = restaurantId;
            CustomerId = customerId;
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
    }
}
