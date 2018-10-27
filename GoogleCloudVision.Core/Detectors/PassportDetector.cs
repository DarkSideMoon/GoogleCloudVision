using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleCloudVision.Model;

namespace GoogleCloudVision.Core.Detectors
{
    /// <summary>
    /// Passport old version
    /// </summary>
    public class PassportDetector : BaseDetector
    {
        public PassportDetector(string textDocument)
            : base(textDocument)
        {
            // Less number - because the less of coincidences 
            DefaultCountOfCoincidences = 6;

            LabelDocuments = new[]
            {
                "UKRAINE PASSPORT",
                "ПАСПОРТ ГРАЖДАНИНА УКРАИНЫ",
                "IDENTITY DOCUMENT"
            };

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

        public override IDocument GetDocumentInformation()
        {
            throw new NotImplementedException();
        }
    }
}
