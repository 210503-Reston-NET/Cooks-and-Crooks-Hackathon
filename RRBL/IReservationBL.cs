using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRDL;
using RRModels;

namespace RRBL
{
    public interface IReservationBL
    {
        Reservation AddResevation(Reservation reservation);

        List<Reservation> GetReservationsByCustomer(int id);

        List<Reservation> GetReservationsByRestaurant(int id);

        List<Reservation> GetReservationsByCustomerRestaurant(string customerId, int RestaurantId);
    }
}