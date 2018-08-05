using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoogleCloudVision.Model.Passport
{
    public class BiometricPassport
    {
        [JsonProperty("nameUkr")]
        public string NameUkr { get; set; }

        [JsonProperty("nameEng")]
        public string NameEng { get; set; }

        [JsonProperty("surnameUkr")]
        public string SurnameUkr { get; set; }

        [JsonProperty("surnameEng")]
        public string SurnameEng { get; set; }

        [JsonProperty("nationalityEng")]
        public string NationalityEng { get; set; }

        [JsonProperty("nationalityUkr")]
        public string NationalityUkr { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("birthPlaceUkr")]
        public string BirthPlaceUkr { get; set; }

        [JsonProperty("birthPlaceEng")]
        public string BirthPlaceEng { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("expireDate")]
        public DateTime ExpireDate { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("recordNumber")]
        public string RecordNumber { get; set; }
    }
}
