using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGisBLL
{
    public class Map: IMap
    {
        private string _name = string.Empty;
        private ILayer[] _layers = new Layer[] {};

        string IMap.Name
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

        ILayer[] IMap.Layers
        {
            get { return _layers; }
        }

        void IMap.AddLayer(ILayer layer)
        {
            Array.Resize(ref _layers, _layers.Length + 1);
            int newIndex = _layers.Length - 1;
            _layers[newIndex] = (ILayer)layer;
        }

        void IMap.RemoveLayer(int index)
        {
            for (int i = 0; i < _layers.Length; i++)
            {
                if (i < index)
                    _layers[i] = _layers[i];
                if (i > index)
                    _layers[i - 1] = _layers[i];
            }
            Array.Resize(ref _layers, _layers.Length - 1);
        }
    }
}
