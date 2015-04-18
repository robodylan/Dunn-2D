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
		
		public static float getDistance(Vector2i d1, Vector2i d2) {
			int x1 = d1.X;
			int x2 = d2.X;
			int y1 = d1.Y;
			int y2 = d2.Y;
				
				return (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
		}
		
		public static bool willCollide(FloatRect first, FloatRect second) {
			
				
				return  (Math.Abs(first.Left - second.Left) * 2 < (first.Width + second.Width)) && (Math.Abs(first.Top - second.Top) * 2 < (first.Height + second.Height));
		}
		
	}
}
