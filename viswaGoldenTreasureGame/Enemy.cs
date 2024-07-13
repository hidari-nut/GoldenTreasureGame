using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace viswaGoldenTreasureGame
{
    public class Enemy
    {
        private string name;
        private string tag;
        private PictureBox picture;
        private int life;
        private int speed;
        private Area currentArea;
        private List<Projectile> listProjectiles;
        Point centerPoint;
        int diagonalLength;

        public Enemy(string name, string tag, Image image, Point location, 
            Size size, int speed, Area currentArea)
        {
            Name = name;
            Tag = tag;
            Picture = new PictureBox();
            Picture.Image = image;
            Picture.Location = location;
            Picture.Size = size;
            Speed = speed;
            CurrentArea = currentArea;
            ListProjectiles = new List<Projectile>();

            CenterPoint = new Point(location.X + size.Width / 2, location.Y + size.Height / 2);
            DiagonalLength = (int)Math.Sqrt(Math.Pow(size.Width, 2) + Math.Pow(size.Height, 2));
        }

        public string Name { get => name; set => name = value; }
        public string Tag { get => tag; set => tag = value; }
        public PictureBox Picture { get => picture; set => picture = value; }
        public int Speed { get => speed; set => speed = value; }
        public Area CurrentArea { get => currentArea; set => currentArea = value; }
        public List<Projectile> ListProjectiles { get => listProjectiles; set => listProjectiles = value; }
        public Point CenterPoint { get => centerPoint; set => centerPoint = value; }
        public int DiagonalLength { get => diagonalLength; set => diagonalLength = value; }

        public void DisplayPicture(Control container)
        {
            Picture.Parent = container;
            Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            Picture.BackColor = Color.Transparent;
            Picture.Visible = true;
            Picture.BringToFront();
        }

        //public void ShootDown(Projectile projectile, int shootEndPoint, int distance, Control container)
        //{
        //    Point projectileSpawnPoint = new Point(this.Picture.Location.X + this.Picture.Size.Width/2 -
        //        projectile.Picture.Size.Width/2, 
        //        this.Picture.Location.Y + this.Picture.Size.Height);
        //    if (projectile.Picture.Location.Y <= projectileSpawnPoint.Y)
        //    {
        //        projectile.MovingDown = true;
        //        projectile.ItemMoveDown(distance);
        //        projectile.DisplayPicture(container);
        //    }
        //    if (projectile.Picture.Location.Y >= shootEndPoint)
        //    {
        //        projectile.MovingDown = false;
        //        projectile.Picture.Location = projectileSpawnPoint;
        //        projectile.DisplayPicture(container);
        //    }
        //    if (projectile.Picture.Location.Y > projectileSpawnPoint.Y &&
        //        projectile.Picture.Location.Y < shootEndPoint)
        //    {
        //        if (projectile.MovingDown == true)
        //        {
        //            projectile.ItemMoveDown(distance);
        //            projectile.DisplayPicture(container);
        //        }
        //    }
        //}

        //Finds the point according to the angle on a circle that contains a rectangle
        //With the radius of the circle being half the diagonal length of the rectangle
        //Angle is in degrees
        public Point FindCirclePoint(int degrees, Point centerPoint, int radius)
        {
            int circlePointX = (int)(centerPoint.X + (radius * Math.Cos(degrees * Math.PI / 180)));
            int circlePointY = (int)(centerPoint.Y + (radius * Math.Sin(degrees * Math.PI / 180)));
            Point circlePoint = new Point(circlePointX, circlePointY);

            return circlePoint;
        }

        //Parameter angle represents the angle that the projectile is being shot
        //in respect of the shooter (enemy)
        //Quadrant 1 (0 <= angle < 90) is the bottom right quadrant
        //Quadrant 2 (90 <= angle < 180) is the bottom left quadrant
        //Quadrant 3 (180 <= angle < 270) is the top left quadrant
        //Quadrant 4 (270 <= angle < 360) is the top right quadrant
        public void ShootProjectile(Projectile projectile, int distance, int speed, int angle, 
            Control container)
        {
            Point enemyCirclePoint = FindCirclePoint(angle, CenterPoint, DiagonalLength/2);
            //Point projectileCirclePoint = FindCirclePoint(180 - angle, projectile.CenterPoint,
            //    projectile.DiagonalLength);

            Point projectileCenterPoint = FindCirclePoint((int)Math.Abs(angle),
                enemyCirclePoint, projectile.DiagonalLength/2);
            Point projectileSpawnPoint = new Point(projectileCenterPoint.X - projectile.Picture.Width/2,
                projectileCenterPoint.Y - projectile.Picture.Height/2);
            Point projectileEndPoint = FindCirclePoint(angle, projectileSpawnPoint, distance);

            projectile.OriginalLocation = projectileSpawnPoint;
            if (projectile.Moving == false)
            {
                projectile.Picture.Location = projectileSpawnPoint;
                projectile.DisplayPicture(container);
                projectile.OriginalLocation = projectileSpawnPoint;
            }

            //Quadrant 1 (0 deg <= angle < 90)
            if (angle >= 0 && angle < 90)
            {
                if (projectile.Picture.Location.X <= projectileSpawnPoint.X &&
                    projectile.Picture.Location.Y <= projectileSpawnPoint.Y)
                {
                    projectile.Moving = true;
                    projectile.ItemMove(angle, projectile.Picture.Location, speed);
                    projectile.DisplayPicture(container);
                }
                //Test, Subject to change, sign is either AND or OR, further test required
                else if (projectile.Picture.Location.X >= projectileEndPoint.X &&
                    projectile.Picture.Location.Y >= projectileEndPoint.Y)
                {
                    projectile.Moving = false;
                    projectile.ReachDestination = true;
                    //projectile.Picture.Dispose();
                    //projectile = null;
                    //projectile.Picture.Location = projectileSpawnPoint;
                    //projectile.DisplayPicture(container);
                }
                else
                {
                    if (projectile.Moving == true)
                    {
                        projectile.ItemMove(angle, projectile.Picture.Location, speed);
                        projectile.DisplayPicture(container);
                    }
                    else
                    {
                        projectile.Picture.Location = projectileSpawnPoint;
                        projectile.DisplayPicture(container);
                        projectile.OriginalLocation = projectileSpawnPoint;
                    }
                }
            }
            //Quadrant 2 (90 <= angle < 180)
            else if (angle >= 90 && angle < 180)
            {
                if (projectile.Picture.Location.X >= projectileSpawnPoint.X &&
                    projectile.Picture.Location.Y <= projectileSpawnPoint.Y)
                {
                    projectile.Moving = true;
                    projectile.ItemMove(angle, projectile.Picture.Location, speed);
                    projectile.DisplayPicture(container);
                }
                //Test, Subject to change, sign is either AND or OR, further test required
                else if (projectile.Picture.Location.X <= projectileEndPoint.X &&
                    projectile.Picture.Location.Y >= projectileEndPoint.Y)
                {
                    projectile.Moving = false;
                    projectile.ReachDestination = true;
                    //projectile.Picture.Dispose();
                    //projectile = null;
                    //projectile.Picture.Location = projectileSpawnPoint;
                    //projectile.DisplayPicture(container);
                }
                else
                {
                    if (projectile.Moving == true)
                    {
                        projectile.ItemMove(angle, projectile.Picture.Location, speed);
                        projectile.DisplayPicture(container);
                    }
                    else
                    {
                        projectile.Picture.Location = projectileSpawnPoint;
                        projectile.DisplayPicture(container);
                        projectile.OriginalLocation = projectileSpawnPoint;
                    }
                }
            }
            //Quadrant 3 (180 <= angle < 270)
            else if (angle >= 180 && angle < 270)
            {
                if (projectile.Picture.Location.X >= projectileSpawnPoint.X &&
                    projectile.Picture.Location.Y >= projectileSpawnPoint.Y)
                {
                    projectile.Picture.Location = projectileSpawnPoint;
                    projectile.OriginalLocation = projectileSpawnPoint;

                    projectile.Moving = true;
                    projectile.ItemMove(angle, projectile.Picture.Location, speed);
                    projectile.DisplayPicture(container);
                }
                //Test, Subject to change, sign is either AND or OR, further test required
                else if (projectile.Picture.Location.X <= projectileEndPoint.X &&
                    projectile.Picture.Location.Y <= projectileEndPoint.Y)
                {
                    projectile.Moving = false;
                    projectile.ReachDestination = true;
                    //projectile.Picture.Dispose();
                    //projectile = null;
                    //projectile.Picture.Location = projectileSpawnPoint;
                    //projectile.DisplayPicture(container);
                }
                else
                {
                    if (projectile.Moving == true)
                    {
                        projectile.ItemMove(angle, projectile.Picture.Location, speed);
                        projectile.DisplayPicture(container);
                    }
                    else
                    {
                        projectile.Picture.Location = projectileSpawnPoint;
                        projectile.DisplayPicture(container);
                        projectile.OriginalLocation = projectileSpawnPoint;
                    }
                }
            }
            //Quadrant 4 (270 <= angle < 360)
            else
            {
                if (projectile.Picture.Location.X <= projectileSpawnPoint.X &&
                    projectile.Picture.Location.Y >= projectileSpawnPoint.Y)
                {
                    projectile.Moving = true;
                    projectile.ItemMove(angle, projectile.Picture.Location, speed);
                    projectile.DisplayPicture(container);
                }
                //Test, Subject to change, sign is either AND or OR, further test required
                else if (projectile.Picture.Location.X >= projectileEndPoint.X &&
                    projectile.Picture.Location.Y <= projectileEndPoint.Y)
                {
                    projectile.Moving = false;
                    projectile.ReachDestination = true;
                    //projectile.Picture.Dispose();
                    //projectile = null;
                    //projectile.Picture.Location = projectileSpawnPoint;
                    //projectile.DisplayPicture(container);
                }
                else
                {
                    if (projectile.Moving == true)
                    {
                        projectile.ItemMove(angle, projectile.Picture.Location, speed);
                        projectile.DisplayPicture(container);
                    }
                    else
                    {
                        projectile.Picture.Location = projectileSpawnPoint;
                        projectile.DisplayPicture(container);
                        projectile.OriginalLocation = projectileSpawnPoint;
                    }
                }
            }

            if (projectile.Picture.Location.X <= 100 || projectile.Picture.Location.X >= 1050
                || projectile.Picture.Location.Y <= 55 || projectile.Picture.Location.Y >= 600)
            {
                projectile.Moving = false;
                projectile.ReachDestination = true;
            }
        }
    }
}
