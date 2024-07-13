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
    public partial class FormNotes : Form
    {
        public FormNotes()
        {
            InitializeComponent();
        }

        private void FormNotes_Load(object sender, EventArgs e)
        {
            string text = "Form Menu:" +
                "\n 1. Improved Graphics" +
                "\n 2. Menu Bar changed to Buttons." +
                "\n 3. Added BGM." +
                "\n 4. Added intro video" +

                "\n" +
                "\nGame Improvements:" +
                "\n 1. Improved Graphics." +
                "\n 2. Improved SFX, BGM and" +
                "\n   sound mechanism" +
                "\n 3. Reworked UI Design to fit Aesthetic standards." +
                "\n 4. Rework on Player movement, added smoothness" +
                "\n 5. Improved and stabilized Player Controls" +
                "\n 6. Added Play/Pause button." +
                "\n 7. Added Menu Button." +
                "\n 8. Items have been changed and added." +
                "\n 9. Added advanced projectile mechanism." +
                "\n 10. Adding an extra boss fight." +
                "\n 11. Map composition have been changed and improved." +
                "\n 12. Added improved barriers that forbid players" +
                "\n   from walking on or interacting with" + 
                "\n   certain map elements." +
                "\n 13. Improved Gameplay Stability" +
                "\n" +

                "\nCredits:" +
                "\nGraphics updates were made using RPGMakerZ "+
                "\nand Adobe Photoshop." +
                "\nBoss model by deviantart.com/briivannz";

            listBoxUpdates.Items.AddRange(text.Split('\n'));
            this.CenterToScreen();
        }
    }
}
