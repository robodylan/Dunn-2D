using System;
using SFML.Graphics;
using SFML.System;

namespace Dunn_2D
{ 
	/// <summary>
	/// The base class for all classes that represent a entity or character in the game.
	/// </summary>
	public class Entity
	{
		public Texture texture;
		public Vector2f position;
		public Vector2f velocity;
		public bool hasPhysics = false;
		public Entity(string filename, Vector2f position)
		{
			this.texture = Util.getTexture(filename);
			this.position = position;			
		}
		
		public Entity(string filename, Vector2f position, bool hasPhysics)
		{
			this.texture = Util.getTexture(filename);
			this.position = position;
			this.hasPhysics = hasPhysics;
		}
		
		public Entity(string filename, int x, int y)
		{
			this.texture = Util.getTexture(filename);
			this.position = new Vector2f(x,y);
		}
		
		public Entity(string filename, int x, int y, bool hasPhysics)
		{
			this.texture = Util.getTexture(filename);
			this.position = new Vector2f(x,y);
			this.hasPhysics = hasPhysics;
		}
		
		public void Move(int x, int y) {
			this.setX(this.getX() + x);
			this.setY(this.getY() + y);
		}
		
		public void Move(Vector2i increment) {
			this.setX(this.getX() + increment.X);
			this.setY(this.getY() + increment.Y);
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
