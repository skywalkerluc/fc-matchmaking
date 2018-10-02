using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matchmaking.Engine.Business;
using Matchmaking.Engine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Matchmaking.Engine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FightersController : ControllerBase
    {
        private readonly FightersBusiness fightersBusiness;

        public FightersController()
        {
            fightersBusiness = new FightersBusiness();
        }

        // GET: api/Fighters
        [HttpGet]
        public IEnumerable<Fighter> Get([FromQuery] FighterQuery query)
        {
            return fightersBusiness.GetFighters(query);
        }
        
    }
}
