
namespace viswaGoldenTreasureGame
{
    partial class FormNotes
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
            this.listBoxUpdates = new System.Windows.Forms.ListBox();
            this.labelListOfUpdates = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxUpdates
            // 
            this.listBoxUpdates.Font = new System.Drawing.Font("MINI 7", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxUpdates.FormattingEnabled = true;
            this.listBoxUpdates.ItemHeight = 17;
            this.listBoxUpdates.Location = new System.Drawing.Point(12, 252);
            this.listBoxUpdates.Name = "listBoxUpdates";
            this.listBoxUpdates.Size = new System.Drawing.Size(932, 344);
            this.listBoxUpdates.TabIndex = 1;
            // 
            // labelListOfUpdates
            // 
            this.labelListOfUpdates.AutoSize = true;
            this.labelListOfUpdates.BackColor = System.Drawing.Color.Transparent;
            this.labelListOfUpdates.Font = new System.Drawing.Font("MINI 7", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListOfUpdates.Location = new System.Drawing.Point(246, 203);
            this.labelListOfUpdates.Name = "labelListOfUpdates";
            this.labelListOfUpdates.Size = new System.Drawing.Size(471, 34);
            this.labelListOfUpdates.TabIndex = 2;
            this.labelListOfUpdates.Text = "List Of Updates";
            // 
            // FormNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_Title;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(956, 653);
            this.Controls.Add(this.labelListOfUpdates);
            this.Controls.Add(this.listBoxUpdates);
            this.Name = "FormNotes";
            this.Text = "Formnotes";
            this.Load += new System.EventHandler(this.FormNotes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxUpdates;
        private System.Windows.Forms.Label labelListOfUpdates;
    }
}