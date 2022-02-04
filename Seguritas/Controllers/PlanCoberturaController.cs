using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguritas.Controllers
{
    public class PlanCoberturaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            BL.PlanM plan = new BL.PlanM();

            plan.Nombre = plan.Nombre == null ? "" : plan.Nombre;
            plan.Descripcion = plan.Descripcion == null ? "" : plan.Descripcion;
            plan.FechaModificacion = plan.FechaModificacion == null ? "" : plan.FechaModificacion;

            BL.Result result = BL.Plan.GetAll();

            plan.Planes = result.Objects;

            return View(plan);
        }

        [HttpGet]
        public ActionResult CoberturasAsignadas(int idPlan)
        {
            BL.PlanCoberturaM planCobertura = new BL.PlanCoberturaM();

            planCobertura.Plan = new BL.PlanM();
            planCobertura.Plan.IdPlan = idPlan;

            BL.Result resultPlan = BL.Plan.GetById(idPlan);
            planCobertura.Plan = ((BL.PlanM)resultPlan.Object);

            BL.Result resultCoberturas = BL.PlanCobertura.CoberturaGetByIdPlan(idPlan);
            planCobertura.PlanCoberturas = resultCoberturas.Objects;

            return View(planCobertura);
        }

        [HttpGet]
        public ActionResult CoberturasNoAsignadas(int idPlan)
        {
            BL.PlanCoberturaM planCobertura = new BL.PlanCoberturaM();
            planCobertura.Plan = new BL.PlanM();
            planCobertura.Plan.IdPlan = idPlan;

            BL.Result resultPlan = BL.Plan.GetById(idPlan);
            planCobertura.Plan = ((BL.PlanM)resultPlan.Object);

            BL.Result resultCoberturasNoAsignadas = BL.PlanCobertura.CoberturasNoAsignadasByIdPlan(idPlan);
            planCobertura.PlanCoberturas = resultCoberturasNoAsignadas.Objects;

            return View(planCobertura);
        }

        [HttpGet]
        public ActionResult CoberturaDeleteByIdPlanCobertura(int idPlanCobertura, int idPlan)
        {
            BL.PlanCoberturaM planCobertura = new BL.PlanCoberturaM();
            planCobertura.Plan = new BL.PlanM();
            planCobertura.Plan.IdPlan= idPlan;

            planCobertura.IdPlanCobertura = idPlanCobertura;

            BL.Result result = BL.PlanCobertura.CoberturaDeleteByIdPlanCobertura(idPlanCobertura);

            ViewBag.CoberturasAsignadas = true;
            ViewBag.idPlan = idPlan;

            if (result.Correct)
            {
                ViewBag.Mensaje = "Cobertura eliminada correctamente";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo eliminar correctamente";
            }

            return PartialView("Modal");
        }


        [HttpPost]
        public ActionResult PlanCoberturaAdd(BL.PlanCoberturaM planCobertura )
        {
            foreach (string cobertura in planCobertura.PlanCoberturas)
            {
                int idCobertura = int.Parse(cobertura);
                BL.PlanCobertura.PlanCoberturaAdd(planCobertura.Plan.IdPlan, idCobertura);                
            }

            return RedirectToAction("CoberturasAsignadas", "PlanCobertura", new { idPlan = planCobertura.Plan.IdPlan });
        }
    }
}
