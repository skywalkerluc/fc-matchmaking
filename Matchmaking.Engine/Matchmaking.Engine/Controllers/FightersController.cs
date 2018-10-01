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
        public IEnumerable<Fighter> Get(bool? champ = false, string lastName = null)
        {
            return fightersBusiness.GetFighters(champ.Value, lastName);
        }

        // GET: api/Fighters/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        

        // POST: api/Fighters
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Fighters/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
