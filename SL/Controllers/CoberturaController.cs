using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class CoberturaController : ApiController
    {
        [HttpGet]
        [Route("api/Cobertura/GetAll")]
        public IHttpActionResult GetAll()
        {
            BL.Result result = BL.Cobertura.GetAll();

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
        [Route("api/Cobertura/Add")]
        public IHttpActionResult Add([FromBody] BL.CoberturaM cobertura)
        {
            BL.Result result = BL.Cobertura.Add(cobertura);

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
        [Route("api/Cobertura/GetById/{idCobertura}")]
        public IHttpActionResult GetById(int idCobertura)
        {
            BL.Result result = BL.Cobertura.GetById(idCobertura);

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
        [Route("api/Cobertura/Update")]
        public IHttpActionResult Update([FromBody] BL.CoberturaM cobertura)
        {
            BL.Result result = BL.Cobertura.Update(cobertura);

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
        [Route("api/Cobertura/Delete/{idCobertura}")]
        public IHttpActionResult Delete(int idCobertura)
        {
            BL.Result result = BL.Cobertura.Delete(idCobertura);

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
