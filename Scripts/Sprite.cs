using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Scripts
{
    public class Sprite
    {
        protected Texture2D _texture;
        public Vector2 Velocity;
        public Vector2 Pos { get; set; }
        public bool _deadly;
        public Rectangle Rect
        {
            get { return new Rectangle((int)Pos.X, (int)Pos.Y, _texture.Width, _texture.Height);}
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Pos, Color.White);
        }
        public Sprite(Texture2D texture, bool deadly)
        {
            _texture = texture;
            _deadly = deadly;
        }
        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }
        
        protected bool IstouchingLeft(Sprite sprite)
        {
            return this.Rect.Right + this.Velocity.X > sprite.Rect.Left &&
                   this.Rect.Left < sprite.Rect.Left &&
                   this.Rect.Bottom > sprite.Rect.Top &&
                   this.Rect.Top < sprite.Rect.Bottom;

        }
        protected bool IstouchingRight(Sprite sprite)
        {
            return this.Rect.Left + this.Velocity.X < sprite.Rect.Right &&
                   this.Rect.Right > sprite.Rect.Right &&
                   this.Rect.Bottom > sprite.Rect.Top &&
                   this.Rect.Top < sprite.Rect.Bottom;

        }
        protected bool IstouchingTop(Sprite sprite)
        {
            return this.Rect.Bottom + this.Velocity.Y > sprite.Rect.Top &&
                   this.Rect.Top < sprite.Rect.Top &&
                   this.Rect.Right > sprite.Rect.Left &&
                   this.Rect.Left < sprite.Rect.Right;

        }
        protected bool IstouchingBottom(Sprite sprite)
        {
            return this.Rect.Top + this.Velocity.Y < sprite.Rect.Bottom &&
                   this.Rect.Bottom > sprite.Rect.Bottom &&
                   this.Rect.Right > sprite.Rect.Left &&
                   this.Rect.Left < sprite.Rect.Right;

        }
    }

}
