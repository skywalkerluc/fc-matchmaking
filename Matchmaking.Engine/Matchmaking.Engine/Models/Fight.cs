using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matchmaking.Engine.Models
{
    public class Fight
    {
        public Fighter[] Fighters { get; set; }

        public Fight()
        {
            Fighters = new Fighter[1];
        }
    }
}
