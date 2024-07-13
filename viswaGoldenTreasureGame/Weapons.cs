using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace viswaGoldenTreasureGame
{
    public class Weapons : Items
    {
        private int bossDamage;
        private Point spawnPoint;
        private double spawnInterval;
        private bool hasSpawned;


        public Weapons(string name, string tag, Image image, Point location, Size size,
            int bossDamage, double spawnInterval)
            : base(name, tag, image, location, size)
        {
            BossDamage = bossDamage;
            SpawnInterval = spawnInterval;
            HasSpawned = false;
        }
        public Weapons(Weapons copiedWeapon)
            :base(copiedWeapon.Name, (string)copiedWeapon.Picture.Tag, copiedWeapon.Picture.Image,
                 copiedWeapon.Picture.Location, copiedWeapon.Picture.Size)
        {
            BossDamage = copiedWeapon.BossDamage;
            SpawnInterval = copiedWeapon.SpawnInterval;
        }

        public int BossDamage { get => bossDamage; set => bossDamage = value; }
        public Point SpawnPoint { get => spawnPoint; set => spawnPoint = value; }
        public double SpawnInterval { get => spawnInterval; set => spawnInterval = value; }
        public bool HasSpawned { get => hasSpawned; set => hasSpawned = value; }

        public int CheckDamage()
        {
            return BossDamage;
        }

        public void TouchItem(ref Boss boss, Player player)
        {
            boss.Health -= BossDamage;
            player.CurrentArea.HideItem(this);
            player.CurrentArea.RemoveItem(this);
        }
    }
}