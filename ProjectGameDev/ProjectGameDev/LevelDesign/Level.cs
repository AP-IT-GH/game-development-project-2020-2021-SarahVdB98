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
        public Brick steen;

        //public byte[,] tileArray = new Byte[,]
        //{
        //    {0,0,0,0,0,0 },
        //    {0,0,0,0,0,0 },
        //    {0,0,0,0,0,0 },
        //    {1,0,1,0,1,0 },
        //    {0,1,0,1,0,1 },
        //};

        //public Brick[,] blokArray = new Brick[5, 6];

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
            steen = new Brick(texture, new Vector2(128, 250));

            //for (int x = 0; x < 5; x++)
            //{
            //    for (int y = 0; y < 6; y++)
            //    {
            //        if (tileArray[x, y] == 1)
            //        {
            //           blokArray[x, y] = new Brick(texture, new Vector2(y * 128, x * 64));
            //        }
            //    }
            //}
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            steen.Draw(spritebatch);
            //for (int x = 0; x < 5; x++)
            //{
            //    for (int y = 0; y < 6; y++)
            //    {
            //        if (blokArray[x, y] != null)
            //        {
            //            blokArray[x, y].Draw(spritebatch);
            //        }
            //    }
            //}

        }
    
}
}
