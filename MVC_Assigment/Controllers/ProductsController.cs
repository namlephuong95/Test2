using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MVC_Assigment.Data;
using MVC_Assigment.Models;

namespace MVC_Assigment.Controllers
{
    public class ProductsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Products
        public ActionResult Index()
        {
            //ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName");
            List<SelectListItem> items = new SelectList(db.Categories, "CateId", "CateName").ToList();
            items.Insert(0, (new SelectListItem { Text = "Select All--", Value = "0" }));
            ViewBag.CateId = items;
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }
        public ActionResult FilterAjax(int id)
        {
            var products = db.Products.Include(p => p.Category).ToList();
            if (id != 0)
            {
                var cate = db.Categories.Find(id);
                products = cate.ListProducts;
            }
            return PartialView("_FilterAjax",products);
        }
        public ActionResult ProductSearch(string keyword)
        {
            // tai sao function lap lai 3 lan?
            Debug.WriteLine(keyword);
            var products = db.Products.Where(p => p.ProdName.Contains(keyword));
            return View("_FilterAjax", products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdId,ProdCode,ProdName,ProdPrice,ProdDescription,ProdThumbnail,CateId")] Product product, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", product.CateId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", product.CateId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdId,ProdCode,ProdName,ProdPrice,ProdDescription,ProdThumbnail,CateId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CateId = new SelectList(db.Categories, "CateId", "CateName", product.CateId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
