using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dunn_2D;

namespace Test_Game
{
    class testGame : Game
    {

        public override void Setup()
        {
            setScale(32);
            setFPS(60);
            gravity = 0.1f;
            blocks = Util.getBlocksFrom("map.png", "portrait.png",0);
            entities = Util.getEntitiesFrom("mape.png", "entity.png",0);
        }

        public override void Update()
        {
            foreach(Entity e in entities)
            {
                e.addVelocity(0,0.1f);
            }
        }
    }
}
