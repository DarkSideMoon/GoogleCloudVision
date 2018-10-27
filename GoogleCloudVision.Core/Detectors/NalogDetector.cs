using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GoogleCloudVision.Model;
using GoogleCloudVision.Model.TaxCode;

namespace GoogleCloudVision.Core.Detectors
{
    public class NalogDetector : BaseDetector
    {
        public NalogDetector(string textDocument)
            : base(textDocument)
        {
            DefaultCountOfCoincidences = 20;

            LabelDocuments = new[]
            {
                "ІДЕНТИФІКАЦІЙНИЙ КОД",
                "КАРТКА ПЛАТНИКА ПОДАТКІВ",
                "ИНН УКРАИНА"
            };

            DetectionKeyWords = new[]
            {
                "National identification number",
                "Індивідуальний податковий номер",
                "Code",
                "Идентификационный номер налогоплательщика",
                "Tax",
                "Taxpayer Identification Number"
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
                "ПОДАТКОВОЮ АДМІНІСТРАЦІЄЮ",
                "ПОДАТКОВОЇ СЛУЖБИ",
                "ІДЕНТИФІКАЦІЙНИЙ",
                "НОМЕР",
                "ДЕРЖАВНОЮ"
            };
        }

        public TaxIdentificationNumber GetInformation()
        {
            return new TaxIdentificationNumber()
            {
                FullName = GetPersonFullNameText(),
                IssueDate = DateTime.Parse(GetDateOfNalogcode()),
                Number = GetNalogcode(),
            };
        }

        private string GetNalogcode()
        {
            var regex = new Regex(@"\d{10}");
            var match = regex.Match(TextDocument);

            return match.Success ? match.Value : String.Empty;
        }

        private string GetDateOfNalogcode()
        {
            var matchList = Regex.Matches(TextDocument,
                @"([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}");

            var list = matchList.Cast<Match>()
                .Select(match => match.Value)
                .ToList();

            // Last date
            return list.LastOrDefault();
        }

        private string GetPersonFullNameText()
        {
            var fullNameTextPart = TextDocument.Split('\n')[2];

            return fullNameTextPart.Substring(15, fullNameTextPart.Length - 15);
        }

        ///// <summary>
        ///// One way to get fullname
        ///// </summary>
        ///// <returns></returns>
        //private string GetPersonFullName()
        //{
        //    return GetBetween(TextDocument, "ПОВІДОМЛЯЄ, ЩО", "ОДЕРЖАВ (ЛА)");
        //}

        //private string GetBetween(string strSource, string strStart, string strEnd)
        //{
        //    if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        //    {
        //        var start = strSource.IndexOf(strStart, 0, StringComparison.Ordinal) + strStart.Length;
        //        var end = strSource.IndexOf(strEnd, start, StringComparison.Ordinal);
        //        return strSource.Substring(start, end - start);
        //    }

        //    return string.Empty;
        //}

        public override IDocument GetDocumentInformation()
        {
            throw new NotImplementedException();
        }
    }
}
