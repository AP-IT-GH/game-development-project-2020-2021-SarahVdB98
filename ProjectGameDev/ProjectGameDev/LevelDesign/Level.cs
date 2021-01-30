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
        public static int rows = 6;
        public static int columns = 8;
        

        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,0,0,0 },
            {0,0,0,1,0,1,1,1 },
            {0,0,0,1,1,1,0,0 },
            {0,0,1,1,0,0,1,1 },
            {0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0 }
        };

        public Brick[,] blokArray = new Brick[rows, columns];

        private ContentManager content;

        public Level(ContentManager content)
        {
            this.content = content;

            InitializeContent();
        }

        private void InitializeContent()
        {
            texture = content.Load<Texture2D>("blok");
        }


        public void CreateWorld()
        {
            //steen = new Brick(texture, new Vector2(128, 325));

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    if (tileArray[x, y] == 1)
                    {
                        blokArray[x, y] = new Brick(texture, new Vector2(y *50 , x*90
                            ));
                    }
                }
            }
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            //steen.Draw(spritebatch);
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    if (blokArray[x, y] != null)
                    {
                        blokArray[x, y].Draw(spritebatch);
                    }
                }
            }

        }
    
}
}
