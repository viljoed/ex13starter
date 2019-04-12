using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGisBLL
{
    public class FeatureLayer: Layer, IFeatureLayer
    {

        private string _featureClass = string.Empty;
        
        string IFeatureLayer.FeatureClass
        {
            get
            {
                return _featureClass;
            }
            set
            {
                _featureClass = value;
            }
        }
    }
}
