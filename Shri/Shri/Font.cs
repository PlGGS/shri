using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    public class Font
    {
        private FramedSprite _sprite;
        public FramedSprite Sprite
        {
            get
            {
                return _sprite;
            }
        }

        Size spacing; //TODO figure out why I can't access Size.cs

        private Dictionary<int, int> mapping;

        public Font(FramedSprite framedSprite, Dictionary<int, int> mapping, int horizontalCell, int verticalCell, Color fontColor)
        {
            _sprite = sprite;
            _sprite.SetCurrentFrame(0);
            _sprite.SetTint(fontColor);

            _mapping = mapping;

            //TODO Set spacing here
        }
    }
}
