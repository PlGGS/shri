using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shri.Managers
{
    public class SoundManager
    {
        Dictionary<string, SoundFX> _settings { get; set; }
        Dictionary<string, SoundEffect> _soundEffects { get; set; }
        Dictionary<string, List<SoundEffectInstance>> _soundEffectInstances { get; set; }
        int _maxSoundEffectInstances = 3;

        public SoundManager(List<SoundFX> settings, int maxSoundEffectInstances = 3)
        {
            _settings = settings.ToDictionary(s => s.Key);
            _soundEffects = new Dictionary<string, SoundEffect>();
            _soundEffectInstances = new Dictionary<string, List<SoundEffectInstance>>();
            _maxSoundEffectInstances = maxSoundEffectInstances;
        }

        public void LoadContent(ContentManager contentManager)
        {
            if (_soundEffects == null)
            {
                _soundEffects = new Dictionary<string, SoundEffect>();
            }

            if (_soundEffectInstances == null)
            {
                _soundEffectInstances = new Dictionary<string, List<SoundEffectInstance>>();
            }

            foreach (KeyValuePair<string, SoundFX> sfx in _settings)
            {
                SoundEffect soundEffect = contentManager.GetSoundEffect(sfx.Value.FileName);

                if (soundEffect != null)
                {
                    _soundEffects.Add(sfx.Key, soundEffect);
                }
            }

            foreach (KeyValuePair<string, SoundEffect> sfx in _soundEffects)
            {
                List<SoundEffectInstance> sfxInstances = new List<SoundEffectInstance>();

                for (int i = 0; i < _maxSoundEffectInstances; i++)
                {
                    SoundEffectInstance sfxInstance = sfx.Value.CreateInstance();
                    sfxInstance.Pitch = _settings[sfx.Key].DefaultPitch;
                    sfxInstance.Volume = _settings[sfx.Key].DefaultVolume;
                    sfxInstances.Add(sfxInstance);
                }

                _soundEffectInstances.Add(sfx.Key, sfxInstances);
            }
        }

        public void PlaySound(string key, bool allowInterrupt = false)
        {
            if (_soundEffectInstances.ContainsKey(key))
            {
                List<SoundEffectInstance> instances = _soundEffectInstances[key];
                IEnumerable<SoundEffectInstance> stoppedInstances = instances.Where(s => s.State == SoundState.Stopped);
                
                if (stoppedInstances.Count() == 0 && allowInterrupt)
                {
                    SoundEffectInstance instance = instances.First();
                    instance.Stop();
                    instance.Play();
                }
                else if (stoppedInstances.Count() > 0)
                {
                    stoppedInstances.First().Play();
                }
            }
        }

        public void StopSound(string key)
        {
            if (_soundEffectInstances.ContainsKey(key))
            {
                List<SoundEffectInstance> instances = _soundEffectInstances[key];
                foreach (SoundEffectInstance instance in instances)
                {
                    if (instance.State != SoundState.Stopped)
                    {
                        instance.Stop();
                    }
                }
            }
        }
    }
}
