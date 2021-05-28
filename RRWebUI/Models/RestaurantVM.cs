using Microsoft.AspNetCore.Http;
using RRModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RRWebUI.Models
{
    /// <summary>
    /// Restaurant View Model. This contains the neccessary information I want presented to the
    /// end user, or some info that is vital to data processing (i.e the id)
    /// </summary>
    public class RestaurantVM
    {
        public RestaurantVM(Restaurant restaurant)
        {
            Id = restaurant.Id;
            Name = restaurant.Name;
            City = restaurant.City;
            State = restaurant.State;
            ImageName = restaurant.imageName;
            Image = restaurant.ImageFile;
        }

        public RestaurantVM()
        {
        }
        

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }
            
        [DisplayName("State or Province")]
        [Required]
        public string State { get; set; }
        public string ImageName { get; set; }

        [DisplayName("Restaurant Image")]
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}