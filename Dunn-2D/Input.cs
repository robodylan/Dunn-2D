using SFML.Graphics;
using SFML.Window;
using SFML.System;

using System;

namespace Dunn_2D
{
    /// <summary>
    /// Description of Input.
    /// </summary>
    //Input variables
    public static class Input
    {

        public static int MouseX = 0;
        public static int MouseY = 0;
        public static int getMouseX()
        {
            return MouseX;
        }

        public static int getMouseY()
        {
            return MouseY;
        }

        public static void setMousePos(Object sender, MouseMoveEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
        }

    }
}
