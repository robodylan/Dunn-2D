using System;
using SFML.Graphics;
using SFML.System;

namespace Dunn_2D
{
    /// <summary>
    /// The base class for all classes that represent a entity or character in the game.
    /// </summary>
    public class Particle
    {
        public int Age = 0;
        public Texture texture;
        public Vector2f position;
        public Vector2f velocity;
        public bool isParticle = false;
        public bool hasPhysics = false;

        public Particle(string filename, int x, int y)
        {
            this.texture = Util.getTexture(filename);
            this.position = new Vector2f(x, y);
        }

        public void Move(float x, float y)
        {
            this.setX(this.getX() + x);
            this.setY(this.getY() + y);
        }

        public void Move(Vector2i increment)
        {
            this.setX(this.getX() + increment.X);
            this.setY(this.getY() + increment.Y);
        }

        #region GettersAndSetters
        public float getX()
        {
            return this.position.X;
        }

        public float getY()
        {
            return this.position.Y;
        }
        public Vector2f getPosition()
        {
            return this.position;
        }

        public void setX(float x)
        {
            this.position = new Vector2f(x, this.position.Y);
        }

        public void setY(float y)
        {
            this.position = new Vector2f(this.position.X, y);
        }
        public void setPosition(float x, float y)
        {
            this.position = new Vector2f(x, y);
        }
        public void setPosition(Vector2f position)
        {
            this.position = position;
        }
        public void addVelocity(float x, float y)
        {
            this.velocity = new Vector2f(velocity.X + x, velocity.Y + y);
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
        #endregion
    }
}
