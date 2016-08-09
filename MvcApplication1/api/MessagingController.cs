using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplication1.Models;

namespace MvcApplication1.api
{
    public class MessagingController : ApiController
    {
        [HttpGet]
        public string GetMessage()
        {
            BusinessLogic bl = new BusinessLogic();
            return bl.GetMessage();
        }
    }
}
