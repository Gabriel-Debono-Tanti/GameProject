using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Scripts
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        public void Follow(Sprite target)
        {
            var pos = Matrix.CreateTranslation(-target.Pos.X - (target.Rect.Width / 2),
                                                 -target.Pos.Y - (target.Rect.Height / 2),
                                                 0);
            var offset = Matrix.CreateTranslation(
                                    Game1.ScreenWidth / 2,
                                    Game1.ScreenHeight / 2, 0);
            Transform = pos * offset;

        }
    }
}
