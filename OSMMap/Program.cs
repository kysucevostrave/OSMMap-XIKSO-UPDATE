using OSMMapLib;
using System;

namespace OSMMap
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Layer layer = new Layer();
            layer[0] = 1;
            layer[1] = 2;
            layer[2] = 3;

            Tile tile = layer.newTile();
            Console.WriteLine(tile.ToString());*/
            /*Console.WriteLine(layer.UrlTemplate);
            Console.WriteLine(layer.MaxZoom);*/

            Map mapa = new Map();
            mapa.Lat = 49.83148019813019;
            mapa.Lon = 18.159852471293025; 
            mapa.Zoom = 17;
            mapa.Layer = new Layer("http://c.tile.stamen.com/watercolor/{z}/{x}/{y}.jpg",17);
            mapa.Render("fileName.png");

        }
    }
}
