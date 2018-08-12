using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudVision.Core.Detectors
{
    public class NalogDetector : Detector
    {
        public NalogDetector()
        {
            LabelDocument = "IDENTITY CARD";

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
    }
}
