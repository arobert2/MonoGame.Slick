using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.Slick.ECS.SpriteComponents
{
    public class SpriteComponent
    {
        public AnimatedSprite AnimatedSprite { get; set; }

        private TimeSpan _lasttrigger = new TimeSpan(0);

        public void Update(TimeSpan timespan)
        {
            if (_lasttrigger - timespan >= AnimatedSprite.FramePause)
                AnimatedSprite.Update();
        }
    }
}
