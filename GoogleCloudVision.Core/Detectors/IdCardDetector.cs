using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoogleCloudVision.Core.Detectors
{
    public class IdCardDetector : Detector
    {
        public IdCardDetector()
        {
            LabelDocument = "IDENTITY CARDS";

            DetectionKeyWords = new[]
            {
                "Identity document",
                "Ukraine",
                "Ukrainian identity card",
                "Passport"
            };

            TextKeyWords = new[]
            {
                "УКРАЇНА",
                "UKRAINE",
                "ПАСПОРТ",
                "ПАСПОРТ ГРОМАДЯНИНА УКРАЇНИ",
                "PASSPORT",
                "PASSPORT OF THE CITIZEN OF UKRAINE",
                "Nationality",
                "Record No",
                "Document No"
            };
        }

        public string GetIdCardNumber()
        {
            Regex regex = new Regex(@"\d{9}");
            Match match = regex.Match(TextDocument);

            return match.Success ? match.Value : String.Empty;
        }

        public string GetIdCardRecordNumber()
        {
            Regex regex = new Regex(@"\d{8}-\d{5}");
            Match match = regex.Match(TextDocument);

            return match.Success ? match.Value : String.Empty;
        }
    }
}
