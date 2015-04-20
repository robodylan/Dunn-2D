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
        public static void setKeyDown(Object sender, KeyEventArgs e)
        {
            
        }

        public static bool isLeftClicked()
        {
            return Mouse.IsButtonPressed(Mouse.Button.Left);
        }
        public static bool isRightClicked()
        {
            return Mouse.IsButtonPressed(Mouse.Button.Right);
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
