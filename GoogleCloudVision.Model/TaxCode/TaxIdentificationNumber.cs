using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoogleCloudVision.Model.TaxCode
{
    public class TaxIdentificationNumber
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("issueDate")]
        public DateTime IssueDate { get; set; }
    }
}
