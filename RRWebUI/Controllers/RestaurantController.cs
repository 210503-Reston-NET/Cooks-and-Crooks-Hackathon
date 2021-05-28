using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RRBL;
using RRModels;
using RRWebUI.Models;
using System;
using System.IO;
using System.Linq;

namespace RRWebUI.Controllers
{
    [Authorize]
    public class RestaurantController : Controller
    {
        private IRestaurantBL _restaurantBL;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RestaurantController(IRestaurantBL restaurantBL, IWebHostEnvironment webHostEnvironment)
        {
            _restaurantBL = restaurantBL;
            this._webHostEnvironment = webHostEnvironment;
        }
        // GET: RestaurantController
        // Actions are public methods in controllers that respond to client requests
        // You can have specific actions respond to specific requests,
        // you can also have actions, that respond to multiple kinds of requests
        // You just have to map the request type to the action properly

        public ActionResult Index()
        {
            // You have different kinds of Views:
            // Strongly typed views - tied to a model, you declare the model at the top of the page with
            //                          @model DataType
            // Weakly typed views - not tied to a model. You can still pass data to it via, viewbag
            //                      viewdata, tempdata etc
            // Dynamic views - pass a model, let view figure it out. @model dynamic
            // This is an example of a strongly typed view
            return View(_restaurantBL
                .GetAllRestaurants()
                .Select(restaurant => new RestaurantVM(restaurant))
                .ToList()
                );
        }

        // GET: RestaurantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantVM restaurantVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Save image to wwwroot/images
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(restaurantVM.Image.FileName);
                    string extension = Path.GetExtension(restaurantVM.Image.FileName);
                    restaurantVM.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath+"/images/", fileName);
                    using (var fileStream = new FileStream(path,FileMode.Create))
                    {
                        restaurantVM.Image.CopyToAsync(fileStream);
                    }

                    _restaurantBL.AddRestaurant(new Restaurant
                        {
                            Name = restaurantVM.Name,
                            City = restaurantVM.City,
                            State = restaurantVM.State,
                            imageName = restaurantVM.ImageName,
                            ImageFile = restaurantVM.Image
                        }
                    );
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new RestaurantVM(_restaurantBL.GetRestaurantById(id)));
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RestaurantVM restaurantVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Save image to wwwroot/images
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(restaurantVM.Image.FileName);
                    string extension = Path.GetExtension(restaurantVM.Image.FileName);
                    restaurantVM.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        restaurantVM.Image.CopyToAsync(fileStream);
                    }
                    _restaurantBL.UpdateRestaurant(new Restaurant(restaurantVM.Id, restaurantVM.Name, restaurantVM.City, restaurantVM.State, restaurantVM.ImageName, restaurantVM.Image));
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new RestaurantVM(_restaurantBL.GetRestaurantById(id)));
        }

        // POST: RestaurantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _restaurantBL.DeleteRestaurant(_restaurantBL.GetRestaurantById(id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}