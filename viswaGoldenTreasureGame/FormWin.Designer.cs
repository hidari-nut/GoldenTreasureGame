
namespace viswaGoldenTreasureGame
{
    partial class FormWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNo = new System.Windows.Forms.Button();
            this.buttonYes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNo
            // 
            this.buttonNo.BackColor = System.Drawing.Color.Transparent;
            this.buttonNo.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.ButtonNo;
            this.buttonNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNo.Location = new System.Drawing.Point(405, 189);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(83, 42);
            this.buttonNo.TabIndex = 5;
            this.buttonNo.UseVisualStyleBackColor = false;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.BackColor = System.Drawing.Color.Transparent;
            this.buttonYes.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.ButtonYes;
            this.buttonYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonYes.Location = new System.Drawing.Point(75, 189);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(83, 42);
            this.buttonYes.TabIndex = 4;
            this.buttonYes.UseVisualStyleBackColor = false;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // FormWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.BackgroundWin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(563, 421);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonYes);
            this.Name = "FormWin";
            this.Text = "FormWin";
            this.Load += new System.EventHandler(this.FormWin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Button buttonYes;
    }
}