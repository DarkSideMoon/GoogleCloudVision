using System;
using System.Linq;
using Google.Cloud.Vision.V1;
using GoogleCloudVision.Core.Detectors;
using GoogleCloudVision.Model.Google;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleCloudVision.Tests
{
    [TestClass]
    public class TestPassport : BaseTest
    {
        [TestMethod]
        public void TestPassportDetection()
        {
            _pathToImage = @"F:\test3.jpg";
            var image = Image.FromFile(_pathToImage);

            var documentText = _client.DetectDocumentText(image, _imageContext);
            var detection = _client.DetectWebInformation(image, _imageContext);

            PassportDetector passportDetector = new PassportDetector()
            {
                TextDocument = documentText.Text.ToUpper(),
                WebDetection = new Detection()
                {
                    Label = detection.BestGuessLabels.FirstOrDefault().Label.ToUpper(),
                    WebEntities = GetWebEntities(detection)
                }
            };

            Assert.IsTrue(passportDetector.IsDocumentDetected());
        }
    }
}
