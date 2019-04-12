using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGisBLL
{
    public interface IFeatureLayer: ILayer
    {
        string FeatureClass { get; set; }
    }
}
