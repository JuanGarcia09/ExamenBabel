using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguritas.Controllers
{
    public class CoberturaController : Controller
    {
       [HttpGet]
        public ActionResult GetAll()
        {
            BL.Result result = BL.Cobertura.GetAll();
            BL.CoberturaM cobertura = new BL.CoberturaM();
            cobertura.Coberturas = result.Objects;

            return View(cobertura);
        }

        [HttpGet]
        public ActionResult Delete(int idCobertura)
        {
            BL.Result result = BL.Cobertura.Delete(idCobertura);            

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
