using System;
using SFML.System;
using SFML.Graphics;
namespace Dunn_2D
{
	/// <summary>
	/// Contains various calculation functions for physics and other stuff.
	/// </summary>
	public static class PhysMath
	{
		
		public static float getDistance(Vector2f d1, Vector2f d2) {
	        float x1 = d1.X;
			float x2 = d2.X;
			float y1 = d1.Y;
			float y2 = d2.Y;
		    float rtn = (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine(rtn);
				return rtn;
		}
		
		public static bool willCollide(FloatRect first, FloatRect second) {
			
				
				return  (Math.Abs(first.Left - second.Left) * 2 < (first.Width + second.Width)) && (Math.Abs(first.Top - second.Top) * 2 < (first.Height + second.Height));
		}
		
	}
}
