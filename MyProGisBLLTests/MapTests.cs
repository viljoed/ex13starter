using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGisBLL;

namespace MyProGisBLLTests
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void AddLayer_AddOneLayer_NameMatchesExpected()
        {
            IMap map = new Map();
            string layername = "layer1";
            map.AddLayer(GetFeatureLayer(layername, @"C:\data\layer1.shp"));
            Assert.AreEqual(layername, map.Layers[0].Name);
        }

        [TestMethod]
        public void RemoveLayer_AddTwoRemoveFirst_NameMatchesFirstLayer()
        {
            IMap map = new Map();
            map.AddLayer(GetFeatureLayer("layer1", @"C:\data\layer1.shp"));
            map.AddLayer(GetFeatureLayer("layer2", @"C:\data\layer2.shp"));
            map.RemoveLayer(0);
            Assert.AreEqual("layer2", map.Layers[0].Name);
        }

        [TestMethod]
        public void AddLayer_AddTwoLayers_LayerCountEquals2()
        {
            IMap map = new Map();
            map.AddLayer(GetFeatureLayer("layer1", @"C:\data\layer1.shp"));
            map.AddLayer(GetFeatureLayer("layer2", @"C:\data\layer2.shp"));
            Assert.AreEqual(2, map.Layers.Length);
        }

        private IFeatureLayer GetFeatureLayer(string name, string featureclass)
        {
            IFeatureLayer flayer = new FeatureLayer();
            flayer.FeatureClass = featureclass;
            flayer.Name = name;
            return flayer;
        }
    }
}
