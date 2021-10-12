using OSMMapLib;
using System;

namespace OSMMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Layer layer = new Layer();
            layer[0] = 1;
            layer[1] = 2;
            layer[2] = 3;

            Tile tile = layer.newTile();
            Console.WriteLine(tile.ToString());
            /*Console.WriteLine(layer.UrlTemplate);
            Console.WriteLine(layer.MaxZoom);*/

        }
    }
}
