using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMMapLib
{
    public class Layer{

        public Layer(string _urlTemplate = "https://{c}.tile.openstreetmap.org/{z}/{x}/{y}.png")
        {
            this.UrlTemplate = _urlTemplate;
            this.MaxZoom = 10;
        }
        public Layer(int _maxZoom)
        {
            this.UrlTemplate = "https://{c}.tile.openstreetmap.org/{z}/{x}/{y}.png";
            this.MaxZoom = _maxZoom;
        }
        public Layer(string _urlTemplate, int _maxZoom = 10) :this(_urlTemplate)
        {
            this.MaxZoom = _maxZoom;
        }

        private int[] val = new int[3]; 

        public int this[int i]
        {
            get { return val[i]; }
            set { val[i] = value; }
        }


        private string urlTemplate;
        private int maxZoom;

        public string UrlTemplate { get { return urlTemplate; } private set { urlTemplate = value; } }
        public int MaxZoom {  get { return maxZoom; } private set { maxZoom = value; } }

        public Tile newTile()
        {
            Tile tile = new Tile(val[0], val[1], val[2], this.FormatUrl(val[0], val[1], val[2]));
            return tile;
        }

        public string FormatUrl(int _x, int _y, int _zoom)
        {
            StringBuilder sb = new StringBuilder(this.UrlTemplate);

            sb.Replace("{x}", _x.ToString());
            sb.Replace("{y}", _y.ToString());
            sb.Replace("{z}", _zoom.ToString());

            Random rnd = new Random();
            int pismeno_cislo = rnd.Next(0, 3); 
            char pismeno = (char)(97+pismeno_cislo);
            sb.Replace("{c}", pismeno.ToString());

            return sb.ToString();
        }

    }
}
