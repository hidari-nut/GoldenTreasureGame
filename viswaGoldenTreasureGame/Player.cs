using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace viswaGoldenTreasureGame
{
    public class Player
    {
        #region DATA MEMBER
        private string name;
        private PictureBox picture;
        private int life;
        private int speed;
        private Area currentArea;
        private List<Items> listInventory;
        private bool movingUp;
        private bool movingDown;
        private bool movingRight;
        private bool movingLeft;

        #endregion
        #region CONSTRUCTOR
        public Player(string name, Image image, Point location, Size size, int life, int speed, Area currentArea)
        {
            Name = name;
            Picture = new PictureBox();
            Picture.Image = image;
            Picture.Location = location;
            Picture.Size = size;
            Life = life;
            Speed = speed;
            CurrentArea = currentArea;
            ListInventory = new List<Items>();
            MovingUp = false;
            MovingDown = false;
            MovingLeft = false;
            MovingRight = false;
        }
        #endregion
        #region PROPERTIES

        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Life
        {
            get => life;
            set
            {
                if (value > 0)
                {
                    life = value;
                }
                else
                {
                    life = 0;
                }
            }
        }
        public int Speed { get => speed; set => speed = value; }
        public Area CurrentArea
        {
            get => currentArea;
            set => currentArea = value;
        }
        internal PictureBox Picture
        {
            get => picture;
            set => picture = value;
        }
        public List<Items> ListInventory { get => listInventory; set => listInventory = value; }
        public bool MovingUp { get => movingUp; set => movingUp = value; }
        public bool MovingDown { get => movingDown; set => movingDown = value; }
        public bool MovingRight { get => movingRight; set => movingRight = value; }
        public bool MovingLeft { get => movingLeft; set => movingLeft = value; }

        #endregion
        #region METHOD
        public string DisplayData()
        {
            string data =
                 Name +
                "\nLife : " + Life;
            return data;
        }
        public void DisplayPicture(Control container)
        {
            Picture.Parent = container;
            Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            Picture.BackColor = Color.Transparent;
            Picture.Visible = true;
            Picture.BringToFront();
        }
        public void MoveLeft(int distance)
        {
            Picture.Location = new Point(Picture.Location.X - distance, Picture.Location.Y);
        }
        public void MoveRight(int distance)
        {
            Picture.Location = new Point(Picture.Location.X + distance, Picture.Location.Y);
        }
        public void MoveUp(int distance)
        {
            Picture.Location = new Point(Picture.Location.X, Picture.Location.Y - distance);
        }
        public void MoveDown(int distance)
        {
            Picture.Location = new Point(Picture.Location.X, Picture.Location.Y + distance);
        }
        #endregion
    }
}
