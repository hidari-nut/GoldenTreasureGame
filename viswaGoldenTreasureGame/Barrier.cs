using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace viswaGoldenTreasureGame
{
    public class Barrier : Items
    {
        public Barrier(string name, string tag, Image image, Point location, Size size) 
            : base(name, tag, image, location, size)
        {

        }

        public bool[] barrierCollisions(PictureBox playerPicture, PictureBox barrierPicture)
        {
            Rectangle intersection = Rectangle.Intersect(playerPicture.Bounds, barrierPicture.Bounds);
            if (intersection.IsEmpty)
            {
                return new[] { false, false, false, false };
            }

            bool hitSomethingAbove = playerPicture.Top == intersection.Top;
            bool hitSomethingBelow = playerPicture.Bottom == intersection.Bottom;
            bool hitSomethingOnTheRight = playerPicture.Right == intersection.Right;
            bool hitSomethingOnTheLeft = playerPicture.Left == intersection.Left;

            return new bool[]
            {
                hitSomethingAbove,
                hitSomethingBelow,
                hitSomethingOnTheRight,
                hitSomethingOnTheLeft,
            };
        }

        public override void TouchItem(ref Player player)
        {
            player.MovingUp = false;
            player.MovingDown = false;
            player.MovingLeft = false;
            player.MovingRight = false;

            Rectangle intersection = Rectangle.Intersect(player.Picture.Bounds, this.Picture.Bounds);
            bool[] barrierCollisionBool = barrierCollisions(player.Picture, this.Picture);
            if (barrierCollisionBool[0] == true)
            {
                player.MoveDown(intersection.Height);
            }
            if (barrierCollisionBool[1] == true)
            {
                player.MoveUp(intersection.Height);
            }
            if (barrierCollisionBool[2] == true)
            {
                player.MoveLeft(intersection.Width);
            }
            if (barrierCollisionBool[3] == true)
            {
                player.MoveRight(intersection.Width);
            }
        }
        public void RemoveThis(Player player)
        {
            player.CurrentArea.HideItem(this);
            player.CurrentArea.RemoveItem(this);
        }
    }
}