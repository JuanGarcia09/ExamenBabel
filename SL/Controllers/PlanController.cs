using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class PlanController : ApiController
    {
        [HttpGet]
        [Route("api/Plan/GetAll")]
        public IHttpActionResult GetAll()
        {
            BL.Result result = BL.Plan.GetAll();

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
        [Route("api/Plan/Add")]
        public IHttpActionResult Add([FromBody] BL.PlanM plan)
        {
            BL.Result result = BL.Plan.Add(plan);

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
        [Route("api/Plan/GetById/{idPlan}")]
        public IHttpActionResult GetById(int idPlan)
        {
            BL.Result result = BL.Plan.GetById(idPlan);

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
        [Route("api/Plan/Update")]
        public IHttpActionResult Update([FromBody] BL.PlanM plan)
        {
            BL.Result result = BL.Plan.Update(plan);

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
        [Route("api/Plan/Delete/{idPlan}")]
        public IHttpActionResult Delete(int idPlan)
        {
            BL.Result result = BL.Plan.Delete(idPlan);

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
