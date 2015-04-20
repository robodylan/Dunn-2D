using System;
using System.Collections.Generic;
using Dunn_2D;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Diagnostics;

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
        public List<Entity> entities = new List<Entity>();
        public List<Block> blocks = new List<Block>();
        public List<GUI.Button> buttons = new List<GUI.Button>();
        public List<GUI.Text> texts = new List<GUI.Text>();
        public Sprite bufferSprite;
        public Text bufferText;
        public int totalFrames = 0;
        public Random rand = new Random();
        public Texture background;
        public Texture overlay;
        public static int Kills;
        public int Destroyed;

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
            bufferText = new Text("", new Font("content/fnt/Font.ttf"));
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
            Sprite bg = new Sprite(background);
            bg.Scale = new Vector2f(10,10);
            bg.Position = new Vector2f((window.GetView().Center.X  / 1.5f) - 800, (window.GetView().Center.Y / 1.5f) - 600);
            window.Draw(bg);
            totalFrames++;
            //Draw each Block in blocks
            foreach (Block b in blocks)
            {
                if (b.getX() > (int)window.GetView().Center.X - (int)(width / 2) - b.texture.Size.X && b.getX() < (int)window.GetView().Center.X - (int)(width / 2) + width)
                {
                    int mX = Mouse.GetPosition(window).X + (int)window.GetView().Center.X - (int)(width / 2);
                    int mY = Mouse.GetPosition(window).Y + (int)window.GetView().Center.Y - (int)(height / 2);
                    if (b.ID == 14) b.rotation += 5;
                    if (b.mouseHover)
                    {
                        bufferSprite.Color = Color.Red;
                    }
                        bufferSprite = new Sprite(b.texture);
                        bufferSprite.Rotation = b.rotation;
                        bufferSprite.Color = b.color;
                        bufferSprite.Position = b.position;
                        if (b.ID == 14) bufferSprite.Position = new Vector2f(b.position.X + 32, b.position.Y + 32);
                        if (b.ID == 14) bufferSprite.Origin = new Vector2f(32,32);
                        window.Draw(bufferSprite);
                        bufferSprite.Color = Color.White;
                }
            }
            try
            {
                //Draw each Entity in entities
                foreach (Entity e in entities)
                {
                        bufferSprite = new Sprite(e.texture);
                        bufferSprite.Color = e.color;
                        bufferSprite.Position = e.position;
                        window.Draw(bufferSprite);
                        bufferSprite.Color = Color.White;
                    if (e.getX() > (int)window.GetView().Center.X - (int)(width / 2) - 64 && e.getX() < (int)window.GetView().Center.X - (int)(width / 2) + width) 
                    {
                        if(e.position.Y > 10000 && !e.isControlled)
                        {
                            entities.Remove(e);
                            if (!e.isParticle) Kills++;
                            return;
                        }
                        if (!e.isControlled && e.isColliding)
                        {
                            if(e.getX() < e.targetX)
                            {                                
                                e.addVelocity(rand.Next(2, 22) / 20f,0);
                                e.fileName = "content/img/enemyRight";
                            }
                            if (e.getX() > e.targetX)
                            {
                                e.addVelocity(-rand.Next(2, 22) / 20f, 0);
                                e.fileName = "content/img/enemyLeft";
                            }
                            if (e.getY() > e.targetY)
                            {
                                e.addVelocity(0, -rand.Next(1, 8) * 3.56f);
                            }
                        }
                        if (e.Health < 0)
                        {
                            if (!e.isParticle) Kills++;
                            entities.Remove(e);
                        }
                        bool touch = false;
                        if (e.killedByTouch)
                        {
                            foreach (Entity check in entities)
                            {
                                if (PhysMath.willCollide(new FloatRect(e.getX(), e.getY(), e.texture.Size.X, e.texture.Size.Y), new FloatRect(check.getX(), check.getY(), check.texture.Size.X, check.texture.Size.Y)) && !(check == e) && !check.isParticle)
                                {
                                    touch = true;
                                }
                            }
                        }
                        if (touch && !e.isParticle)
                        {
                            e.touching = true;
                        }
                        else
                        {
                            e.touching = false;
                        }
                        if (totalFrames % 2.5f == 0)
                        {
                            e.Animate();
                        }
                        //Begin physics processing
                        if (e.hasPhysics)
                        {
                            bool willCollideOnX = false;
                            bool willCollideOnY = false;
                            foreach (Block check in blocks)
                            {
                                if (check.getX() > (int)window.GetView().Center.X - (int)(width / 2) - 64 && check.getX() < (int)window.GetView().Center.X - (int)(width / 2) + width && check.getY() > (int)window.GetView().Center.Y - (int)(width / 2) - 64 && check.getY() < (int)window.GetView().Center.Y - (int)(height / 2) + height && !e.isParticle)
                                {
                                    if (PhysMath.willCollide(new FloatRect(e.position.X + 1 + e.velocity.X, e.position.Y + 1, e.texture.Size.X - 1, e.texture.Size.Y - 1),
                                                             new FloatRect(check.position.X, check.position.Y, check.texture.Size.X, check.texture.Size.Y)))
                                    {
                                        if (check.ID == 14)
                                        {
                                            if (e.isControlled)
                                            {
                                                Cleanup();
                                            }
                                            if (!e.isParticle) check.damage = check.damage + 40;
                                            if (!e.isParticle) Kills++;
                                            entities.Remove(e);
                                            return;
                                        }
                                        if (!e.isParticle) e.setVelocity(e.velocity.X / 1.4f, e.velocity.Y);
                                        willCollideOnX = true;
                                    }
                                    if (PhysMath.willCollide(new FloatRect(e.position.X + 1, e.position.Y + 1 + e.velocity.Y + gravity, e.texture.Size.X - 1, e.texture.Size.Y - 1),
                                                             new FloatRect(check.position.X, check.position.Y, check.texture.Size.X, check.texture.Size.Y)))
                                    {
                                        if (check.ID == 14)
                                        {
                                            if (e.isControlled)
                                            {
                                                Cleanup();
                                            }
                                            if (!e.isParticle) check.damage = check.damage + 40;
                                            if (!e.isParticle) Kills++;
                                            entities.Remove(e);
                                            return;
                                        }
                                        if (!e.isParticle) e.setVelocity(e.velocity.X * .90f, e.velocity.Y / 1.4f);
                                        willCollideOnY = true;
                                    }
                                }
                            }

                            if (!willCollideOnX || e.isParticle)
                            {
                                e.Move(e.velocity.X, 0);
                            }
                            if (!willCollideOnY || e.isParticle)
                            {
                                e.isColliding = false;
                                e.addVelocity(0, gravity);
                                e.Move(0, e.velocity.Y);
                            }
                            else if(e.velocity.Y > 0)
                            {
                                e.isColliding = true;
                            }
                        }
                    }
                }
                foreach(GUI.Text t in texts)
                {   
                    bufferText.Color = Color.Black;
                    bufferText.CharacterSize = 25;
                    bufferText.Position = new Vector2f(t.x + (int)window.GetView().Center.X - (int)(width / 2) + 3, t.y + (int)window.GetView().Center.Y - (int)(height / 2) + 3);
                    bufferText.DisplayedString = t.text;
                    window.Draw(bufferText);
                    bufferText.Color = t.color;
                    bufferText.CharacterSize = 25;
                    bufferText.Position = new Vector2f(t.x + (int)window.GetView().Center.X - (int)(width / 2), t.y + (int)window.GetView().Center.Y - (int)(height / 2));
                    bufferText.DisplayedString = t.text;
                    window.Draw(bufferText);
                }
            }
            catch
            {

            }
            window.Display();
        }

        public void Cleanup()
        {
            window.Close();
            Log.Output(1, "Cleaning up.... ;)");
        }

        public void OnClose(object sender, EventArgs e)
        {
            Log.Output(2, "Window has been closed, exiting...");
            window.Close();
        }
        #region GettersAndSetters

        public int getMouseX()
        {
            return Mouse.GetPosition(window).X + offsetX() - (int)(width / 2) - 32;
        }

        public int getMouseY()
        {
            return Mouse.GetPosition(window).Y + offsetY() - (int)(height / 2) - 32;
        }
        public int offsetX()
        {
            return (int)window.GetView().Center.X;
        }
        public int offsetY()
        {
            return (int)window.GetView().Center.Y;
        }
        public void setBackground(string filename)
        {
            this.background = Util.getTexture(filename);
        }
        public void setOverlay(string filename)
        {
            this.overlay = Util.getTexture(filename);
        }
        public void setCenter(int centerX, int centerY)
        {
            window.SetView(new View(new FloatRect(centerX - ((width - 64) / 2), centerY - ((height - 64) / 2), 800, 600)));
        }
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

        public void AddToScene(GUI.Text t)
        {
            texts.Add(t);
        }

        public void AddToScene(GUI.Button btn)
        {
            buttons.Add(btn);
        }

        public void createParticleSystem(int x, int y, string fileName)
        {
            for (int i = 0; i < 3; i++)
            {
                Entity e = new Entity(fileName, x, y, true, true);
                e.setVelocity(rand.Next(-100, 100) / 10f, rand.Next(-100, 100) / 10f);
                e.setColor(255,255,255);
                e.isParticle = true;
                AddToScene(e);
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