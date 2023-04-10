using Model.Entities;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHotel.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            var roomTypes = new List<RoomType>();

            try
            {
                using (var db = new MyDBContext())
                {
                    roomTypes = db.RoomTypes.ToList();
                }
            }
            catch (Exception ex)
            {
            }

            return View(roomTypes);
        }

        public ActionResult Details(int id)
        {
            RoomType roomType = null;

            try
            {
                using (var db = new MyDBContext())
                {
                    ViewBag.Rooms = db.Rooms.Where(x => x.Type == id).ToList();
                    roomType = db.RoomTypes.FirstOrDefault(x => x.ID == id);
                }
            }
            catch (Exception ex)
            {
            }

            return View(roomType);
        }

        [HttpPost]
        public ActionResult Booking(Booking booking)
        {
            var res = new ServiceResponse();

            try
            {
                using (var db = new MyDBContext())
                {
                    db.Bookings.Add(booking);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}