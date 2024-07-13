using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace viswaGoldenTreasureGame
{
    public class Hazard : Items
    {
        private int lifeDamage;

        public Hazard(string name, string tag, Image image, Point location, Size size, int lifeDamage)
            :base(name, tag, image, location, size)
        {
            LifeDamage = lifeDamage;
        }

        public int LifeDamage { get => lifeDamage; set => lifeDamage = value; }

        public override void TouchItem(ref Player player)
        {
            player.Life -= this.LifeDamage;
        }
    }
}