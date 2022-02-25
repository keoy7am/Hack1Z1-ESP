using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace H1Z1ESP
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.showPlayers.Checked = Main.ShowPlayers;
            this.showAggressive.Checked = Main.ShowAggressive;
            this.snowAnimals.Checked = Main.ShowAnimals;
            this.showContainers.Checked = Main.ShowContainers;
            this.showWeapons.Checked = Main.ShowWeapons;
            this.showAmmo.Checked = Main.ShowAmmo;
            this.showItems.Checked = Main.ShowItems;
            this.showVehicles.Checked = Main.ShowVehicles;
            this.ShowRoot.Checked = Main.ShowRoot;
            this.ShowCorpse.Checked = Main.ShowCorpse;

            this.hideESPAiming.Checked = Main.HideESPWhenAiming;
            // Misc
            this.showEntityLists.Checked = Main.ShowEntityLists;
            this.RadarMap.Checked = Main.RadarMap;
            this.RadarLine.Checked = Main.RadarLine;
            this.AimC.Value = Main.AimC;


            this.boxedPlayers.Checked = Main.BoxedPlayers;
            this.boxedAggressive.Checked = Main.BoxedAggressive;
            this.boxedAnimals.Checked = Main.BoxedAnimals;
            this.boxedItems.Checked = Main.BoxedItems;
            this.boxedVehicles.Checked = Main.BoxedVehicles;
            this.boxed3D.Checked = Main.Boxed3D;

            this.showPosition.Checked = Main.ShowPosition;
            this.showCities.Checked = Main.ShowCities;
            this.hideDead.Checked = Main.HideDead;

            this.mapLarge.Checked = Main.ShowMapLarge;
            this.mapTransparency.Value = Main.MapTransparency;
            this.showRadar.Checked = Main.ShowRadar;
            this.radarTransparency.Value = Main.RadarTransparency;

            this.radarPlayers.Checked = Main.RadarPlayers;
            this.radarAggressive.Checked = Main.RadarAggressive;
            this.radarAnimals.Checked = Main.RadarAnimals;
            this.radarVehicles.Checked = Main.RadarVehicles;

            this.brMode.Checked = Main.BRMode;
            this.showAR.Checked = Main.ShowAR;
            this.showShotgun.Checked = Main.ShowShotgun;
            this.showFirstAid.Checked = Main.ShowFirstAid;
            this.showBackpack.Checked = Main.ShowBackpack;
            this.showHelmet.Checked = Main.ShowHelmet;
        }

        private void showPlayers_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowPlayers = this.showPlayers.Checked;
            Main.Ini.IniWriteValue("ESP", "ShowPlayers", Main.ShowPlayers.ToString());
        }

        private void showAggressive_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowAggressive = this.showAggressive.Checked;
            Main.Ini.IniWriteValue("ESP", "ShowAggressive", Main.ShowAggressive.ToString());
        }

        private void snowAnimals_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowAnimals = this.snowAnimals.Checked;
            Main.Ini.IniWriteValue("ESP", "ShowAnimals", Main.ShowAnimals.ToString());
        }

        private void showContainers_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowContainers = this.showContainers.Checked;
            Main.Ini.IniWriteValue("ESP", "ShowContainers", Main.ShowContainers.ToString());
        }

        private void showWeapons_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowWeapons = this.showWeapons.Checked;
            Main.Ini.IniWriteValue("ESP", "ShowWeapons", Main.ShowWeapons.ToString());
        }

        private void showAmmo_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowAmmo = this.showAmmo.Checked;
            Main.Ini.IniWriteValue("ESP", "ShowAmmo", Main.ShowAmmo.ToString());
        }

        private void showItems_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowItems = this.showItems.Checked;
            Main.Ini.IniWriteValue("ESP", "ShowItems", Main.ShowItems.ToString());
        }

        private void showVehicles_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowVehicles = this.showVehicles.Checked;
            Main.Ini.IniWriteValue("ESP", "ShowVehicles", Main.ShowVehicles.ToString());
        }

        private void showPosition_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowPosition = this.showPosition.Checked;
            Main.Ini.IniWriteValue("Misc", "ShowPosition", Main.ShowPosition.ToString());
        }

        private void showCities_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowCities = this.showCities.Checked;
            Main.Ini.IniWriteValue("Misc", "ShowCities", Main.ShowCities.ToString());
        }

        private void hideDead_CheckedChanged(object sender, EventArgs e)
        {
            Main.HideDead = this.hideDead.Checked;
            Main.Ini.IniWriteValue("Misc", "HideDead", Main.HideDead.ToString());
        }

        private void hideESPAiming_CheckedChanged(object sender, EventArgs e)
        {
            Main.HideESPWhenAiming = this.hideESPAiming.Checked;
            Main.Ini.IniWriteValue("Misc", "HideESPWhenAiming", Main.HideESPWhenAiming.ToString());
        }

        private void boxedPlayers_CheckedChanged(object sender, EventArgs e)
        {
            Main.BoxedPlayers = this.boxedPlayers.Checked;
            Main.Ini.IniWriteValue("Boxed", "Players", Main.BoxedPlayers.ToString());
        }

        private void boxedAggressive_CheckedChanged(object sender, EventArgs e)
        {
            Main.BoxedAggressive = this.boxedAggressive.Checked;
            Main.Ini.IniWriteValue("Boxed", "Aggressive", Main.BoxedAggressive.ToString());
        }

        private void boxedAnimals_CheckedChanged(object sender, EventArgs e)
        {
            Main.BoxedAnimals = this.boxedAnimals.Checked;
            Main.Ini.IniWriteValue("Boxed", "Animals", Main.BoxedAnimals.ToString());
        }

        private void boxedItems_CheckedChanged(object sender, EventArgs e)
        {
            Main.BoxedItems = this.boxedItems.Checked;
            Main.Ini.IniWriteValue("Boxed", "Items", Main.BoxedItems.ToString());
        }

        private void boxedVehicles_CheckedChanged(object sender, EventArgs e)
        {
            Main.BoxedVehicles = this.boxedVehicles.Checked;
            Main.Ini.IniWriteValue("Boxed", "Vehicles", Main.BoxedVehicles.ToString());
        }

        private void boxed3D_CheckedChanged(object sender, EventArgs e)
        {
            Main.Boxed3D = this.boxed3D.Checked;
            Main.Ini.IniWriteValue("Boxed", "3D", Main.Boxed3D.ToString());
        }

        private void mapLarge_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowMapLarge = this.mapLarge.Checked;
            Main.Ini.IniWriteValue("Map", "LargeMap", Main.ShowMapLarge.ToString());
        }

        private void mapTransparency_Scroll(object sender, EventArgs e)
        {
            Main.MapTransparency = this.mapTransparency.Value;
            Main.Ini.IniWriteValue("Map", "Transparency", Main.MapTransparency.ToString());
        }

        private void showRadar_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowRadar = this.showRadar.Checked;
            Main.Ini.IniWriteValue("Radar", "Show", Main.ShowRadar.ToString());
        }

        private void radarTransparency_Scroll(object sender, EventArgs e)
        {
            Main.RadarTransparency = this.radarTransparency.Value;
            Main.Ini.IniWriteValue("Radar", "Transparency", Main.RadarTransparency.ToString());

        }

        private void radarPlayers_CheckedChanged(object sender, EventArgs e)
        {
            Main.RadarPlayers = this.radarPlayers.Checked;
            Main.Ini.IniWriteValue("Radar", "Players", Main.RadarPlayers.ToString());
        }

        private void radarAggressive_CheckedChanged(object sender, EventArgs e)
        {
            Main.RadarAggressive = this.radarAggressive.Checked;
            Main.Ini.IniWriteValue("Radar", "Aggressive", Main.RadarAggressive.ToString());
        }

        private void radarAnimals_CheckedChanged(object sender, EventArgs e)
        {
            Main.RadarAnimals = this.radarAnimals.Checked;
            Main.Ini.IniWriteValue("Radar", "Animals", Main.RadarAnimals.ToString());
        }

        private void radarVehicles_CheckedChanged(object sender, EventArgs e)
        {
            Main.RadarVehicles = this.radarVehicles.Checked;
            Main.Ini.IniWriteValue("Radar", "Vehicles", Main.RadarVehicles.ToString());
        }

        private void showEntityLists_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowEntityLists = this.showEntityLists.Checked;
            Main.Ini.IniWriteValue("Misc", "ShowEntityLists", Main.ShowEntityLists.ToString());
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void brMode_CheckedChanged(object sender, EventArgs e)
        {
            Main.BRMode = this.brMode.Checked;

            this.showPlayers.Checked = true;
            Main.ShowPlayers = true;
            this.showAggressive.Checked = false;
            Main.ShowAggressive = false;
            this.snowAnimals.Checked = false;
            Main.ShowAnimals = false;
            this.showContainers.Checked = false;
            Main.ShowContainers = false;
            this.showWeapons.Checked = true;
            Main.ShowWeapons = true;
            this.showAmmo.Checked = true;
            Main.ShowAmmo = true;
            this.showItems.Checked = true;
            Main.ShowItems = true;
            this.showVehicles.Checked = true;
            Main.ShowVehicles = true;
            this.showPosition.Checked = true;
            Main.ShowPosition = true;
            this.showCities.Checked = true;
            Main.ShowCities = true;
            this.hideDead.Checked = true;
            Main.HideDead = true;
            //this.hideESPAiming.Checked;
            //this.boxedPlayers.Checked;
            this.boxedAggressive.Checked = false;
            Main.BoxedAggressive = false;
            this.boxedAnimals.Checked = false;
            Main.BoxedAnimals = false;
            this.boxedItems.Checked = false;
            Main.BoxedItems = false;
            this.boxedVehicles.Checked = false;
            Main.BoxedVehicles = false;
            //this.boxed3D.Checked;
            //this.mapLarge.Checked;
            //this.mapTransparency.Value;
            this.showRadar.Checked = true;
            Main.ShowRadar = true;
            //this.radarTransparency.Value;
            this.radarPlayers.Checked = true;
            Main.RadarPlayers = true;
            this.radarAggressive.Checked = false;
            Main.RadarAggressive = false;
            this.radarAnimals.Checked = false;
            Main.RadarAnimals = false;
            this.radarVehicles.Checked = true;
            Main.RadarVehicles = true;
            this.showEntityLists.Checked = true;
            Main.ShowEntityLists = true;
            this.ShowRoot.Checked = true;
            Main.ShowCorpse = true;
            this.ShowCorpse.Checked = false;
            Main.ShowCorpse = false;

            Main.Ini.IniWriteValue("BR", "BRMode", Main.BRMode.ToString());
        }

        private void showAR_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowAR = this.showAR.Checked;
            Main.Ini.IniWriteValue("BR", "ShowAR", Main.ShowAR.ToString());
        }

        private void showShotgun_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowShotgun = this.showShotgun.Checked;
            Main.Ini.IniWriteValue("BR", "ShowShotgun", Main.ShowShotgun.ToString());
        }

        private void showFirstAid_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowFirstAid = this.showFirstAid.Checked;
            Main.Ini.IniWriteValue("BR", "ShowFirstAid", Main.ShowFirstAid.ToString());
        }

        private void showBackpack_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowBackpack = this.showBackpack.Checked;
            Main.Ini.IniWriteValue("BR", "ShowBackpack", Main.ShowBackpack.ToString());
        }

        private void showHelmet_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowHelmet = this.showHelmet.Checked;
            Main.Ini.IniWriteValue("BR", "ShowHelmet", Main.ShowHelmet.ToString());
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadarMap_CheckedChanged(object sender, EventArgs e)
        {
            Main.RadarMap = this.RadarMap.Checked;
            Main.Ini.IniWriteValue("Radar", "RadarMap", Main.RadarMap.ToString());
        }

        private void RadarLine_CheckedChanged(object sender, EventArgs e)
        {
            Main.RadarLine = this.RadarLine.Checked;
            Main.Ini.IniWriteValue("Radar", "RadarLine", Main.RadarLine.ToString());
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Main.RadarLine = this.RadarLine.Checked;
            Main.Ini.IniWriteValue("Radar", "RadarLine", Main.RadarLine.ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowRoot = this.ShowRoot.Checked;
            Main.Ini.IniWriteValue("ESP", "ShowRoot", Main.RadarLine.ToString());
        }

        private void ShowCorpse_CheckedChanged(object sender, EventArgs e)
        {
            Main.ShowCorpse = this.ShowCorpse.Checked;
            Main.Ini.IniWriteValue("ESP", "ShowCorpse", Main.RadarLine.ToString());
        }

        private void AimC_Scroll(object sender, EventArgs e)
        {
            Main.AimC = this.AimC.Value;
            Main.Ini.IniWriteValue("Misc", "AimC", Main.AimC.ToString());
        }
    }
}