using System;    
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;    
using System.Linq;    
using System.Web;    
namespace RRWebUI.Models
{
    public class Locations
    {
        public Locations()
        {}
        public Locations(string cityName, double lat, double lon, string name)
        {
            CityName = cityName;
            Latitude = lat;
            Longitude = lon;
            Name = name;
        }
        public int Id { get; set; }    
        [Required(ErrorMessage ="Please enter city name")]    
        [Display(Name ="City Name")]    
       
        public string Name { get; set; }    
        public double Latitude { get; set; }    
        public double Longitude { get; set; }    
        public string CityName { get; set; }  

        public string State { get; set;}
        public string Category { get; set; } 
    }
}