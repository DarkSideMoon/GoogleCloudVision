using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudVision.Core.Detectors
{
    /// <summary>
    /// Passport old version
    /// </summary>
    public class PassportDetector : Detector
    {
        public PassportDetector()
        {
            LabelDocument = "UKRAINE PASSPORT";

            DetectionKeyWords = new[]
            {
                "Identity document",
                "Ukrainian passport",
                "Ukraine",
                "Passport",
                "Ukrainian passport"
            };

            TextKeyWords = new[]
            {
                "ПАСПОРТ ГРОМАДЯНИНА УКРАЇНИ",
                "ПАССПОРТ ГРАЖДАНИНА УКРАИНЫ"
            };
        }
    }
}
