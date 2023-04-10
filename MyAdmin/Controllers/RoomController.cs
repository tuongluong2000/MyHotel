using Model.Entities;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Model.ViewModels;

namespace MyAdmin.Controllers
{
    public class RoomController : BaseController
    {
        // GET: Room
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id = 0)
        {
            using (var db = new MyDBContext())
            {
                Room room;
                if (id > 0)
                {
                    room = db.Rooms.FirstOrDefault(x => x.ID == id);
                }
                else
                {
                    room = new Room();
                }
                return View(room);
            }
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            var res = new ServiceResponse();

            try
            {
                using (var db = new MyDBContext())
                {
                    // Mode Update
                    if (room.ID > 0)
                    {
                        var roomInDB = db.Rooms.FirstOrDefault(x => x.ID == room.ID);
                        roomInDB.Number = room.Number;
                    }
                    // Mode Insert
                    else
                    {
                        db.Rooms.Add(room);
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
                    res.Data = db.Rooms.Include(x => x.RoomType).Select(x => new RoomViewModel()
                    {
                        ID = x.ID,
                        Number = x.Number,
                        Type = x.Type,
                        TypeName = x.RoomType.Name
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
                    var room = db.Rooms.FirstOrDefault(x => x.ID == id);

                    db.Rooms.Remove(room);
                    db.SaveChanges();
                    res.Data = 1;
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