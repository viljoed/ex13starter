using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGisBLL
{
    public interface IMapManager
    {
        void AddMap(IMap map);
        void RemoveMap(int index);
        void SetFocusMap(int index);
    }
}
