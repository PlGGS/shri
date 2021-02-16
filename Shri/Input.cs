using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    [Flags]
    public enum Input
    {
        Up = 1,
        Left = 2,
        Down = 4,
        Right = 8,
        Back = 16,
        Start = 32,
        Grow = 64,
        Shrink = 128,
        Blue = 256,
        Yellow = 512,
        Red = 1024,
        Shoot = 2048
    }
}
