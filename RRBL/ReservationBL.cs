using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRDL;
using RRModels;

namespace RRBL
{
    public class ReservationBL : IReservationBL
    {
        private IRepository _repo;
        public ReservationBL(IRepository repo)
        {
            _repo = repo;
        }

        public Reservation AddResevation(Reservation reservation)
        {
            if (ValidReservation(reservation) == false) 
                throw new Exception("The restaurant is busy at that time make a reservation for another time");
            else
            {
                _repo.AddReservation(reservation);
                return reservation;
            }
        }

        /// <summary>
        /// this checks if the reservation is valid given the time and the restaurants capacity
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        private bool ValidReservation(Reservation reservation)
        {
            // This sets the time range in which a new reservation might create a conflict with
            DateTime lowRange = reservation.ReservationDate.AddHours(-2);
            DateTime highRange = reservation.ReservationDate.AddHours(2);

            // This gets the capacity of the restaurant and all the reservations made at that restaurant
            int Capacity = _repo.GetRestaurantById(reservation.RestaurantId).Capacity;
            List<Reservation> restaurantReservations = GetReservationsByRestaurant(reservation.RestaurantId);

            // if the restaurant has no reservation it returns true
            if (restaurantReservations.Count == 0) return true;

            // This loop checks all reservations that conflict with the new reservation and subtracts the reservation
            // from the capacity of the restaurant
            foreach(Reservation res in restaurantReservations)
            {
                if (DateTime.Compare(res.ReservationDate, lowRange) > 0 && DateTime.Compare(res.ReservationDate, highRange) < 0)
                {
                    Capacity -= res.PartySize;
                }
            }

            // This returns true if the capacity is higher than the party size of the reservation
            if (Capacity > reservation.PartySize) return true;
            else
            {
                return false;
            }
        }

        public List<Reservation> GetReservationsByCustomer(int id)
        {
            return _repo.GetReservationByCustomerId(id);
        }

        public List<Reservation> GetReservationsByRestaurant(int id)
        {
            return _repo.GetReservationsByRestaurantId(id);
        }

        public List<Reservation> GetReservationsByCustomerRestaurant(int customerId, int RestaurantId)
        {
            return _repo.GetReservationsByCustomerRestaurant(customerId, RestaurantId);
        }
    }
}
