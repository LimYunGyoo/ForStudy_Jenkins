using log4net;
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
    public class New4NetController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public IHttpActionResult GetTry()
        {
            int result = 0;
            for (int i = 0; i < 1000; i++)
            {
                result += i;
            }


            log4net.Config.BasicConfigurator.Configure();

            log.Info("Try I");
            log.Error("Try E");

            return Ok("result ok : " + result);

        }

        public IHttpActionResult PostCar()
        {
            int result = 0;
            for (int i = 0; i < 1000; i++)
            {
                result += i;
            }


            log4net.Config.BasicConfigurator.Configure();

            log.Info("Car I");
            log.Error("Car E");
            log.Debug("Car D");

            return Ok("result ok : " + result);

        }
    }
}
