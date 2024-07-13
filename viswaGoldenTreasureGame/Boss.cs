using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace viswaGoldenTreasureGame
{
    public class Boss : Enemy
    {
        private int health;
        private int originalHealth;
        private int phase;
        private List<int> phaseHealthLimit;

        public Boss(string name, string tag, Image image, Point location,
            Size size, int speed, Area currentArea,
            List<int> phaseHealthLimit, int health)
            : base(name, tag, image, location, size, speed, currentArea)
        {
            Phase = 1;
            PhaseHealthLimit = phaseHealthLimit;
            Health = health;
            originalHealth = health;
        }

        public int Phase { get => phase; set => phase = value; }
        public List<int> PhaseHealthLimit { get => phaseHealthLimit; set => phaseHealthLimit = value; }
        public int Health { get => health; set => health = value; }
        public int OriginalHealth { get => originalHealth; set => originalHealth = value; }
    }
}