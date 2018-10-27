using GoogleCloudVision.Model.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using GoogleCloudVision.Model;

namespace GoogleCloudVision.Core
{
    public abstract class BaseDetector
    {
        /// <summary>
        /// Label of document
        /// </summary>
        protected string[] LabelDocuments { get; set; }

        /// <summary>
        /// Detection Words from API
        /// </summary>
        protected string[] DetectionKeyWords { get; set; }

        /// <summary>
        /// Key words from text
        /// </summary>
        protected string[] TextKeyWords { get; set; }

        /// <summary>
        /// For each document own default count of coincidences
        /// If the number is greater - it is more precise document definition
        /// If the number is less - it is less precise document definition
        /// </summary>
        protected int DefaultCountOfCoincidences { get; set; }

        /// <summary>
        /// Web detection from google api
        /// </summary>
        public Detection WebDetection { get; set; }

        /// <summary>
        /// All text of document
        /// </summary>
        public string TextDocument { get; set; }

        protected BaseDetector(string textDocument)
        {
            TextDocument = textDocument;
        }

        /// <summary>
        /// Get the result of detection
        /// Count coincidences by different params
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDocumentDetected()
        {
            string lableDetected = WebDetection.Label.ToUpper();

            int countOfCoincidences = TextKeyWords.Count(keyWord => TextDocument.Contains(keyWord));

            if (LabelDocuments.Contains(lableDetected))
                countOfCoincidences += 3;

            foreach (var entity in WebDetection.WebEntities)
            {
                if (DetectionKeyWords.Contains(entity.KeyWord) && entity.Score > 1)
                    countOfCoincidences += 4;

                if (DetectionKeyWords.Contains(entity.KeyWord) && entity.Score > 0.7)
                    countOfCoincidences += 2;

                if (DetectionKeyWords.Contains(entity.KeyWord) && entity.Score > 0.5)
                    countOfCoincidences += 1;
            }

            return countOfCoincidences >= DefaultCountOfCoincidences;
        }

        public abstract IDocument GetDocumentInformation();
    }
}
