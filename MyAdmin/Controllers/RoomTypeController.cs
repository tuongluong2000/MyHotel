using Model.Entities;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAdmin.Controllers
{
    public class RoomTypeController : BaseController
    {
        // GET: RoomType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id = 0)
        {
            using (var db = new MyDBContext())
            {
                RoomType roomType;
                if(id > 0)
                {
                    roomType = db.RoomTypes.FirstOrDefault(x => x.ID == id);
                }
                else
                {
                    roomType = new RoomType();
                }
                return View(roomType);
            }
        }

        [HttpPost]
        public ActionResult Create(RoomType roomType)
        {
            var res = new ServiceResponse();

            try
            {
                using (var db = new MyDBContext())
                {
                    // Mode Update
                    if(roomType.ID > 0)
                    {
                        var roomtypeInDB = db.RoomTypes.FirstOrDefault(x => x.ID == roomType.ID);
                        roomtypeInDB.Name = roomType.Name;
                        roomtypeInDB.Price = roomType.Price;
                        roomtypeInDB.Size = roomType.Size;
                        roomtypeInDB.Capacity = roomType.Capacity;
                        roomtypeInDB.Bed = roomType.Bed;
                        roomtypeInDB.Services = roomType.Services;
                        roomtypeInDB.Image = roomType.Image;
                        roomtypeInDB.Description = roomType.Description;
                    }
                    // Mode Insert
                    else
                    {
                        db.RoomTypes.Add(roomType);
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

        public ActionResult GetAll()
        {
            var res = new ServiceResponse();

            try
            {
                using (var db = new MyDBContext())
                {
                    res.Data = db.RoomTypes.ToList();
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
                    var containsRoom = db.Rooms.Any(x => x.Type == id);
                    if(containsRoom)
                    {
                        res.Data = -1;
                    }
                    else
                    {
                        var roomType = db.RoomTypes.FirstOrDefault(x => x.ID == id);

                        db.RoomTypes.Remove(roomType);
                        db.SaveChanges();
                        res.Data = 1;
                    }
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