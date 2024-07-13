using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace viswaGoldenTreasureGame
{
    public abstract class Items
    {
        string name;
        PictureBox picture;

        protected Items(string name, string tag, Image image, Point location, Size size)
        {
            Name = name;
            Picture = new PictureBox();
            Picture.Image = image;
            Picture.Tag = tag;
            Picture.Location = location;
            Picture.Size = size;
            Picture.BackColor = Color.Transparent;
        }

        public string Name { get => name; set => name = value; }
        public PictureBox Picture { get => picture; set => picture = value; }

        public void DisplayPicture(Control container)
        {
            Picture.Parent = container;
            Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            Picture.BackColor = Color.Transparent;
            Picture.Visible = true;
            Picture.BringToFront();
        }

        public virtual void TouchItem(ref Player player)
        {
            return;
        }

        //Moves the item on an angle (degrees) based on a circle
        //with the speed being the radius of the circle

        //Quadrant 1 (0 <= angle < 90) is the bottom right quadrant
        //Quadrant 2 (90 <= angle < 180) is the bottom left quadrant
        //Quadrant 3 (180 <= angle < 270) is the top left quadrant
        //Quadrant 4 (270 <= angle < 360) is the top right quadrant
        public void ItemMove(int degrees, Point centerPoint, int radius)
        {
            int destinationPointX = (int)(centerPoint.X + (radius * Math.Cos((degrees * Math.PI) / 180)));
            int destinationPointY = (int)(centerPoint.Y + (radius * Math.Sin((degrees * Math.PI) / 180)));
            Point destinationPoint = new Point(destinationPointX, destinationPointY);

            Picture.Location = destinationPoint;
        }
    }
}