using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matchmaking.Engine.Models
{
    public class FighterQuery
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char? Gender { get; set; }
        public bool? TitleHolder { get; set; }

        public FighterQuery()
        {
            
        }
    }
}
