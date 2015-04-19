using System;
using SFML.Graphics;
using SFML.System;
using System.IO;

namespace Dunn_2D
{ 
	/// <summary>
	/// The base class for all classes that represent an entity or character in the game.
	/// </summary>
	public class Entity
	{
        public int Age = 0;
		public Texture texture;
		public Vector2f position;
		public Vector2f velocity;
        public bool isParticle = false;
		public bool hasPhysics = false;
        public bool isColliding = false;
        public int animationFrame = 0;
        public int Health;
        public string fileName;
        public bool touching;
        public bool killedByTouch;
        public bool isControlled;
        public Color color;
        public int targetX;
        public int targetY;
		public Entity(string filename, Vector2f position)
		{
            this.fileName = filename;
			this.texture = Util.getTexture(filename + "0.png");
			this.position = position;			
		}
		
		public Entity(string filename, Vector2f position, bool hasPhysics)
		{
            this.fileName = filename;
			this.texture = Util.getTexture(filename + "0.png");
			this.position = position;
			this.hasPhysics = hasPhysics;
		}
		
		public Entity(string filename, int x, int y)
		{
            this.fileName = filename;
			this.texture = Util.getTexture(filename + "0.png");
			this.position = new Vector2f(x,y);
		}
		
		public Entity(string filename, int x, int y, bool hasPhysics)
		{
            this.fileName = filename;
			this.texture = Util.getTexture(filename + "0.png");
			this.position = new Vector2f(x,y);
			this.hasPhysics = hasPhysics;
		}

        public Entity(string filename, int x, int y, bool hasPhysics, bool isParticle)
        {
            this.isParticle = isParticle;
            this.fileName = filename;
            this.texture = Util.getTexture(filename + "0.png");
            this.position = new Vector2f(x, y);
            this.hasPhysics = hasPhysics;
        }
		
		public virtual void Move(float x, float y) {
			this.setX(this.getX() + x);
			this.setY(this.getY() + y);
		}
		
		public void Move(Vector2i increment) {
			this.setX(this.getX() + increment.X);
			this.setY(this.getY() + increment.Y);
		}

        public void Animate()
        {
            if(File.Exists(fileName + animationFrame + ".png"))
            {
                texture = Util.getTexture(fileName + animationFrame + ".png");
                animationFrame++;
            }
            else
            {
                animationFrame = 0;
            }
        }
		
	#region GettersAndSetters

        public void setColor(int R, int G, int B)
        {
            this.color = new Color((byte)R, (byte)G, (byte)B);
        }
		public float getX() {
			return this.position.X;
		}
		
		public float getY() {
			return this.position.Y;
		}
		public Vector2f getPosition(){
			return this.position;
		}
		
		public void setX(float x) {
			this.position = new Vector2f(x, this.position.Y);
		}
		
		public void setY(float y) {
			this.position = new Vector2f(this.position.X, y);
		}
		public void setPosition(float x, float y) {
			this.position = new Vector2f(x,y);
		}
		public void setPosition(Vector2f position) {
			this.position = position;
		}
        public void addVelocity(float x, float y)
        {
            this.velocity = new Vector2f(velocity.X + x,velocity.Y + y);
        }
        public void setVelocityX(float x)
        {
            this.velocity = new Vector2f(x, velocity.Y);
        }

        public void setVelocityY(float y)
        {
            this.velocity = new Vector2f(velocity.X, y);
        }

        public void setVelocity(float x, float y)
        {
            this.velocity = new Vector2f(x, y);
        }

        public float getVelocityX()
        {
            return this.velocity.X;
        }
        public float getVelocityY()
        {
            return this.velocity.Y;
        }

        public void setTexture(string fileName)
        {
            this.texture = Util.getTexture(fileName);
        }
	#endregion
	}
}
