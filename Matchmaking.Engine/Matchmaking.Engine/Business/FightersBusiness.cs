using Matchmaking.Engine.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Matchmaking.Engine.Business
{
    public class FightersBusiness
    {
        public IEnumerable<Fighter> GetFighters(bool champ = false, string lastName = null)
        {
            List<Fighter> allFighters = new List<Fighter>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://ufc-data-api.ufc.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/v1/us/fighters").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    allFighters = JsonConvert.DeserializeObject<List<Fighter>>(responseString);
                }
            }

            // refactor later (create a searchModel)
            allFighters = (!string.IsNullOrEmpty(lastName)) ? allFighters.Where(m => m.LastName.Contains(lastName)).ToList() : allFighters;
            allFighters = (champ) ? allFighters.Where(m => m.TitleHolder.Equals(true)).ToList() : allFighters;

            return allFighters.OrderBy(m => m.WeightClass);
        }
    }
}
