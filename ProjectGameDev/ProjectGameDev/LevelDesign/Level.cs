using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGameDev.LevelDesign
{
    class Level
    {
        public Texture2D texture;
        public Vector2 pos = new Vector2(250, 340);

        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {1,0,1,0,1,0 },
            {0,1,0,1,0,1 },

        };
        private Brick[,] brickArray = new Brick[4,6];

        private ContentManager content;

        public Level(ContentManager content)
        {
            this.content = content;
            InitializeContent();

        }

        private void InitializeContent()
        {
            texture = content.Load<Texture2D>("wall");
        }

        public void CreateWorld()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (tileArray[x,y] == 1)
                    {
                        brickArray[x, y] = new Brick(texture, new Vector2(y *128, x * 90));
                    }
                }
            }

        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (brickArray[x,y] != null)
                    {
                        brickArray[x, y].Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
