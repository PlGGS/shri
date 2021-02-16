using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri.Managers
{
    public struct SoundFX
    {
        public string Key { get; set; }
        public string FileName { get; set; }
        public float DefaultVolume { get; set; }
        public float DefaultPitch{ get; set; }
    }
}