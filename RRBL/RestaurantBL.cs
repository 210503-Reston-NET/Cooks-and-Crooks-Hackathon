using RRDL;
using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RRBL
{
    /// <summary>
    /// Business logic class for the restaurant model
    /// </summary>
    public class RestaurantBL : IRestaurantBL
    {
        // Some things to note:
        // BL classes are in charge of processing/ sanitizing/ further validating data
        // As the name suggests its in charge of processing logic. For example, how does the ordering process
        // work in a store app.
        // Any logic that is related to accessing the data stored somewhere, should be relegated to the DL
        private IRepository _repo;
        private IReviewBL _reviewBL;

        public RestaurantBL(IRepository repo, IReviewBL reviewBL)
        {
            _repo = repo;
            _reviewBL = reviewBL;
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            // Todo: call a repo method that adds a restaurant
            if (_repo.GetRestaurant(restaurant) != null)
            {
                throw new Exception("Restaurant already exists :<");
            }
            return _repo.AddRestaurant(restaurant);
        }

        public Restaurant DeleteRestaurant(Restaurant restaurant)
        {
            Restaurant toBeDeleted = _repo.GetRestaurant(restaurant);
            if (toBeDeleted != null) return _repo.DeleteRestaurant(toBeDeleted);
            else throw new Exception("Restaurant does not exist. Must've been deleted already :>");
        }

        public List<Restaurant> GetAllRestaurants()
        {
            //Note that this method isn't really dependent on any inputs/parameters, I can just directly call the
            // DL method in charge of getting all restaurants
            return _repo.GetAllRestaurants();
        }

        public List<Restaurant> GetRecommendation(Customer customer)
        {
            Random random = new Random();
            List<Restaurant> restaurants = GetAllRestaurants();
            List<Restaurant> recommendations = new List<Restaurant>();
            foreach (Restaurant restaurant in restaurants)
            {
                if (customer.City.Equals(restaurant.City))
                {
                    Tuple<List<Review>, int> reviews = _reviewBL.GetReviews(restaurant);
                    if (reviews.Item2 >= 3)
                    {
                        recommendations.Add(restaurant);
                    }
                }
            }
            if (!recommendations.Any())
            {
                return null;
            }
            recommendations = recommendations.OrderBy(rec => random.Next()).Take(1).ToList();
            return recommendations;
        }

        public Restaurant GetRestaurant(Restaurant restaurant)
        {
            return _repo.GetRestaurant(restaurant);
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _repo.GetRestaurantById(id);
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            return _repo.UpdateRestaurant(restaurant);
        }
    }
}