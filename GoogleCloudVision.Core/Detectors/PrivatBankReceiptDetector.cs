using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleCloudVision.Model;
using GoogleCloudVision.Model.Receipt;

namespace GoogleCloudVision.Core.Detectors
{
    public class PrivatBankReceiptDetector : BaseDetector
    {
        public string[] TextEntityAnnotations { get; set; }

        public PrivatBankReceiptDetector(string textDocument)
            : base(textDocument)
        {
            DefaultCountOfCoincidences = 25;

            LabelDocuments = new[]
            {
                "БАНКІВСЬКА КВИТАНЦІЯ",
                "КВИТАНЦИЯ ПРИВАТ24",
                "КВИТАНЦІЯ ПРО ОПЛАТУ ПРИВАТБАНК"
            };

            DetectionKeyWords = new[]
            {
                "Receipt",
                "Приват24",
                "PrivatBank",
                "Bank"
            };

            TextKeyWords = new[]
            {
                "ПРИВАТБАНК",
                "КОД КВИТАНЦІЇ",
                "HELP@PRIVATBANK.UA",
                "WWW.PB.UA",
                "(ПРИВАТБАНК (УКРАИНА)",
                "ВІДПРАВНИК",
                "ОДЕРЖУВАЧ",
                "КОД КВИТАНЦІЇ",
                "РАХУНОК",
                "ПІДПИС",
                "КОД БАНКУ",
                "ПРИЗНАЧЕННЯ"
            };
        }

        public PrivatBankReceipt GetInformation()
        {
            return new PrivatBankReceipt()
            {
                Sum = double.Parse(TextEntityAnnotations[53].Replace('.', ',')),
                ReceiptNumber = TextEntityAnnotations[29],
                BankSender = TextEntityAnnotations[40],
                BankSenderCode = TextEntityAnnotations[47],
                BankReceiver = TextEntityAnnotations[71] + TextEntityAnnotations[72] + TextEntityAnnotations[73],
                BankReceiverCode = TextEntityAnnotations[85].Substring(1, 6),
                Type = DocumentType.PrivatBankReceipt
            };
        }

        public override IDocument GetDocumentInformation()
        {
            return GetInformation();
        }
    }
}
