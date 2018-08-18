using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GoogleCloudVision.Model.Passport;

namespace GoogleCloudVision.Core.Detectors
{
    public class IdCardDetector : Detector
    {
        private readonly string[] _textParts;

        public IdCardDetector(string textDocument) 
            : base(textDocument)
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

            _textParts = textDocument.Split('\n');
        }

        public IdCardPassport GetInformation()
        {
            return new IdCardPassport()
            {
                Number = GetIdCardNumber(),
                RecordNumber = GetIdCardRecordNumber(),
                SurnameUkr = GetSurnameUkr(),
                SurnameEng = GetSurnameEng(),
                NameUkr = GetNameUkr(),
                NameEng = GetNameEng(),
                Gender = GetGender(),
                BirthDate = GetDateOfBirthday(),
                ExpireDate = GetExpireDate()
            };
        }

        private DateTime GetExpireDate()
        {
            return DateTime.Parse(_textParts[18]);
        }

        private DateTime GetDateOfBirthday()
        {
            return DateTime.Parse(_textParts[16]);
        }

        private string GetGender()
        {
            return _textParts[14].Substring(2, 1);
        }

        private string GetSurnameEng()
        {
            return _textParts[7];
        }

        private string GetSurnameUkr()
        {
            return _textParts[6];
        }

        private string GetNameEng()
        {
            return _textParts[10];
        }

        private string GetNameUkr()
        {
            return _textParts[9];
        }

        private string GetIdCardNumber()
        {
            Regex regex = new Regex(@"\d{9}");
            Match match = regex.Match(TextDocument);

            return match.Success ? match.Value : String.Empty;
        }

        private string GetIdCardRecordNumber()
        {
            Regex regex = new Regex(@"\d{8}-\d{5}");
            Match match = regex.Match(TextDocument);

            return match.Success ? match.Value : String.Empty;
        }
    }
}
