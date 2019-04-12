using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGisBLL
{
    public class Layer: ILayer
    {
        private string _name = string.Empty;

        string ILayer.Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
