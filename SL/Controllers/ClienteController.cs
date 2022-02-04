using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class ClienteController : ApiController
    {
        [HttpGet]
        [Route("api/Cliente/GetAll")]
        public IHttpActionResult GetAll()
        {
            BL.Result result = BL.Cliente.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPost]
        [Route("api/Cliente/Add")]
        public IHttpActionResult Add([FromBody]BL.ClienteM cliente)
        {
            BL.Result result = BL.Cliente.Add(cliente);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpGet]
        [Route("api/Cliente/GetById/{idCliente}")]
        public IHttpActionResult GetById(int idCliente)
        {
            BL.Result result = BL.Cliente.GetById(idCliente);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPost]
        [Route("api/Cliente/Update")]
        public IHttpActionResult Update([FromBody]BL.ClienteM cliente)
        {
            BL.Result result = BL.Cliente.Update(cliente);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpGet]
        [Route("api/Cliente/Delete/{idCliente}")]
        public IHttpActionResult Delete(int idCliente)
        {
            BL.Result result = BL.Cliente.Delete(idCliente);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
