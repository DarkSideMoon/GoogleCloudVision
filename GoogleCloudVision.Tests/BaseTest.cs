using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Vision.V1;
using GoogleCloudVision.Model.Google;

namespace GoogleCloudVision.Tests
{
    public class BaseTest
    {
        protected string _pathToImage;

        protected ImageContext _imageContext;

        protected ImageAnnotatorClient _client;

        public BaseTest()
        {
            _imageContext = new ImageContext()
            {
                // Language to detect
                LanguageHints = { "ua" }
            };

            // Instantiates a client
            _client = ImageAnnotatorClient.Create();
        }

        protected List<Entity> GetWebEntities(WebDetection detection)
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
