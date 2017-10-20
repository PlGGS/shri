using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri
{
    public class ContentManager
    {
        private GraphicsDevice _graphicsDevice;
        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return _graphicsDevice;
            }
        }

        public ContentManager()
        {

        }

        /// <summary>
        /// Grabs a completely created GraphicsDevice so the game doesn't compile null.
        /// </summary>
        /// <param name="graphicsDevice"></param>
        public void Prepare(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        /// <summary>
        /// Gets a texture for later use.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public Texture2D GetTexture(string filePath) //No need to check multiple folders, as all of our texture files should be in Content\Sprites
        {
            Texture2D texture = null;

            if (File.Exists(filePath))
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    texture = Texture2D.FromStream(_graphicsDevice, stream);
                }
            }
            else
            {
                throw new FileNotFoundException("Couldn't find image file: " + filePath);
            }

            return texture;
        }

        public Dictionary<int, int> GetFontMapping(string filePath)
        {
            Dictionary<int, int> mapping = new Dictionary<int, int>();

            if (File.Exists(filePath))
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        int lineVal = 0;

                        while (reader.EndOfStream == false)
                        {
                            string line = reader.ReadLine();
                            int key = BitConverter.ToInt16(Encoding.Unicode.GetBytes(line), 0);

                            mapping.Add(key, lineVal);

                            lineVal++;
                        }
                    }
                }
            }

            return mapping;
        }

        public SoundEffect GetSoundEffect(string filePath)
        {
            SoundEffect sfx = null;

            if (File.Exists(filePath))
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    sfx = SoundEffect.FromStream(stream);
                }
            }
            else
            {
                throw new FileNotFoundException("Couldn't find audio file: " + filePath);
            }

            return sfx;
        }
    }
}
