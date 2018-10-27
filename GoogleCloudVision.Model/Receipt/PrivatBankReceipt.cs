using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudVision.Model.Receipt
{
    public class PrivatBankReceipt : IDocument
    {
        public double Sum { get; set; }

        public string ReceiptNumber { get; set; }

        public string BankSender { get; set; }

        public string BankSenderCode { get; set; }

        public string BankReceiver { get; set; }
            
        public string BankReceiverCode { get; set; }

        public DocumentType Type { get; set; }

        public override string ToString()
        {
            return Sum + "\n" + ReceiptNumber + "\n" + BankSender + "\n" + BankReceiver;
        }
    }
}
