using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RRBL;
using RRModels;
using RRWebUI.Models;

namespace RRWebUI.Controllers
{
    public class ReservationController : Controller
    {
        private IRestaurantBL _restaurantBL;
        private IReservationBL _reservationBL;
        public ReservationController(IRestaurantBL restaurantBL, IReservationBL reservationBL)
        {
            _restaurantBL = restaurantBL;
            _reservationBL = reservationBL;
        }

        // GET: ReservationController
        public ActionResult Index(int id)
        {
            ViewBag.Restaurant = _restaurantBL.GetRestaurantById(id);
            List<ReservationVM> reservations = _reservationBL.GetReservationsByCustomerRestaurant(0, id).Select(res => new ReservationVM(res)).ToList();
            return View(reservations);
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            return View();
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
