using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace Dunn_2D
{
	/// <summary>
	/// Creates a list of all Entities, Blocks, or Other types in a given level file.
	/// </summary>
	public static class Util
	{
		public static Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
		
		public static List<Entity> getEntitiesFrom(string mapFile, int id)
		{
			Log.Output(1, "Beginning the loading of entities of ID:" + id + " from map: " + mapFile);			
			List<Entity> entities = new List<Entity>();
			try {
	            Image image = new Image(mapFile);            
			    for (int y = 0; y < image.Size.Y; y++) {
			    	for (int x = 0; x < image.Size.X; x++)	{
	            		if (image.GetPixel((uint)x,(uint)y).R == id) {
	            			entities.Add(new Entity("portrait.png",x * Block.blockSize, y * Block.blockSize));
						}	
	            	}
				}
			} catch {
				Log.Output(3, "Error in loading entities from map: " + mapFile);
			}
			Log.Output(1, "Done loading entities");
            return entities;            
		}
		public static List<Block> getBlocksFrom(string mapFile, int id) 
		{
			Log.Output(1, "Beginning the loading of blocks of ID:" + id +" from map: " + mapFile);
			List<Block> blocks = new List<Block>();
			try {
				Image image = new Image(mapFile);
				for(int y = 0; y < image.Size.Y; y++) {
					for(int x = 0; x < image.Size.X; x++) {
						if(image.GetPixel((uint)x,(uint)y).R == id) {
							blocks.Add(new Block("portrait.png", x * Block.blockSize, y * Block.blockSize));
						}
					}
				}
			} catch {
				Log.Output(3, "Error in loading the blocks from the map");
			}
			Log.Output(1, "Done loading blocks");
			return blocks;
		}
		
		public static Texture getTexture(string filename) {
			if (textures.ContainsKey(filename)) {
				return textures[filename];
				Console.WriteLine("Loaded " + filename);
				//TODO exception handling 
			}
			else
			{
				Texture tex = new Texture(filename);
				textures.Add(filename, tex);
				return tex;
			}
		}
	}
}
