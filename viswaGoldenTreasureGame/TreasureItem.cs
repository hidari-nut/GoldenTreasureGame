using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace viswaGoldenTreasureGame
{
    public class TreasureItem : Items
    {
        string description;

        public TreasureItem(string name, string tag, Image image, Point location, 
            Size size, string description):base(name, tag, image, location, size)
        {
            Description = description;
        }

        public string Description { get => description; set => description = value; }

        public override void TouchItem(ref Player player)
        {
            player.ListInventory.Add(this);
            player.CurrentArea.HideItem(this);
            player.CurrentArea.RemoveItem(this);
        }
    }
}