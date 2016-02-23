using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ForJenkins.Controllers
{


    public class SlowController : ApiController
    {
        public IHttpActionResult GetSlow()
        {
            int result = 0;

            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    SlowMan sm = new SlowMan();
                    result += sm.SlowMethod();

                }
            }
            catch (Exception e)
            {
                return Ok(e.ToString());
            }

            return Ok("result ok : " + result);
        }

        public IHttpActionResult PostSlow([FromBody]SlowDto slowDto)
        {
            int result = 0;
            int limit = 1000;

            if (slowDto.limitNum != 0 && slowDto.limitNum != null)
            {
                limit = slowDto.limitNum;
            }


            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    SlowMan sm = new SlowMan();
                    result += sm.SlowMethod();

                }
            }
            catch (Exception e)
            {
                return Ok(e.ToString());
            }

            return Ok("result ok : " + result);
        }

    }
    public class SlowMan
    {
        public int SlowMethod()
        {

            int result = 0;

            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    result += i;
                }
                else
                {
                    Random r = new Random();
                    result += r.Next(50, 150);
                }

            }

            return result;
        }

    }

    [Serializable]
    public class SlowDto
    {
        public Int16 limitNum { get; set; }
    }
}

