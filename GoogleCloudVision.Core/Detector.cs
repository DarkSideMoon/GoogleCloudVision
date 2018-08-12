using GoogleCloudVision.Model.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudVision.Core
{
    public abstract class Detector
    {
        /// <summary>
        /// All text of document
        /// </summary>
        public string TextDocument { get; set; }

        /// <summary>
        /// Label of document
        /// </summary>
        protected string LabelDocument { get; set; }

        /// <summary>
        /// Detection Words from API
        /// </summary>
        protected string[] DetectionKeyWords { get; set; }

        /// <summary>
        /// Key words from text
        /// </summary>
        protected string[] TextKeyWords { get; set; }

        /// <summary>
        /// Web detection from google api
        /// </summary>
        public Detection WebDetection { get; set; }

        /// <summary>
        /// Get the result of detection
        /// Count coincidences by different params
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDocumentDetected()
        {
            string lableDetected = WebDetection.Label.ToUpper();

            int countOfCoincidences = TextKeyWords.Count(keyWord => TextDocument.Contains(keyWord));

            foreach (var entity in WebDetection.WebEntities)
            {
                if (DetectionKeyWords.Contains(entity.KeyWord) && entity.Score > 1)
                    countOfCoincidences += 3;

                if (DetectionKeyWords.Contains(entity.KeyWord) && entity.Score > 0.8)
                    countOfCoincidences += 2;

                if (DetectionKeyWords.Contains(entity.KeyWord) && entity.Score > 0.5)
                    countOfCoincidences += 1;
            }

            return countOfCoincidences >= 6 && LabelDocument == lableDetected;
        }
    }
}
