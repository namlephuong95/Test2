using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MVC_Assigment.Data;

namespace MVC_Assigment.Controllers
{
    public class TestController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.CateId = new SelectList(db.Categories.ToList(), "CateId", "CateName");
            return View();
        }
        [HttpGet]
        public ActionResult Index(FormCollection form)
        {
            Debug.WriteLine(form["gender"]);
            return PartialView("Index");
        }
        public ActionResult FilterAjax(string keyword, DropDownList dropDownCate, FormCollection form)
        {
            Debug.WriteLine(dropDownCate.SelectedValue);

            Debug.WriteLine(form["CateList"]);

            Debug.WriteLine(keyword);
            Debug.WriteLine("Test");
            return PartialView();
        }
    }
}