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
        public IEnumerable<Fighter> GetFighters(FighterQuery query)
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
            QueryFighters(ref allFighters, query);
            return allFighters.OrderBy(m => m.WeightClass);
        }

        private void QueryFighters(ref List<Fighter> allFighters, FighterQuery query)
        {
            if (query.Id.HasValue) allFighters = allFighters.Where(m => m.Id.Equals(query.Id.Value)).ToList();
            if (!string.IsNullOrEmpty(query.FirstName)) allFighters = allFighters.Where(m => m.FirstName.Contains(query.FirstName)).ToList();
            if (!string.IsNullOrEmpty(query.LastName)) allFighters = allFighters.Where(m => m.LastName.Contains(query.LastName)).ToList();
            if (query.Gender.HasValue) allFighters = allFighters.Where(m => m.Gender.ToString().First().Equals(query.Gender.Value)).ToList();
            if (query.TitleHolder.HasValue) allFighters = allFighters.Where(m => m.TitleHolder.Equals(query.TitleHolder.Value)).ToList();
        }
        
    }
}
