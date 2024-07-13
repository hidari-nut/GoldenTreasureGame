namespace viswaGoldenTreasureGame
{
    partial class FormGame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.labelTime = new System.Windows.Forms.Label();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.panelInventory = new System.Windows.Forms.Panel();
            this.pictureBoxItemEx3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItemEx2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItemEx1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItem8 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItem10 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItem11 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItem12 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItem1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItem2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItem9 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItem3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItem4 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItem5 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItem6 = new System.Windows.Forms.PictureBox();
            this.pictureBoxItem7 = new System.Windows.Forms.PictureBox();
            this.buttonNotes = new System.Windows.Forms.Button();
            this.timerGameTime = new System.Windows.Forms.Timer(this.components);
            this.timerGameTick = new System.Windows.Forms.Timer(this.components);
            this.timerMovement = new System.Windows.Forms.Timer(this.components);
            this.timerObstacleMove = new System.Windows.Forms.Timer(this.components);
            this.labelArea = new System.Windows.Forms.Label();
            this.timerHazardDamage = new System.Windows.Forms.Timer(this.components);
            this.panelInfo = new System.Windows.Forms.Panel();
            this.panelTime = new System.Windows.Forms.Panel();
            this.panelArea = new System.Windows.Forms.Panel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.pictureBoxButtonPlayPause = new System.Windows.Forms.PictureBox();
            this.timerBossFight = new System.Windows.Forms.Timer(this.components);
            this.axWindowsMediaPlayerIntro = new AxWMPLib.AxWindowsMediaPlayer();
            this.pictureBoxMenu = new System.Windows.Forms.PictureBox();
            this.timerBossEvents = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxBossHealthBar = new System.Windows.Forms.PictureBox();
            this.labelBossName = new System.Windows.Forms.Label();
            this.pictureBoxPaused = new System.Windows.Forms.PictureBox();
            this.buttonData = new System.Windows.Forms.Button();
            this.panelInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemEx3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemEx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem7)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.panelTime.SuspendLayout();
            this.panelArea.SuspendLayout();
            this.panelPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxButtonPlayPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayerIntro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBossHealthBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaused)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.Transparent;
            this.labelTime.Font = new System.Drawing.Font("MINI 7 Condensed", 16F);
            this.labelTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTime.Location = new System.Drawing.Point(63, 10);
            this.labelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(142, 27);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "00:00:00";
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer.Font = new System.Drawing.Font("MINI 7 Condensed", 11F);
            this.labelPlayer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelPlayer.Location = new System.Drawing.Point(31, 5);
            this.labelPlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(84, 19);
            this.labelPlayer.TabIndex = 3;
            this.labelPlayer.Text = "Player";
            // 
            // panelInventory
            // 
            this.panelInventory.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.WOOD;
            this.panelInventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelInventory.Controls.Add(this.pictureBoxItemEx3);
            this.panelInventory.Controls.Add(this.pictureBoxItemEx2);
            this.panelInventory.Controls.Add(this.pictureBoxItemEx1);
            this.panelInventory.Controls.Add(this.pictureBoxItem8);
            this.panelInventory.Controls.Add(this.pictureBoxItem10);
            this.panelInventory.Controls.Add(this.pictureBoxItem11);
            this.panelInventory.Controls.Add(this.pictureBoxItem12);
            this.panelInventory.Controls.Add(this.pictureBoxItem1);
            this.panelInventory.Controls.Add(this.pictureBoxItem2);
            this.panelInventory.Controls.Add(this.pictureBoxItem9);
            this.panelInventory.Controls.Add(this.pictureBoxItem3);
            this.panelInventory.Controls.Add(this.pictureBoxItem4);
            this.panelInventory.Controls.Add(this.pictureBoxItem5);
            this.panelInventory.Controls.Add(this.pictureBoxItem6);
            this.panelInventory.Controls.Add(this.pictureBoxItem7);
            this.panelInventory.Location = new System.Drawing.Point(5, 660);
            this.panelInventory.Margin = new System.Windows.Forms.Padding(4);
            this.panelInventory.Name = "panelInventory";
            this.panelInventory.Size = new System.Drawing.Size(1040, 86);
            this.panelInventory.TabIndex = 5;
            // 
            // pictureBoxItemEx3
            // 
            this.pictureBoxItemEx3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItemEx3.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Mysthical_Book;
            this.pictureBoxItemEx3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItemEx3.Location = new System.Drawing.Point(449, 16);
            this.pictureBoxItemEx3.Name = "pictureBoxItemEx3";
            this.pictureBoxItemEx3.Size = new System.Drawing.Size(53, 50);
            this.pictureBoxItemEx3.TabIndex = 24;
            this.pictureBoxItemEx3.TabStop = false;
            this.pictureBoxItemEx3.Tag = "mysthical_book";
            // 
            // pictureBoxItemEx2
            // 
            this.pictureBoxItemEx2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItemEx2.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Ancient_Literature;
            this.pictureBoxItemEx2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItemEx2.Location = new System.Drawing.Point(385, 16);
            this.pictureBoxItemEx2.Name = "pictureBoxItemEx2";
            this.pictureBoxItemEx2.Size = new System.Drawing.Size(53, 50);
            this.pictureBoxItemEx2.TabIndex = 24;
            this.pictureBoxItemEx2.TabStop = false;
            this.pictureBoxItemEx2.Tag = "ancient_literature";
            // 
            // pictureBoxItemEx1
            // 
            this.pictureBoxItemEx1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItemEx1.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Cool_Map;
            this.pictureBoxItemEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItemEx1.Location = new System.Drawing.Point(321, 16);
            this.pictureBoxItemEx1.Name = "pictureBoxItemEx1";
            this.pictureBoxItemEx1.Size = new System.Drawing.Size(53, 50);
            this.pictureBoxItemEx1.TabIndex = 23;
            this.pictureBoxItemEx1.TabStop = false;
            this.pictureBoxItemEx1.Tag = "cool_map";
            // 
            // pictureBoxItem8
            // 
            this.pictureBoxItem8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem8.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_02_ImpossibleSnowman;
            this.pictureBoxItem8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem8.Location = new System.Drawing.Point(696, 16);
            this.pictureBoxItem8.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxItem8.Name = "pictureBoxItem8";
            this.pictureBoxItem8.Size = new System.Drawing.Size(40, 50);
            this.pictureBoxItem8.TabIndex = 12;
            this.pictureBoxItem8.TabStop = false;
            this.pictureBoxItem8.Tag = "impossible_snowman";
            // 
            // pictureBoxItem10
            // 
            this.pictureBoxItem10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem10.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_03_CoolPC;
            this.pictureBoxItem10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem10.Location = new System.Drawing.Point(828, 16);
            this.pictureBoxItem10.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxItem10.Name = "pictureBoxItem10";
            this.pictureBoxItem10.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxItem10.TabIndex = 15;
            this.pictureBoxItem10.TabStop = false;
            this.pictureBoxItem10.Tag = "computer";
            // 
            // pictureBoxItem11
            // 
            this.pictureBoxItem11.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem11.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_03_RareCollectiblePoster;
            this.pictureBoxItem11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem11.Location = new System.Drawing.Point(889, 16);
            this.pictureBoxItem11.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxItem11.Name = "pictureBoxItem11";
            this.pictureBoxItem11.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxItem11.TabIndex = 14;
            this.pictureBoxItem11.TabStop = false;
            this.pictureBoxItem11.Tag = "rare_poster";
            // 
            // pictureBoxItem12
            // 
            this.pictureBoxItem12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem12.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_03_Tank;
            this.pictureBoxItem12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem12.Location = new System.Drawing.Point(950, 16);
            this.pictureBoxItem12.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxItem12.Name = "pictureBoxItem12";
            this.pictureBoxItem12.Size = new System.Drawing.Size(70, 50);
            this.pictureBoxItem12.TabIndex = 16;
            this.pictureBoxItem12.TabStop = false;
            this.pictureBoxItem12.Tag = "tank";
            // 
            // pictureBoxItem1
            // 
            this.pictureBoxItem1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem1.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_01_Pot;
            this.pictureBoxItem1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem1.Location = new System.Drawing.Point(77, 16);
            this.pictureBoxItem1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxItem1.Name = "pictureBoxItem1";
            this.pictureBoxItem1.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxItem1.TabIndex = 6;
            this.pictureBoxItem1.TabStop = false;
            this.pictureBoxItem1.Tag = "pot";
            // 
            // pictureBoxItem2
            // 
            this.pictureBoxItem2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem2.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_01_RareFossil;
            this.pictureBoxItem2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem2.Location = new System.Drawing.Point(138, 16);
            this.pictureBoxItem2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxItem2.Name = "pictureBoxItem2";
            this.pictureBoxItem2.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxItem2.TabIndex = 7;
            this.pictureBoxItem2.TabStop = false;
            this.pictureBoxItem2.Tag = "rare_fossil";
            // 
            // pictureBoxItem9
            // 
            this.pictureBoxItem9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem9.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_03_Car;
            this.pictureBoxItem9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem9.Location = new System.Drawing.Point(747, 16);
            this.pictureBoxItem9.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxItem9.Name = "pictureBoxItem9";
            this.pictureBoxItem9.Size = new System.Drawing.Size(70, 50);
            this.pictureBoxItem9.TabIndex = 13;
            this.pictureBoxItem9.TabStop = false;
            this.pictureBoxItem9.Tag = "car";
            // 
            // pictureBoxItem3
            // 
            this.pictureBoxItem3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem3.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_01_RareSkeleton;
            this.pictureBoxItem3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem3.Location = new System.Drawing.Point(199, 16);
            this.pictureBoxItem3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxItem3.Name = "pictureBoxItem3";
            this.pictureBoxItem3.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxItem3.TabIndex = 8;
            this.pictureBoxItem3.TabStop = false;
            this.pictureBoxItem3.Tag = "rare_skeleton";
            // 
            // pictureBoxItem4
            // 
            this.pictureBoxItem4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem4.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_01_Sacrofagus;
            this.pictureBoxItem4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem4.Location = new System.Drawing.Point(260, 16);
            this.pictureBoxItem4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxItem4.Name = "pictureBoxItem4";
            this.pictureBoxItem4.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxItem4.TabIndex = 7;
            this.pictureBoxItem4.TabStop = false;
            this.pictureBoxItem4.Tag = "sacrofagus";
            // 
            // pictureBoxItem5
            // 
            this.pictureBoxItem5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem5.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Rare_Statue;
            this.pictureBoxItem5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem5.Location = new System.Drawing.Point(513, 16);
            this.pictureBoxItem5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxItem5.Name = "pictureBoxItem5";
            this.pictureBoxItem5.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxItem5.TabIndex = 9;
            this.pictureBoxItem5.TabStop = false;
            this.pictureBoxItem5.Tag = "rare_statue";
            // 
            // pictureBoxItem6
            // 
            this.pictureBoxItem6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem6.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_02_Box_Of_Sword;
            this.pictureBoxItem6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem6.Location = new System.Drawing.Point(574, 16);
            this.pictureBoxItem6.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxItem6.Name = "pictureBoxItem6";
            this.pictureBoxItem6.Size = new System.Drawing.Size(60, 50);
            this.pictureBoxItem6.TabIndex = 10;
            this.pictureBoxItem6.TabStop = false;
            this.pictureBoxItem6.Tag = "box_of_sword";
            // 
            // pictureBoxItem7
            // 
            this.pictureBoxItem7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxItem7.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_02_Holy_Corpse;
            this.pictureBoxItem7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxItem7.Location = new System.Drawing.Point(645, 16);
            this.pictureBoxItem7.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxItem7.Name = "pictureBoxItem7";
            this.pictureBoxItem7.Size = new System.Drawing.Size(40, 50);
            this.pictureBoxItem7.TabIndex = 11;
            this.pictureBoxItem7.TabStop = false;
            this.pictureBoxItem7.Tag = "holy_corpse";
            // 
            // buttonNotes
            // 
            this.buttonNotes.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.ButtonNotes;
            this.buttonNotes.Location = new System.Drawing.Point(32, 93);
            this.buttonNotes.Name = "buttonNotes";
            this.buttonNotes.Size = new System.Drawing.Size(174, 72);
            this.buttonNotes.TabIndex = 21;
            this.buttonNotes.UseVisualStyleBackColor = true;
            this.buttonNotes.Click += new System.EventHandler(this.buttonNotes_Click);
            // 
            // timerGameTime
            // 
            this.timerGameTime.Interval = 1000;
            this.timerGameTime.Tick += new System.EventHandler(this.timerGameTime_Tick);
            // 
            // timerGameTick
            // 
            this.timerGameTick.Interval = 50;
            this.timerGameTick.Tick += new System.EventHandler(this.timerGameTick_Tick);
            // 
            // timerMovement
            // 
            this.timerMovement.Interval = 20;
            this.timerMovement.Tick += new System.EventHandler(this.timerMovement_Tick);
            // 
            // timerObstacleMove
            // 
            this.timerObstacleMove.Interval = 50;
            this.timerObstacleMove.Tick += new System.EventHandler(this.timerObstacleMove_Tick);
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.BackColor = System.Drawing.Color.Transparent;
            this.labelArea.Font = new System.Drawing.Font("MINI 7 Condensed", 14F);
            this.labelArea.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelArea.Location = new System.Drawing.Point(6, 2);
            this.labelArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(75, 24);
            this.labelArea.TabIndex = 1;
            this.labelArea.Text = "Area";
            // 
            // timerHazardDamage
            // 
            this.timerHazardDamage.Interval = 1000;
            this.timerHazardDamage.Tick += new System.EventHandler(this.timerHazardDamage_Tick);
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelInfo.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Place;
            this.panelInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelInfo.Controls.Add(this.panelTime);
            this.panelInfo.Controls.Add(this.panelArea);
            this.panelInfo.Controls.Add(this.panelPlayer);
            this.panelInfo.Location = new System.Drawing.Point(174, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(710, 54);
            this.panelInfo.TabIndex = 6;
            // 
            // panelTime
            // 
            this.panelTime.BackColor = System.Drawing.Color.Transparent;
            this.panelTime.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Time_slot;
            this.panelTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTime.Controls.Add(this.labelTime);
            this.panelTime.ForeColor = System.Drawing.Color.Transparent;
            this.panelTime.Location = new System.Drawing.Point(230, 1);
            this.panelTime.Name = "panelTime";
            this.panelTime.Size = new System.Drawing.Size(250, 52);
            this.panelTime.TabIndex = 7;
            // 
            // panelArea
            // 
            this.panelArea.BackColor = System.Drawing.Color.Transparent;
            this.panelArea.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Place;
            this.panelArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelArea.Controls.Add(this.labelDescription);
            this.panelArea.Controls.Add(this.labelArea);
            this.panelArea.Location = new System.Drawing.Point(3, 2);
            this.panelArea.Name = "panelArea";
            this.panelArea.Size = new System.Drawing.Size(250, 52);
            this.panelArea.TabIndex = 0;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelDescription.Font = new System.Drawing.Font("MINI 7 Condensed", 8F);
            this.labelDescription.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelDescription.Location = new System.Drawing.Point(6, 27);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(101, 14);
            this.labelDescription.TabIndex = 17;
            this.labelDescription.Text = "Description";
            // 
            // panelPlayer
            // 
            this.panelPlayer.BackColor = System.Drawing.Color.Transparent;
            this.panelPlayer.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.PlayerInfo;
            this.panelPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelPlayer.Controls.Add(this.labelPlayer);
            this.panelPlayer.Location = new System.Drawing.Point(456, 2);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(250, 52);
            this.panelPlayer.TabIndex = 8;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Button_Exit;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonExit.Location = new System.Drawing.Point(418, 525);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(236, 71);
            this.buttonExit.TabIndex = 14;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonStart.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Button_Start;
            this.buttonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonStart.Location = new System.Drawing.Point(374, 317);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(314, 94);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // pictureBoxButtonPlayPause
            // 
            this.pictureBoxButtonPlayPause.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxButtonPlayPause.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Button_Pause;
            this.pictureBoxButtonPlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxButtonPlayPause.Location = new System.Drawing.Point(32, 3);
            this.pictureBoxButtonPlayPause.Name = "pictureBoxButtonPlayPause";
            this.pictureBoxButtonPlayPause.Size = new System.Drawing.Size(100, 54);
            this.pictureBoxButtonPlayPause.TabIndex = 16;
            this.pictureBoxButtonPlayPause.TabStop = false;
            this.pictureBoxButtonPlayPause.Click += new System.EventHandler(this.pictureBoxButtonPlayPause_Click);
            // 
            // timerBossFight
            // 
            this.timerBossFight.Tick += new System.EventHandler(this.timerBossFight_Tick);
            // 
            // axWindowsMediaPlayerIntro
            // 
            this.axWindowsMediaPlayerIntro.Enabled = true;
            this.axWindowsMediaPlayerIntro.Location = new System.Drawing.Point(32, 63);
            this.axWindowsMediaPlayerIntro.Name = "axWindowsMediaPlayerIntro";
            this.axWindowsMediaPlayerIntro.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayerIntro.OcxState")));
            this.axWindowsMediaPlayerIntro.Size = new System.Drawing.Size(100, 24);
            this.axWindowsMediaPlayerIntro.TabIndex = 17;
            this.axWindowsMediaPlayerIntro.Visible = false;
            this.axWindowsMediaPlayerIntro.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.IntroVideo_PlaystateChange);
            // 
            // pictureBoxMenu
            // 
            this.pictureBoxMenu.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMenu.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.ButtonMenu;
            this.pictureBoxMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxMenu.Location = new System.Drawing.Point(928, 2);
            this.pictureBoxMenu.Name = "pictureBoxMenu";
            this.pictureBoxMenu.Size = new System.Drawing.Size(100, 54);
            this.pictureBoxMenu.TabIndex = 18;
            this.pictureBoxMenu.TabStop = false;
            this.pictureBoxMenu.Click += new System.EventHandler(this.pictureBoxMenu_Click);
            // 
            // timerBossEvents
            // 
            this.timerBossEvents.Tick += new System.EventHandler(this.timerBossEvents_Tick);
            // 
            // pictureBoxBossHealthBar
            // 
            this.pictureBoxBossHealthBar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBossHealthBar.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.HealthBar_Boss_Above50;
            this.pictureBoxBossHealthBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxBossHealthBar.Location = new System.Drawing.Point(5, 720);
            this.pictureBoxBossHealthBar.Name = "pictureBoxBossHealthBar";
            this.pictureBoxBossHealthBar.Size = new System.Drawing.Size(1040, 23);
            this.pictureBoxBossHealthBar.TabIndex = 19;
            this.pictureBoxBossHealthBar.TabStop = false;
            // 
            // labelBossName
            // 
            this.labelBossName.AutoSize = true;
            this.labelBossName.BackColor = System.Drawing.Color.Transparent;
            this.labelBossName.Font = new System.Drawing.Font("MINI 7", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBossName.ForeColor = System.Drawing.SystemColors.Control;
            this.labelBossName.Location = new System.Drawing.Point(1, 685);
            this.labelBossName.Name = "labelBossName";
            this.labelBossName.Size = new System.Drawing.Size(223, 24);
            this.labelBossName.TabIndex = 20;
            this.labelBossName.Text = "Demonytta";
            // 
            // pictureBoxPaused
            // 
            this.pictureBoxPaused.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPaused.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Paused;
            this.pictureBoxPaused.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxPaused.Location = new System.Drawing.Point(256, 317);
            this.pictureBoxPaused.Name = "pictureBoxPaused";
            this.pictureBoxPaused.Size = new System.Drawing.Size(549, 94);
            this.pictureBoxPaused.TabIndex = 22;
            this.pictureBoxPaused.TabStop = false;
            this.pictureBoxPaused.Visible = false;
            // 
            // buttonData
            // 
            this.buttonData.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Button_Data;
            this.buttonData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonData.Location = new System.Drawing.Point(374, 421);
            this.buttonData.Name = "buttonData";
            this.buttonData.Size = new System.Drawing.Size(314, 94);
            this.buttonData.TabIndex = 24;
            this.buttonData.UseVisualStyleBackColor = true;
            this.buttonData.Click += new System.EventHandler(this.buttonData_Click);
            // 
            // FormGame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::viswaGoldenTreasureGame.Properties.Resources.Map_Title;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1058, 759);
            this.Controls.Add(this.buttonData);
            this.Controls.Add(this.pictureBoxPaused);
            this.Controls.Add(this.buttonNotes);
            this.Controls.Add(this.labelBossName);
            this.Controls.Add(this.pictureBoxBossHealthBar);
            this.Controls.Add(this.pictureBoxMenu);
            this.Controls.Add(this.axWindowsMediaPlayerIntro);
            this.Controls.Add(this.pictureBoxButtonPlayPause);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.panelInventory);
            this.Controls.Add(this.panelInfo);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGame";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Gold Treasure Hunt";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyUp);
            this.panelInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemEx3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemEx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem7)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelTime.ResumeLayout(false);
            this.panelTime.PerformLayout();
            this.panelArea.ResumeLayout(false);
            this.panelArea.PerformLayout();
            this.panelPlayer.ResumeLayout(false);
            this.panelPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxButtonPlayPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayerIntro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBossHealthBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaused)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Panel panelInventory;
        private System.Windows.Forms.Timer timerGameTime;
        private System.Windows.Forms.PictureBox pictureBoxItem1;
        private System.Windows.Forms.PictureBox pictureBoxItem7;
        private System.Windows.Forms.PictureBox pictureBoxItem6;
        private System.Windows.Forms.PictureBox pictureBoxItem5;
        private System.Windows.Forms.PictureBox pictureBoxItem4;
        private System.Windows.Forms.PictureBox pictureBoxItem3;
        private System.Windows.Forms.PictureBox pictureBoxItem2;
        private System.Windows.Forms.Timer timerGameTick;
        private System.Windows.Forms.Timer timerMovement;
        private System.Windows.Forms.Timer timerObstacleMove;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Timer timerHazardDamage;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelArea;
        private System.Windows.Forms.Panel panelTime;
        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.PictureBox pictureBoxButtonPlayPause;
        private System.Windows.Forms.PictureBox pictureBoxItem8;
        private System.Windows.Forms.PictureBox pictureBoxItem9;
        private System.Windows.Forms.PictureBox pictureBoxItem10;
        private System.Windows.Forms.PictureBox pictureBoxItem11;
        private System.Windows.Forms.PictureBox pictureBoxItem12;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Timer timerBossFight;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayerIntro;
        private System.Windows.Forms.PictureBox pictureBoxMenu;
        private System.Windows.Forms.Timer timerBossEvents;
        private System.Windows.Forms.PictureBox pictureBoxBossHealthBar;
        private System.Windows.Forms.Label labelBossName;
        private System.Windows.Forms.Button buttonNotes;
        private System.Windows.Forms.PictureBox pictureBoxPaused;
        private System.Windows.Forms.PictureBox pictureBoxItemEx1;
        private System.Windows.Forms.PictureBox pictureBoxItemEx2;
        private System.Windows.Forms.PictureBox pictureBoxItemEx3;
        private System.Windows.Forms.Button buttonData;
    }
}