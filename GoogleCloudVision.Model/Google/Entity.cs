using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudVision.Model.Google
{
    /// <summary>
    /// Google web enitty
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// The weight of fing document
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Find key word
        /// </summary>
        public string KeyWord { get; set; }

    }
}
