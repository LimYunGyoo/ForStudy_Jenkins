using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ForJenkins.Controllers
{
    public class TestController : ApiController
    {
        public IHttpActionResult GetText()
        {
            return Ok("result ok");
        }
    }

}
