using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace viswaGoldenTreasureGame
{
    public partial class FormGame : Form
    {
        public FormGame()
        {
            InitializeComponent();
        }
        Player player;
        Player ghostPlayer;
        ViswaTime time;
        List<Area> listOfArea = new List<Area>();
        Area area1;
        Area area2;
        Area area3;
        Area bossArea;
        Area areaEx1;
        Area areaEx2;

        //List<Point> map1_TreasureSpawn = new List<Point>();
        //List<Point> map2_TreasureSpawn = new List<Point>();
        //List<Point> map3_TreasureSpawn = new List<Point>();
        //List<Point> map1_ObstacleSpawn = new List<Point>();
        //List<Point> map2_ObstacleSpawn = new List<Point>();
        //List<Point> map3_ObstacleSpawn = new List<Point>();

        //Point[,] treasureSpawn_2DArray = new Point[3, 5];
        //Point[,] obstacleSpawn_2DArray = new Point[3, 4];

        Projectile[][] bossProjectile_Array = new Projectile[4][];

        //Weapons 1-6, Buffs 7-8
        Weapons[] bossWeapons_Array = new Weapons[6];

        bool gameIsRunning = false; //boolean to categorize whether a game is running or not.
        bool messageShowing;
        bool bossFightRunning = false;

        int leftMargin = 20;
        int rightMargin = 1050;
        int topMargin = 80;
        int bottomMargin = 630;
        int maxArea = 4; //NEW

        WindowsMediaPlayer wmplayerBacksound = null;
        WindowsMediaPlayer wmplayerTitle = null;
        WindowsMediaPlayer wmplayerBoss = null;
        WindowsMediaPlayer wmplayerBossHit = null;
        WindowsMediaPlayer wmplayerPlayerHit = null;
        WindowsMediaPlayer wmplayerItemFound = null;
        WindowsMediaPlayer wmplayerLose = null;
        WindowsMediaPlayer wmplayerAttack = null;
        WindowsMediaPlayer wmplayerWin = null;

        int originalBossHealthBarWidth = 1040;
        int originalBossHealthBarHeight = 23;

        Items treasureBox;
        Items bossLetter;
        bool treasureSpawned = false;
        bool letterSpawned = false;
        Items item;
        Enemy enemy;
        Boss boss;
        Projectile projectile;
        int totalKeyItems;
        double bossTimeCounter;
        
        List<PictureBox> listPictureBoxInventory = new List<PictureBox>();

        private void StopPlayerMovement()
        {
            player.MovingLeft = false;
            player.MovingRight = false;
            player.MovingUp = false;
            player.MovingDown = false;
        }

        private void StopGame()
        {

            player.MovingUp = false;
            player.MovingDown = false;
            player.MovingRight = false;
            player.MovingLeft = false;

            timerGameTime.Stop();
            timerGameTick.Stop();
            timerMovement.Stop();
            timerObstacleMove.Stop();
            timerHazardDamage.Stop();

            if (player.CurrentArea.AreaNum == 4)
            {
                timerBossEvents.Stop();
                timerBossFight.Stop();
            }
            
        }
        private void UnpauseGame()
        {
            timerGameTime.Start();
            timerGameTick.Start();
            timerMovement.Start();
            timerObstacleMove.Start();
            timerHazardDamage.Start();

            if (player.CurrentArea.AreaNum == 4)
            {
                timerBossEvents.Start();
                timerBossFight.Start();
            }
        }

        private void ShowMenu()
        {
            InitializeGame();

            panelInventory.Visible = false;
            panelInfo.Visible = false;
            pictureBoxButtonPlayPause.Visible = false;
            pictureBoxButtonPlayPause.Enabled = false;
            pictureBoxMenu.Visible = false;
            pictureBoxMenu.Enabled = false;

            labelBossName.Visible = false;
            pictureBoxBossHealthBar.Visible = false;

            buttonStart.Visible = true;
            buttonExit.Visible = true;
            buttonNotes.Visible = true;
            buttonData.Visible = true;

            buttonStart.Enabled = true;
            buttonExit.Enabled = true;
            buttonNotes.Enabled = true;
            buttonData.Enabled = true;
            buttonNotes.Location = new Point(12, 680);

            this.BackgroundImage = Properties.Resources.Map_Title;

            wmplayerTitle.settings.volume = 10;
            wmplayerTitle.URL = Application.StartupPath + @"\sound\titleMusic.mp3";
            wmplayerTitle.controls.play();
        }

        double lastActionCounter1 = 0;
        double lastActionCounter2 = 0;
        double lastActionCounter3 = 0;
        int randomNumber = 0;
        Random random = new Random();
        int angle = 0;
        int projectileNum1;
        int projectileNum2;
        Projectile bossProjectile;
        List<Projectile> listShotBossProjectiles = new List<Projectile>();
        List<Projectile> listShotBossProjectiles2 = new List<Projectile>();
        List<Weapons> listSpawnedWeapons = new List<Weapons>();

        private void GenerateBossItems(Boss boss)
        {
            Weapons weapon;

            bossProjectile_Array[0] = new Projectile[6];
            bossProjectile_Array[1] = new Projectile[10];
            bossProjectile_Array[2] = new Projectile[6];
            bossProjectile_Array[3] = new Projectile[6];


            //Phase 1 Projectiles
            for (int i = 0; i < 6; i++)
            {
                bossProjectile = boss.ListProjectiles[0];
                bossProjectile_Array[0][i] = bossProjectile;
            }
            //Phase 2(1) Projectiles
            for (int i = 0; i < 10; i++)
            {
                bossProjectile = boss.ListProjectiles[1];
                bossProjectile_Array[1][i] = bossProjectile;
            }
            //Phase 2(2) Projectiles
            for (int i = 0; i < 6; i++)
            {
                bossProjectile = boss.ListProjectiles[2];
                bossProjectile_Array[2][i] = bossProjectile;
            }
            //Phase 3 Projectiles
            for (int i = 0; i < 6; i++)
            {
                bossProjectile = boss.ListProjectiles[3];
                bossProjectile_Array[3][i] = bossProjectile;
            }

            //Items Generation
            weapon = new Weapons("Bow", "bow", Properties.Resources.Boss_Fight_Bow_Arrow,
                new Point(0, 0), new Size(46, 40), 25, 2);
            bossWeapons_Array[0] = weapon;

            weapon = new Weapons("Dagger", "dagger", Properties.Resources.Boss_Fight_Dagger,
                new Point(0, 0), new Size(46, 40), 25, 1);
            bossWeapons_Array[1] = weapon;

            weapon = new Weapons("Dogouken", "dogouken", Properties.Resources.Boss_Fight_Dogouken,
                new Point(0, 0), new Size(22, 45), 40, 4);
            bossWeapons_Array[2] = weapon;

            weapon = new Weapons("Excalibur", "excalibur", Properties.Resources.Boss_Fight_Excalibur,
                new Point(0, 0), new Size(24, 47), 50, 5);
            bossWeapons_Array[3] = weapon;

            weapon = new Weapons("Magic Wand", "magic_wand", Properties.Resources.Boss_Fight_Magic_Wand,
                new Point(0, 0), new Size(46, 46), 75, 10);
            bossWeapons_Array[4] = weapon;

            weapon = new Weapons("Mighty Axe", "mighty_axe", Properties.Resources.Boss_Fight_Mighty_Axe,
                new Point(0, 0), new Size(34, 46), 25, 3);
            bossWeapons_Array[5] = weapon;

        }

        Weapons weaponSelected = null;

        private void RunBossFight(Boss boss)
        {
            Projectile projectileSelected;


            if (bossTimeCounter > 3)
            {
                //Phase 1
                bossFightRunning = true;
                if (boss.Phase == 1)
                {
                    angle = random.Next(135, 225);
                    //angle = random.Next(180, 225);

                    //ScrambleFire Attack
                    projectileSelected = new Projectile(boss.ListProjectiles[0]);
                    if (lastActionCounter1 >= projectileSelected.SpawnInterval)
                    {
                        //boss.ShootProjectile(projectileSelected, 1000, 20, angle, this);
                        lastActionCounter1 = 0;
                        projectileSelected.ShootingAngle = angle;
                        projectileSelected.HasBeenShot = true;
                        listShotBossProjectiles.Add(projectileSelected);
                    }
                }
                //Phase 2
                else if (boss.Phase == 2)
                {
                    //CornerSource Fireballs
                    angle = random.Next(120, 170);
                    projectileSelected = new Projectile(boss.ListProjectiles[2]);
                    if (lastActionCounter1 >= projectileSelected.SpawnInterval)
                    {
                        lastActionCounter1 = 0;
                        projectileSelected.ShootingAngle = angle;
                        projectileSelected.HasBeenShot = true;
                        listShotBossProjectiles.Add(projectileSelected);
                    }

                    //Rain of Fire
                    projectileSelected = new Projectile(boss.ListProjectiles[0]);
                    if (lastActionCounter2 >= 0.7)
                    {
                        lastActionCounter2 = 0;
                        projectileSelected.ShootingAngle = 90;
                        projectileSelected.HasBeenShot = true;
                        listShotBossProjectiles2.Add(projectileSelected);
                    }
                }

                else if (boss.Phase == 3)
                {
                    //CornerSource Fireballs
                    angle = random.Next(120, 170);
                    projectileSelected = new Projectile(boss.ListProjectiles[2]);
                    if (lastActionCounter1 >= 0.8)
                    {
                        lastActionCounter1 = 0;
                        projectileSelected.ShootingAngle = angle;
                        projectileSelected.HasBeenShot = true;
                        listShotBossProjectiles.Add(projectileSelected);
                    }

                    //BlueFire Cluster
                    angle = random.Next(135, 215);
                    
                    if (lastActionCounter2 > 2)
                    {
                        lastActionCounter2 = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            projectileSelected = new Projectile(boss.ListProjectiles[3]);
                            projectileSelected.ShootingAngle = angle + (i*3);
                            projectileSelected.HasBeenShot = true;
                            listShotBossProjectiles2.Add(projectileSelected);
                        }
                    }
                    
                }
                else
                {
                    boss.Phase = 0;
                }
            }

            if (bossTimeCounter > 6)
            {
                Point spawnPoint = new Point(random.Next(120, 700), random.Next(60, 555));
                if (weaponSelected == null)
                {
                    weaponSelected = new Weapons(bossWeapons_Array[random.Next(0, 5)]);
                    weaponSelected.SpawnPoint = spawnPoint;
                }

                if (lastActionCounter3 >= weaponSelected.SpawnInterval &&
                    listSpawnedWeapons.Count <= 6)
                {
                    lastActionCounter3 = 0;
                    weaponSelected.HasSpawned = true;
                    listSpawnedWeapons.Add(weaponSelected);
                    weaponSelected = null;
                }
            }
        }

        private void InitializeGame()
        {
            timerBossEvents.Stop();
            timerBossFight.Stop();
            bossTimeCounter = 0;
            labelBossName.Visible = false;
            pictureBoxBossHealthBar.Visible = false;

            foreach (Projectile projectile in listOfShotProjectiles)
            {
                projectile.Picture.Hide();
            }
            listOfShotProjectiles.Clear();


            foreach (Projectile projectile in listShotBossProjectiles.ToList())
            {
                listShotBossProjectiles.Remove(projectile);
                projectile.Picture.Dispose();
            }
            foreach (Projectile projectile2 in listShotBossProjectiles2.ToList())
            {
                listShotBossProjectiles2.Remove(projectile2);
                projectile2.Picture.Dispose();
            }
            foreach (Weapons weapon in listSpawnedWeapons.ToList())
            {
                listSpawnedWeapons.Remove(weapon);
                weapon.Picture.Dispose();
            }

            foreach (Area area in listOfArea)
            {
                area.HideAllItems();
                area.HideAllEnemy();
                area.ListItems.Clear();
                area.ListEnemy.Clear();
            }

            ghostPlayer.Picture.Visible = false;
            player.Picture.Visible = false;
            StopPlayerMovement();
            player = null;
            ghostPlayer = null;
            time = null;
            listOfArea.Clear();
            //area1 = null;
            //area2 = null;
            //area3 = null;

            gameIsRunning = false;
            messageShowing = false;

            wmplayerBacksound.controls.stop();
            wmplayerTitle.controls.stop();
            wmplayerBoss.controls.stop();
            wmplayerLose.controls.stop();
            wmplayerWin.controls.stop();

            wmplayerBacksound = null;
            wmplayerTitle = null;
            wmplayerBoss = null;
            wmplayerBossHit = null;
            wmplayerPlayerHit = null;
            wmplayerItemFound = null;
            wmplayerLose = null;
            wmplayerAttack = null;
            wmplayerWin = null;

            treasureBox = null;
            bossLetter = null;
            treasureSpawned = false;
            letterSpawned = false;
            foreach (PictureBox pictureBox in panelInventory.Controls)
            {
                pictureBox.BorderStyle = BorderStyle.None;
            }

            item = null;
            totalKeyItems = 0;

            listPictureBoxInventory = new List<PictureBox>();

            wmplayerBacksound = new WindowsMediaPlayer();
            wmplayerTitle = new WindowsMediaPlayer();
            wmplayerBoss = new WindowsMediaPlayer();
            wmplayerBossHit = new WindowsMediaPlayer();
            wmplayerPlayerHit = new WindowsMediaPlayer();
            wmplayerItemFound = new WindowsMediaPlayer();
            wmplayerLose = new WindowsMediaPlayer();
            wmplayerAttack = new WindowsMediaPlayer();
            wmplayerWin = new WindowsMediaPlayer();

            wmplayerBacksound.settings.setMode("loop", true);
            wmplayerTitle.settings.setMode("loop", true);
            wmplayerLose.settings.setMode("loop", true);
            wmplayerWin.settings.setMode("loop", true);
            wmplayerBoss.settings.setMode("loop", true);
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1076, 806);
            this.CenterToScreen();

            labelArea.Visible = false;
            labelDescription.Visible = false;
            labelPlayer.Visible = false;
            labelTime.Visible = false;
            panelInventory.Visible = false;
            panelInfo.Visible = false;
            pictureBoxButtonPlayPause.Visible = false;
            pictureBoxButtonPlayPause.Enabled = false;
            pictureBoxMenu.Visible = false;
            pictureBoxMenu.Enabled = false;
            labelBossName.Visible = false;
            pictureBoxBossHealthBar.Visible = false;

            pictureBoxPaused.Visible = false;


            wmplayerBacksound = new WindowsMediaPlayer();
            wmplayerTitle = new WindowsMediaPlayer();
            wmplayerBoss = new WindowsMediaPlayer();
            wmplayerBossHit = new WindowsMediaPlayer();
            wmplayerPlayerHit = new WindowsMediaPlayer();
            wmplayerItemFound = new WindowsMediaPlayer();
            wmplayerLose = new WindowsMediaPlayer();
            wmplayerAttack = new WindowsMediaPlayer();
            wmplayerWin = new WindowsMediaPlayer();

            wmplayerBacksound.settings.setMode("loop", true);
            wmplayerTitle.settings.setMode("loop", true);
            wmplayerLose.settings.setMode("loop", true);
            wmplayerWin.settings.setMode("loop", true);
            wmplayerBoss.settings.setMode("loop", true);


            //foreach (Control pictureBox in panelInventory.Controls)
            //{
            //    pictureBox.Tag = BackgroundImage.ToString();
            //}

            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);

            axWindowsMediaPlayerIntro.Visible = true;
            axWindowsMediaPlayerIntro.uiMode = "none";
            axWindowsMediaPlayerIntro.Size = new Size(1076, 806);
            axWindowsMediaPlayerIntro.Location = new Point(0, 0);
            axWindowsMediaPlayerIntro.stretchToFit = true;
            axWindowsMediaPlayerIntro.settings.autoStart = true;
            axWindowsMediaPlayerIntro.URL = Application.StartupPath + @"\Video\Opening.mp4";
            axWindowsMediaPlayerIntro.BringToFront();

            wmplayerTitle.settings.volume = 10;
            wmplayerTitle.URL = Application.StartupPath + @"\sound\titleMusic.mp3";
            wmplayerTitle.controls.play();

        }
        private void StartGame()
        {
            player = new Player("Amelia", Properties.Resources.MC_Right, new Point(60, 400), 
                new Size(50, 50), 500, 18, null);
            ghostPlayer = new Player("Ghost", null, new Point(20, 400),
                new Size(50, 50), 10, 18, null);
            labelTime.Visible = true;
            time = new ViswaTime(0, 6, 0);

            timerGameTime.Interval = 1000;
            timerGameTime.Start();
            timerGameTick.Interval = 50;
            timerGameTick.Start();
            timerMovement.Interval = 20;
            timerMovement.Start();
            timerObstacleMove.Interval = 50;
            timerObstacleMove.Start();
            timerHazardDamage.Interval = 1000;
            timerHazardDamage.Start();

            panelInventory.Visible = true;
            panelInfo.Visible = true;
            pictureBoxButtonPlayPause.Visible = true;
            pictureBoxButtonPlayPause.Enabled = true;
            pictureBoxMenu.Visible = true;
            pictureBoxMenu.Enabled = true;

            buttonStart.Visible = false;
            buttonExit.Visible = false;
            buttonNotes.Visible = false;
            buttonData.Visible = false;

            buttonStart.Enabled = false;
            buttonExit.Enabled = false;
            buttonNotes.Enabled = false;
            buttonData.Enabled = false;

            CreateAllArea();

            OpenArea(null, listOfArea[0]);

            wmplayerTitle.controls.stop();
            wmplayerBacksound.settings.volume = 5;
            wmplayerBacksound.URL = Application.StartupPath + @"\sound\inGameMusic.mp3";
            wmplayerBacksound.controls.play();
            //I commented this because I need to go through so many debugging sessions
            //and it's driving me insane.

            gameIsRunning = true;

            totalKeyItems = 15;
        }

        

        private void ReplayGame()
        {
            InitializeGame();
            StartGame();
        }

        //NEW CODE Thursday, 21st of April 2022
        private void OpenArea(Area fromArea, Area toArea)
        {
            foreach (Area area in listOfArea)
            {
                if (area.AreaNum == toArea.AreaNum)
                {
                    toArea.DisplayArea(this);
                    labelArea.Text = toArea.DisplayData();
                    labelArea.Visible = true;
                    labelDescription.Text = toArea.DisplayDesc();
                    labelDescription.Visible = true;
                    labelArea.BringToFront();
                    
                    player.CurrentArea = toArea;
                    player.DisplayPicture(this);
                    ghostPlayer.CurrentArea = toArea;
                    ghostPlayer.DisplayPicture(this);
                    
                    labelPlayer.Text = player.DisplayData();
                    labelPlayer.Visible = true;
                    labelPlayer.BringToFront();
                    panelInventory.BringToFront();
                    labelTime.BringToFront();

                    if (fromArea != null)
                    {
                        fromArea.HideAllEnemy();
                        fromArea.HideAllItems();
                        fromArea.HideAllProjectiles();
                    }
                    if (toArea.AreaNum == 4)
                    {
                        foreach (Items item in toArea.ListItems)
                        {
                            if (item is Hazard)
                            {
                                Hazard hazard = (Hazard)item;
                                hazard.Picture.SendToBack();
                            }
                        }

                        timerBossFight.Interval = 100;
                        timerBossFight.Start();
                        timerBossEvents.Interval = 50;
                        timerBossEvents.Start();
                        labelBossName.Visible = true;
                        pictureBoxBossHealthBar.Visible = true;

                        double bossHealthFraction = ((double)boss.Health / boss.OriginalHealth);
                        pictureBoxBossHealthBar.Size = new Size((int)(originalBossHealthBarWidth *
                            bossHealthFraction), originalBossHealthBarHeight);

                        wmplayerBacksound.controls.stop();
                        wmplayerBoss.settings.volume = 5;
                        wmplayerBoss.URL = Application.StartupPath + @"\sound\bossMusic.mp3";
                        wmplayerBoss.controls.play();

                        panelInventory.Visible = false;
                    }
                    toArea.ShowAllItem();
                    toArea.ShowAllEnemy(this);

                    foreach (Projectile projectile in listOfShotProjectiles)
                    {
                        projectile.Picture.Hide();
                        return;
                    }
                    listOfShotProjectiles.Clear();
                    
                    if (currentProjectile != null)
                    {
                        currentProjectile.Picture.Hide();
                        currentProjectile = null;
                    }

                    foreach (Items barrier in toArea.ListItems)
                    {
                        if (barrier is Barrier)
                        {
                            barrier.Picture.SendToBack();
                        }
                    }
                }
            }
        }
        private void CreateAllArea()
        {
            area1 = new Area(1, "Desert", Properties.Resources.Map_1, "Vast horizon of sand and heat");
            item = new TreasureItem("Pot", "pot", Properties.Resources.Map_01_Pot,
                new Point(824, 81), new Size(40, 40), "Hundred years old pot");
            area1.AddItem(item);
            item = new TreasureItem("Rare fossil", "rare_fossil", Properties.Resources.Map_01_RareFossil,
                new Point(516, 582), new Size(47, 47), "Fossil of a long gone species");
            area1.AddItem(item);
            item = new TreasureItem("Rare skeleton", "rare_skeleton", Properties.Resources.Map_01_RareSkeleton,
                new Point(136, 153), new Size(45, 45), "Skeleton of a long lost ruler");
            area1.AddItem(item);
            item = new TreasureItem("Sacrofagus", "sacrofagus", Properties.Resources.Map_01_Sacrofagus,
                new Point(452, 294), new Size(45, 48), "Sacrofagus that started the rise and downfall of empires");
            area1.AddItem(item);
            item = new ObstacleItem("Trap cactus", "trap_cactus", Properties.Resources.Map_01_Trap_Cacty,
                new Point(136, 607), new Size(42, 46), 10);
            area1.AddItem(item);
            item = new ObstacleItem("Trap bomb", "trap_bomb", Properties.Resources.Map_01_Trap_Bomb,
                new Point(951, 249), new Size(42, 38), 20);
            area1.AddItem(item);

            item = new Barrier("Blockade 10", "blockade_10", Properties.Resources.blank,
               new Point(-55, 63), new Size(100, 590));
            area1.AddItem(item);
            item = new Barrier("Blockade 11", "blockade_11", Properties.Resources.blank,
                new Point(82, 63), new Size(41, 143));
            area1.AddItem(item);
            item = new Barrier("Blockade 12", "blockade_12", Properties.Resources.blank,
                new Point(82, 498), new Size(66, 116));
            area1.AddItem(item);
            item = new Barrier("Blockade 13", "blockade_13", Properties.Resources.blank,
                new Point(205, 60), new Size(185, 74));
            area1.AddItem(item);
            item = new Barrier("Blockade 14", "blockade_14", Properties.Resources.blank,
                new Point(205, 131), new Size(64, 75));
            area1.AddItem(item);
            item = new Barrier("Blockade 15", "blockade_15", Properties.Resources.blank,
                new Point(329, 131), new Size(61, 75));
            area1.AddItem(item);
            item = new Barrier("Blockade 16", "blockade_16", Properties.Resources.blank,
                new Point(389, 83), new Size(67, 123));
            area1.AddItem(item);
            item = new Barrier("Blockade 17", "blockade_17", Properties.Resources.blank,
                new Point(348, 59), new Size(403, 18));
            area1.AddItem(item);
            item = new Barrier("Blockade 18", "blockade_18", Properties.Resources.blank,
                new Point(1008, -32), new Size(69, 175));
            area1.AddItem(item);
            item = new Barrier("Blockade 120", "blockade_120", Properties.Resources.blank,
                new Point(758, 59), new Size(72, 28));
            area1.AddItem(item);

            item = new Entrance("Tent Entrance", "tent_entrance", Properties.Resources.blank,
                new Point(246, 164), new Size(66, 88), 5, new Point(502, 459));
            area1.AddItem(item);

            listOfArea.Add(area1);
            area1.HideAllItems();


            area2 = new Area(2, "Palace Garden", Properties.Resources.Map_2, "Beatiful Palace Garden");
            item = new TreasureItem("Rare statue", "rare_statue", Properties.Resources.Rare_Statue,
                new Point(883, 177), new Size(40, 40), "Statue of the leader of the lost army");
            area2.AddItem(item);
            item = new TreasureItem("Box of sword", "box_of_sword", Properties.Resources.Map_02_Box_Of_Sword,
                new Point(350, 175), new Size(48, 34), "A box of sword belongs to an ancient army");
            area2.AddItem(item);
            item = new TreasureItem("Holy Corpse", "holy_corpse", Properties.Resources.Map_02_Holy_Corpse,
                new Point(579, 533), new Size(35, 47), "Is it graverobbing? Eh probably not right?");
            area2.AddItem(item);
            item = new TreasureItem("Impossible Snowman", "impossible_snowman", Properties.Resources.Map_02_ImpossibleSnowman,
                new Point(707, 357), new Size(38, 46), "Snowman that broke the rules of physics, Fascinating.");
            area2.AddItem(item);
            item = new ObstacleItem("Trap hole", "trap_hole", Properties.Resources.Map_02_Trap_Hole,
                new Point(747, 473), new Size(46, 34), 5);
            area2.AddItem(item);
            item = new ObstacleItem("Trap Poisonous Flower", "trap_poisonous_flower", Properties.Resources.Map_02_Trap_PoisonousFlower,
                new Point(634, 178), new Size(48, 41), 20);
            area2.AddItem(item);
            item = new ObstacleItem("Trap Poisonous Mushrooms", "trap_poisonous_mushrooms", Properties.Resources.Map_02_Trap_PoisonousShrooms,
                new Point(365, 539), new Size(41, 45), 15);
            area2.AddItem(item);

            item = new Barrier("Blockade 20", "blockade_20", Properties.Resources.blank,
               new Point(-6, 59), new Size(494, 116));
            area2.AddItem(item);
            item = new Barrier("Blockade 21", "mblockade_21", Properties.Resources.blank,
               new Point(685, 71), new Size(127, 102));
            area2.AddItem(item);
            item = new Barrier("Blockade 22", "blockade_22", Properties.Resources.blank,
               new Point(903, -1), new Size(176, 144));
            area2.AddItem(item);
            item = new Barrier("Blockade 23", "blockade_23", Properties.Resources.blank,
               new Point(685, 525), new Size(127, 123));
            area2.AddItem(item);

            listOfArea.Add(area2);
            area2.HideAllItems();

            area3 = new Area(3, "Workshop", Properties.Resources.Map_3, "Venue of Efficiency and Production");
            item = new TreasureItem("Car", "car", Properties.Resources.Map_03_Car,
                new Point(249, 596), new Size(95, 46), "A marvel of modern engineering that revolutionized transportation");
            area3.AddItem(item);
            item = new TreasureItem("Computer", "computer", Properties.Resources.Map_03_CoolPC,
                new Point(759, 194), new Size(39, 40), "A machine that changed the modern world");
            area3.AddItem(item);
            item = new TreasureItem("Rare Collectible Poster", "rare_poster", Properties.Resources.Map_03_RareCollectiblePoster,
                new Point(704, 540), new Size(38, 46), "Oh look a poster of my favourite anime!");
            area3.AddItem(item);
            item = new TreasureItem("Tank", "tank", Properties.Resources.Map_03_Tank,
                new Point(566, 293), new Size(92, 67), "I am in a tank and you're not.");
            area3.AddItem(item);
            item = new ObstacleItem("Trap Holes", "trap_holes", Properties.Resources.Map_03_Trap_Holes,
                new Point(546, 189), new Size(48, 48), 5);
            area3.AddItem(item);

            item = new Barrier("Magic Barrier", "magic_barrier", Properties.Resources.MapBlock,
                new Point(995, 345), new Size(62, 185));
            area3.AddItem(item);
            item = new Barrier("Blockade 30", "blockade_30", Properties.Resources.blank,
                new Point(-12, 59), new Size(1070, 109));
            area3.AddItem(item);
            item = new Barrier("Blockade 31", "blockade_31", Properties.Resources.blank,
                new Point(806, 52), new Size(252, 280));
            area3.AddItem(item);
            item = new Barrier("Blockade 32", "blockade_32", Properties.Resources.blank,
                new Point(811, 416), new Size(252, 237));
            area3.AddItem(item);
            item = new Barrier("Blockade 33", "blockade_33", Properties.Resources.blank,
                new Point(392, 593), new Size(417, 60));
            area3.AddItem(item);

            enemy = new Enemy("Witch", "witch", Properties.Resources.Mob_Witch,
                new Point(242, 121), new Size(45, 58), 6, area3);
            //enemy = new Enemy("Witch", "witch", Properties.Resources.Mob_Witch,
            //    new Point(400, 400), new Size(45, 58), 6, area3);
            //projectile = new Projectile("Witch Flame", "witch_flame", Properties.Resources.Boss_Attack_Flame,
            //    new Point(239, 184), new Size(41, 43), 4);
            projectile = new Projectile("Witch Flame", "witch_flame", Properties.Resources.Boss_Attack_Flame,
                new Point(enemy.Picture.Location.X + enemy.Picture.Size.Width / 2 - 41 / 2,
                enemy.Picture.Location.Y + enemy.Picture.Size.Height),
                new Size(41, 43), 10, 4);
            enemy.ListProjectiles.Add(projectile);
            area3.AddEnemy(enemy);

            item = new Barrier("Magic Barrier", "magic_barrier", Properties.Resources.MapBlock,
                new Point(995, 345), new Size(62, 185));
            area3.AddItem(item);

            listOfArea.Add(area3);
            area3.HideAllItems();

            bossArea = new Area(4, "Underground", Properties.Resources.Map_Boss, "Depths of the realm");
            item = new Hazard("Magma", "magma_1", null, new Point(0, 697), new Size(1060, 65), 5);
            bossArea.AddItem(item);
            item = new Hazard("Magma", "magma_2", null, new Point(998, 59), new Size(62, 642), 5);
            bossArea.AddItem(item);
            item = new Hazard("Magma", "magma_3", null, new Point(0, 0), new Size(1060, 67), 5);
            bossArea.AddItem(item);
            item = new Hazard("Magma", "magma_4", null, new Point(0, 59), new Size(62, 227), 5);
            bossArea.AddItem(item);
            item = new Hazard("Magma", "magma_5", null, new Point(0, 534), new Size(62, 167), 5);
            bossArea.AddItem(item);
            item = new Barrier("Barrier 40", "barrier_40", Properties.Resources.blank,
                new Point(820, 345), new Size(129, 128));
            bossArea.AddItem(item);

            List<int> phaseHealthLimit = new List<int>();
            int[] healthLimitValues = {1650, 1000, 650};
            phaseHealthLimit.AddRange(healthLimitValues);
            boss = new Boss("Demonytta", "demonytta", Properties.Resources.Boss,
                new Point(820, 345), new Size(129, 128), 10, bossArea, phaseHealthLimit, 1650);
            projectile = new Projectile("Flame", "flame", Properties.Resources.Boss_Attack_Flame,
                new Point(0, 0), new Size(41, 41), 20, 0.5);
            boss.ListProjectiles.Add(projectile);
            projectile = new Projectile("Lava", "lava", Properties.Resources.Boss_Attack_Lava,
                new Point(0, 0), new Size(48, 61), 25, 3);
            boss.ListProjectiles.Add(projectile);
            projectile = new Projectile("Fire Rain", "fire_rain", Properties.Resources.Boss_Attack_Fireball,
                new Point(0, 0), new Size(42, 47), 20, 1);
            boss.ListProjectiles.Add(projectile);
            projectile = new Projectile("Blue Fire", "blue_fire", Properties.Resources.Boss_Attack_Blue_Fireball,
                new Point(0, 0), new Size(42, 47), 30, 2);
            boss.ListProjectiles.Add(projectile);
            bossArea.ListEnemy.Add(boss);

            GenerateBossItems(boss);

            listOfArea.Add(bossArea);
            bossArea.HideAllItems();

            areaEx1 = new Area(5, "Tent", Properties.Resources.MapEX1, "Abandoned tent");
            item = new Barrier("Blockade 50", "blockade_50", Properties.Resources.blank,
               new Point(-6, 59), new Size(1063, 113));
            areaEx1.AddItem(item);
            item = new Barrier("Blockade 51", "blockade_51", Properties.Resources.blank,
               new Point(809, 143), new Size(254, 510));
            areaEx1.AddItem(item);
            item = new Barrier("Blockade 52", "blockade_52", Properties.Resources.blank,
               new Point(-6, 600), new Size(1069, 53));
            areaEx1.AddItem(item);
            item = new Barrier("Blockade 53", "blockade_53", Properties.Resources.blank,
               new Point(-6, 143), new Size(251, 430));
            areaEx1.AddItem(item);
            item = new Barrier("Blockade 54", "blockade_54", Properties.Resources.blank,
               new Point(240, 172), new Size(114, 53));
            areaEx1.AddItem(item);
            item = new Barrier("Blockade 55", "blockade_55", Properties.Resources.blank,
               new Point(745, 172), new Size(58, 107));
            areaEx1.AddItem(item);
            item = new Barrier("Blockade 56", "blockade_56", Properties.Resources.blank,
               new Point(247, 486), new Size(56, 108));
            areaEx1.AddItem(item);
            item = new Barrier("Blockade 57", "blockade_57", Properties.Resources.blank,
               new Point(309, 543), new Size(119, 52));
            areaEx1.AddItem(item);
            //item = new Barrier("Blockade 58", "blockade_58", Properties.Resources.blank,
            //   new Point(430, 436), new Size(47, 108));
            //areaEx1.AddItem(item);
            //item = new Barrier("Blockade 59", "blockade_59", Properties.Resources.blank,
            //   new Point(569, 436), new Size(47, 109));
            //areaEx1.AddItem(item);
            item = new Barrier("Blockade 500", "blockade_500", Properties.Resources.blank,
               new Point(628, 543), new Size(84, 52));
            areaEx1.AddItem(item);
            item = new Barrier("Blockade 501", "blockade_501", Properties.Resources.blank,
               new Point(682, 483), new Size(126, 115));
            areaEx1.AddItem(item);

            item = new Entrance("Basement Entrance", "basement_entrance", Properties.Resources.blank,
                new Point(497, 306), new Size(62, 53), 6, new Point(505, 442));
            areaEx1.AddItem(item);
            item = new Entrance("Tent Exit", "tent_exit", Properties.Resources.blank,
                new Point(437, 560), new Size(185, 37), 1, new Point(255, 311));
            areaEx1.AddItem(item);

            listOfArea.Add(areaEx1);
            areaEx1.HideAllItems();

            areaEx2 = new Area(6, "Basement", Properties.Resources.MapEX2, "Basement");
            item = new TreasureItem("Ancient Literature", "ancient_literature", Properties.Resources.Ancient_Literature,
                new Point(824, 460), new Size(40, 40), "Formula to eternity.");
            areaEx2.AddItem(item);
            item = new TreasureItem("Cool Map", "cool_map", Properties.Resources.Cool_Map,
                new Point(190, 282), new Size(47, 47), "Crazy insane map");
            areaEx2.AddItem(item);
            item = new TreasureItem("Mysthical Book", "mysthical_book", Properties.Resources.Mysthical_Book,
                new Point(750, 162), new Size(45, 45), "Forbidden dark magic");
            areaEx2.AddItem(item);
            item = new ObstacleItem("Trap Cursed Doll", "trap_cursed_doll", Properties.Resources.Trap_Cursed_Doll,
                new Point(190, 563), new Size(42, 46), 15);
            areaEx2.AddItem(item);
            item = new ObstacleItem("Trap Expired Food", "trap_expired_food", Properties.Resources.Trap_ExpiredFood,
                new Point(315, 162), new Size(42, 38), 25);
            areaEx2.AddItem(item);
            item = new Barrier("Blockade 60", "blockade_60", Properties.Resources.blank,
               new Point(-5, 59), new Size(186, 594));
            areaEx2.AddItem(item);
            item = new Barrier("Blockade 61", "blockade_61", Properties.Resources.blank,
               new Point(-5, 59), new Size(1060, 89));
            areaEx2.AddItem(item);
            item = new Barrier("Blockade 62", "blockade_62", Properties.Resources.blank,
               new Point(867, 121), new Size(188, 532));
            areaEx2.AddItem(item);
            item = new Barrier("Blockade 63", "blockade_63", Properties.Resources.blank,
               new Point(-5, 615), new Size(1069, 38));
            areaEx2.AddItem(item);
            item = new Barrier("Blockade 64", "blockade_64", Properties.Resources.blank,
               new Point(177, 147), new Size(132, 120));
            areaEx2.AddItem(item);
            item = new Barrier("Blockade 65", "blockade_65", Properties.Resources.blank,
               new Point(738, 252), new Size(73, 71));
            areaEx2.AddItem(item);
            item = new Barrier("Blockade 66", "blockade_66", Properties.Resources.blank,
               new Point(802, 147), new Size(65, 178));
            areaEx2.AddItem(item);
            item = new Barrier("Blockade 67", "blockade_68", Properties.Resources.blank,
               new Point(802, 506), new Size(65, 117));
            areaEx2.AddItem(item);

            item = new Entrance("Basement Exit", "basement_exit", Properties.Resources.blank,
                new Point(494, 336), new Size(71, 66), 5, new Point(503, 226));
            areaEx2.AddItem(item);

            listOfArea.Add(areaEx2);
            areaEx2.HideAllItems();

            treasureBox = new TreasureItem("Treasure Box", "treasure_box",
            Properties.Resources.Treasure_Chest, new Point(540, 360), new Size(41,40),
            "A treasure box filled with treasures");
            treasureBox.Picture.Visible = false;

            bossLetter = new TreasureItem("Letter", "letter",
                Properties.Resources.Trap_CopyrightStrikeLetter, new Point(540, 360), new Size(30, 31),
            "a Mysterious letter");
            bossLetter.Picture.Visible = false;
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            //if (playPauseGameToolStripMenuItem.Text != "Play") //What?

            if (gameIsRunning == true)
            {
                if (e.KeyCode == Keys.Right)
                {
                    player.MovingRight = true;
                }
                if (e.KeyCode == Keys.Left)
                {
                    player.MovingLeft = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    player.MovingUp = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    player.MovingDown = true;
                }
            }
            
        }

        private void FormGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                player.MovingRight = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                player.MovingLeft = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                player.MovingUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                player.MovingDown = false;
            }
        }

        //Timer for obstacle movement
        //bool movingUp = false;
        //bool movingLeft = false;
        Projectile currentProjectile = null;
        List<Projectile> listOfShotProjectiles = new List<Projectile>();

        private void timerHazardDamage_Tick(object sender, EventArgs e)
        {
            foreach (Items item in player.CurrentArea.ListItems)
            {
                if (player.Picture.Bounds.IntersectsWith(item.Picture.Bounds))
                {
                    if (item is Hazard)
                    {
                        item.TouchItem(ref player);
                        labelPlayer.Text = player.DisplayData();

                        wmplayerPlayerHit.settings.volume = 80;
                        wmplayerPlayerHit.URL = Application.StartupPath + @"\sound\playerHit.mp3";
                        wmplayerPlayerHit.controls.play();

                        return;
                    }
                    else
                    {
                        return;
                    }
                }   
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            //If button is pressed while game is running, it means that
            //User pressed a pause button.
            if (gameIsRunning)
            {
                pictureBoxButtonPlayPause.BackgroundImage = Properties.Resources.Button_Play;
                gameIsRunning = false;
                StopGame();
                pictureBoxPaused.Visible = true;
            }
            //User pressed the unpause button
            else
            {
                pictureBoxButtonPlayPause.BackgroundImage = Properties.Resources.Button_Pause;
                gameIsRunning = true;
                pictureBoxPaused.Visible = false;
                UnpauseGame();
            }
        }

        private void pictureBoxButtonPlayPause_Click(object sender, EventArgs e)
        {
            //If button is pressed while game is running, it means that
            //User pressed a pause button.
            if (gameIsRunning)
            {
                pictureBoxButtonPlayPause.BackgroundImage = Properties.Resources.Button_Play;
                gameIsRunning = false;
                pictureBoxPaused.Visible = true;
                pictureBoxPaused.BringToFront();
                StopGame();
            }
            //User pressed the unpause button
            else
            {
                pictureBoxButtonPlayPause.BackgroundImage = Properties.Resources.Button_Pause;
                gameIsRunning = true;
                pictureBoxPaused.Visible = false;
                UnpauseGame();
            }
        }




        //Timer for Game timer.
        private void timerGameTime_Tick(object sender, EventArgs e)
        {

            time.AddSecond(-1);
            labelTime.Text = time.Hour.ToString().PadLeft(2, '0') + ":" +
               time.Minute.ToString().PadLeft(2, '0') + ":" + time.Second.ToString().PadLeft(2, '0');
            if (time.Hour == 0 && time.Minute == 0 && time.Second == 0)
            {
                timerGameTime.Stop();

                messageShowing = true;
                StopGame();

                wmplayerBacksound.controls.stop();
                wmplayerBoss.controls.stop();
                wmplayerLose.settings.volume = 20;
                wmplayerLose.URL = Application.StartupPath + @"\sound\loseMusic.mp3";
                wmplayerLose.controls.play();

                FormLose formLose = new FormLose();
                formLose.ShowDialog();
                if (formLose.YesNo == true)
                {
                    ReplayGame();
                }
                else
                {
                    this.Close();
                }
            }
        }

        //Ticker that has interval of 50ms. This is an event ticker to detect any events.
        private void timerGameTick_Tick(object sender, EventArgs e)
        {
            if (player.ListInventory.Count >= totalKeyItems)
            {
                if (letterSpawned == false)
                {
                    if (player.CurrentArea.AreaNum == 6)
                    {
                        listOfArea[0].AddItem(bossLetter);
                        letterSpawned = true;
                    }
                    else
                    {
                        player.CurrentArea.AddItem(bossLetter);
                        player.CurrentArea.DisplayArea(this);
                        player.CurrentArea.ShowAllItem();
                        letterSpawned = true;
                    }
                    
                }
                if (treasureSpawned == false && boss.Health <= 0)
                {
                    player.CurrentArea.AddItem(treasureBox);
                    player.CurrentArea.DisplayArea(this);
                    player.CurrentArea.ShowAllItem();
                    treasureSpawned = true;

                    foreach (Items hazard in player.CurrentArea.ListItems)
                    {
                        if (hazard is Hazard)
                        {
                            hazard.Picture.SendToBack();
                        } 
                    }
                }
                foreach (Items item in player.CurrentArea.ListItems)
                {
                    if ((string)item.Picture.Tag == "magic_barrier")
                    {
                        item.Picture.Visible = false;
                        player.CurrentArea.RemoveItem(item);
                        return;
                    }
                }
            }

            //To collect items.
            foreach (Items item in player.CurrentArea.ListItems)
            {
                //To detect if player is touching an item
                if (player.Picture.Bounds.IntersectsWith(item.Picture.Bounds))
                {
                    if (item is Hazard || item is Barrier)
                    {
                        return;
                    }
                    else if (item is Entrance)
                    {
                        Entrance entrance = (Entrance)item;
                        Area fromArea = player.CurrentArea;
                        Area toArea = listOfArea[entrance.TargetAreaNum - 1];
                        OpenArea(fromArea, toArea);
                        player.Picture.Location = entrance.PlayerSpawnPoint;
                        ghostPlayer.Picture.Location = player.Picture.Location;
                    }
                    else
                    {
                        item.TouchItem(ref player);
                        if (item is TreasureItem)
                        {
                            wmplayerItemFound.settings.volume = 20;
                            wmplayerItemFound.URL = Application.StartupPath + @"\sound\itemFound.mp3";
                            wmplayerItemFound.controls.play();
                        }
                        else if (item is ObstacleItem)
                        {
                            wmplayerPlayerHit.settings.volume = 80;
                            wmplayerPlayerHit.URL = Application.StartupPath + @"\sound\playerHit.mp3";
                            wmplayerPlayerHit.controls.play();
                        }
                        
                    }
                    
                    if (item is TreasureItem)
                    {
                        foreach (PictureBox pictureBox in panelInventory.Controls)
                        {
                            //Potentially Temporary as the tag on the pictureBoxes
                            //need to be set manually.
                            if (item.Picture.Tag == pictureBox.Tag)
                            {
                                pictureBox.BorderStyle = BorderStyle.Fixed3D;
                            }
                        }
                    }

                    if (item == bossLetter && player.ListInventory.Count >= totalKeyItems)
                    {
                        messageShowing = true;
                        StopGame();

                        FormLetter formLetter = new FormLetter();
                        formLetter.ShowDialog();

                        if (formLetter.YesNo == true)
                        {
                            UnpauseGame();
                            messageShowing = false;
                        }
                        else
                        {
                            wmplayerBacksound.controls.stop();
                            wmplayerBoss.controls.stop();
                            wmplayerLose.settings.volume = 20;
                            wmplayerLose.URL = Application.StartupPath + @"\sound\loseMusic.mp3";
                            wmplayerLose.controls.play();

                            FormLose formLose = new FormLose();
                            formLose.ShowDialog();
                            if (formLose.YesNo == true)
                            {
                                ReplayGame();
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                    }

                    if (item == treasureBox &&
                    player.ListInventory.Count >= totalKeyItems && boss.Health <= 0)
                    {
                        messageShowing = true;
                        StopGame();
                        foreach (Projectile projectile in listShotBossProjectiles.ToList())
                        {
                            listShotBossProjectiles.Remove(projectile);
                            projectile.Picture.Dispose();
                        }
                        foreach (Projectile projectile2 in listShotBossProjectiles2.ToList())
                        {
                            listShotBossProjectiles2.Remove(projectile2);
                            projectile2.Picture.Dispose();
                        }
                        foreach (Weapons weapon in listSpawnedWeapons.ToList())
                        {
                            listSpawnedWeapons.Remove(weapon);
                            weapon.Picture.Dispose();
                        }

                        wmplayerBacksound.controls.stop();
                        wmplayerBoss.controls.stop();
                        wmplayerWin.settings.volume = 20;
                        wmplayerWin.URL = Application.StartupPath + @"\sound\winMusic.mp3";
                        wmplayerWin.controls.play();

                        FormWin formWin = new FormWin();
                        formWin.ShowDialog();


                        if (formWin.YesNo == true)
                        {
                            ReplayGame();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    return;
                }
            }
            labelPlayer.Text = player.DisplayData();
            if (messageShowing == false && player.Life <= 0)
            {
                messageShowing = true;
                StopGame();

                wmplayerBacksound.controls.stop();
                wmplayerBoss.controls.stop();
                wmplayerLose.settings.volume = 20;
                wmplayerLose.URL = Application.StartupPath + @"\sound\loseMusic.mp3";
                wmplayerLose.controls.play();

                FormLose formLose = new FormLose();
                formLose.ShowDialog();
                if (formLose.YesNo == true)
                {
                    ReplayGame();
                }
                else
                {
                    this.Close();
                }
            }
        }

        //Timer for player movement, moves player if key is down every 20ms (interval is 20ms)
        private void timerMovement_Tick(object sender, EventArgs e)
        {
            bool intersectWithBarrier = false;

            if (player.MovingRight == true)
            {
                if (player.Picture.Location.X + player.Picture.Width <= rightMargin)
                {
                    ghostPlayer.MoveRight(player.Speed);
                }
            }
            if (player.MovingLeft == true)
            {
                if (player.Picture.Location.X >= leftMargin)
                {
                    ghostPlayer.MoveLeft(player.Speed);
                }
            }
            if (player.MovingUp == true)
            {
                if (player.Picture.Location.Y >= topMargin)
                {
                    ghostPlayer.MoveUp(player.Speed);
                }
            }
            if (player.MovingDown == true)
            {
                if (player.Picture.Location.Y + player.Picture.Height <= bottomMargin)
                {
                    ghostPlayer.MoveDown(player.Speed);

                }
            }

            foreach (Items item in player.CurrentArea.ListItems)
            {
                //if (item is Barrier)
                //{
                //    if (ghostPlayer.Picture.Bounds.IntersectsWith(item.Picture.Bounds))
                //    {
                //        intersectWithBarrier = true;
                //    }
                //    else
                //    {
                //        intersectWithBarrier = false;
                //    }
                //}
                //else
                //{
                //    intersectWithBarrier = false;
                //}

                if (ghostPlayer.Picture.Bounds.IntersectsWith(item.Picture.Bounds))
                {
                    if (item is Barrier)
                    {
                        intersectWithBarrier = true;
                        break;
                    }
                    else
                    {
                        intersectWithBarrier = false;
                    }
                }
                else
                {
                    intersectWithBarrier = false;
                }
            }

            if (intersectWithBarrier == false)
            {
                if (player.MovingRight == true)
                {
                    if (player.Picture.Location.X + player.Picture.Width <= rightMargin)
                    {
                        player.Picture.Location = ghostPlayer.Picture.Location;
                        player.Picture.Image = Properties.Resources.MC_Right;
                    }
                    else
                    {
                        if (player.CurrentArea.AreaNum < maxArea)
                        {
                            Area fromArea = player.CurrentArea;
                            Area toArea = listOfArea[player.CurrentArea.AreaNum];
                            OpenArea(fromArea, toArea);
                            player.Picture.Location = new Point(20, 400);
                            ghostPlayer.Picture.Location = player.Picture.Location;
                        }
                    }
                }
                if (player.MovingLeft == true)
                {
                    if (player.Picture.Location.X >= leftMargin)
                    {
                        player.Picture.Location = ghostPlayer.Picture.Location;
                        player.Picture.Image = Properties.Resources.MC_Left;
                    }
                    else
                    {
                        if (player.CurrentArea.AreaNum > 1 && player.CurrentArea.AreaNum != 4)
                        {
                            Area fromArea = player.CurrentArea;
                            Area toArea = listOfArea[player.CurrentArea.AreaNum - 2];
                            OpenArea(fromArea, toArea);
                            player.Picture.Location = new Point(this.Width - player.Picture.Width - 20,
                                400);
                            ghostPlayer.Picture.Location = player.Picture.Location;
                        }
                    }
                }
                if (player.MovingUp == true)
                {
                    if (player.Picture.Location.Y >= topMargin)
                    {
                        player.Picture.Location = ghostPlayer.Picture.Location;
                    }
                    player.Picture.Image = Properties.Resources.MC_Back;
                }
                if (player.MovingDown == true)
                {
                    if (player.Picture.Location.Y + player.Picture.Height <= bottomMargin)
                    {
                        player.Picture.Location = ghostPlayer.Picture.Location;

                    }
                    player.Picture.Image = Properties.Resources.MC_Front;
                }
                player.DisplayPicture(this);

                //To disable the ghost from going further than the mc at certain points/time
                ghostPlayer.Picture.Location = player.Picture.Location;

            }
            else
            {
                ghostPlayer.Picture.Location = player.Picture.Location;
            }


        }

        private void IntroVideo_PlaystateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayerIntro.playState == WMPPlayState.wmppsStopped)
            {
                axWindowsMediaPlayerIntro.Visible = false;
                buttonNotes.Location = new Point(12, 680);
            }
        }

        private void pictureBoxMenu_Click(object sender, EventArgs e)
        {
            StopGame();
            FormMenuBox formMenuBox = new FormMenuBox();
            formMenuBox.ShowDialog();
            if (formMenuBox.YesNo == true)
            {
                ShowMenu();
            }
            else
            {
                UnpauseGame();
            }
        }

        private void timerObstacleMove_Tick(object sender, EventArgs e)
        {
            int speed = 15;


            foreach (Projectile projectile in listShotBossProjectiles.ToList())
            {
                if (player.Picture.Bounds.IntersectsWith(projectile.Picture.Bounds))
                {
                    projectile.TouchItem(ref player);
                    listShotBossProjectiles.Remove(projectile);
                    projectile.Picture.Dispose();

                    wmplayerPlayerHit.settings.volume = 80;
                    wmplayerPlayerHit.URL = Application.StartupPath + @"\sound\playerHit.mp3";
                    wmplayerPlayerHit.controls.play();
                }

                if (projectile.ReachDestination == true)
                {
                    listShotBossProjectiles.Remove(projectile);
                    projectile.Picture.Dispose();
                }
            }
            foreach (Projectile projectile2 in listShotBossProjectiles2.ToList())
            {
                if (player.Picture.Bounds.IntersectsWith(projectile2.Picture.Bounds))
                {
                    projectile2.TouchItem(ref player);
                    listShotBossProjectiles2.Remove(projectile2);
                    projectile2.Picture.Dispose();

                    wmplayerPlayerHit.settings.volume = 80;
                    wmplayerPlayerHit.URL = Application.StartupPath + @"\sound\playerHit.mp3";
                    wmplayerPlayerHit.controls.play();
                }

                if (projectile2.ReachDestination == true)
                {
                    listShotBossProjectiles2.Remove(projectile2);
                    projectile2.Picture.Dispose();
                }
            }

            if (player.CurrentArea.AreaNum == 3)
            {
                foreach (Enemy enemy in player.CurrentArea.ListEnemy)
                {
                    if (enemy.Tag == "witch")
                    {
                        if (currentProjectile == null)
                        {
                            currentProjectile = new Projectile(enemy.ListProjectiles[0]);
                            listOfShotProjectiles.Add(currentProjectile);
                        }
                        enemy.ShootProjectile(currentProjectile, 400, speed, 90, this);
                        if (currentProjectile.ReachDestination == true)
                        {
                            listOfShotProjectiles.Remove(currentProjectile);
                            currentProjectile.Picture.Dispose();
                            currentProjectile = null;
                        }
                    }
                }
            }
            if (player.CurrentArea.AreaNum == 4)
            {
                foreach (Projectile projectile in listShotBossProjectiles)
                {
                    if (boss.Phase == 1)
                    {
                        //Scramble Fire
                        if (projectile.ReachDestination == false)
                        {
                            boss.ShootProjectile(projectile, 900, 20, projectile.ShootingAngle, this);
                        }
                    }
                    else if (boss.Phase == 2)
                    {
                        //CornerSource Fireball
                        if (projectile.ReachDestination == false)
                        {
                            projectile.ShootProjectile(projectile, new Point(1016, 60), 60, 1000, 20,
                                projectile.ShootingAngle, this);
                        }
                    }

                    else if (boss.Phase == 3)
                    {
                        //CornerSource Fireball
                        if (projectile.ReachDestination == false)
                        {
                            projectile.ShootProjectile(projectile, new Point(1016, 60), 60, 1000, 20,
                                projectile.ShootingAngle, this);
                        }
                    }
                }
                foreach (Projectile projectile2 in listShotBossProjectiles2)
                {

                    //Rain of Fire
                    if (boss.Phase == 2)
                    {
                        Point projectileSpawnPoint = new Point(random.Next(120, 730), 30);
                        if (projectile2.ReachDestination == false)
                        {
                            projectile2.ShootProjectile(projectile2, projectileSpawnPoint, 20, 1000, 20,
                                projectile2.ShootingAngle, this);
                        }
                    }

                    //BlueFire Cluster
                    else if (boss.Phase == 3)
                    {
                        if (projectile2.ReachDestination == false)
                        {
                            boss.ShootProjectile(projectile2, 900, 20, projectile2.ShootingAngle, this);
                        }
                    }
                }
            }

            if (currentProjectile != null)
            {
                if (player.Picture.Bounds.IntersectsWith(currentProjectile.Picture.Bounds))
                {
                    currentProjectile.Picture.Location = currentProjectile.OriginalLocation;
                    currentProjectile.TouchItem(ref player);
                    listOfShotProjectiles.Remove(currentProjectile);
                    currentProjectile = null;

                    wmplayerPlayerHit.settings.volume = 80;
                    wmplayerPlayerHit.URL = Application.StartupPath + @"\sound\playerHit.mp3";
                    wmplayerPlayerHit.controls.play();
                }
            }

        }


        private void timerBossFight_Tick(object sender, EventArgs e)
        {
            bossTimeCounter += 0.1;
            lastActionCounter1 += 0.1;
            lastActionCounter2 += 0.1;
            lastActionCounter3 += 0.1;
            RunBossFight(boss);
        }

        private void timerBossEvents_Tick(object sender, EventArgs e)
        {
            foreach (Weapons weapon in listSpawnedWeapons.ToList())
            {
                if (weapon.HasSpawned == true)
                {
                    weapon.Picture.Location = weapon.SpawnPoint;
                    weapon.DisplayPicture(this);
                }
                if (player.Picture.Bounds.IntersectsWith(weapon.Picture.Bounds))
                {
                    weapon.TouchItem(ref boss, player);
                    weapon.HasSpawned = false;
                    listSpawnedWeapons.Remove(weapon);

                    wmplayerAttack.settings.volume = 50;
                    wmplayerAttack.URL = Application.StartupPath + @"\sound\playerAttack.mp3";
                    wmplayerAttack.controls.play();

                    double bossHealthFraction = ((double)boss.Health / boss.OriginalHealth);
                    pictureBoxBossHealthBar.Size = new Size((int)(originalBossHealthBarWidth * 
                        bossHealthFraction), originalBossHealthBarHeight);

                    //Phase 1 test
                    if (boss.Health <= boss.PhaseHealthLimit[0] && 
                        boss.Health > boss.PhaseHealthLimit[1] && boss.Phase != 1)
                    {
                        boss.Phase = 1;
                    }
                    else if (boss.Health <= boss.PhaseHealthLimit[1] && 
                        boss.Health > boss.PhaseHealthLimit[2] && boss.Phase != 2)
                    {
                        boss.Phase = 2;
                        bossTimeCounter = 0;
                        lastActionCounter1 = 0;
                        lastActionCounter2 = 0;
                        lastActionCounter3 = 0;

                        foreach (Projectile projectile in listShotBossProjectiles.ToList())
                        {
                            listShotBossProjectiles.Remove(projectile);
                            projectile.Picture.Dispose();
                        }
                        foreach (Projectile projectile2 in listShotBossProjectiles2.ToList())
                        {
                            listShotBossProjectiles2.Remove(projectile2);
                            projectile2.Picture.Dispose();
                        }
                    }
                    else if (boss.Health <= boss.PhaseHealthLimit[2] && boss.Phase != 3)
                    {
                        boss.Phase = 3;
                        bossTimeCounter = 0;
                        lastActionCounter1 = 0;
                        lastActionCounter2 = 0;
                        lastActionCounter3 = 0;

                        foreach (Projectile projectile in listShotBossProjectiles.ToList())
                        {
                            listShotBossProjectiles.Remove(projectile);
                            projectile.Picture.Dispose();
                        }
                        foreach (Projectile projectile2 in listShotBossProjectiles2.ToList())
                        {
                            listShotBossProjectiles2.Remove(projectile2);
                            projectile2.Picture.Dispose();
                        }
                    }
                    return;
                }
                
            }
            labelBossName.Text = boss.Name + " [Phase" + boss.Phase + "]";
        }

        private void buttonNotes_Click(object sender, EventArgs e)
        {
            FormNotes formNotes = new FormNotes();
            formNotes.ShowDialog();

            
        }

        private void buttonData_Click(object sender, EventArgs e)
        {
            FormData formData = new FormData();
            formData.ShowDialog();
        }
    }
}
