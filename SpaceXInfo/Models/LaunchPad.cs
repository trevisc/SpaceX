
using Newtonsoft.Json;

namespace SpaceXInfo.Models
{
    public class LaunchPad
    {
        public string Id { get; set; }
        [JsonProperty("full_name")]
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
