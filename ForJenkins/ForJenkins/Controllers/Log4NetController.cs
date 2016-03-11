﻿using System;
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
                log.Info("Test INFO : " + result);
            }



            logMessage.Body = result;
            MessageQueue msgQ = new MessageQueue(".\\Private$\\logqueue");

            msgQ.Send(logMessage);

            return Ok("result ok : " + result);
        }



    }
}
