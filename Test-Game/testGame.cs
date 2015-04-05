// This is the test game for the Dunn-2D engine which demonstrates the basic usage of all of it's functions as well as it's features. 
using System;
using Dunn_2D;

namespace Test_Game
{
	public class testGame : Game 
	{
		Entity player = new Entity("portrait.png", 10, 10, true);
		public override void Setup() {
			this.setScale(26);
			this.setTitle("This is a new title");
			this.entities = Util.getEntitiesFrom("map.png", 255);
			this.blocks = Util.getBlocksFrom("map.png", 0);
			this.AddEntity(player); 
		}
		
		public override void Update() {
			player.Move(10,10);
		}
	}
}
