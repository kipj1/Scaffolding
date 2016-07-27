using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data; 
using System.Data.Entity; 
using System.Net; 
using Scaffolding.Models;

namespace Scaffolding.Controllers
{
    public class HomeController : Controller
    {
        private CustomerContext db = new CustomerContext();

        public ActionResult About()
        {
            //--Passs back in the VeiwBage a message
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //--Passs back in the VeiwBage a message
            ViewBag.Message = "Your contact page.";

            return View();
        }

         // GET: Customers 
         public ActionResult Index()
         {
            //---Return customers to show when on the index page----
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5 
        public ActionResult Details(string id)
         { 
             if (id == null) 
             {
                //---Through "BadRequest" error back if id = null------
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
             }
            //---Find customer based in index------
            Customer customer = db.Customers.Find(id); 
             if (customer == null) 
             {
                //---Through "HttpNotFound" error back if customer = null------
                return HttpNotFound(); 
             } 
             return View(customer); 
         } 
 
 
         // GET: Customers/Create 
         public ActionResult Create()
         { 
             return View(); 
         } 
 

         // POST: Customers/Create 
         [HttpPost] 
         [ValidateAntiForgeryToken] 
         public ActionResult Create([Bind(Include = "CustomerCode,CustomerName")] Customer customer)
         { 
             if (ModelState.IsValid) 
             { 
                 db.Customers.Add(customer); 
                 db.SaveChanges(); 
                 return RedirectToAction("Index"); 
             } 
 
 
             return View(customer); 
         } 
 
 
         // GET: Customers/Edit/5 
         public ActionResult Edit(string id)
         { 
             if (id == null) 
             {
                //---Through "BadRequest" error back if id = null------
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
             }
            //---Find Customer With id as Index------
            Customer customer = db.Customers.Find(id); 
             if (customer == null) 
             {
                //---Through "HttpNotFound" error back if customer = null------
                return HttpNotFound(); 
             } 
             return View(customer); 
         } 
 
 
         // POST: Customers/Edit/5 
         [HttpPost] 
         [ValidateAntiForgeryToken] 
         public ActionResult Edit([Bind(Include = "CustomerCode,CustomerName")] Customer customer)
         { 
             if (ModelState.IsValid) 
             {
                 //---Tell Entity Framework you want to perform a update/edit and then save changes then redirect back to index page------
                 db.Entry(customer).State = EntityState.Modified; 
                 db.SaveChanges(); 
                 return RedirectToAction("Index"); 
             } 
             return View(customer); 
         } 
 
 
         // GET: Customers/Delete/5 
         public ActionResult Delete(string id)
         { 
             if (id == null) 
             {
                //---Through "BadRequest" error back if id = null------
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
             } 
            Customer customer = db.Customers.Find(id); 
             if (customer == null) 
             {
                //---Through "HttpNotFound" error back if customer = null------
                return HttpNotFound(); 
             } 
             return View(customer); 
         } 
 
 
         // POST: Customers/Delete/5 
         [HttpPost, ActionName("Delete")] 
         [ValidateAntiForgeryToken] 
         public ActionResult DeleteConfirmed(string id)
         { 
            //---Delete Customer With id as Index------
             Customer customer = db.Customers.Find(id); 
             db.Customers.Remove(customer); 
             db.SaveChanges(); 
             return RedirectToAction("Index"); 
         } 
 
 
         protected override void Dispose(bool disposing)
         { 
             if (disposing) 
             {
                //---Dispose db object------
                db.Dispose(); 
             } 
             base.Dispose(disposing); 
         } 

    }
}