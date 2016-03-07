using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ForJenkins.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Log4NetController : ApiController
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
