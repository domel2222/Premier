using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {

        [HttpGet]
        [Produces("application/json")]
        public IActionResult  GetTournaments()
        {
            return this.Ok (new { NickNae = "DIno", Name = "London Master55" });
        }
    }
}
