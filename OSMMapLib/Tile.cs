using System;
using System.Text;

namespace OSMMapLib
{
    public class Tile {
        public Tile(int _x, int _y, int _zoom, string _url) {
            this.X = _x;
            this.Y = _y;
            this.Zoom = _zoom;
            this.Url = _url;
        }
        private int x;
        private int y;
        private int zoom;
        private string url;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }


        public int Zoom { get { return zoom; }
            set {
                if (value! < 1)
                {
                    zoom = 1;
                }
                zoom = value;
            }
        }
        public string Url { get { return url; } set { url = value; } }

        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("[{0}, {1}, {2}]: {3}", this.X.ToString(), this.Y.ToString(), this.Zoom.ToString(), this.Url);

            return sb.ToString();
        }


    }
}
