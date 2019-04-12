using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyGisBLL;

namespace MyGisConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create layers and maps
            //
            IMapDocument mapDoc = new MapDocument();
            IMapManager mapManager = (IMapManager)mapDoc;
            IMap mapCanada = new Map();
            mapCanada.Name = "Canada";
            mapManager.AddMap(mapCanada);

            // Add layers to Canada map
            IFeatureLayer canProvLayer = new FeatureLayer();
            canProvLayer.FeatureClass = "C:\\Data\\prov.shp";
            canProvLayer.Name = "Provinces";
            mapCanada.AddLayer(canProvLayer);
            
            IFeatureLayer canLakesLayer = new FeatureLayer();
            canLakesLayer.FeatureClass = "C:\\Data\\canlakes.shp";
            canLakesLayer.Name = "Lakes";
            mapCanada.AddLayer(canLakesLayer);

            // Add USA Map
            IMap mapUSA = new Map();
            mapUSA.Name = "U.S.";
            mapManager.AddMap(mapUSA);

            // Add layers to US map
            IFeatureLayer usStateLayer = new FeatureLayer();
            usStateLayer.FeatureClass = "C:\\Data\\states.shp";
            usStateLayer.Name = "States";
            mapUSA.AddLayer(usStateLayer);

            IFeatureLayer usLakesLayer = new FeatureLayer();
            usLakesLayer.FeatureClass = "C:\\Data\\uslakes.shp";
            usLakesLayer.Name = "Lakes";
            mapUSA.AddLayer(usLakesLayer);
            
            IFeatureLayer usRiversLayer = new FeatureLayer();
            usRiversLayer.FeatureClass = "C:\\Data\\usrivers.shp";
            usRiversLayer.Name = "Rivers";
            mapUSA.AddLayer(usRiversLayer);

            mapManager.SetFocusMap(1);

            Console.WriteLine("Map Document Report");
            Console.WriteLine("Focus Map = {0}\n", mapDoc.FocusMap.Name);
            foreach (IMap m in mapDoc.Maps)
            {
                Console.WriteLine("Map Name = {0}",m.Name);
                Console.WriteLine("Layer Count = {0}", m.Layers.Length);
                foreach (IFeatureLayer lyr in m.Layers)
                {
                    Console.WriteLine("\tFeatureLayer name = {0}", lyr.Name);
                    Console.WriteLine("\tFeatureLayer featureClass = {0}\n", lyr.FeatureClass);
                }
            }

            mapManager.RemoveMap(0);
            mapUSA.RemoveLayer(2);

            Console.WriteLine("Map Document Report");
            Console.WriteLine("Focus Map = {0}\n", mapDoc.FocusMap.Name);
            foreach (IMap m in mapDoc.Maps)
            {
                Console.WriteLine("Map Name = {0}", m.Name);
                Console.WriteLine("Layer Count = {0}", m.Layers.Length);
                foreach (IFeatureLayer lyr in m.Layers)
                {
                    Console.WriteLine("\tFeatureLayer name = {0}", lyr.Name);
                    Console.WriteLine("\tFeatureLayer featureClass = {0}\n", lyr.FeatureClass);
                }
            }

            Console.ReadKey();
        }
    }
}
