using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dunn_2D;

namespace Test_Game
{
    class testGame : Game
    {
        Block b = new Block("Data/img/block.png", 1, 1, true);
        public override void Setup()
        {
            setScale(16);
            setFPS(60);
            gravity = 0.1f;
            entities = Util.getEntitiesFrom("Data/img/mape.png", "Data/img/entity.png", 0);
            blocks = Util.getBlocksFrom("Data/img/map.png", "Data/img/block.png", 0);
            AddBlock(b);
            foreach(Entity e in entities) {
                e.addVelocity(1f, 0);
            }
        }

        public override void Update()
        {
            b.setPosition(Input.getMouseX(), Input.getMouseY());
        }
    }
}
