using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace viswaGoldenTreasureGame
{
    public class ObstacleItem : Items
    {
        int lifeDamage;
        bool movingUp;
        bool movingDown;
        bool movingRight;
        bool movingLeft;

        public ObstacleItem(string name, string tag, Image image, Point location, 
            Size size, int lifeDamage) : base(name, tag, image, location, size)
        {
            LifeDamage = lifeDamage;
            MovingUp = false;
            MovingDown = false;
            MovingRight = false;
            MovingLeft = false;
        }

        public int LifeDamage { get => lifeDamage; set => lifeDamage = value; }
        public bool MovingUp { get => movingUp; set => movingUp = value; }
        public bool MovingDown { get => movingDown; set => movingDown = value; }
        public bool MovingRight { get => movingRight; set => movingRight = value; }
        public bool MovingLeft { get => movingLeft; set => movingLeft = value; }      

        public override void TouchItem(ref Player player)
        {
            player.Life -= this.LifeDamage;
            player.CurrentArea.HideItem(this);
            player.CurrentArea.RemoveItem(this);
        }
    }
}