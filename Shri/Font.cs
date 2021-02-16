using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public Font(FramedSprite framedSprite, Dictionary<int, int> mapping, int horizontalKern, int verticalKern, Color fontColor)
        {
            _sprite = framedSprite;
            _sprite.CurrentFrame = 0;
            _sprite.SetTint(fontColor);

            _mapping = mapping;

            kerning = new Size
            {
                Height = horizontalKern,
                Width = verticalKern
            };
        }

        public void DrawString(SpriteBatch spriteBatch, string text, Vector2 position)
        {
            int x = (int)position.X;
            int y = (int)position.Y;

            foreach (char c in text)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(new char[] { c });
                int key = BitConverter.ToInt16(bytes, 0);
                int translatedValue = _mapping[key];

                _sprite.CurrentFrame = translatedValue;

                _sprite.Position = new Vector2(x, y);
                x += Sprite.FrameSize.Width + kerning.Width;

                _sprite.Draw(spriteBatch);
            }
        }
    }
}
