using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GameProject.Scripts
{
    public class Player : Sprite
    {
        public float health = 100f;
        
        public Player(Texture2D texture, bool deadly)

          : base(texture, deadly)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            

            var speed = 3f;
            
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                Velocity.Y = -speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
                Velocity.Y = speed;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                Velocity.X = -speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                Velocity.X = speed;
            foreach(var sprite in sprites)
            {
                if(sprite == this)
                {
                    continue;

                }
                if((this.Velocity.X > 0 && this.IstouchingLeft(sprite)) || (this.Velocity.X < 0 && this.IstouchingRight(sprite)))
                {
                    Velocity.X = 0;
                    if(sprite._deadly == true)
                    {
                        
                            health -= 1;
                            Debug.WriteLine(health.ToString());
                        Pos = new Vector2(Pos.X - (sprite.Pos.X * 10), Pos.Y);

                    }
                }
                if ((this.Velocity.Y > 0 && this.IstouchingTop(sprite)) || (this.Velocity.Y < 0 && this.IstouchingBottom(sprite)))
                {
                    Velocity.Y = 0;
                    if (sprite._deadly == true)
                    { 

                      
                            health -= 1;
                            Debug.WriteLine(health.ToString());
                        
                            Pos = new Vector2(Pos.X, Pos.Y - (sprite.Pos.Y * 10));
                        
                        


                    }
                }
            }
            
            
            Pos += Velocity;

            Velocity = Vector2.Zero;
        }
        
    }
}
