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
    public class TestDocuments
    {
        private string _pathToImage;

        private ImageContext _imageContext;

        private ImageAnnotatorClient _client;

        [TestInitialize]
        public void Initialize()
        {
            _imageContext = new ImageContext()
            {
                // Language to detect
                LanguageHints = { "ua" }
            };

            // Instantiates a client
            _client = ImageAnnotatorClient.Create();
        }

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

        private List<Entity> GetWebEntities(WebDetection detection)
        {
            var entities = new List<Entity>();

            foreach (var webEntity in detection.WebEntities)
                entities.Add(new Entity
                {
                    KeyWord = webEntity.Description,
                    Score = webEntity.Score
                });

            return entities;
        }
    }
}
