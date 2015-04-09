using System;
using System.Collections.Generic;
using Dunn_2D;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Dunn_2D
{
    /// <summary>
    /// Creates a new instance of the game loop and render window.
    ///	Handles keeping track of all game objects, rendering all of them, and creating the game loop.
    /// </summary>
    abstract public class Game
    {
        //Type variables
        public float gravity;
        public RenderWindow window;
        public String title;
        public List<Particle> particles = new List<Particle>();
        public List<Entity> entities = new List<Entity>();
        public List<Block> blocks = new List<Block>();
        public Sprite bufferSprite;

        //Native variables
        public uint width, height;

        public Game()
        {
            Init();
            Setup();
            while (window.IsOpen)
            {
                Update();
                Prepare();
                Draw();
            }
            Cleanup();
        }


        public void Init()
        {
            title = "Test Game";
            width = 800; //TODO Need to make this scalable
            height = 600; //TODO Need to make this scalable 
            Log.Output(0, "Created with Dunn-2D by robodylan\nFork it on GitHub: http://github.com/robodylan/dunn-2d"); //TODO: Check that url
            window = new RenderWindow(new VideoMode(width, height), title);
            if (window != null)
            {
                Log.Output(1, "Created render window successfully");
            }
            else
            {
                Log.Output(3, "Could not create render window");
            }
            try
            {
                window.Closed += OnClose;
                window.MouseMoved += Input.setMousePos;
            }
            catch
            {
                Log.Output(3, "Could not create event handlers");
            }
            Log.Output(1, "Created event handlers successfully");
            //Add References
            entities = new List<Entity>();
            blocks = new List<Block>();
            bufferSprite = new Sprite();
            Log.Output(1, "Created base references successfully");
        }
        abstract public void Setup();

        public void Prepare()
        {
            try
            {
                window.DispatchEvents();
                window.Clear();
            }
            catch
            {
                Log.Output(3, "Could not dispatch window events or clear the window");
            }
        }
        abstract public void Update();

        public void Draw()
        {
            //Draw each Block in blocks
            foreach (Block b in blocks)
            {
                bufferSprite.Texture = b.texture;
                bufferSprite.Position = b.position;
                window.Draw(bufferSprite);
            }
            //Draw each Entity in entities
            foreach (Entity e in entities)
            {
                bufferSprite.Texture = e.texture;
                bufferSprite.Position = e.position;
                window.Draw(bufferSprite);
                //Begin physics processing
                if (e.hasPhysics)
                {
                    bool willCollideOnX = false;
                    bool willCollideOnY = false;
                    foreach (Block check in blocks)
                    {
                        if (PhysMath.willCollide(new FloatRect(e.position.X + e.velocity.X, e.position.Y, e.texture.Size.X, e.texture.Size.Y),
                                                 new FloatRect(check.position.X, check.position.Y, check.texture.Size.X, check.texture.Size.Y)))
                        {

                            e.setVelocity(-e.velocity.X / 2, e.velocity.Y / 2);
                            willCollideOnX = true;
                        }
                    }
                    foreach (Block check in blocks)
                    {
                        if (PhysMath.willCollide(new FloatRect(e.position.X, e.position.Y + e.velocity.Y, e.texture.Size.X, e.texture.Size.Y),
                                                 new FloatRect(check.position.X, check.position.Y, check.texture.Size.X, check.texture.Size.Y)))
                        {
                            e.setVelocity(e.velocity.X / 2, -e.velocity.Y / 2);
                            willCollideOnY = true;
                        }
                    }

                    if (!willCollideOnX)
                    {
                        e.Move(e.velocity.X, 0);
                    }
                    if (!willCollideOnY)
                    {

                        e.addVelocity(0, gravity);
                        e.Move(0, e.velocity.Y);
                    }
                }
            }

            foreach (Particle e in particles)
            {
                bufferSprite.Texture = e.texture;
                bufferSprite.Position = e.position;
                window.Draw(bufferSprite);
                e.Move(e.velocity.X, 0);
                e.addVelocity(0, gravity);
                e.Move(0, e.velocity.Y);
                
            }
            window.Display();
        }

        public void Cleanup()
        {
            Log.Output(1, "Cleaning up.... ;)");
        }

        public void OnClose(object sender, EventArgs e)
        {
            Log.Output(2, "Window has been closed, exiting...");
            window.Close();
        }
        #region GettersAndSetters
        public void setScale(int scale)
        {
            Block.blockSize = scale;
            Log.Output(1, "Changed the game scale to " + scale + " pixels");
        }

        public void setTitle(string title)
        {
            window.SetTitle(title);
            Log.Output(1, "Change the window title to \"" + title + "\"");
        }

        public void removeAllEntities()
        {
            Log.Output(1, "All entities were cleared successfully");
            entities.Clear();
        }

        public void removeAllBlocks()
        {
            Log.Output(1, "All blocks were cleared successfully");
            blocks.Clear();
        }

        public void AddToScene(Entity e)
        {
            entities.Add(e);
        }

        public void AddToScene(Block b)
        {
            blocks.Add(b);
        }

        public void createParticleSystem(int x, int y, string fileName)
        {
            Random r = new Random(12);
        }

        public void createParticleSystem(int x, int y, string fileName, int seed)
        {
            Random r = new Random(seed);
            for (int i = 0; i < 100; i++)
            {
                particles.Add(new Particle(fileName, x, y));
            }
        }

        public void setFPS(int fps)
        {
            window.SetFramerateLimit((uint)fps);
        }

        public void setGravity(float g)
        {
            gravity = g;
        }
        #endregion
    }
}