using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using log4net;
using System.Messaging;


namespace ForJenkins.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Log4NetController : ApiController
    {        
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IHttpActionResult GetText()
        {

            Message logMessage = new Message();
            
            int result = 0;
            for (int i = 0; i < 100000; i++)
            {
                result += i;
            }



            logMessage.Body = result;
            MessageQueue msgQ = new MessageQueue(".\\Private$\\logqueue");
            Message ms = new Message();
            ms.Body = DateTime.Now.ToString();
            ms.Label = "result";


            msgQ.Send(ms);

            return Ok("result ok : " + result);
        }


        public IHttpActionResult PostText()
        {

            int result = 0;
            for (int i = 0; i < 100000; i++)
            {
                result += i;
            
            }

            log4net.Config.BasicConfigurator.Configure();

            log.Info("Test I");
            log.Error("Test E");
            log.Debug("TEST D");

            return Ok("result ok : " + result);
        }


    }
}
