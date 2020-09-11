using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vkbot.ASP.Models
{
    [Serializable]
    public class CallbackModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("group_id")]
        public int GroupID { get; set; }
        [JsonProperty("object")]
        public JObject Object { get; set; }

        public override string ToString()
        {
            return $"Type:{Type}, Group:{GroupID}, Object:{Object}";
        }
    }
}
