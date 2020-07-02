using GetDataAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace GetDataAjax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public JsonResult GetPerson(int? id)
        {
            //Simulando data
            var personList = new List<Persona>();
            personList.Add(new Persona { Id = 1, Name = "Alonso", Age = 23, IsAlive = true });
            personList.Add(new Persona { Id = 2, Name = "Gabriela", Age = 32, IsAlive = false });
            personList.Add(new Persona { Id = 3, Name = "Wen", Age = 25, IsAlive = true });
            personList.Add(new Persona { Id = 4, Name = "Julio", Age = 50, IsAlive = false });

            Persona result = null;
            if(id.HasValue)
            {
                result = personList.Where(p => p.Id == id.Value).FirstOrDefault();
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}