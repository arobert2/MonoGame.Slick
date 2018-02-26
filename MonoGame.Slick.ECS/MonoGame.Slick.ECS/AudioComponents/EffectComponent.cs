using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.Slick.ECS.AudioComponents
{
    public abstract class SoundEffectComponent
    {
        public Dictionary<string, SoundEffect> SoundEffects { get; set; } = new Dictionary<string, SoundEffect>();

        public abstract void Update(IEntity ientity);
    }
}
