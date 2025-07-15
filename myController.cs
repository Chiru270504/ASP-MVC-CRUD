using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using medamtest.Models;

namespace medamtest.Controllers
{
    public class myController : Controller
    {
        repo db = new repo();
        public ActionResult Index()
        {
            return View(db.GetAll());
        }
        public ActionResult Create()
        {
            return View(new form());
        }
        [HttpPost]
        public ActionResult Create(form f1)
        {
            if (ModelState.IsValid)
            {
                db.AddUser(f1);
                return RedirectToAction("Index");
            }
            return View(f1);
        }
        public ActionResult Edit(int uid)
        {
            var Edituser = db.GetAll().Find(x => x.uid == uid);
            return View(Edituser);
        }
        [HttpPost]
        public ActionResult Edit(form f1)
        {
            if (ModelState.IsValid)
            {
                db.UpdateUser(f1);
                return RedirectToAction("Index");
            }

            return View(f1);
        }
        public ActionResult Delete(int uid)
        {
            db.DeleteUser(uid);
            return RedirectToAction("Index");

        }
    }
}