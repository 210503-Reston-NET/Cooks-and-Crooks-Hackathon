using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRBL;
using RRModels;
using RRWebUI.Models;
using Microsoft.AspNetCore.Identity;

namespace RRWebUI.Controllers
{
    public class ReservationController : Controller
    {
        private IRestaurantBL _restaurantBL;
        private IReservationBL _reservationBL;
        private UserManager<Customer> _userManager;
        
        public ReservationController(IRestaurantBL restaurantBL, IReservationBL reservationBL, UserManager<Customer> usermanager)
        {
            _restaurantBL = restaurantBL;
            _reservationBL = reservationBL;
            _userManager = usermanager;
        }

        // GET: ReservationController
        public ActionResult Index(int id)
        {
            ViewBag.Restaurant = _restaurantBL.GetRestaurantById(id);
            var user =  _userManager.FindByEmailAsync(User.Identity.Name);


            List<ReservationVM> reservations = _reservationBL.GetReservationsByCustomerRestaurant(user.Id.ToString(), id).Select(res => new ReservationVM(res)).ToList();
            return View(reservations);
        }


        // GET: ReservationController/Create
        public ActionResult Create(int id)
        {
            var user = _userManager.FindByEmailAsync(User.Identity.Name);
            return View(new ReservationVM(id, user.Id));
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationVM reservation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _reservationBL.AddResevation(new Reservation(reservation.CustomerId, reservation.RestaurantId, reservation.ReservationDate, reservation.PartySize));
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
