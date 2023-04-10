using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAdmin.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            using (var db = new MyDBContext())
            {
                var now = DateTime.Now;

                ViewBag.MonthlyEarning = db.Bookings.Where(x => x.Status == 999 && ((x.CompletedDate.Value.Month - now.Month) + 12 * (x.CompletedDate.Value.Year - now.Year)) <= 1).Sum(x => x.TotalPrice);
                ViewBag.AnnualEarning = db.Bookings.Where(x => x.Status == 999 &&  now.Year - x.CompletedDate.Value.Year <= 1).Sum(x => x.TotalPrice);
                ViewBag.TotalBooking = db.Bookings.Count();
                ViewBag.BookingCompleted = db.Bookings.Count(x => x.Status == 999);

                ViewBag.EarningsOverview = db.Bookings.Where(x => x.Status == 999 && x.CompletedDate != null)
                                                        .GroupBy(x => x.CompletedDate.Value.Month)
                                                        .Select(x => new { 
                                                            Key = x.Key,
                                                            Value = x.Sum(y => y.TotalPrice)
                                                        }).ToList();

                ViewBag.RoomTypeRating = db.Bookings.Where(x => x.Status == 999 && x.CompletedDate != null)
                                                    .GroupBy(x => x.RoomType)
                                                    .Select(x => new {
                                                        Key = x.Key.Name,
                                                        Value = x.Count()
                                                    }).ToList();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}