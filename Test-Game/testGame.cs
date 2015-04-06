using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dunn_2D;

namespace Test_Game
{
    class testGame : Game
    {
        Entity player = new Entity("portrait.png",1,1,true);
        public override void Setup()
        {
            setFPS(200);
            setScale(32);
            AddEntity(player);
            player.addVelocity(.5f,1f);
            entities = Util.getEntitiesFrom("mape.png", 0);
            blocks = Util.getBlocksFrom("map.png", 0);
        }

        public override void Update()
        {
            player.addVelocity(0, 0);
        }
    }
}
