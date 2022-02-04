using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguritas.Controllers
{
    public class ClientePlanController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            BL.ClienteM cliente = new BL.ClienteM();

            cliente.Nombre = cliente.Nombre == null ? "" : cliente.Nombre;
            cliente.ApellidoPaterno = cliente.ApellidoPaterno == null ? "" : cliente.ApellidoPaterno;
            cliente.ApellidoMaterno = cliente.ApellidoMaterno == null ? "" : cliente.ApellidoMaterno;

            BL.Result result = BL.Cliente.GetAll();

            cliente.Clientes = result.Objects;

            return View(cliente);
        }

        [HttpGet]
        public ActionResult PlanesAsignados(int idCliente)
        {
            BL.ClientePlanM clientePlan = new BL.ClientePlanM();

            clientePlan.Cliente = new BL.ClienteM();
            clientePlan.Cliente.IdCliente = idCliente;

            BL.Result resultCliente = BL.Cliente.GetById(idCliente);
            clientePlan.Cliente = ((BL.ClienteM)resultCliente.Object);

            BL.Result resultPlanes = BL.ClientePlan.PlanesGetByIdCliente(idCliente);
            clientePlan.ClientePlanes = resultPlanes.Objects;

            return View(clientePlan);
        }

        [HttpGet]
        public ActionResult PlanesNoAsignados(int idCliente)
        {
            BL.ClientePlanM clientePlan = new BL.ClientePlanM();
            clientePlan.Cliente = new BL.ClienteM();
            clientePlan.Cliente.IdCliente = idCliente;

            BL.Result resultCliente = BL.Cliente.GetById(idCliente);
            clientePlan.Cliente = ((BL.ClienteM)resultCliente.Object);

            BL.Result resultPlanesNoAsignados = BL.ClientePlan.PlanesNoAsignadosByIdCliente(idCliente);
            clientePlan.ClientePlanes= resultPlanesNoAsignados.Objects;

            return View(clientePlan);
        }

        [HttpGet]
        public ActionResult PlanDeleteByIdClientePlan(int idClientePlan, int idCliente)
        {
            BL.ClientePlanM clientePlan = new BL.ClientePlanM();
            clientePlan.Cliente = new BL.ClienteM();
            clientePlan.Cliente.IdCliente= idCliente;

            clientePlan.IdClientePlan = idClientePlan;

            BL.Result result = BL.ClientePlan.PlanDeleteByIdClientePlan(idClientePlan);

            ViewBag.PlanesAsignados = true;
            ViewBag.idCliente = idCliente;

            if (result.Correct)
            {
                ViewBag.Mensaje = "Plan eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo eliminar correctamente";
            }

            return PartialView("Modal");
        }

        
        [HttpPost]
        public ActionResult ClientesPlanAdd(BL.ClientePlanM clientePlan)
        {
            foreach (string plan in clientePlan.ClientePlanes)
            {
                int idPlan = int.Parse(plan);
                BL.ClientePlan.ClientePlanAdd(clientePlan.Cliente.IdCliente, idPlan);
            }

            return RedirectToAction("PlanesAsignados", "ClientePlan", new { idCliente = clientePlan.Cliente.IdCliente});
        }

       
    }
}
