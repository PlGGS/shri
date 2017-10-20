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

        Size kerning;

        private Dictionary<int, int> _mapping;
        public Dictionary<int, int> Mapping
        {
            get
            {
                return _mapping;
            }
        }

        public Font(FramedSprite framedSprite, Dictionary<int, int> mapping, int horizontalCell, int verticalCell, Color fontColor)
        {
            _sprite = framedSprite;
            _sprite.CurrentFrame = 0;
            _sprite.SetTint(fontColor);

            _mapping = mapping;

            kerning = new Size
            {
                Height = horizontalCell,
                Width = verticalCell
            };
        }

        public void DrawString(string text, Vector2 position)
        {
            //TODO draw text here
        }
    }
}
