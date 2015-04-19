using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dunn_2D.GUI
{
    public class Text
    {
        public int x;
        public int y;
        public string text;
        public Color color;

        public Text(int x, int y, string text)
        {
            this.x = x;
            this.y = y;
            this.text = text;
        }

        public void setColor(int R, int G, int B)
        {
            this.color = new Color((byte)R, (byte)G, (byte)B);
        }
    }
}
