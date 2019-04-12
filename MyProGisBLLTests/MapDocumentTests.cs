using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGisBLL;

namespace MyProGisBLLTests
{
    [TestClass]
    public class MapDocumentTests
    {
        [TestMethod]
        public void AddMap_AddOneMap_NameMatchesExpected()
        {
            IMapManager mgr = new MapDocument();
            IMapDocument doc = (IMapDocument)mgr;
            IMap map = new Map();
            string name = "map1";
            mgr.AddMap(GetMap(name));
            Assert.AreEqual(name, doc.Maps[0].Name);
        }

        [TestMethod]
        public void RemoveMap_AddTwoRemoveFirst_NameMatchesFirstMap()
        {
            IMapManager mgr = new MapDocument();
            IMapDocument doc = (IMapDocument)mgr;
            IMap map = new Map();
            mgr.AddMap(GetMap("map1"));
            mgr.AddMap(GetMap("map2"));
            mgr.RemoveMap(0);
            Assert.AreEqual("map2", doc.Maps[0].Name);
        }

        [TestMethod]
        public void SetFocusMap_AddTwoSetFirstAsFocus_NameMatchesFirstMap()
        {
            IMapManager mgr = new MapDocument();
            IMapDocument doc = (IMapDocument)mgr;
            IMap map = new Map();
            mgr.AddMap(GetMap("map1"));
            mgr.AddMap(GetMap("map2"));
            mgr.SetFocusMap(0);
            Assert.AreEqual("map1", doc.Maps[0].Name);
        }

        [TestMethod]
        public void GetMap_AddTwoGetSecond_NameMatchesSecondMap()
        {
            IMapManager mgr = new MapDocument();
            IMapDocument doc = (IMapDocument)mgr;
            IMap map = new Map();
            mgr.AddMap(GetMap("map1"));
            mgr.AddMap(GetMap("map2"));
            IMap mapActual = doc.GetMap("map2");
            Assert.AreEqual("map2", mapActual.Name);
        }

        private IMap GetMap(string name)
        {
            IMap map = new Map();
            map.Name = name;
            return map;
        }

        private void InterfaceDemo1()
        {
            ILayer layer = new FeatureLayer();
            layer.Name = "Some feature layer";

            // Need to cast layer to IFeatureLayer
            // to access IFeatureLayer members
            //
            IFeatureLayer flayer = (IFeatureLayer)layer;
            flayer.FeatureClass = @"C:\data\prov.shp";
        }

        private void InterfaceDemo2()
        {
            // Interface inheritance means IFeatureLayer 
            // has access to ILayer members
            //
            IFeatureLayer flayer = new FeatureLayer();
            flayer.Name = "Some feature layer";
            flayer.FeatureClass = @"C:\data\prov.shp";
        }

        private void InterfaceDemo3()
        {
            IMapDocument mapdoc = new MapDocument();
            IMap map = (IMap)mapdoc;
            map.Name = "Bob";
        }
    }
}
