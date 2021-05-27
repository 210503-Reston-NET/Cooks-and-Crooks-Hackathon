using RRModels;
using System.Collections.Generic;

namespace RRBL
{
    public interface IRestaurantBL
    {
        List<Restaurant> GetAllRestaurants();

        Restaurant AddRestaurant(Restaurant restaurant);

        Restaurant GetRestaurant(Restaurant restaurant);

        Restaurant GetRestaurantById(int id);

        Restaurant DeleteRestaurant(Restaurant restaurant);

        Restaurant UpdateRestaurant(Restaurant restaurant);
    }
}