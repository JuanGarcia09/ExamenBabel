using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguritas.Controllers
{
    public class PlanController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            BL.Result result = BL.Plan.GetAll();
            BL.PlanM plan = new BL.PlanM();
            plan.Planes = result.Objects;

            return View(plan);
        }

        [HttpGet]
        public ActionResult Delete(int idPlan)
        {
            BL.Result result = BL.Plan.Delete(idPlan);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Registro eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar registro";
            }

            return PartialView("Modal");
        }
    }
}
