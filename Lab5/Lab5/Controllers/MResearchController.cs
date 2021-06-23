using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class MResearchController : Controller
    {
        //ERROR
        public string MXX()
        {
            return "MXX";
        }

        //M01
        public string Index()
        {
            return "GET:M01";
        }

        public string M01()
        {
            return "GET:M01";
        }

        [Route("V2/MResearch/M01"), Route("V3/MResearch/{X:maxlength(1)}/M01")]
        public string V_M01()
        {
            return "GET:M01";
        }

        //M02
        public string M02()
        {
            return "GET:M02";
        }

        [Route("V2"), Route("V2/MResearch/M02"), Route("V2/MResearch"), Route("V3/MResearch/{X:maxlength(1)}/M02")]
        public string V2()
        {
            return "GET:M02";
        }

        //M03
        [Route("V3")]
        public string V3()
        {
            return "GET:M03";
        }
        [Route("V3/MResearch/{X:maxlength(1)}/M03"), Route("V3/MResearch/{X:maxlength(1)}")]
        public string V3_X_M03()
        {
            return "GET:M03";
        }
    }
}