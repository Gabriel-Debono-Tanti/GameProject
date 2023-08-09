using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Scripts
{
    public class Biome
    {
        protected Texture2D _texture;
        
        public Vector2 Pos { get; set; }

        public Rectangle Rect
        {
            get { return new Rectangle((int)Pos.X, (int)Pos.Y, _texture.Width, _texture.Height); }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Pos, Color.White);
            
        }
        public Biome(Texture2D texture, Vector2 pos)
        {
            _texture = texture;
            Pos = pos;
        }
        

    }
}
