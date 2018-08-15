﻿using System;
using System.Linq;
using Google.Cloud.Vision.V1;
using GoogleCloudVision.Core.Detectors;
using GoogleCloudVision.Model.Google;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleCloudVision.Tests
{
    [TestClass]
    public class TestIdCard : BaseTest
    {
        [TestMethod]
        public void TestIdCardDetection()
        {
            _pathToImage = @"F:\test1.jpg";
            var image = Image.FromFile(_pathToImage);

            var documentText = _client.DetectDocumentText(image, _imageContext);
            var detection = _client.DetectWebInformation(image, _imageContext);
            var text = _client.DetectText(image, _imageContext);

            IdCardDetector idCardDetector = new IdCardDetector()
            {
                TextDocument = documentText.Text.ToUpper(),
                WebDetection = new Detection()
                {
                    Label = detection.BestGuessLabels.FirstOrDefault().Label.ToUpper(),
                    WebEntities = GetWebEntities(detection)
                }
            };

            Assert.IsTrue(idCardDetector.IsDocumentDetected());

            Console.WriteLine(idCardDetector.GetIdCardNumber());
            Console.WriteLine(idCardDetector.GetIdCardRecordNumber());
        }
    }
}