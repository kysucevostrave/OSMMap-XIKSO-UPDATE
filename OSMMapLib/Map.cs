using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapRendererLib;

namespace OSMMapLib
{
    class Map
    {

        public Layer Layer { get => layer; set => layer = value;  }

        private double lat;
        private double lon;
        private int zoom;
        public double Lat
        {
            get { return lat; }
            set
            {
                lat = (value + 90.0) % 180 - 90.0;
            }
        }

        public double Lon
        {
            get { return lon; }
            set
            {
                 lon = (value + 180.0) % 360 - 180.0;
            }
        }

        public int Zoom { get {
                var rand = new Random();
                return rand.Next(1, Layer.MaxZoom);

            } 
            set {

                if (Layer.MaxZoom < value)
                {
                    Zoom = Layer.MaxZoom;

                }
                
	           else
                {
                    zoom = value;
                }
            } }

        private int centerTileX;

        public int CenterTileX {
            get { return (int)((Lon + 180.0) / 360.0 * (1 << Zoom)); } set { } }
        public int CenterTileY
        {
            get { return (int)((1.0 - Math.Log(Math.Tan(Lat * Math.PI / 180.0) + 1.0 / Math.Cos(Lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << Zoom)); }
            set { }
        }

        public void Render()
        {
            MapRenderer mapRenderer = new MapRenderer(4, 4);
            for (int x = -2; x < 2; x++)
            {
                for (int y = -2; y < 2; y++)
                {
                    Tile tile = this.Layer[this.CenterTileX + x, this.CenterTileY + y, this.Zoom];

                    Console.WriteLine(tile);

                    mapRenderer.Set(x + 2, y + 2, tile.Url);
                }
            }
            mapRenderer.Flush();
            mapRenderer.Render(fileName);

        }
    }


}
