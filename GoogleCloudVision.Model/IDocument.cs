﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudVision.Model
{
    public interface IDocument
    {
        DocumentType Type { get; set; }
    }
}
