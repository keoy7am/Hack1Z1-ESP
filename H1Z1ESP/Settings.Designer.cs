namespace H1Z1ESP
{
    partial class Settings
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
            this.hideESPAiming = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.hideDead = new System.Windows.Forms.CheckBox();
            this.showPosition = new System.Windows.Forms.CheckBox();
            this.showCities = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mapTransparency = new System.Windows.Forms.TrackBar();
            this.mapLarge = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowRoot = new System.Windows.Forms.CheckBox();
            this.ShowCorpse = new System.Windows.Forms.CheckBox();
            this.showVehicles = new System.Windows.Forms.CheckBox();
            this.showAmmo = new System.Windows.Forms.CheckBox();
            this.showWeapons = new System.Windows.Forms.CheckBox();
            this.showItems = new System.Windows.Forms.CheckBox();
            this.snowAnimals = new System.Windows.Forms.CheckBox();
            this.showAggressive = new System.Windows.Forms.CheckBox();
            this.showContainers = new System.Windows.Forms.CheckBox();
            this.showPlayers = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.boxed3D = new System.Windows.Forms.CheckBox();
            this.boxedVehicles = new System.Windows.Forms.CheckBox();
            this.boxedItems = new System.Windows.Forms.CheckBox();
            this.boxedAnimals = new System.Windows.Forms.CheckBox();
            this.boxedAggressive = new System.Windows.Forms.CheckBox();
            this.boxedPlayers = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radarTransparency = new System.Windows.Forms.TrackBar();
            this.radarVehicles = new System.Windows.Forms.CheckBox();
            this.radarAnimals = new System.Windows.Forms.CheckBox();
            this.radarAggressive = new System.Windows.Forms.CheckBox();
            this.radarPlayers = new System.Windows.Forms.CheckBox();
            this.showRadar = new System.Windows.Forms.CheckBox();
            this.showEntityLists = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.RadarLine = new System.Windows.Forms.CheckBox();
            this.RadarMap = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.showHelmet = new System.Windows.Forms.CheckBox();
            this.showBackpack = new System.Windows.Forms.CheckBox();
            this.showFirstAid = new System.Windows.Forms.CheckBox();
            this.showShotgun = new System.Windows.Forms.CheckBox();
            this.showAR = new System.Windows.Forms.CheckBox();
            this.brMode = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.AimCS = new System.Windows.Forms.Label();
            this.AimCF = new System.Windows.Forms.Label();
            this.AimCText = new System.Windows.Forms.Label();
            this.AimC = new System.Windows.Forms.TrackBar();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapTransparency)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radarTransparency)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AimC)).BeginInit();
            this.SuspendLayout();
            // 
            // hideESPAiming
            // 
            this.hideESPAiming.AutoSize = true;
            this.hideESPAiming.Checked = true;
            this.hideESPAiming.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideESPAiming.Location = new System.Drawing.Point(12, 4);
            this.hideESPAiming.Name = "hideESPAiming";
            this.hideESPAiming.Size = new System.Drawing.Size(151, 16);
            this.hideESPAiming.TabIndex = 21;
            this.hideESPAiming.Text = "Hide All ESP when Aiming";
            this.hideESPAiming.UseVisualStyleBackColor = true;
            this.hideESPAiming.CheckedChanged += new System.EventHandler(this.hideESPAiming_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.hideDead);
            this.groupBox3.Controls.Add(this.showPosition);
            this.groupBox3.Controls.Add(this.showCities);
            this.groupBox3.Location = new System.Drawing.Point(376, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 95);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "一般其他";
            // 
            // hideDead
            // 
            this.hideDead.AutoSize = true;
            this.hideDead.Checked = true;
            this.hideDead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideDead.Location = new System.Drawing.Point(16, 64);
            this.hideDead.Name = "hideDead";
            this.hideDead.Size = new System.Drawing.Size(75, 16);
            this.hideDead.TabIndex = 12;
            this.hideDead.Text = "隱藏 死亡";
            this.hideDead.UseVisualStyleBackColor = true;
            this.hideDead.CheckedChanged += new System.EventHandler(this.hideDead_CheckedChanged);
            // 
            // showPosition
            // 
            this.showPosition.AutoSize = true;
            this.showPosition.Checked = true;
            this.showPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPosition.Location = new System.Drawing.Point(16, 21);
            this.showPosition.Name = "showPosition";
            this.showPosition.Size = new System.Drawing.Size(75, 16);
            this.showPosition.TabIndex = 11;
            this.showPosition.Text = "顯示 坐標";
            this.showPosition.UseVisualStyleBackColor = true;
            this.showPosition.CheckedChanged += new System.EventHandler(this.showPosition_CheckedChanged);
            // 
            // showCities
            // 
            this.showCities.AutoSize = true;
            this.showCities.Checked = true;
            this.showCities.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCities.Location = new System.Drawing.Point(16, 42);
            this.showCities.Name = "showCities";
            this.showCities.Size = new System.Drawing.Size(75, 16);
            this.showCities.TabIndex = 10;
            this.showCities.Text = "顯示 城市";
            this.showCities.UseVisualStyleBackColor = true;
            this.showCities.CheckedChanged += new System.EventHandler(this.showCities_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mapTransparency);
            this.groupBox2.Controls.Add(this.mapLarge);
            this.groupBox2.Location = new System.Drawing.Point(190, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 66);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Map";
            // 
            // mapTransparency
            // 
            this.mapTransparency.AutoSize = false;
            this.mapTransparency.Location = new System.Drawing.Point(6, 40);
            this.mapTransparency.Maximum = 255;
            this.mapTransparency.Name = "mapTransparency";
            this.mapTransparency.Size = new System.Drawing.Size(168, 21);
            this.mapTransparency.TabIndex = 1;
            this.mapTransparency.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mapTransparency.Value = 210;
            this.mapTransparency.Scroll += new System.EventHandler(this.mapTransparency_Scroll);
            // 
            // mapLarge
            // 
            this.mapLarge.AutoSize = true;
            this.mapLarge.Location = new System.Drawing.Point(16, 21);
            this.mapLarge.Name = "mapLarge";
            this.mapLarge.Size = new System.Drawing.Size(75, 16);
            this.mapLarge.TabIndex = 0;
            this.mapLarge.Text = "Large Map";
            this.mapLarge.UseVisualStyleBackColor = true;
            this.mapLarge.CheckedChanged += new System.EventHandler(this.mapLarge_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ShowRoot);
            this.groupBox1.Controls.Add(this.ShowCorpse);
            this.groupBox1.Controls.Add(this.showVehicles);
            this.groupBox1.Controls.Add(this.showAmmo);
            this.groupBox1.Controls.Add(this.showWeapons);
            this.groupBox1.Controls.Add(this.showItems);
            this.groupBox1.Controls.Add(this.snowAnimals);
            this.groupBox1.Controls.Add(this.showAggressive);
            this.groupBox1.Controls.Add(this.showContainers);
            this.groupBox1.Controls.Add(this.showPlayers);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 238);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ESP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "←Outdate";
            // 
            // ShowRoot
            // 
            this.ShowRoot.AutoSize = true;
            this.ShowRoot.Checked = true;
            this.ShowRoot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowRoot.Location = new System.Drawing.Point(13, 191);
            this.ShowRoot.Name = "ShowRoot";
            this.ShowRoot.Size = new System.Drawing.Size(76, 16);
            this.ShowRoot.TabIndex = 14;
            this.ShowRoot.Text = "Show Root";
            this.ShowRoot.UseVisualStyleBackColor = true;
            this.ShowRoot.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ShowCorpse
            // 
            this.ShowCorpse.AutoSize = true;
            this.ShowCorpse.Location = new System.Drawing.Point(13, 211);
            this.ShowCorpse.Name = "ShowCorpse";
            this.ShowCorpse.Size = new System.Drawing.Size(86, 16);
            this.ShowCorpse.TabIndex = 6;
            this.ShowCorpse.Text = "Show Corpse";
            this.ShowCorpse.UseVisualStyleBackColor = true;
            this.ShowCorpse.CheckedChanged += new System.EventHandler(this.ShowCorpse_CheckedChanged);
            // 
            // showVehicles
            // 
            this.showVehicles.AutoSize = true;
            this.showVehicles.Checked = true;
            this.showVehicles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showVehicles.Location = new System.Drawing.Point(13, 170);
            this.showVehicles.Name = "showVehicles";
            this.showVehicles.Size = new System.Drawing.Size(92, 16);
            this.showVehicles.TabIndex = 12;
            this.showVehicles.Text = "Show Vehicles";
            this.showVehicles.UseVisualStyleBackColor = true;
            this.showVehicles.CheckedChanged += new System.EventHandler(this.showVehicles_CheckedChanged);
            // 
            // showAmmo
            // 
            this.showAmmo.AutoSize = true;
            this.showAmmo.Checked = true;
            this.showAmmo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showAmmo.Location = new System.Drawing.Point(13, 130);
            this.showAmmo.Name = "showAmmo";
            this.showAmmo.Size = new System.Drawing.Size(85, 16);
            this.showAmmo.TabIndex = 11;
            this.showAmmo.Text = "Show Ammo";
            this.showAmmo.UseVisualStyleBackColor = true;
            this.showAmmo.CheckedChanged += new System.EventHandler(this.showAmmo_CheckedChanged);
            // 
            // showWeapons
            // 
            this.showWeapons.AutoSize = true;
            this.showWeapons.Checked = true;
            this.showWeapons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showWeapons.Location = new System.Drawing.Point(13, 109);
            this.showWeapons.Name = "showWeapons";
            this.showWeapons.Size = new System.Drawing.Size(96, 16);
            this.showWeapons.TabIndex = 10;
            this.showWeapons.Text = "Show Weapons";
            this.showWeapons.UseVisualStyleBackColor = true;
            this.showWeapons.CheckedChanged += new System.EventHandler(this.showWeapons_CheckedChanged);
            // 
            // showItems
            // 
            this.showItems.AutoSize = true;
            this.showItems.Checked = true;
            this.showItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showItems.Location = new System.Drawing.Point(13, 149);
            this.showItems.Name = "showItems";
            this.showItems.Size = new System.Drawing.Size(78, 16);
            this.showItems.TabIndex = 9;
            this.showItems.Text = "Show Items";
            this.showItems.UseVisualStyleBackColor = true;
            this.showItems.CheckedChanged += new System.EventHandler(this.showItems_CheckedChanged);
            // 
            // snowAnimals
            // 
            this.snowAnimals.AutoSize = true;
            this.snowAnimals.Location = new System.Drawing.Point(13, 66);
            this.snowAnimals.Name = "snowAnimals";
            this.snowAnimals.Size = new System.Drawing.Size(91, 16);
            this.snowAnimals.TabIndex = 8;
            this.snowAnimals.Text = "Show Animals";
            this.snowAnimals.UseVisualStyleBackColor = true;
            this.snowAnimals.CheckedChanged += new System.EventHandler(this.snowAnimals_CheckedChanged);
            // 
            // showAggressive
            // 
            this.showAggressive.AutoSize = true;
            this.showAggressive.Checked = true;
            this.showAggressive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showAggressive.Location = new System.Drawing.Point(13, 45);
            this.showAggressive.Name = "showAggressive";
            this.showAggressive.Size = new System.Drawing.Size(104, 16);
            this.showAggressive.TabIndex = 6;
            this.showAggressive.Text = "Show Aggressive";
            this.showAggressive.UseVisualStyleBackColor = true;
            this.showAggressive.CheckedChanged += new System.EventHandler(this.showAggressive_CheckedChanged);
            // 
            // showContainers
            // 
            this.showContainers.AutoSize = true;
            this.showContainers.Location = new System.Drawing.Point(13, 88);
            this.showContainers.Name = "showContainers";
            this.showContainers.Size = new System.Drawing.Size(103, 16);
            this.showContainers.TabIndex = 5;
            this.showContainers.Text = "Show Containers";
            this.showContainers.UseVisualStyleBackColor = true;
            this.showContainers.CheckedChanged += new System.EventHandler(this.showContainers_CheckedChanged);
            // 
            // showPlayers
            // 
            this.showPlayers.AutoSize = true;
            this.showPlayers.Checked = true;
            this.showPlayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPlayers.Location = new System.Drawing.Point(13, 24);
            this.showPlayers.Name = "showPlayers";
            this.showPlayers.Size = new System.Drawing.Size(86, 16);
            this.showPlayers.TabIndex = 4;
            this.showPlayers.Text = "Show Players";
            this.showPlayers.UseVisualStyleBackColor = true;
            this.showPlayers.CheckedChanged += new System.EventHandler(this.showPlayers_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.boxed3D);
            this.groupBox4.Controls.Add(this.boxedVehicles);
            this.groupBox4.Controls.Add(this.boxedItems);
            this.groupBox4.Controls.Add(this.boxedAnimals);
            this.groupBox4.Controls.Add(this.boxedAggressive);
            this.groupBox4.Controls.Add(this.boxedPlayers);
            this.groupBox4.Location = new System.Drawing.Point(190, 25);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(180, 158);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Boxes";
            // 
            // boxed3D
            // 
            this.boxed3D.AutoSize = true;
            this.boxed3D.Checked = true;
            this.boxed3D.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxed3D.Location = new System.Drawing.Point(17, 135);
            this.boxed3D.Name = "boxed3D";
            this.boxed3D.Size = new System.Drawing.Size(61, 16);
            this.boxed3D.TabIndex = 5;
            this.boxed3D.Text = "3D Box";
            this.boxed3D.UseVisualStyleBackColor = true;
            this.boxed3D.CheckedChanged += new System.EventHandler(this.boxed3D_CheckedChanged);
            // 
            // boxedVehicles
            // 
            this.boxedVehicles.AutoSize = true;
            this.boxedVehicles.Checked = true;
            this.boxedVehicles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxedVehicles.Location = new System.Drawing.Point(17, 112);
            this.boxedVehicles.Name = "boxedVehicles";
            this.boxedVehicles.Size = new System.Drawing.Size(91, 16);
            this.boxedVehicles.TabIndex = 4;
            this.boxedVehicles.Text = "Vehicle Boxes";
            this.boxedVehicles.UseVisualStyleBackColor = true;
            this.boxedVehicles.CheckedChanged += new System.EventHandler(this.boxedVehicles_CheckedChanged);
            // 
            // boxedItems
            // 
            this.boxedItems.AutoSize = true;
            this.boxedItems.Checked = true;
            this.boxedItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxedItems.Location = new System.Drawing.Point(17, 89);
            this.boxedItems.Name = "boxedItems";
            this.boxedItems.Size = new System.Drawing.Size(77, 16);
            this.boxedItems.TabIndex = 3;
            this.boxedItems.Text = "Item Boxes";
            this.boxedItems.UseVisualStyleBackColor = true;
            this.boxedItems.CheckedChanged += new System.EventHandler(this.boxedItems_CheckedChanged);
            // 
            // boxedAnimals
            // 
            this.boxedAnimals.AutoSize = true;
            this.boxedAnimals.Checked = true;
            this.boxedAnimals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxedAnimals.Location = new System.Drawing.Point(17, 66);
            this.boxedAnimals.Name = "boxedAnimals";
            this.boxedAnimals.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.boxedAnimals.Size = new System.Drawing.Size(90, 16);
            this.boxedAnimals.TabIndex = 2;
            this.boxedAnimals.Text = "Animal Boxes";
            this.boxedAnimals.UseVisualStyleBackColor = true;
            this.boxedAnimals.CheckedChanged += new System.EventHandler(this.boxedAnimals_CheckedChanged);
            // 
            // boxedAggressive
            // 
            this.boxedAggressive.AutoSize = true;
            this.boxedAggressive.Checked = true;
            this.boxedAggressive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxedAggressive.Location = new System.Drawing.Point(17, 43);
            this.boxedAggressive.Name = "boxedAggressive";
            this.boxedAggressive.Size = new System.Drawing.Size(107, 16);
            this.boxedAggressive.TabIndex = 1;
            this.boxedAggressive.Text = "Aggressive Boxes";
            this.boxedAggressive.UseVisualStyleBackColor = true;
            this.boxedAggressive.CheckedChanged += new System.EventHandler(this.boxedAggressive_CheckedChanged);
            // 
            // boxedPlayers
            // 
            this.boxedPlayers.AutoSize = true;
            this.boxedPlayers.Checked = true;
            this.boxedPlayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxedPlayers.Location = new System.Drawing.Point(17, 21);
            this.boxedPlayers.Name = "boxedPlayers";
            this.boxedPlayers.Size = new System.Drawing.Size(85, 16);
            this.boxedPlayers.TabIndex = 0;
            this.boxedPlayers.Text = "Player Boxes";
            this.boxedPlayers.UseVisualStyleBackColor = true;
            this.boxedPlayers.CheckedChanged += new System.EventHandler(this.boxedPlayers_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radarTransparency);
            this.groupBox5.Controls.Add(this.radarVehicles);
            this.groupBox5.Controls.Add(this.radarAnimals);
            this.groupBox5.Controls.Add(this.radarAggressive);
            this.groupBox5.Controls.Add(this.radarPlayers);
            this.groupBox5.Controls.Add(this.showRadar);
            this.groupBox5.Location = new System.Drawing.Point(190, 190);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(180, 171);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Radar";
            // 
            // radarTransparency
            // 
            this.radarTransparency.AutoSize = false;
            this.radarTransparency.Location = new System.Drawing.Point(6, 52);
            this.radarTransparency.Maximum = 255;
            this.radarTransparency.Name = "radarTransparency";
            this.radarTransparency.Size = new System.Drawing.Size(168, 21);
            this.radarTransparency.TabIndex = 6;
            this.radarTransparency.TickStyle = System.Windows.Forms.TickStyle.None;
            this.radarTransparency.Value = 210;
            this.radarTransparency.Scroll += new System.EventHandler(this.radarTransparency_Scroll);
            // 
            // radarVehicles
            // 
            this.radarVehicles.AutoSize = true;
            this.radarVehicles.Checked = true;
            this.radarVehicles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radarVehicles.Location = new System.Drawing.Point(16, 142);
            this.radarVehicles.Name = "radarVehicles";
            this.radarVehicles.Size = new System.Drawing.Size(63, 16);
            this.radarVehicles.TabIndex = 5;
            this.radarVehicles.Text = "Vehicles";
            this.radarVehicles.UseVisualStyleBackColor = true;
            this.radarVehicles.CheckedChanged += new System.EventHandler(this.radarVehicles_CheckedChanged);
            // 
            // radarAnimals
            // 
            this.radarAnimals.AutoSize = true;
            this.radarAnimals.Checked = true;
            this.radarAnimals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radarAnimals.Location = new System.Drawing.Point(16, 119);
            this.radarAnimals.Name = "radarAnimals";
            this.radarAnimals.Size = new System.Drawing.Size(62, 16);
            this.radarAnimals.TabIndex = 4;
            this.radarAnimals.Text = "Animals";
            this.radarAnimals.UseVisualStyleBackColor = true;
            this.radarAnimals.CheckedChanged += new System.EventHandler(this.radarAnimals_CheckedChanged);
            // 
            // radarAggressive
            // 
            this.radarAggressive.AutoSize = true;
            this.radarAggressive.Checked = true;
            this.radarAggressive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radarAggressive.Location = new System.Drawing.Point(16, 97);
            this.radarAggressive.Name = "radarAggressive";
            this.radarAggressive.Size = new System.Drawing.Size(75, 16);
            this.radarAggressive.TabIndex = 3;
            this.radarAggressive.Text = "Aggressive";
            this.radarAggressive.UseVisualStyleBackColor = true;
            this.radarAggressive.CheckedChanged += new System.EventHandler(this.radarAggressive_CheckedChanged);
            // 
            // radarPlayers
            // 
            this.radarPlayers.AutoSize = true;
            this.radarPlayers.Checked = true;
            this.radarPlayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radarPlayers.Location = new System.Drawing.Point(16, 74);
            this.radarPlayers.Name = "radarPlayers";
            this.radarPlayers.Size = new System.Drawing.Size(57, 16);
            this.radarPlayers.TabIndex = 2;
            this.radarPlayers.Text = "Players";
            this.radarPlayers.UseVisualStyleBackColor = true;
            this.radarPlayers.CheckedChanged += new System.EventHandler(this.radarPlayers_CheckedChanged);
            // 
            // showRadar
            // 
            this.showRadar.AutoSize = true;
            this.showRadar.Checked = true;
            this.showRadar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showRadar.Location = new System.Drawing.Point(16, 30);
            this.showRadar.Name = "showRadar";
            this.showRadar.Size = new System.Drawing.Size(81, 16);
            this.showRadar.TabIndex = 0;
            this.showRadar.Text = "Show Radar";
            this.showRadar.UseVisualStyleBackColor = true;
            this.showRadar.CheckedChanged += new System.EventHandler(this.showRadar_CheckedChanged);
            // 
            // showEntityLists
            // 
            this.showEntityLists.Checked = true;
            this.showEntityLists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showEntityLists.Location = new System.Drawing.Point(19, 18);
            this.showEntityLists.Name = "showEntityLists";
            this.showEntityLists.Size = new System.Drawing.Size(104, 24);
            this.showEntityLists.TabIndex = 0;
            this.showEntityLists.Text = "ShowEntityLists";
            this.showEntityLists.CheckedChanged += new System.EventHandler(this.showEntityLists_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.RadarLine);
            this.groupBox6.Controls.Add(this.RadarMap);
            this.groupBox6.Controls.Add(this.showEntityLists);
            this.groupBox6.Location = new System.Drawing.Point(376, 123);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(180, 74);
            this.groupBox6.TabIndex = 24;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "特殊其他";
            // 
            // RadarLine
            // 
            this.RadarLine.AutoSize = true;
            this.RadarLine.Location = new System.Drawing.Point(103, 47);
            this.RadarLine.Name = "RadarLine";
            this.RadarLine.Size = new System.Drawing.Size(45, 16);
            this.RadarLine.TabIndex = 2;
            this.RadarLine.Text = "Line";
            this.RadarLine.UseVisualStyleBackColor = true;
            this.RadarLine.CheckedChanged += new System.EventHandler(this.RadarLine_CheckedChanged);
            // 
            // RadarMap
            // 
            this.RadarMap.AutoSize = true;
            this.RadarMap.Location = new System.Drawing.Point(19, 47);
            this.RadarMap.Name = "RadarMap";
            this.RadarMap.Size = new System.Drawing.Size(67, 16);
            this.RadarMap.TabIndex = 1;
            this.RadarMap.Text = "MiniMap";
            this.RadarMap.UseVisualStyleBackColor = true;
            this.RadarMap.CheckedChanged += new System.EventHandler(this.RadarMap_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.showHelmet);
            this.groupBox7.Controls.Add(this.showBackpack);
            this.groupBox7.Controls.Add(this.showFirstAid);
            this.groupBox7.Controls.Add(this.showShotgun);
            this.groupBox7.Controls.Add(this.showAR);
            this.groupBox7.Controls.Add(this.brMode);
            this.groupBox7.Location = new System.Drawing.Point(12, 267);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(172, 166);
            this.groupBox7.TabIndex = 25;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "BR";
            // 
            // showHelmet
            // 
            this.showHelmet.AutoSize = true;
            this.showHelmet.Location = new System.Drawing.Point(11, 139);
            this.showHelmet.Name = "showHelmet";
            this.showHelmet.Size = new System.Drawing.Size(129, 16);
            this.showHelmet.TabIndex = 5;
            this.showHelmet.Text = "Show Helmet、Armor";
            this.showHelmet.UseVisualStyleBackColor = true;
            this.showHelmet.CheckedChanged += new System.EventHandler(this.showHelmet_CheckedChanged);
            // 
            // showBackpack
            // 
            this.showBackpack.AutoSize = true;
            this.showBackpack.Location = new System.Drawing.Point(12, 117);
            this.showBackpack.Name = "showBackpack";
            this.showBackpack.Size = new System.Drawing.Size(99, 16);
            this.showBackpack.TabIndex = 4;
            this.showBackpack.Text = "Show Backpack";
            this.showBackpack.UseVisualStyleBackColor = true;
            this.showBackpack.CheckedChanged += new System.EventHandler(this.showBackpack_CheckedChanged);
            // 
            // showFirstAid
            // 
            this.showFirstAid.AutoSize = true;
            this.showFirstAid.Location = new System.Drawing.Point(12, 94);
            this.showFirstAid.Name = "showFirstAid";
            this.showFirstAid.Size = new System.Drawing.Size(110, 16);
            this.showFirstAid.TabIndex = 3;
            this.showFirstAid.Text = "Show First Aid Kit";
            this.showFirstAid.UseVisualStyleBackColor = true;
            this.showFirstAid.CheckedChanged += new System.EventHandler(this.showFirstAid_CheckedChanged);
            // 
            // showShotgun
            // 
            this.showShotgun.AutoSize = true;
            this.showShotgun.Location = new System.Drawing.Point(12, 71);
            this.showShotgun.Name = "showShotgun";
            this.showShotgun.Size = new System.Drawing.Size(92, 16);
            this.showShotgun.TabIndex = 2;
            this.showShotgun.Text = "Show Shotgun";
            this.showShotgun.UseVisualStyleBackColor = true;
            this.showShotgun.CheckedChanged += new System.EventHandler(this.showShotgun_CheckedChanged);
            // 
            // showAR
            // 
            this.showAR.AutoSize = true;
            this.showAR.Location = new System.Drawing.Point(12, 48);
            this.showAR.Name = "showAR";
            this.showAR.Size = new System.Drawing.Size(69, 16);
            this.showAR.TabIndex = 1;
            this.showAR.Text = "Show AR";
            this.showAR.UseVisualStyleBackColor = true;
            this.showAR.CheckedChanged += new System.EventHandler(this.showAR_CheckedChanged);
            // 
            // brMode
            // 
            this.brMode.AutoSize = true;
            this.brMode.Location = new System.Drawing.Point(12, 25);
            this.brMode.Name = "brMode";
            this.brMode.Size = new System.Drawing.Size(70, 16);
            this.brMode.TabIndex = 0;
            this.brMode.Text = "BR Mode";
            this.brMode.UseVisualStyleBackColor = true;
            this.brMode.CheckedChanged += new System.EventHandler(this.brMode_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(401, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "但使用本程式有被鎖風險";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(401, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "// Hack1Z1 免責聲明 //";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(401, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "本程式不負任何責任.";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(376, 341);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(180, 90);
            this.richTextBox1.TabIndex = 29;
            this.richTextBox1.Text = "Hack1Z1 Ver 0516\nCredits : \n@facelessleader \n(Open source code)\n@unknowncheats H1" +
    "Z1 Member\n(Discuss and Reversal)\n@GetChu\n";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.AimCS);
            this.groupBox8.Controls.Add(this.AimCF);
            this.groupBox8.Controls.Add(this.AimCText);
            this.groupBox8.Controls.Add(this.AimC);
            this.groupBox8.Location = new System.Drawing.Point(376, 202);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(180, 78);
            this.groupBox8.TabIndex = 30;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "AimControl";
            // 
            // AimCS
            // 
            this.AimCS.AutoSize = true;
            this.AimCS.BackColor = System.Drawing.SystemColors.Control;
            this.AimCS.Cursor = System.Windows.Forms.Cursors.Default;
            this.AimCS.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AimCS.Location = new System.Drawing.Point(157, 43);
            this.AimCS.Name = "AimCS";
            this.AimCS.Size = new System.Drawing.Size(14, 15);
            this.AimCS.TabIndex = 3;
            this.AimCS.Text = "S";
            // 
            // AimCF
            // 
            this.AimCF.AutoSize = true;
            this.AimCF.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AimCF.Location = new System.Drawing.Point(9, 43);
            this.AimCF.Name = "AimCF";
            this.AimCF.Size = new System.Drawing.Size(14, 15);
            this.AimCF.TabIndex = 2;
            this.AimCF.Text = "F";
            // 
            // AimCText
            // 
            this.AimCText.AutoSize = true;
            this.AimCText.Location = new System.Drawing.Point(25, 24);
            this.AimCText.Name = "AimCText";
            this.AimCText.Size = new System.Drawing.Size(57, 12);
            this.AimCText.TabIndex = 1;
            this.AimCText.Text = "Default：2";
            // 
            // AimC
            // 
            this.AimC.AutoSize = false;
            this.AimC.Location = new System.Drawing.Point(19, 40);
            this.AimC.Maximum = 9;
            this.AimC.Minimum = 1;
            this.AimC.Name = "AimC";
            this.AimC.Size = new System.Drawing.Size(144, 32);
            this.AimC.TabIndex = 0;
            this.AimC.Value = 2;
            this.AimC.Scroll += new System.EventHandler(this.AimC_Scroll);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 434);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.hideESPAiming);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.Opacity = 0.8D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Hack1Z1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapTransparency)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radarTransparency)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AimC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox hideESPAiming;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox hideDead;
        private System.Windows.Forms.CheckBox showPosition;
        private System.Windows.Forms.CheckBox showCities;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar mapTransparency;
        private System.Windows.Forms.CheckBox mapLarge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox showAmmo;
        private System.Windows.Forms.CheckBox showWeapons;
        private System.Windows.Forms.CheckBox showItems;
        private System.Windows.Forms.CheckBox snowAnimals;
        private System.Windows.Forms.CheckBox showAggressive;
        private System.Windows.Forms.CheckBox showContainers;
        private System.Windows.Forms.CheckBox showPlayers;
        private System.Windows.Forms.CheckBox showVehicles;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox boxedPlayers;
        private System.Windows.Forms.CheckBox boxedAggressive;
        private System.Windows.Forms.CheckBox boxedAnimals;
        private System.Windows.Forms.CheckBox boxedItems;
        private System.Windows.Forms.CheckBox boxedVehicles;
        private System.Windows.Forms.CheckBox boxed3D;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox showRadar;
        private System.Windows.Forms.CheckBox radarPlayers;
        private System.Windows.Forms.CheckBox radarAggressive;
        private System.Windows.Forms.CheckBox radarAnimals;
        private System.Windows.Forms.CheckBox showEntityLists;
        private System.Windows.Forms.CheckBox radarVehicles;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TrackBar radarTransparency;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox brMode;
        private System.Windows.Forms.CheckBox showHelmet;
        private System.Windows.Forms.CheckBox showBackpack;
        private System.Windows.Forms.CheckBox showFirstAid;
        private System.Windows.Forms.CheckBox showShotgun;
        private System.Windows.Forms.CheckBox showAR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox RadarMap;
        private System.Windows.Forms.CheckBox RadarLine;
        private System.Windows.Forms.CheckBox ShowCorpse;
        private System.Windows.Forms.CheckBox ShowRoot;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label AimCS;
        private System.Windows.Forms.Label AimCF;
        private System.Windows.Forms.Label AimCText;
        private System.Windows.Forms.TrackBar AimC;
        private System.Windows.Forms.Label label1;

    }
}