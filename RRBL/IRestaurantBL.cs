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

        List<Restaurant> GetRecommendation(Customer customer);

        List<Restaurant> GetMatchedRestaurants(string city, string state);
        List<Restaurant> GetMatchedCategory(string city, string state, string category);
        

    }
}