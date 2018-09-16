using SpaceXInfo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace SpaceXInfo.Repositories
{
    public class SpaceXRepository : ISpaceXRepository
    {
        private const string SpaceXUriString = "http://api.spacexdata.com";

        public async Task<IEnumerable<LaunchPad>> GetLaunchPadInfoAsync()
        {
            IList<LaunchPad> lpList;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SpaceXUriString);
                var response = await client.GetAsync($"/v2/launchpads");
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                lpList = JsonConvert.DeserializeObject<IList<LaunchPad>>(stringResult);
                if (lpList == null)
                {
                    lpList = new List<LaunchPad>();
                    LaunchPad lp = new LaunchPad() { Id = string.Empty, Name = "Launchpad Info not found", Status = string.Empty };
                    lpList.Add(lp);
                }
            }
            return lpList;
        }

        public async Task<LaunchPad> GetLaunchPadInfoByNameAsync(string padname)
        {
            LaunchPad lp;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SpaceXUriString);
                var response = await client.GetAsync($"/v2/launchpads/{padname}");
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                lp = JsonConvert.DeserializeObject<LaunchPad>(stringResult);
                if (lp == null)
                    lp = new LaunchPad() { Id = string.Empty, Name = "Launchpad not found", Status = string.Empty };
            }
            return lp;
        }
    }
}
