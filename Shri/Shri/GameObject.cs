using Microsoft.Xna.Framework;

namespace Shri
{
    internal class GameObject
    {
        Sprite Sprite;
        Vector2 Position;

        public GameObject(Sprite sprite)
        {
            Sprite = sprite;
            Position = sprite.Position;
        }
    }
}