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
        public static bool collided = false;
        public static bool hasKeyOne = false;
        public static bool hasKeyTwo = false;
        public static bool hasAccessLevelTwo = false;

        public static bool hasAccessLevelEnd = false;
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
                            else if (hero.CollisionRectangle.X > level.blokArray[x, y].CollisionRectangle.X+20)
                            {
                                collided = true;
                                hero.inputReader.canMoveUp = false;
                                hero.inputReader.canMoveLeft = false;
                            }
                            //links ertegen
                            else if (hero.CollisionRectangle.X + 30 < level.blokArray[x, y].CollisionRectangle.X-20)
                            {
                                collided = true;

                                hero.inputReader.canMoveUp = false;
                                hero.inputReader.canMoveRight = false;
                            }
                            // als je eronder zit
                            if (hero.CollisionRectangle.Y > level.blokArray[x, y].CollisionRectangle.Y)
                            {
                                collided = true;
                                hero.inputReader.canMoveUp = true;
                                hero.positie.Y = level.blokArray[x, y].CollisionRectangle.Bottom;
                                KeyBoardReader.Velocity.Y = 0.1f;
                            }
                            
                        }

                    }
                }

            }
        }
        public void collisionAction(Level2 level, Hero hero)
        {
            for (int x = 0; x < Level2.rows2; x++)
            {
                for (int y = 0; y < Level2.columns2; y++)
                {
                    if (level.tileArray2[x, y] == 1)
                    {
                        if (CheckCollision(hero.CollisionRectangle, level.blokArray2[x, y].CollisionRectangle))
                        {
                            //als je erbovenop staat
                            if (hero.CollisionRectangle.Y + 80 < level.blokArray2[x, y].CollisionRectangle.Y)
                            {
                                collided = true;
                                hero.positie.Y = level.blokArray2[x, y].CollisionRectangle.Top - hero.CollisionRectangle.Height;
                            }
                            //als je er niet bovenop staat
                            //rechts ertegen
                            else if (hero.CollisionRectangle.X + 30 > level.blokArray2[x, y].CollisionRectangle.X)
                            {
                                collided = true;

                                hero.inputReader.canMoveUp = true;
                                hero.inputReader.canMoveLeft = false;
                            }
                            //links ertegen
                            else if (hero.CollisionRectangle.X + 30 < level.blokArray2[x, y].CollisionRectangle.X)
                            {
                                collided = true;
                                hero.inputReader.canMoveRight = false;
                                hero.inputReader.canMoveUp = true;
                            }
                            // als je eronder zit
                            if (hero.CollisionRectangle.Y > level.blokArray2[x, y].CollisionRectangle.Y)
                            {
                                collided = true;
                                hero.positie.Y = level.blokArray2[x, y].CollisionRectangle.Bottom;
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
                    if (hasAccessLevelTwo)
                    {
                        if (enemy == Game1.enemy3)
                        {
                            Game1.key2.positie = Game1.enemy3.positie;
                        }
                    }
                    collided = true;
                    hero.inputReader.canMoveUp = true;
                    Hero.IsGrounded = true;
                    enemy.positie = new Vector2(-100, -100);
                }
                //als je er niet bovenop staat
                //rechts ertegen
                else if (hero.CollisionRectangle.X + 80 > enemy.CollisionRectangle.X)
                {
                    collided = true;
                    Game1.gameState = GameState.Dead;
                }
                //links ertegen
                else if (hero.CollisionRectangle.X + 80 < enemy.CollisionRectangle.X)
                {
                    collided = true;
                    Game1.gameState = GameState.Dead;
                }
                // als je eronder zit
                if (hero.CollisionRectangle.Y > enemy.CollisionRectangle.Y)
                {
                    hero.inputReader.canMoveUp = false;
                }
            }
        }

        public void collisionAction(Hero hero, Door door)
        {
            if (CheckCollision(hero.CollisionRectangle, door.CollisionRectangle))
            {
                if (hasKeyTwo)
                {
                    //als je erbovenop staat
                    if (hero.CollisionRectangle.Y + 85 < door.CollisionRectangle.Y)
                    {
                        if (hasAccessLevelTwo)
                        {
                            hasAccessLevelEnd = true;
                        }
                        else
                        {
                            hasAccessLevelTwo = true;
                        }
                    }
                    //als je er niet bovenop staat
                    //rechts ertegen
                    else if (hero.CollisionRectangle.X + 80 > door.CollisionRectangle.X)
                    {
                        if (hasAccessLevelTwo)
                        {
                            hasAccessLevelEnd = true;
                        }
                        else
                        {
                            hasAccessLevelTwo = true;
                        }
                    }
                    //links ertegen
                    else if (hero.CollisionRectangle.X + 80 < door.CollisionRectangle.X)
                    {
                        if (hasAccessLevelTwo)
                        {
                            hasAccessLevelEnd = true;
                        }
                        else
                        {
                            hasAccessLevelTwo = true;
                        }
                    }
                    // als je eronder zit
                    if (hero.CollisionRectangle.Y > door.CollisionRectangle.Y)
                    {
                        if (hasAccessLevelTwo)
                        {
                            hasAccessLevelEnd = true;
                        }
                        else
                        {
                            hasAccessLevelTwo = true;
                        }
                    }
                }
            }
        }

        public void collisionAction(Hero hero, Key key)
        {
            if (CheckCollision(hero.CollisionRectangle, key.CollisionRectangle))
            {

                //als je erbovenop staat
                if (hero.CollisionRectangle.Y + 85 < key.CollisionRectangle.Y)
                {
                    if (!hasKeyOne)
                    {
                        if (key == Game1.key)
                        {
                            Game1.key.positie.X = hero.positie.X - 360;

                            Game1.key.positie.Y = 70;
                        }
                        if (key == Game1.key2)
                        {
                            Game1.key2.positie.X = hero.positie.X - 300;

                            Game1.key2.positie.Y = 72;
                        }
                        hasKeyOne = true;
                    }
                    else if (hasKeyOne)
                    {
                        if (key == Game1.key)
                        {
                            Game1.key.positie.X = hero.positie.X - 360;

                            Game1.key.positie.Y = 70;
                        }
                        if (key == Game1.key2)
                        {
                            Game1.key2.positie.X = hero.positie.X - 300;

                            Game1.key2.positie.Y = 72;
                        }
                        hasKeyTwo = true;
                    }

                }
                //als je er niet bovenop staat
                //rechts ertegen
                else if (hero.CollisionRectangle.X + 80 > key.CollisionRectangle.X)
                {
                    if (!hasKeyOne)
                    {
                        if (key == Game1.key)
                        {
                            Game1.key.positie.X = hero.positie.X - 360;

                            Game1.key.positie.Y = 70;
                        }
                        if (key == Game1.key2)
                        {
                            Game1.key2.positie.X = hero.positie.X - 300;

                            Game1.key2.positie.Y = 72;
                        }
                        hasKeyOne = true;
                    }
                    else if (hasKeyOne)
                    {
                        if (key == Game1.key)
                        {
                            Game1.key.positie.X = hero.positie.X - 360;

                            Game1.key.positie.Y = 70;
                        }
                        if (key == Game1.key2)
                        {
                            Game1.key2.positie.X = hero.positie.X - 300;

                            Game1.key2.positie.Y = 72;
                        }
                        hasKeyTwo = true;
                    }
                }
                //links ertegen
                else if (hero.CollisionRectangle.X + 80 < key.CollisionRectangle.X)
                {
                    if (!hasKeyOne)
                    {
                        if (key == Game1.key)
                        {
                            Game1.key.positie.X = hero.positie.X - 360;

                            Game1.key.positie.Y = 70;
                        }
                        if (key == Game1.key2)
                        {
                            Game1.key2.positie.X = hero.positie.X - 300;

                            Game1.key2.positie.Y = 72;
                        }
                        hasKeyOne = true;
                    }
                    else if (hasKeyOne)
                    {
                        if (key == Game1.key)
                        {
                            Game1.key.positie.X = hero.positie.X - 360;

                            Game1.key.positie.Y = 70;
                        }
                        if (key == Game1.key2)
                        {
                            Game1.key2.positie.X = hero.positie.X - 300;

                            Game1.key2.positie.Y = 72;
                        }
                        hasKeyTwo = true;
                    }
                }
                else if (hero.CollisionRectangle.Y > key.CollisionRectangle.Y)
                {
                    if (!hasKeyOne)
                    {
                        if (key == Game1.key)
                        {
                            Game1.key.positie.X = hero.positie.X - 360;
                            Game1.key.positie.Y = 70;
                        }
                        if (key == Game1.key2)
                        {
                            Game1.key2.positie.X = hero.positie.X - 300;

                            Game1.key2.positie.Y = 72;
                        }
                        hasKeyOne = true;
                    }
                    else if (hasKeyOne)
                    {
                        if (key == Game1.key)
                        {
                            Game1.key.positie.X = hero.positie.X - 360;

                            Game1.key.positie.Y = 70;
                        }
                        if (key == Game1.key2)
                        {
                            Game1.key2.positie.X = hero.positie.X - 300;

                            Game1.key2.positie.Y = 72;
                        }
                        hasKeyTwo = true;
                    }
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
