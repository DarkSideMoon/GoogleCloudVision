﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Vision.V1;
using GoogleCloudVision.Core.Detectors;
using GoogleCloudVision.Core.Extension;
using GoogleCloudVision.Model;
using GoogleCloudVision.Model.Google;

namespace GoogleCloudVision.Core
{
    public class Detector
    {
        private readonly string _label;

        private readonly string _textDocument;

        private readonly WebDetection _webDetection;

        private Detection _detection;

        private readonly IReadOnlyList<EntityAnnotation> _entityAnnotations;

        public Detector(string textDocument, 
            string label,
            WebDetection webDetection,
            IReadOnlyList<EntityAnnotation> entityAnnotations)
        {
            _textDocument = textDocument;
            _label = label;
            _webDetection = webDetection;
            _entityAnnotations = entityAnnotations;

            Initialize();
        }

        private void Initialize()
        {
            _detection = new Detection()
            {
                Label = _label,
                WebEntities = _webDetection.GetWebEntities()
            };
        }

        public IDocument Execute()
        {
            // Create list of all detectors
            var detectors = new List<BaseDetector>()
            {
                new IdCardDetector(_textDocument)
                {
                    WebDetection = _detection
                },
                new NalogDetector(_textDocument)
                {
                    WebDetection = _detection
                },
                new PassportDetector(_textDocument)
                {
                    WebDetection = _detection
                },
                new PrivatBankReceiptDetector(_textDocument)
                {
                    TextEntityAnnotations = _entityAnnotations.Select(x => x.Description).ToArray(),
                    WebDetection = _detection
                }
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
