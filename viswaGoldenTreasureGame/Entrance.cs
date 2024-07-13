using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace viswaGoldenTreasureGame
{
    public class Entrance : Items
    {
        private int targetAreaNum;
        private Point playerSpawnPoint;

        public Entrance(string name, string tag, Image image, Point location, Size size,
            int targetAreaNum, Point playerSpawnPoint)
            : base(name, tag, image, location, size)
        {
            TargetAreaNum = targetAreaNum;
            PlayerSpawnPoint = playerSpawnPoint;
        }

        public int TargetAreaNum { get => targetAreaNum; set => targetAreaNum = value; }
        public Point PlayerSpawnPoint { get => playerSpawnPoint; set => playerSpawnPoint = value; }
    }
}