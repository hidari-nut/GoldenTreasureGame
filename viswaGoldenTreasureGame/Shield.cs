using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace viswaGoldenTreasureGame
{
    public class Shield : Items
    {
        private int duration;

        public Shield(string name, string tag, Image image, Point location, Size size,
            int duration)
            : base(name, tag, image, location, size)
        {
            Duration = duration;
        }

        public Shield(Shield copiedShield)
            :base(copiedShield.Name, (string)copiedShield.Picture.Tag, copiedShield.Picture.Image,
                 copiedShield.Picture.Location, copiedShield.Picture.Size)
        {
            Duration = copiedShield.Duration;
        }

        public int Duration { get => duration; set => duration = value; }
    }
}