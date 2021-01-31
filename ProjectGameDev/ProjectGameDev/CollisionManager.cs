using Microsoft.Xna.Framework;
using ProjectGameDev.Input;
using ProjectGameDev.LevelDesign;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProjectGameDev
{
    class CollisionManager
    {
        public static bool collided;
        public void collisionAction( Level level, Hero hero)
        {
            for (int x = 0; x < Level.rows; x++)
            {
                for (int y = 0; y < Level.columns; y++)
                {
                    if (level.tileArray[x, y] == 1)
                    {
                        if (CheckCollision(hero.CollisionRectangle, level.blokArray[x, y].CollisionRectangle))
                        {
                            //als je erbovenop staat
                            if (hero.CollisionRectangle.Y+80< level.blokArray[x, y].CollisionRectangle.Y)
                            {
                                collided = true;
                                hero.positie.Y = level.blokArray[x, y].CollisionRectangle.Top - hero.CollisionRectangle.Height;
                            }
                            //als je er niet bovenop staat
                            //rechts ertegen
                            else if (hero.CollisionRectangle.X + 30 > level.blokArray[x, y].CollisionRectangle.X)
                            {
                                hero.inputReader.canMoveLeft = false;
                            }
                            //links ertegen
                            else if (hero.CollisionRectangle.X + 30 < level.blokArray[x, y].CollisionRectangle.X)
                            {
                                hero.inputReader.canMoveRight = false;
                            }
                            // als je eronder zit
                            if (hero.CollisionRectangle.Y > level.blokArray[x, y].CollisionRectangle.Y)
                            {
                                hero.inputReader.canMoveUp = false;
                                hero.positie.Y = level.blokArray[x, y].CollisionRectangle.Bottom;
                                KeyBoardReader.Velocity.Y = 0.1f;
                            }
                        }

                    }
                }

            }
        }

        public void collisionAction(Hero hero, Enemy enemy)
        {
            if (CheckCollision(hero.CollisionRectangle, enemy.CollisionRectangle))
            {
                //als je erbovenop staat
                if (hero.CollisionRectangle.Y + 85 < enemy.CollisionRectangle.Y)
                {
                    collided = true;
                    enemy.positie = new Vector2(-100, -100);
                }
                //als je er niet bovenop staat
                //rechts ertegen
                else if (hero.CollisionRectangle.X + 80 > enemy.CollisionRectangle.X)
                {
                    Game1.gameState = GameState.Dead;
                }
                //links ertegen
                else if (hero.CollisionRectangle.X + 80 < enemy.CollisionRectangle.X)
                {
                    Game1.gameState = GameState.Dead;
                }
                // als je eronder zit
                if (hero.CollisionRectangle.Y > enemy.CollisionRectangle.Y)
                {
                    Game1.gameState = GameState.Dead;
                    hero.inputReader.canMoveUp = false;
                }
            }
        

            }
        

        public bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {

            if (rect1.Intersects(rect2)) 
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
