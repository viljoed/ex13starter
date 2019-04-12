using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGisBLL
{
    public class MapDocument:IMapDocument, IMapManager
    {
        private IMap _focusMap = new Map();
        private IMap[] _maps = new Map[] {};

        IMap IMapDocument.FocusMap
        {
            get { return _focusMap; }
        }

        IMap[] IMapDocument.Maps
        {
            get {return _maps;}               
        }

        IMap IMapDocument.GetMap(string name)
        {
            for (int i = 0; i < _maps.Length; i++)
            {
                if (_maps[i].Name == name)
                    return _maps[i];
            }
            return null;
        }

        void IMapManager.AddMap(IMap map)
        {
            Array.Resize(ref _maps, _maps.Length + 1);
            int newIndex = _maps.Length - 1;
            _maps[newIndex] = (IMap)map;  
        }

        void IMapManager.RemoveMap(int index)
        {
            for (int i = 0; i < _maps.Length; i++)
            {
                if (i < index)
                    _maps[i] = _maps[i];
                if (i > index)
                    _maps[i - 1] = _maps[i];
            }
            Array.Resize(ref _maps, _maps.Length - 1);
        }

        void IMapManager.SetFocusMap(int index)
        {
            _focusMap = _maps[index];
        }
    }
}
