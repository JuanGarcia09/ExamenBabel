using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguritas.Controllers
{
    public class ClientesController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            BL.Result result = BL.Cliente.GetAll();
            BL.ClienteM cliente = new BL.ClienteM();
            cliente.Clientes = result.Objects;

            return View(cliente);
        }

        [HttpGet]
        public ActionResult Delete(int idCliente)
        {
            BL.Result result = BL.Cliente.Delete(idCliente);

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
