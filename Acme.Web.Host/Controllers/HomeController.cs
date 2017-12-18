using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Web.Host.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// We want all traffic to route and go through our angular app
        /// </summary>
        /// <returns></returns>
        public IActionResult App()
        {
            return File("~/index.html", "text/html");
        }
    }
}