using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventoryManagementCore.Models;
using inventoryManagementCore.Services.Utilities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inventoryManagementCore.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUtilities _utilities;
         
        public TokenController(IUtilities utilities)
        {
            _utilities = utilities;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Utility>>> SetToken(Utility utility)
        {
            return Ok(await _utilities.SetToken(utility));
        }
    }
}
