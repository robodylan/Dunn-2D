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
		
		public static bool willCollide(IntRect first, IntRect second) {
			
			/*//Define First's Corners
			Vector2f firstTopLeft = new Vector2f(firstObjectsCords.X, firstObjectsCords.Y);
			Vector2f firstTopRight = new Vector2f(firstObjectsCords.X + firstObjectsDimensions.X, firstObjectsCords.Y);
			Vector2f firstBottomRight = new Vector2f(firstObjectsCords.X + firstObjectsDimensions.X, firstObjectsCords.Y + firstObjectsDimensions.Y);
			Vector2f firstBottomLeft = new Vector2f(firstObjectsCords.X, firstObjectsCords.Y + firstObjectsDimensions.Y);
			
			//Define Seconds's Corners
			Vector2f secondTopLeft = new Vector2f(secondObjectsCords.X, secondObjectsCords.Y);
			Vector2f secondTopRight = new Vector2f(secondObjectsCords.X + secondObjectsDimensions.X, secondObjectsCords.Y);
			Vector2f secondBottomRight = new Vector2f(secondObjectsCords.X + secondObjectsDimensions.X, secondObjectsCords.Y + secondObjectsDimensions.Y);
			Vector2f secondBottomLeft = new Vector2f(secondObjectsCords.X, secondObjectsCords.Y + secondObjectsDimensions.Y);
			//Check Top 
			if(firstTopLeft.X >=  secondBottomLeft && firstTopRaight >= secondBottomRight) return true;
			//Check Right
			//Check Left
			//Check Bottom
			*/ //Thought of an easier way, HEHE :)
				
				return  (Math.Abs(first.Left - second.Left) * 2 < (first.Width + second.Width)) && (Math.Abs(first.Top - second.Top) * 2 < (first.Height + second.Height));
		}
		
	}
}
