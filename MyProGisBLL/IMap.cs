using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGisBLL
{
    public interface IMap
    {
        string Name { get; set; }
        ILayer[] Layers { get; }
        void AddLayer(ILayer layer);
        void RemoveLayer(int index);
    }
}
