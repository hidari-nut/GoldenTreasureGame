using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace viswaGoldenTreasureGame
{
    public class Projectile : Items
    {
        int lifeDamage;
        bool moving;
        bool hasBeenShot;
        bool reachDestination;
        Point originalLocation;
        Point centerPoint;
        int diagonalLength;
        double spawnInterval;
        int despawnCount;
        int shootingAngle;

        public Projectile(string name, string tag, Image image, Point location,
            Size size, int lifeDamage, double spawnInterval) : base(name, tag, image, location, size)
        {
            LifeDamage = lifeDamage;
            Moving = false;
            OriginalLocation = location;
            CenterPoint = new Point(location.X + size.Width / 2, location.Y + size.Height / 2);
            DiagonalLength = (int)Math.Sqrt(Math.Pow(size.Width, 2) + Math.Pow(size.Height, 2));
            SpawnInterval = spawnInterval;
            DespawnCount = 0;
            HasBeenShot = false;
            reachDestination = false;
        }

        public Projectile(Projectile copiedProjectile)
            :base(copiedProjectile.Name, (string)copiedProjectile.Picture.Tag, copiedProjectile.Picture.Image,
                 copiedProjectile.Picture.Location, copiedProjectile.Picture.Size)
        {
            LifeDamage = copiedProjectile.LifeDamage;
            OriginalLocation = copiedProjectile.OriginalLocation;
            CenterPoint = copiedProjectile.CenterPoint;
            DiagonalLength = copiedProjectile.DiagonalLength;
            SpawnInterval = copiedProjectile.SpawnInterval;

            DespawnCount = 0;
            Moving = false;
            HasBeenShot = false;
            reachDestination = false;
            shootingAngle = 180;
        }

        public int LifeDamage { get => lifeDamage; set => lifeDamage = value; }
        public Point OriginalLocation { get => originalLocation; set => originalLocation = value; }
        public int DiagonalLength { get => diagonalLength; set => diagonalLength = value; }
        public Point CenterPoint { get => centerPoint; set => centerPoint = value; }
        public bool Moving { get => moving; set => moving = value; }
        public double SpawnInterval { get => spawnInterval; set => spawnInterval = value; }
        public int DespawnCount { get => despawnCount; set => despawnCount = value; }
        public bool HasBeenShot { get => hasBeenShot; set => hasBeenShot = value; }
        public bool ReachDestination { get => reachDestination; set => reachDestination = value; }
        public int ShootingAngle { get => shootingAngle; set => shootingAngle = value; }

        public override void TouchItem(ref Player player)
        {
            player.Life -= this.LifeDamage;
            player.CurrentArea.HideItem(this);
            player.CurrentArea.RemoveItem(this);
        }

        public Point FindCirclePoint(int degrees, Point centerPoint, int radius)
        {
            int circlePointX = (int)(centerPoint.X + (radius * Math.Cos(degrees * Math.PI / 180)));
            int circlePointY = (int)(centerPoint.Y + (radius * Math.Sin(degrees * Math.PI / 180)));
            Point circlePoint = new Point(circlePointX, circlePointY);

            return circlePoint;
        }

        //Parameter angle represents the angle that the projectile is being shot
        //in respect of the shooter (source)
        //Quadrant 1 (0 <= angle < 90) is the bottom right quadrant
        //Quadrant 2 (90 <= angle < 180) is the bottom left quadrant
        //Quadrant 3 (180 <= angle < 270) is the top left quadrant
        //Quadrant 4 (270 <= angle < 360) is the top right quadrant
        public void ShootProjectile(Projectile projectile, Point sourcePoint, int sourceRadius, 
            int distance, int speed, int angle, Control container)
        {
            Point sourceCirclePoint = FindCirclePoint(angle, sourcePoint, sourceRadius / 2);
            //Point projectileCirclePoint = FindCirclePoint(180 - angle, projectile.CenterPoint,
            //    projectile.DiagonalLength);

            Point projectileCenterPoint = FindCirclePoint((int)Math.Abs(angle),
                sourceCirclePoint, projectile.DiagonalLength / 2);
            Point projectileSpawnPoint = new Point(projectileCenterPoint.X - projectile.Picture.Width / 2,
                projectileCenterPoint.Y - projectile.Picture.Height / 2);
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

            if (projectile.Picture.Location.X <= 100 || projectile.Picture.Location.X >= 1080
                || projectile.Picture.Location.Y <= 20 || projectile.Picture.Location.Y >= 600)
            {
                projectile.Moving = false;
                projectile.ReachDestination = true;
            }
        }
    }
}