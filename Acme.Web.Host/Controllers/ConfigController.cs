using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Acme.Web.Host.Models;
using Microsoft.Extensions.Options;

namespace Acme.Web.Host.Controllers
{

    public class ConfigController : Controller
    {

        private AcmeSettings _acmeSettings = null;

        public ConfigController(IOptions<AcmeSettings> settings)
        {
            _acmeSettings = settings.Value;
        }

        [HttpGet]
        [Route("api/config")]
        public IActionResult GetConfig()
        {
            try
            {
                return Ok(_acmeSettings);

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}