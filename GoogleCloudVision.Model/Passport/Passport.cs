using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoogleCloudVision.Model.Passport
{
    public class Passport : IDocument
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public DocumentType Type { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
