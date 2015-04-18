using SFML.Graphics;
using SFML.Window;
using SFML.System;

using System;
using System.Collections.Generic;

namespace Dunn_2D
{
    /// <summary>
    /// Description of Input.
    /// </summary>
    //Input variables
    public static class Input
    {
        public enum Key
        {
            Up,
            Down,
            Right,
            Left,
            Jump,
            Shoot
        }
        public static List<Key> keysDown = new List<Key>();
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

        public static void setKeyDown(Object sender, KeyEventArgs e)
        {
            
        }

        public static bool isKeyDown(Key key)
        {
            switch(key)
            {

                case Key.Up:
                    if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                    {
                        return true;
                    }
                    break;
                case Key.Down:
                    if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                    {
                        return true;
                    }
                    break;
                case Key.Left:
                    if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    {
                        return true;
                    }
                    break;
                case Key.Right:
                    if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                    {
                        return true;
                    }
                    break;
                case Key.Jump:
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                    {
                        return true;
                    }
                    break;
                case Key.Shoot:
                    if (Keyboard.IsKeyPressed(Keyboard.Key.F))
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

    }
}
