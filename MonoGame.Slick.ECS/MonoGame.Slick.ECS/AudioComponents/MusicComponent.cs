using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.Slick.ECS.AudioComponents
{
    public abstract class MusicComponent
    {
        public MusicSet CurrentMusicSet { get; set; }

        public abstract void Update(IEntity ientity);
    }
}
