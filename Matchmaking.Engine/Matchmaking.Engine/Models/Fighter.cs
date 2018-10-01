using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matchmaking.Engine.Models
{
    public class Fighter
    {       
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("weight_class")]
        public string WeightClass { get; set; }

        public Gender Gender { get => (!string.IsNullOrEmpty(this.WeightClass)) ? WeightClass.Contains("Women") ? Gender.Female : Gender.Male : Gender.NotDefined; }

        public string GenderText { get => Gender.ToString(); }

        [JsonProperty("title_holder")]
        public bool TitleHolder { get; set; }

        // fix later (format)
        [JsonProperty("fighter_status")]
        public string Status { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
