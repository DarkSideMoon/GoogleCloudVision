using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleCloudVision.Core.Detectors;
using GoogleCloudVision.Model;

namespace GoogleCloudVision.Core
{
    public class Detector
    {
        private readonly string _textDocument;

        public Detector(string textDocument)
        {
            _textDocument = textDocument;
        }

        public IDocument Execute()
        {
            // Create list of all detectors
            var detectors = new List<BaseDetector>()
            {
                new IdCardDetector(_textDocument),
                new NalogDetector(_textDocument),
                new PassportDetector(_textDocument),
                new PrivatBankReceiptDetector(_textDocument)
            };

            // Check is document detected in each detector
            foreach (var detect in detectors)
            {
                if (detect.IsDocumentDetected())
                {
                    return detect.GetDocumentInformation();
                }
            }

            return null;
        }
    }
}
