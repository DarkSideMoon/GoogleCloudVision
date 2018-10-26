using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Vision.V1;
using GoogleCloudVision.Model.Google;

namespace GoogleCloudVision.Core.Extension
{
    public static class WebDetectionExtension
    {
        public static List<Entity> GetWebEntities(this WebDetection detection)
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
