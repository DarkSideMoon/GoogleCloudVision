using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoogleCloudVision.Core.Detectors
{
    public class NalogDetector : Detector
    {
        public NalogDetector()
        {
            LabelDocument = "ИНН УКРАИНА";

            DetectionKeyWords = new[]
            {
                "National identification number",
                "Індивідуальний податковий номер",
                "Code",
                "Идентификационный номер налогоплательщика"
            };

            TextKeyWords = new[]
            {
                "КАРТКА",
                "ФІЗИЧНОЇ ОСОБИ",
                "ФІЗИЧНА ОСОБИ",
                "ПЛАТНИКА ПОДАТКІВ",
                "ІДЕНТИФІКАЦІЙНИЙ НОМЕР",
                "УКРАЇНИ",
                "ОБЛІКОВІЙ КАРТЦІ",
                "ПОДАТКОВОЮ АДМІНІСТРАЦІЄЮ"
            };
        }

        public string GetNalogcode()
        {
            var regex = new Regex(@"\d{10}");
            var match = regex.Match(TextDocument);

            return match.Success ? match.Value : String.Empty;
        }

        public string GetDateOfNalogcode()
        {
            var matchList = Regex.Matches(TextDocument,
                @"([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}");

            var list = matchList.Cast<Match>()
                .Select(match => match.Value)
                .ToList();

            // Last date
            return list.LastOrDefault();
        }

        public string GetPersonFullname()
        {
            return GetBetween(TextDocument, "ПОВІДОМЛЯЄ, ЩО", "ОДЕРЖАВ (ЛА)");
        }

        private string GetBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                var start = strSource.IndexOf(strStart, 0, StringComparison.Ordinal) + strStart.Length;
                var end = strSource.IndexOf(strEnd, start, StringComparison.Ordinal);
                return strSource.Substring(start, end - start);
            }

            return string.Empty;
        }
    }
}
