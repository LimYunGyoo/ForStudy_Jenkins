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
            int result = 0;
            for (int i = 0; i < 100000; i++)
            {
                result += i;       
            }

            return Ok("result ok : " + result);
        }
    }

}
