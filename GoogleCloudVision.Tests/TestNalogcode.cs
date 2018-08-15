using System;
using System.Collections.Generic;
using System.Linq;
using Google.Cloud.Vision.V1;
using GoogleCloudVision.Core.Detectors;
using GoogleCloudVision.Model.Google;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleCloudVision.Tests
{
    [TestClass]
    public class TestNalogcode : BaseTest
    {
        [TestMethod]
        public void TestNalogcodeDetection()
        {
            _pathToImage = @"F:\test.jpg";
            var image = Image.FromFile(_pathToImage);

            var documentText = _client.DetectDocumentText(image, _imageContext);
            var detection = _client.DetectWebInformation(image, _imageContext);

            NalogDetector nalogDetector = new NalogDetector()
            {
                TextDocument = documentText.Text.ToUpper(),
                WebDetection = new Detection()
                {
                    Label = detection.BestGuessLabels.FirstOrDefault().Label.ToUpper(),
                    WebEntities = GetWebEntities(detection)
                }
            };

            Assert.IsTrue(nalogDetector.IsDocumentDetected());

            Console.WriteLine(nalogDetector.GetDateOfNalogcode());
            Console.WriteLine(nalogDetector.GetNalogcode());
            Console.WriteLine(nalogDetector.GetPersonFullname());
        }
    }
}
