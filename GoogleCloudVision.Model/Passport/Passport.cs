using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoogleCloudVision.Model.Passport
{
    public class Passport
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
