using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using log4net;


namespace ForJenkins.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Log4NetController : ApiController
    {        
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
     
        public IHttpActionResult GetText()
        {
            // thread properties...
            //log4net.LogicalThreadContext.Properties["CustomColumn"] = "Custom value Thread";
            
            // ...or global properties
            //log4net.GlobalContext.Properties["CustomColumn"] = "Custom value Global";

            
            
            int result = 0;
            for (int i = 0; i < 100000; i++)
            {
                result += i;
                log.Info("Test INFO : " + result);
            }
            return Ok("result ok : " + result);
            log.Error("Error : " + result);
        }



    }
}
