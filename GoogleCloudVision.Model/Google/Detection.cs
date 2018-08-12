using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudVision.Model.Google
{
    /// <summary>
    /// Google web detection
    /// </summary>
    public class Detection
    {
        /// <summary>
        /// Label of document from API
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Google web entities
        /// </summary>
        public List<Entity> WebEntities { get; set; }
    }
}
