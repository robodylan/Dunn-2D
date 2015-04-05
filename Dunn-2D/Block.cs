using System;
using SFML.System;
using SFML.Graphics;

namespace Dunn_2D
{
	/// <summary>
	/// The base class for all classes that represent a block or tile in the game.
	/// </summary>
	public class Block
	{
		public static int blockSize = 10;
		public Texture texture;
		public Vector2f position;
		public bool hasPhysics = false;
		
		public Block(string filename, Vector2f position)
		{
			this.texture = Util.getTexture(filename);
			this.position = position;
		}
		
		public Block(string filename, Vector2f position, bool hasPhysics) {
			this.texture = Util.getTexture(filename);
			this.position = position;
			this.hasPhysics = hasPhysics;
		}
		
		public Block(string filename, int x, int y)
		{
			this.texture = Util.getTexture(filename);
			this.position = new Vector2f(x,y);
		}
		
		public Block(string filename, int x, int y, bool hasPhysics)
		{
			this.texture = Util.getTexture(filename);
			this.position = new Vector2f(x,y);
			this.hasPhysics = hasPhysics;
		}
	#region GettersAndSetters
		public int getX() {
			return (int)this.position.X;
		}
		
		public int getY() {
			return (int)this.position.Y;
		}
		public Vector2f getPosition(){
			return this.position;
		}
		
		public void setX(int x) {
			this.position = new Vector2f(x, this.position.Y);
		}
		
		public void setY(int y) {
			this.position = new Vector2f(this.position.X, y);
		}
		public void setPosition(int x, int y) {
			this.position = new Vector2f(x,y);
		}
		public void setPosition(Vector2f position) {
			this.position = position;
		}
	#endregion
	}
}
