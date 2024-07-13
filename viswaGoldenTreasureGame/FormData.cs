using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace viswaGoldenTreasureGame
{
    public partial class FormData : Form
    {
        public FormData()
        {
            InitializeComponent();
        }

        string[,] itemData = new string[15, 3];
        string[,] weaponData = new string[7, 3];
        string[,] obstacleData = new string[9, 4];
        string[,] characterData = new string[2, 2];

        int dataNumber;

        private void FormData_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            //DATA
            itemData[0, 0] = "Pot";
            itemData[0, 1] = "Hundred years old pot that has never \nbeen cleaned, \nkinda gross tbh.";
            itemData[0, 2] = "Desert";
            itemData[1, 0] = "Rare Fossil";
            itemData[1, 1] = "Fossil of a long gone species, \nhopefully they'll revive.";
            itemData[1, 2] = "Desert";
            itemData[2, 0] = "Rare Skeleton";
            itemData[2, 1] = "Skeleton of a long lost ruler, " +
                "\nthe only ruler we need now \nis the one for geometry.";
            itemData[2, 2] = "Desert";
            itemData[3, 0] = "Sacrofagus";
            itemData[3, 1] = "Sacrofagus that started the rise and \ndownfall of empires \nThere's word about the nameless pharaoh.";
            itemData[3, 2] = "Desert";
            itemData[4, 0] = "Cool Map";
            itemData[4, 1] = "Map of ancient civillization\nLooks like ancient Egypt.";
            itemData[4, 2] = "Basement";
            itemData[5, 0] = "Ancient Literature";
            itemData[5, 1] = "Contain the secret of Ancient Egypt\nand Game of Darkness.";
            itemData[5, 2] = "Basement";
            itemData[6, 0] = "Mysthical Book";
            itemData[6, 1] = "Written by Mahad a famous priest from \nEgypt \nHis pupil was cute.";
            itemData[6, 2] = "Basement";
            itemData[7, 0] = "Box of Sword";
            itemData[7, 1] = "A box of sword belongs to an ancient \narmy\nIt might be helpful later.";
            itemData[7, 2] = "Palace Garden";
            itemData[8, 0] = "Holy Corpse";
            itemData[8, 1] = "Is it graverobbing? \nEh probably not right? \nIt's Dirty Deeds Done Dirt Cheap.";
            itemData[8, 2] = "Palace Garden";
            itemData[9, 0] = "Impossible Snowman";
            itemData[9, 1] = "Impossible... yet... fascinating.";
            itemData[9, 2] = "Palace Garden";
            itemData[10, 0] = "Rare Statue";
            itemData[10, 1] = "What's a statue this rare doing here?\nSomeone must've dropped it \nfrom the palace.";
            itemData[10, 2] = "Palace Garden";
            itemData[11, 0] = "Car";
            itemData[11, 1] = "It's a Car";
            itemData[11, 2] = "Workshop";
            itemData[12, 0] = "Computer";
            itemData[12, 1] = "This is what we use to make all of these\nTruly a magnum opus of humanity.";
            itemData[12, 2] = "Workshop";
            itemData[13, 0] = "Rare Collectible Poster";
            itemData[13, 1] = "Oh look a poster of famous anime\nA geek might pay millions for it\neBay time!";
            itemData[13, 2] = "Workshop";
            itemData[14, 0] = "Tank";
            itemData[14, 1] = "A perfectly normal tank \nIt's not like it symbolize a certain event.";
            itemData[14, 2] = "Workshop";

            weaponData[0, 0] = "Bow and Arrow";
            weaponData[0, 1] = "A perfect weapon for one with the \neye of a tiger.";
            weaponData[0, 2] = "Deal 25 damage";
            weaponData[1, 0] = "Daggers";
            weaponData[1, 1] = "A perfect murder weapon for assassin.";
            weaponData[1, 2] = "Deal 25 damage";
            weaponData[2, 0] = "Dogouken";
            weaponData[2, 1] = "Giant sword that have splitted mountains.";
            weaponData[2, 2] = "Deal 40 damage";
            weaponData[3, 0] = "Excalibur";
            weaponData[3, 1] = "Sheathed in the breath of the planet, " +
                "\na torrent of shining life.";
            weaponData[3, 2] = "Deal 50 damage";
            weaponData[4, 0] = "Magic Wand";
            weaponData[4, 1] = "A wand as medium to the strongest\ndark magic attack.";
            weaponData[4, 2] = "Deal 75 damage";
            weaponData[5, 0] = "Mighty Axe";
            weaponData[5, 1] = "Yeah, you guess it right\nIt's an Odinson reference.";
            weaponData[5, 2] = "Deal 25 damage";
            weaponData[6, 0] = "Shield";
            weaponData[6, 1] = "The almighty protector\ncan it be used as a weapon?";
            weaponData[6, 2] = "3 sec Invicibility";

            obstacleData[0, 0] = "Bomb";
            obstacleData[0, 1] = "A brilliant invention that has been \nmissused by humanity.";
            obstacleData[0, 2] = "Deal 20 damage";
            obstacleData[0, 3] = "Desert";
            obstacleData[1, 0] = "Cacty";
            obstacleData[1, 1] = "A cute cactus\nWorth the pain.";
            obstacleData[1, 2] = "Deal 10 damage";
            obstacleData[1, 3] = "Desert";
            obstacleData[2, 0] = "Cursed Doll";
            obstacleData[2, 1] = "It's better if you don't know...";
            obstacleData[2, 2] = "15";
            obstacleData[2, 3] = "Basement";
            obstacleData[3, 0] = "Expired Food";
            obstacleData[3, 1] = "If it's not moldy and smelly\nIt's good to eat!...*barf*";
            obstacleData[3, 2] = "Deal 25 damage";
            obstacleData[3, 3] = "Basement";
            obstacleData[4, 0] = "Hole";
            obstacleData[4, 1] = "It's obvious yet you fell for it.";
            obstacleData[4, 2] = "Deal 5 damage";
            obstacleData[4, 3] = "Palace Garden";
            obstacleData[5, 0] = "Poisonous Flower";
            obstacleData[5, 1] = "It's beautiful yet... smelly.\nBetter take a shower.";
            obstacleData[5, 2] = "Deal 20 damage";
            obstacleData[5, 3] = "Palace Garden";
            obstacleData[6, 0] = "Poisonous Mushrooms";
            obstacleData[6, 1] = "Eat first, regret later";
            obstacleData[6, 2] = "Deal 15 damage";
            obstacleData[6, 3] = "Palace Garden";
            obstacleData[7, 0] = "Hole";
            obstacleData[7, 1] = "If only someone could fix this hole.";
            obstacleData[7, 2] = "Deal 5 damage";
            obstacleData[7, 3] = "Workshop";
            obstacleData[8, 0] = "The Witch";
            obstacleData[8, 1] = "Beware of the witch.\nShe might turn you to spaghetti.";
            obstacleData[8, 2] = "Deal 10 damage/attack";
            obstacleData[8, 3] = "Workshop";

            characterData[0, 0] = "(MC) Amelia Forger";
            characterData[0, 1] = "A Traveller in the Island of Fantasy\nCurrently in a journey to collect\nthe 15 treasures.";
            characterData[1, 0] = "(Boss) Demonytta";
            characterData[1, 1] = "Challenger from the Underground\nHere to test your worthiness.";
        }

        string DisplayItem(int dataNumber)
        {
            return "TREASURE" + "\n================================================================================" +
                "\n\nItem Name: \n" + itemData[dataNumber, 0] +
                "\n\nDescription: \n" + itemData[dataNumber, 1] +
                "\n\nOrigin: \n" + itemData[dataNumber, 2];
        }
        string DisplayWeapon(int dataNumber)
        {
            return "WEAPON" + "\n================================================================================" +
                "\n\nItem Name: \n" + weaponData[dataNumber, 0] +
                "\n\nDescription: \n" + weaponData[dataNumber, 1] +
                "\n\nEffect: \n" + weaponData[dataNumber, 2];
        }
        string DisplayObstacle(int dataNumber)
        {
            return "OBSTACLE" + "\n================================================================================" +
                "\nItem Name: \n" + obstacleData[dataNumber, 0] +
                "\n\nDescription: \n" + obstacleData[dataNumber, 1] +
                "\n\nEffect: \n" + obstacleData[dataNumber, 2] +
                "\n\nOrigin: \n" + obstacleData[dataNumber, 3];
        }
        string DisplayCharacter(int dataNumber)
        {
            return "CHARACTER" + "\n================================================================================" +
                "\n\nName: \n" + characterData[dataNumber, 0] +
                "\n\nDescription: \n" + characterData[dataNumber, 1];
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPot_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 0;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonFossil_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 1;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonSkeleton_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 2;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonSacrofagus_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 3;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonMap_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 4;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonLiterature_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 5;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 6;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonBox_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 7;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonHoly_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 8;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonSnowman_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 9;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonStatue_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 10;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonCar_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 11;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonPC_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 12;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonPoster_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 13;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonTank_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 14;
            listBoxInfo.Items.AddRange(DisplayItem(dataNumber).Split('\n'));
        }

        private void buttonBow_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 0;
            listBoxInfo.Items.AddRange(DisplayWeapon(dataNumber).Split('\n'));
        }

        private void buttonDagger_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 1;
            listBoxInfo.Items.AddRange(DisplayWeapon(dataNumber).Split('\n'));
        }

        private void buttonDogouken_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 2;
            listBoxInfo.Items.AddRange(DisplayWeapon(dataNumber).Split('\n'));
        }

        private void buttonSword_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 3;
            listBoxInfo.Items.AddRange(DisplayWeapon(dataNumber).Split('\n'));
        }

        private void buttonMagic_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 4;
            listBoxInfo.Items.AddRange(DisplayWeapon(dataNumber).Split('\n'));
        }

        private void buttonMighty_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 5;
            listBoxInfo.Items.AddRange(DisplayWeapon(dataNumber).Split('\n'));
        }

        private void buttonBomb_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataNumber = 0;
            listBoxInfo.Items.AddRange(DisplayObstacle(dataNumber).Split('\n'));
        }

        private void buttonCacty_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 1;
            listBoxInfo.Items.AddRange(DisplayObstacle(dataNumber).Split('\n'));
        }

        private void buttonDoll_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 2;
            listBoxInfo.Items.AddRange(DisplayObstacle(dataNumber).Split('\n'));
        }

        private void buttonFood_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 3;
            listBoxInfo.Items.AddRange(DisplayObstacle(dataNumber).Split('\n'));
        }

        private void buttonHole_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 4;
            listBoxInfo.Items.AddRange(DisplayObstacle(dataNumber).Split('\n'));
        }

        private void buttonFlower_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 5;
            listBoxInfo.Items.AddRange(DisplayObstacle(dataNumber).Split('\n'));
        }

        private void buttonShroom_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 6;
            listBoxInfo.Items.AddRange(DisplayObstacle(dataNumber).Split('\n'));
        }

        private void buttonHole2_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 7;
            listBoxInfo.Items.AddRange(DisplayObstacle(dataNumber).Split('\n'));
        }

        private void buttonWitch_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 8;
            listBoxInfo.Items.AddRange(DisplayObstacle(dataNumber).Split('\n'));
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 0;
            listBoxInfo.Items.AddRange(DisplayCharacter(dataNumber).Split('\n'));
        }

        private void buttonBoss_Click(object sender, EventArgs e)
        {

            listBoxInfo.Items.Clear();
            dataNumber = 1;
            listBoxInfo.Items.AddRange(DisplayCharacter(dataNumber).Split('\n'));
        }
    }
}
