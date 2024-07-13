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
    public partial class FormMenuBox : Form
    {
        public FormMenuBox()
        {
            InitializeComponent();
        }

        public bool YesNo;

        private void FormMenuBox_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }


        private void buttonYes_Click(object sender, EventArgs e)
        {
            YesNo = true;
            this.Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            YesNo = false;
            this.Close();
        }
    }
}
