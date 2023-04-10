using Model.Entities;
using Model.Models;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MyAdmin.Controllers
{
    public class BookingController : BaseController
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id = 0)
        {
            using (var db = new MyDBContext())
            {
                Booking booking;
                if (id > 0)
                {
                    booking = db.Bookings.FirstOrDefault(x => x.ID == id);
                }
                else
                {
                    booking = new Booking();
                }
                return View(booking);
            }
        }

        [HttpPost]
        public ActionResult Create(Booking booking)
        {
            var res = new ServiceResponse();

            try
            {
                using (var db = new MyDBContext())
                {
                    // Mode Update
                    if (booking.ID > 0)
                    {
                        var bookingInDB = db.Bookings.FirstOrDefault(x => x.ID == booking.ID);
                        bookingInDB.RoomTypeID = booking.RoomTypeID;
                        bookingInDB.CheckIn = booking.CheckIn;
                        bookingInDB.CheckOut = booking.CheckOut;
                        bookingInDB.GuessName = booking.GuessName;
                        bookingInDB.Email = booking.Email;
                        bookingInDB.PhoneNo = booking.PhoneNo;
                        bookingInDB.TotalPrice = booking.TotalPrice;
                        bookingInDB.Status = booking.Status;

                        if(booking.Status != bookingInDB.Status && booking.Status == 999)
                        {
                            booking.CompletedDate = DateTime.Now;
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            using (var db = new MyDBContext())
            {
                var booking = db.Bookings.Include(x => x.RoomType).FirstOrDefault(x => x.ID == id);
                return View(booking);
            }
        }

        public ActionResult GetAll()
        {
            var res = new ServiceResponse();

            try
            {
                using (var db = new MyDBContext())
                {
                    res.Data = db.Bookings.Include(x => x.RoomType).Select(x => new BookingViewModel() { 
                        ID = x.ID,
                        RoomTypeID = x.RoomTypeID,
                        CheckIn = x.CheckIn,
                        CheckOut = x.CheckOut,
                        GuessName = x.GuessName,
                        Email = x.Email,
                        PhoneNo = x.PhoneNo,
                        TotalPrice = x.TotalPrice,
                        Status = x.Status,
                        RoomTypeName = x.RoomType.Name,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var res = new ServiceResponse();

            try
            {
                using (var db = new MyDBContext())
                {
                    var booking = db.Bookings.FirstOrDefault(x => x.ID == id);

                    // Chỉ cho phép xóa những booking có trạng thái Hủy
                    if(booking.Status == -1)
                    {
                        db.Bookings.Remove(booking);
                        db.SaveChanges();
                        res.Data = 1;
                    }
                    else
                    {
                        res.Data = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CountPending()
        {
            var res = new ServiceResponse();

            try
            {
                using (var db = new MyDBContext())
                {
                    var counter = db.Bookings.Count(x => x.Status == 0);
                    res.Data = counter;
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