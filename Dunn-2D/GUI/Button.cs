using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dunn_2D.GUI
{
    public class Button
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public string Text;

        public Button(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
    }
}
