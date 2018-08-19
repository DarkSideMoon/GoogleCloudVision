using System;
using System.Linq;
using Google.Cloud.Vision.V1;
using GoogleCloudVision.Core.Detectors;
using GoogleCloudVision.Model.Google;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleCloudVision.Tests
{
    [TestClass]
    public class TestPrivatBankReceipt : BaseTest
    {
        [TestMethod]
        public void TestPrivatBankDetection()
        {
            _pathToImage = @"F:\test4.png";
            var image = Image.FromFile(_pathToImage);

            var documentText = _client.DetectDocumentText(image, _imageContext);
            var detection = _client.DetectWebInformation(image, _imageContext);
            var text = _client.DetectText(image, _imageContext);

            PrivatBankReceiptDetector receiptDetector = new PrivatBankReceiptDetector(documentText.Text.ToUpper())
            {
                TextEntityAnnotations = text.Select(x => x.Description).ToArray(),
                WebDetection = new Detection()
                {
                    Label = detection.BestGuessLabels.FirstOrDefault().Label.ToUpper(),
                    WebEntities = GetWebEntities(detection)
                }
            };

            var information = receiptDetector.GetInformation();

            Assert.IsTrue(receiptDetector.IsDocumentDetected());

            Console.WriteLine(information.Sum);
            Console.WriteLine(information.ReceiptNumber);
            Console.WriteLine(information.BankReceiver);
            Console.WriteLine(information.BankReceiverCode);
            Console.WriteLine(information.BankSender);
            Console.WriteLine(information.BankSenderCode);
        }
    }
}
