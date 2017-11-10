using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    public class Circle
    {
        protected Vector2 _center;
        public Vector2 Center
        {
            get
            {
                return _center;
            }
            set
            {
                _center = value;
            }
        }

        protected float _radius;
        public float Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public Circle(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public bool Contains(Vector2 point)
        {
            return ((point - _center).Length() <= _radius);
        }

        public bool Intersects(Circle other) //TODO finish circular collision detection
        {
            Console.WriteLine($"distance: {(Math.Sqrt(Math.Pow((other.Center.X - _center.X), 2) + Math.Pow((other.Center.Y - _center.Y), 2)))} | {other.Radius + _radius}");
            return (Math.Sqrt(Math.Pow((other.Center.X - _center.X), 2) + Math.Pow((other.Center.Y - _center.Y), 2))) < (other.Radius + _radius);
        }

        public bool Intersects(Rectangle rectangle)
        {
            Vector2 v = new Vector2(MathHelper.Clamp(Center.X, rectangle.Left, rectangle.Right),
                                    MathHelper.Clamp(Center.Y, rectangle.Top, rectangle.Bottom));
            Vector2 direction = Center - v;
            float distanceSquared = direction.LengthSquared();

            return ((distanceSquared > 0) && (distanceSquared < _radius * _radius));
        }
    }
}
