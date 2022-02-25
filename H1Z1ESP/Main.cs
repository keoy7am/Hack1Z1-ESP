﻿using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics;
using SlimDX.Direct3D9;
using SlimDX;
using System.Linq;


namespace H1Z1ESP
{
    public partial class Main : Form
    {
        private delegate void AsyncWrite(String Text);
        private delegate void AsyncClear();

        public static Boolean IsRunning = false;

        private Int64 CGameOffset = 0x142979DE0;
        private Int64 GraphicsOffset = 0x142979B20;
       // private Int32 BoneID = 0x14140db60;

        private Hotkey HotKey;
        private Settings Settings;

        private IntPtr GameWindowHandle;
        private MARGIN GameWindowMargin;
        private FastMemory GameMemory = new FastMemory();
        private RECT GameWindowRect;
        private POINT GameWindowSize;
        private POINT GameWindowCenter;

        public static IniHandler Ini;

        public static Boolean Aiming = false;
        public static Boolean AimBot = false;
        private static Boolean Aimed = false;
        private static ENTITY AimedEntity;
      //  private static DateTime AimedUpdate;

        public static Boolean ShowESP = false;

        public static Boolean ShowPlayers = true;
        public static Boolean ShowAggressive = true;
        public static Boolean ShowAnimals = false;
        public static Boolean ShowContainers = false;
        public static Boolean ShowWeapons = true;
        public static Boolean ShowAmmo = true;
        public static Boolean ShowItems = true;
        public static Boolean ShowVehicles = true;
        public static Boolean ShowRoot = true;
        public static Boolean ShowCorpse = false;

        public static Boolean HideESPWhenAiming = true;
        public static Boolean HideDead = true;

        public static Boolean BoxedPlayers = true;
        public static Boolean BoxedAggressive = true;
        public static Boolean BoxedAnimals = false;
        public static Boolean BoxedItems = false;
        public static Boolean BoxedVehicles = false;
        public static Boolean Boxed3D = false;

        public static Boolean ShowMap = false;

        public static Boolean ShowRadar = true;
        public static int RadarTransparency = 210;
        public static Boolean RadarPlayers = true;
        public static Boolean RadarAggressive = true;
        public static Boolean RadarAnimals = true;
        public static Boolean RadarVehicles = true;
        public static Boolean ShowEntityLists = true;

        private static Vector2 RadarCenter;

        public static Boolean ShowMapLarge = true;
        public static int MapTransparency = 210;
        private static float map_pos_x;
        private static float map_pos_z;

        public static Boolean ShowPosition = true;
        public static Boolean ShowCities = true;

        public static Boolean BRMode = false;
        public static Boolean ShowAR = false;
        public static Boolean ShowShotgun = false;
        public static Boolean ShowFirstAid = false;
        public static Boolean ShowBackpack = false;
        public static Boolean ShowHelmet = false;

        public static int shootwhere;
        public static Boolean RadarMap = false;
        public static Boolean RadarLine = false;
        public static int AimC = 2;

        public static Boolean TextShadow = true;

        public static POINT TextRegion;
        public static List<ENTITY> Entity = new List<ENTITY>();

        public static Vector3 PlayerPosition = Vector3.Zero;
        public static float player_X;
        public static float player_Y;
        public static float player_Z;
        public static float player_D;

        public double player_rad;
        public string player_C;

        private static SlimDX.Direct3D9.Device DXDevice;
        private static SlimDX.Direct3D9.Sprite DXSprite;
        private static SlimDX.Direct3D9.Texture DXTextrureMap;
        private static SlimDX.Direct3D9.Texture DXTextrureMapLarge;
        private static SlimDX.Direct3D9.Texture DXTextureGameMap;
        private static SlimDX.Direct3D9.VertexBuffer CircleVertices;
        private static int circleComplexity = 24;

        private static SlimDX.Direct3D9.Line DXLine;
        private static SlimDX.Direct3D9.Font DXFont;
        private static SlimDX.Direct3D9.Font DXFontB;

        // 0511 update add //
        public Boolean IsCorpse;
        public Boolean IsDriving;
        public Boolean InVehicle;


        [DllImport("shlwapi.dll")]
        public static extern int ColorHLSToRGB(int H, int L, int S);

        public Main()
        {
            String iniPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace(@"file:\", "");
            Ini = new IniHandler(iniPath + @"\Settings.ini");

            /*
            if (Ini.IniReadValue("Offsets", "CGame") != String.Empty)
                CGameOffset = Convert.ToInt64("0x14294A240"); 
            if (Ini.IniReadValue("Offsets", "Graphics") != String.Empty)
                GraphicsOffset = Convert.ToInt64("0x142949F88");
            */
            
            if (Ini.IniReadValue("Offsets", "CGame") != String.Empty)
                CGameOffset = Convert.ToInt64(Ini.IniReadValue("Offsets", "CGame"), 16);
            if (Ini.IniReadValue("Offsets", "Graphics") != String.Empty)
                GraphicsOffset = Convert.ToInt64(Ini.IniReadValue("Offsets", "Graphics"), 16);
             

            //
            if (Ini.IniReadValue("ESP", "ShowPlayers") != String.Empty)
                ShowPlayers = Convert.ToBoolean(Ini.IniReadValue("ESP", "ShowPlayers"));

            if (Ini.IniReadValue("ESP", "ShowAggressive") != String.Empty)
                ShowAggressive = Convert.ToBoolean(Ini.IniReadValue("ESP", "ShowAggressive"));

            if (Ini.IniReadValue("ESP", "ShowAnimals") != String.Empty)
                ShowAnimals = Convert.ToBoolean(Ini.IniReadValue("ESP", "ShowAnimals"));

            if (Ini.IniReadValue("ESP", "ShowContainers") != String.Empty)
                ShowContainers = Convert.ToBoolean(Ini.IniReadValue("ESP", "ShowContainers"));

            if (Ini.IniReadValue("ESP", "ShowWeapons") != String.Empty)
                ShowWeapons = Convert.ToBoolean(Ini.IniReadValue("ESP", "ShowWeapons"));

            if (Ini.IniReadValue("ESP", "ShowAmmo") != String.Empty)
                ShowAmmo = Convert.ToBoolean(Ini.IniReadValue("ESP", "ShowAmmo"));

            if (Ini.IniReadValue("ESP", "ShowItems") != String.Empty)
                ShowItems = Convert.ToBoolean(Ini.IniReadValue("ESP", "ShowItems"));

            if (Ini.IniReadValue("ESP", "ShowVehicles") != String.Empty)
                ShowVehicles = Convert.ToBoolean(Ini.IniReadValue("ESP", "ShowVehicles"));

            if (Ini.IniReadValue("ESP", "ShowRoot") != String.Empty)
                ShowRoot =  Convert.ToBoolean(Ini.IniReadValue("ESP", "ShowRoot"));

            if (Ini.IniReadValue("ESP", "ShowCorpse") != String.Empty)
                ShowCorpse = Convert.ToBoolean(Ini.IniReadValue("ESP", "ShowCorpse"));

            //
            if (Ini.IniReadValue("Boxed", "Players") != String.Empty)
                BoxedPlayers = Convert.ToBoolean(Ini.IniReadValue("Boxed", "Players"));

            if (Ini.IniReadValue("Boxed", "Aggressive") != String.Empty)
                BoxedAggressive = Convert.ToBoolean(Ini.IniReadValue("Boxed", "Aggressive"));

            if (Ini.IniReadValue("Boxed", "Animals") != String.Empty)
                BoxedAnimals = Convert.ToBoolean(Ini.IniReadValue("Boxed", "Animals"));

            if (Ini.IniReadValue("Boxed", "Items") != String.Empty)
                BoxedItems = Convert.ToBoolean(Ini.IniReadValue("Boxed", "Items"));


            if (Ini.IniReadValue("Boxed", "Vehicles") != String.Empty)
                BoxedVehicles = Convert.ToBoolean(Ini.IniReadValue("Boxed", "Vehicles"));

            if (Ini.IniReadValue("Boxed", "3D") != String.Empty)
                Boxed3D = Convert.ToBoolean(Ini.IniReadValue("Boxed", "3D"));

            //
            if (Ini.IniReadValue("Misc", "ShowPosition") != String.Empty)
                ShowPosition = Convert.ToBoolean(Ini.IniReadValue("Misc", "ShowPosition"));

            if (Ini.IniReadValue("Misc", "ShowCities") != String.Empty)
                ShowCities = Convert.ToBoolean(Ini.IniReadValue("Misc", "ShowCities"));

            if (Ini.IniReadValue("Radar", "RadarMap") != String.Empty)
                RadarMap = Convert.ToBoolean(Ini.IniReadValue("Radar", "RadarMap"));

            if (Ini.IniReadValue("Radar", "RadarLine") != String.Empty)
                RadarLine = Convert.ToBoolean(Ini.IniReadValue("Radar", "RadarLine"));

            //
            if (Ini.IniReadValue("Misc", "HideDead") != String.Empty)
                HideDead = Convert.ToBoolean(Ini.IniReadValue("Misc", "HideDead"));

            if (Ini.IniReadValue("Misc", "HideESPWhenAiming") != String.Empty)
                HideESPWhenAiming = Convert.ToBoolean(Ini.IniReadValue("Misc", "HideESPWhenAiming"));

            //
            if (Ini.IniReadValue("Map", "LargeMap") != String.Empty)
                ShowMapLarge = Convert.ToBoolean(Ini.IniReadValue("Map", "LargeMap"));

            if (Ini.IniReadValue("Map", "Transparency") != String.Empty)
                MapTransparency = Int32.Parse(Ini.IniReadValue("Map", "Transparency"));

            //
            if (Ini.IniReadValue("Radar", "Show") != String.Empty)
                ShowRadar = Convert.ToBoolean(Ini.IniReadValue("Radar", "Show"));

            if (Ini.IniReadValue("Radar", "Transparency") != String.Empty)
                RadarTransparency = Int32.Parse(Ini.IniReadValue("Radar", "Transparency"));

            if (Ini.IniReadValue("Radar", "Players") != String.Empty)
                RadarPlayers = Convert.ToBoolean(Ini.IniReadValue("Radar", "Players"));

            if (Ini.IniReadValue("Radar", "Aggressive") != String.Empty)
                RadarAggressive = Convert.ToBoolean(Ini.IniReadValue("Radar", "Aggressive"));

            if (Ini.IniReadValue("Radar", "Animals") != String.Empty)
                RadarAnimals = Convert.ToBoolean(Ini.IniReadValue("Radar", "Animals"));

            if (Ini.IniReadValue("Radar", "Vehicles") != String.Empty)
                RadarVehicles = Convert.ToBoolean(Ini.IniReadValue("Radar", "Vehicles"));

            if (Ini.IniReadValue("Misc", "ShowEntityLists") != String.Empty)
                ShowEntityLists = Convert.ToBoolean(Ini.IniReadValue("Misc", "ShowEntityLists"));
            //
            if (Ini.IniReadValue("Misc", "AimC") != String.Empty)
                AimC = Int32.Parse(Ini.IniReadValue("Misc", "AimC"));

            InitializeComponent();
        }

        public static RECT GetWindowRect(IntPtr hWnd)
        {
            RECT lpRect = new RECT();
            Native.GetWindowRect(hWnd, out lpRect);
            return lpRect;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            HotKey = new Hotkey();
            HotKey.enable(this.Handle, Hotkey.Modifiers.None, Keys.Insert); // Delete //Insert
            HotKey.enable(this.Handle, Hotkey.Modifiers.Alt, Keys.F1);
            HotKey.enable(this.Handle, Hotkey.Modifiers.None, Keys.N);
            HotKey.enable(this.Handle, Hotkey.Modifiers.Alt, Keys.F3);
            HotKey.enable(this.Handle, Hotkey.Modifiers.Alt, Keys.F5);
            //HotKey.enable(base.Handle, Hotkey.Modifiers.None, Keys.CapsLock);
            //HotKey.enable(base.Handle, Hotkey.Modifiers.None, Keys.Q);

            Native.SetWindowLong(this.Handle, -20, (IntPtr)((Native.GetWindowLong(this.Handle, -20) ^ 0x80000) ^ 0x20));
            Native.SetLayeredWindowAttributes(this.Handle, 0, 0xff, 2);

            PresentParameters parameters = new SlimDX.Direct3D9.PresentParameters();
            parameters.Windowed = true;
            parameters.SwapEffect = SwapEffect.Discard;
            parameters.BackBufferFormat = Format.A8R8G8B8;
            parameters.BackBufferHeight = this.Height;
            parameters.BackBufferWidth = this.Width;
            parameters.PresentationInterval = PresentInterval.One;

            DXDevice = new SlimDX.Direct3D9.Device(new Direct3D(), 0, DeviceType.Hardware, this.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters[] { parameters });
            if (System.IO.File.Exists("map_large.png")) DXTextrureMapLarge = SlimDX.Direct3D9.Texture.FromFile(DXDevice, "map_large.png");
            if (System.IO.File.Exists("map.png")) DXTextrureMap = SlimDX.Direct3D9.Texture.FromFile(DXDevice, "map.png");
            if (System.IO.File.Exists("LagerMap.jpg")) DXTextureGameMap = SlimDX.Direct3D9.Texture.FromFile(DXDevice, "LagerMap.jpg");
            CircleVertices = new VertexBuffer(DXDevice, (circleComplexity + 2) * TexVertex.SizeBytes, Usage.WriteOnly, VertexFormat.None, Pool.Managed);  
            DXSprite = new SlimDX.Direct3D9.Sprite(DXDevice);
            DXLine = new SlimDX.Direct3D9.Line(DXDevice);
            DXFont = new SlimDX.Direct3D9.Font(DXDevice, new System.Drawing.Font("NewRoman", 9f)); //NewRoman
            DXFontB = new SlimDX.Direct3D9.Font(DXDevice, new System.Drawing.Font("Tahoma", 12f)); //NewRoman

            if (this.GameMemory.Attach("H1Z1 PlayClient (Live)") == false) { Application.Exit(); return; }
            Thread dxThread = new Thread(new ThreadStart(DoProcess));
            dxThread.IsBackground = true;
            dxThread.Start();

            //Thread aimThread = new Thread(new ThreadStart(DoAiming));
            //aimThread.IsBackground = true;
            //aimThread.Start(); 
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            this.GameWindowMargin.Top = 0;
            this.GameWindowMargin.Left = 0;
            this.GameWindowMargin.Right = this.Width;
            this.GameWindowMargin.Bottom = this.Height;
            Native.DwmExtendFrameIntoClientArea(this.Handle, ref this.GameWindowMargin);
        }

        #region RemapValue
        public static float RemapValue(float value, float from1, float to1, float from2, float to2)
        {
            return ((((value - from1) / (to1 - from1)) * (to2 - from2)) + from2);
        }
        #endregion

        #region DrawFilledBox
        public static void DrawFilledBox(float x, float y, float w, float h, Color Color, int alpha = 255)
        {
            Vector2[] vertexList = new Vector2[2];
            DXLine.GLLines = true;
            DXLine.Antialias = false;
            DXLine.Width = w;
            vertexList[0].X = x + (w / 2f);
            vertexList[0].Y = y;
            vertexList[1].X = x + (w / 2f);
            vertexList[1].Y = y + h;
            DXLine.Begin();
            DXLine.Draw(vertexList, Color.FromArgb(alpha, Color.R, Color.G, Color.B));
            DXLine.End();
        }
        #endregion

        #region RotatePoint
        private static Vector2 RotatePoint(Vector2 pointToRotate, Vector2 centerPoint, float angle, bool angleInRadians = false)
        {
            if (!angleInRadians) angle = (float)(angle * 0.017453292519943295);
            float num = (float)Math.Cos((double)angle);
            float num2 = (float)Math.Sin((double)angle);
            Vector2 vector = new Vector2((num * (pointToRotate.X - centerPoint.X)) - (num2 * (pointToRotate.Y - centerPoint.Y)), (num2 * (pointToRotate.X - centerPoint.X)) + (num * (pointToRotate.Y - centerPoint.Y)));
            return (vector + centerPoint);
        }
        #endregion

        #region GetMatrixAxis
        private static Vector3 GetMatrixAxis(Matrix matrix, int i)
        {
            switch (i)
            {
                case 0: return new Vector3(matrix.M11, matrix.M12, matrix.M13);
                case 1: return new Vector3(matrix.M21, matrix.M22, matrix.M23);
                case 2: return new Vector3(matrix.M31, matrix.M32, matrix.M33);
                case 3: return new Vector3(matrix.M41, matrix.M42, matrix.M43);
            }
            return Vector3.Zero;
        }
        #endregion

        #region WorldToScreen
        private bool WorldToScreen(Vector3 vector, out Vector3 screen)
        {
            screen = Vector3.Zero;
            long num = this.GameMemory.ReadInt64(GraphicsOffset);
            long num2 = this.GameMemory.ReadInt64(num + 0x48L);
            long num3 = this.GameMemory.ReadInt64(num2 + 0x20L) + 0x10L;
            Matrix4 matrix = this.GameMemory.ReadMatrix(num3 + 0x1a0L);
            Matrix matrix2 = new Matrix();
            matrix2.M11 = matrix.M11;
            matrix2.M12 = matrix.M12;
            matrix2.M13 = matrix.M13;
            matrix2.M14 = matrix.M14;
            matrix2.M21 = matrix.M21;
            matrix2.M22 = matrix.M22;
            matrix2.M23 = matrix.M23;
            matrix2.M24 = matrix.M24;
            matrix2.M31 = matrix.M31;
            matrix2.M32 = matrix.M32;
            matrix2.M33 = matrix.M33;
            matrix2.M34 = matrix.M34;
            matrix2.M41 = matrix.M41;
            matrix2.M42 = matrix.M42;
            matrix2.M43 = matrix.M43;
            matrix2.M44 = matrix.M44;
            Matrix.Transpose(ref matrix2, out matrix2);
            matrix2.M21 *= -1f;
            matrix2.M22 *= -1f;
            matrix2.M23 *= -1f;
            matrix2.M24 *= -1f;
            float introduced8 = Vector3.Dot(GetMatrixAxis(matrix2, 3), vector);
            float num4 = introduced8 + matrix2.M44;
            if (num4 < 0.098f) return false;
            float introduced9 = Vector3.Dot(GetMatrixAxis(matrix2, 0), vector);
            float num5 = introduced9 + matrix2.M14;
            float introduced10 = Vector3.Dot(GetMatrixAxis(matrix2, 1), vector);
            float num6 = introduced10 + matrix2.M24;
            screen.X = ((((this.GameWindowSize.X - 0x10) / 2) * (1f + (num5 / num4))) + this.GameWindowRect.Left) + 8f;
            screen.Y = ((((this.GameWindowSize.Y - 0x26) / 2) * (1f - (num6 / num4))) + this.GameWindowRect.Top) + 30f;
            return true;
        }
        #endregion

        #region DrawLine
        public static void DrawLine(float x1, float y1, float x2, float y2, float w, Color Color)
        {
            Vector2[] vertexList = new Vector2[] { new Vector2(x1, y1), new Vector2(x2, y2) };
            DXLine.GLLines = true;
            DXLine.Width = w;
            DXLine.Antialias = true;
            DXLine.Begin();
            DXLine.Draw(vertexList, Color);
            DXLine.End();
        }
        #endregion

        #region DrawText
        public static void DrawText(string text, int x, int y, Color color, bool center = false)
        {
            int offset = center ? (text.Length * 5) / 2 : 0;
            if (TextShadow) DXFont.DrawString(null, text, x - offset + 1, y + 1, (Color4)Color.Black);
            DXFont.DrawString(null, text, x - offset, y, (Color4)color);
        }

        public static void DrawTextB(string text, int x, int y, Color color, bool center = false)
        {
            int offset = center ? (text.Length * 5) / 2 : 0;
            if (TextShadow) DXFontB.DrawString(null, text, x - offset + 1, y + 1, (Color4)Color.Black);
            DXFontB.DrawString(null, text, x - offset, y, (Color4)color);
        }

        public static void DrawText(string text, ref POINT point, Color color)
        {
            if (TextShadow) DXFont.DrawString(null, text, point.X + 1, point.Y + 1, (Color4)Color.Black);
            DXFont.DrawString(null, text, point.X, point.Y, (Color4)color); point.Y += 15;
        }
        #endregion

        #region DrawBox
        public static void DrawBox(float x, float y, float w, float h, float px, Color Color)
        {
            DrawFilledBox(x - (w / 2f), (y + h) - (h / 2f), w, px, Color);
            DrawFilledBox((x - (w / 2f)) - px, y - (h / 2f), px, h, Color);
            DrawFilledBox(x - (w / 2f), (y - px) - (h / 2f), w, px, Color);
            DrawFilledBox((x - (w / 2f)) + w, y - (h / 2f), px, h, Color);
        }
        #endregion

        #region DrawBoxAbs
        public static void DrawBoxAbs(float x, float y, float w, float h, float px, Color Color)
        {
            DrawFilledBox(x, y + h, w, px, Color);
            DrawFilledBox(x - px, y, px, h, Color);
            DrawFilledBox(x, y - px, w, px, Color);
            DrawFilledBox(x + w, y, px, h, Color);
        }
        #endregion


        #region EntityToScreen
        public void EntityToScreen(Vector3 pos, string name, Color color, bool dist, bool line, bool bounds, float boxHeight, float yaw, float pitch)
        {
            string text = name;
            Vector3 dest = Vector3.Zero;
            this.WorldToScreen(pos, out dest);

            double distX = pos.X - player_X;
            double distY = pos.Z - player_Z;
            double distZ = pos.Y - player_Y;
            double a = Math.Sqrt(((distX * distX) + (distY * distY)) + (distZ * distZ));

            if (dest.Y > 0f && dest.X > 0f && dest.Y >= this.GameWindowRect.Top + 20 && dest.X >= this.GameWindowRect.Left && dest.X <= this.GameWindowRect.Right && dest.Y <= this.GameWindowRect.Bottom)
            {
                if (dist)
                {
                    text = text + "\n[" + Math.Round(a).ToString() + "m]";
                }

                if (line)
                {
                    DrawLine(dest.X, dest.Y, this.GameWindowCenter.X, this.GameWindowCenter.Y, 1f, color);
                }

                if (bounds)
                {
                    if (!Boxed3D || a >= 100.0)
                    {
                        DrawBox(dest.X, dest.Y, 65f / Math.Max((float)(((float)a) / 10f), (float)0.2f), 150f / Math.Max((float)(((float)a) / 10f), (float)0.2f), 1f, color);
                    }
                    else if (a < 100.0)
                    {
                        float wOffset = (boxHeight < 1f) ? boxHeight : 1f;
                        float zOffset = (boxHeight > 1f) ? boxHeight / 2 : 0f;
                        double num5 = pos.Z + ((1.0 * Math.Cos((double)pitch)) * Math.Cos((double)yaw));
                        double num6 = pos.X + ((1.0 * Math.Cos((double)pitch)) * Math.Sin((double)yaw));
                        double num7 = pos.Y + (1.0 * Math.Sin((double)pitch));
                        Vector3 vector = new Vector3((float)num6, (float)num7, (float)num5);
                        Vector3 zero = Vector3.Zero;
                        this.WorldToScreen(vector, out zero);
                        DrawLine(dest.X, dest.Y, zero.X, zero.Y, 1f, color);
                        num5 = pos.Z + (0.5 * Math.Cos(yaw + 0.78539816339744828));
                        num6 = pos.X + (0.5 * Math.Sin(yaw + 0.78539816339744828));
                        Vector3 vector4 = new Vector3((float)num6, pos.Y - zOffset, (float)num5);
                        Vector3 screen = Vector3.Zero;
                        this.WorldToScreen(vector4, out screen);
                        num5 = pos.Z + (0.5 * Math.Cos(yaw + 5.497787143782138));
                        num6 = pos.X + (0.5 * Math.Sin(yaw + 5.497787143782138));
                        Vector3 vector6 = new Vector3((float)num6, pos.Y - zOffset, (float)num5);
                        Vector3 vector7 = Vector3.Zero;
                        this.WorldToScreen(vector6, out vector7);
                        DrawLine(screen.X, screen.Y, vector7.X, vector7.Y, 1f, color);
                        num5 = pos.Z + (0.5 * Math.Cos(yaw + 3.9269908169872414));
                        num6 = pos.X + (0.5 * Math.Sin(yaw + 3.9269908169872414));
                        Vector3 vector8 = new Vector3((float)num6, pos.Y - zOffset, (float)num5);
                        Vector3 vector9 = Vector3.Zero;
                        this.WorldToScreen(vector8, out vector9);
                        DrawLine(vector7.X, vector7.Y, vector9.X, vector9.Y, 1f, color);
                        num5 = pos.Z + (0.5 * Math.Cos(yaw + 2.3561944901923448));
                        num6 = pos.X + (0.5 * Math.Sin(yaw + 2.3561944901923448));
                        Vector3 vector10 = new Vector3((float)num6, pos.Y - zOffset, (float)num5);
                        Vector3 vector11 = Vector3.Zero;
                        this.WorldToScreen(vector10, out vector11);
                        DrawLine(vector9.X, vector9.Y, vector11.X, vector11.Y, 1f, color);
                        DrawLine(vector11.X, vector11.Y, screen.X, screen.Y, 1f, color);
                        Vector3 vector12 = new Vector3(vector4.X, vector4.Y + boxHeight, vector4.Z);
                        Vector3 vector13 = Vector3.Zero;
                        this.WorldToScreen(vector12, out vector13);
                        DrawLine(screen.X, screen.Y, vector13.X, vector13.Y, 1f, color);
                        Vector3 vector14 = new Vector3(vector6.X, vector6.Y + boxHeight, vector6.Z);
                        Vector3 vector15 = Vector3.Zero;
                        this.WorldToScreen(vector14, out vector15);
                        DrawLine(vector13.X, vector13.Y, vector15.X, vector15.Y, 1f, color);
                        DrawLine(vector7.X, vector7.Y, vector15.X, vector15.Y, 1f, color);
                        Vector3 vector16 = new Vector3(vector8.X, vector8.Y + boxHeight, vector8.Z);
                        Vector3 vector17 = Vector3.Zero;
                        this.WorldToScreen(vector16, out vector17);
                        DrawLine(vector15.X, vector15.Y, vector17.X, vector17.Y, 1f, color);
                        DrawLine(vector9.X, vector9.Y, vector17.X, vector17.Y, 1f, color);
                        Vector3 vector18 = new Vector3(vector10.X, vector10.Y + boxHeight, vector10.Z);
                        Vector3 vector19 = Vector3.Zero;
                        this.WorldToScreen(vector18, out vector19);
                        DrawLine(vector17.X, vector17.Y, vector19.X, vector19.Y, 1f, color);
                        DrawLine(vector11.X, vector11.Y, vector19.X, vector19.Y, 1f, color);
                        DrawLine(vector19.X, vector19.Y, vector13.X, vector13.Y, 1f, color);
                    }
                }
                DrawText(text, (int)dest.X, (int)dest.Y - 20, color, true);
            }
        }
        #endregion

        #region DrawRadar
        // Textured Vertex structure.

        [StructLayout(LayoutKind.Sequential)]
        struct TexVertex
        {
            public Vector3 Position;
            public float Tu;
            public float Tv;

            public static int SizeBytes
            {
                get { return Marshal.SizeOf(typeof(TexVertex)); }
            }

            public static VertexFormat Format
            {
                get { return VertexFormat.Position | VertexFormat.Texture1; }
            }
        }
        private static TexVertex[] BuildVertexCircle(Vector2 center, Vector2 texCenter, float radius, float scale, int complexity = 24)
        {
            TexVertex[] vertexData = new TexVertex[complexity + 2];
            vertexData[0].Position = new Vector3(center.X, center.Y, 0.0f);
            vertexData[0].Tu = texCenter.X;
            vertexData[0].Tv = texCenter.Y;

            double stepAngle = (Math.PI * 2) / complexity;
            for (int i = 0; i <= complexity; i++)
            {
                double angle = (Math.PI * 2) - (i * stepAngle);
                float x = (float)Math.Cos(angle);
                float y = (float)Math.Sin(angle);
                vertexData[i + 1].Position = new Vector3(center.X + x * radius, center.Y + y * radius, 0.0f);
                vertexData[i + 1].Tu = texCenter.X + scale * x;
                vertexData[i + 1].Tv = texCenter.Y - scale * y;
            }
            return vertexData;
        }

        #endregion

        public void DoProcess()
        {
            Main.IsRunning = true;
            this.GameWindowHandle = this.GameMemory.Process.MainWindowHandle;
            Native.SetForegroundWindow(this.GameWindowHandle);

            while (this.GameWindowHandle != IntPtr.Zero && Main.IsRunning && this.GameMemory.IsOpen)
            {
                this.GameWindowRect = GetWindowRect(this.GameWindowHandle);
                this.GameWindowSize.X = this.GameWindowRect.Right - this.GameWindowRect.Left;
                this.GameWindowSize.Y = this.GameWindowRect.Bottom - this.GameWindowRect.Top;
                this.GameWindowCenter.X = this.GameWindowRect.Left + (this.GameWindowSize.X / 2);
                this.GameWindowCenter.Y = this.GameWindowRect.Top + (this.GameWindowSize.Y / 2) + 11;

                DXDevice.Clear(ClearFlags.Target, Color.FromArgb(0, 0, 0, 0), 1f, 0);
                DXDevice.SetRenderState(RenderState.ZEnable, false);
                DXDevice.SetRenderState(RenderState.Lighting, false);
                DXDevice.SetRenderState<Cull>(RenderState.CullMode, Cull.None);
                DXDevice.BeginScene();

                long entityOffset = this.GameMemory.ReadInt64(CGameOffset);
                long playerOffset = this.GameMemory.ReadInt64(entityOffset + 0x11D8);
 
                if ((player_rad >=-11.25) && (player_rad <=11.25)) {player_C ="E";}
                else if ((player_rad >=11.25) && (player_rad <=33.75)) { player_C ="ENE"; }
                else if ((player_rad >=33.75) && (player_rad <=56.25)) { player_C ="NE"; }
                else if ((player_rad >=56.25) && (player_rad <=78.75)) { player_C ="NNE"; }
                else if ((player_rad >=78.75) && (player_rad <=101.25)) { player_C ="N"; }
                else if ((player_rad >=101.25) && (player_rad <=123.75)) { player_C ="NNW"; }
                else if ((player_rad >=123.75) && (player_rad <=146.25)) { player_C ="NW"; }
                else if ((player_rad >=146.25) && (player_rad <=168.75 )) { player_C ="WNW"; }
                else if ((player_rad >=168.75) && (player_rad <=180)) { player_C ="W"; }
                 else if ((player_rad >=-180) && (player_rad <=-168.75)) { player_C ="W"; }
                 else if ((player_rad >=-168.75) && (player_rad <=-146.25)) { player_C ="WSW"; }
                 else if ((player_rad >=-146.25) && (player_rad <=-123.75)) { player_C ="SW"; }
                 else if ((player_rad >=-123.75) && (player_rad <=-101.25)) { player_C ="SSW"; }
                 else if ((player_rad >=-101.25) && (player_rad <=-78.75)) { player_C ="S"; }
                 else if ((player_rad >=-78.75) && (player_rad <=-56.25)) { player_C ="SSE"; }
                 else if ((player_rad >=-56.75) && (player_rad <=-33.75)) { player_C ="SE"; }
                 else if ((player_rad >=-33.75) && (player_rad <=-11.25)) { player_C ="ESE"; }
                
                long posOffset = this.GameMemory.ReadInt64(playerOffset + 0x198);
                player_X = this.GameMemory.ReadFloat(posOffset + 0x100); // 0x110 old
                player_Y = this.GameMemory.ReadFloat(posOffset + 0x104); // 0x114 old
                player_Z = this.GameMemory.ReadFloat(posOffset + 0x108); // 0x118 old
                player_D = this.GameMemory.ReadFloat(playerOffset + 0x240);
                player_rad = player_D * (180.0/Math.PI);

                PlayerPosition.X = player_X;
                PlayerPosition.Y = player_Y;
                PlayerPosition.Z = player_Z;


                TextRegion = new POINT(this.GameWindowRect.Left + 15, this.GameWindowRect.Top + 35);
                if (ShowPosition)
                {
                    DrawText("Position X: " + player_X.ToString("F1") + " Y: " + player_Y.ToString("F1") + " Z: " + player_Z.ToString("F1"), ref TextRegion, Color.White);
                    DrawText("Direction: " + player_D.ToString("F2"), ref TextRegion, Color.White);
                    DrawText("方向:" + player_C, ref TextRegion, Color.White);
                    DrawText("＊Hack1Z1為免費程式請勿商業行為＊", ref TextRegion, Color.SkyBlue);

                }

                ShowESP = (!HideESPWhenAiming || Convert.ToBoolean(Native.GetAsyncKeyState(2) & 0x8000) == false);

                Entity.Clear(); Aimed = false;

                int entityCount = this.GameMemory.ReadInt32(entityOffset + 0x688);
                long entityEntry = this.GameMemory.ReadInt64(playerOffset + 0x410);

                for (int i = 1; i < entityCount; i++)
                {
                    float EntityX = 0;
                    float EntityY = 0;
                    float EntityZ = 0;  
                    float EntityYaw = 0;
                    float EntityPitch = 0;
                    float EntitySpeed = 0;
                    IsCorpse = false;
                    InVehicle = false;
                    IsDriving = false;

                    int EntityType = this.GameMemory.ReadInt32(entityEntry + 0x5D0);
                    if (EntityType == 0) continue;

                    int EntityId = this.GameMemory.ReadInt32(entityEntry + 0x628);

                    long _nameEntry = this.GameMemory.ReadInt64(entityEntry + 0x4E8);
                    String EntityName = this.GameMemory.ReadString(_nameEntry, this.GameMemory.ReadInt32(entityEntry + 0x4F0));
                    /*
                    //XYZ//
                    posOffset = this.GameMemory.ReadInt64(entityEntry + 0x198);
                    if (EntityType == 0x04 || EntityType == 0x05)
                    {
                        EntityX = this.GameMemory.ReadFloat(posOffset + 0x100);
                        EntityY = this.GameMemory.ReadFloat(posOffset + 0x104);
                        EntityZ = this.GameMemory.ReadFloat(posOffset + 0x108);
                        EntitySpeed = this.GameMemory.ReadFloat(entityEntry + 0x2C8);
                        EntityYaw = this.GameMemory.ReadFloat(entityEntry + 0x2E0);
                    }*/
                    
                    // Get Player Pos //
                    if (EntityType == 0x04 || EntityType == 0x05)
                    {
                        EntityX = this.GameMemory.ReadFloat(entityEntry + 0x100);
                        EntityY = this.GameMemory.ReadFloat(entityEntry + 0x104);
                        EntityZ = this.GameMemory.ReadFloat(entityEntry + 0x108);

                        EntitySpeed = this.GameMemory.ReadFloat(entityEntry + 0x2C8); //1D8
                        EntityYaw = this.GameMemory.ReadFloat(entityEntry + 0x240); //1F0
                    }
                    
                        // Vechicle Position //
                        else if (EntityType == 0x11 || EntityType == 0x72 || EntityType == 0x76)
                        {
                            EntityX = this.GameMemory.ReadFloat(entityEntry + 0x250);
                            EntityY = this.GameMemory.ReadFloat(entityEntry + 0x254);
                            EntityZ = this.GameMemory.ReadFloat(entityEntry + 0x258);
                            EntitySpeed = this.GameMemory.ReadFloat(entityEntry + 0x2C8); // old (entityEntry + 0x2C8) 
                            EntityYaw = this.GameMemory.ReadFloat(entityEntry + 0x240);
                        }
                        else
                        {
                        // Try Get NPC Position //
                        EntityX = this.GameMemory.ReadFloat(entityEntry + 0x3C0);
                        if (EntityX == 0)
                        {
                            // Get Item Pos //
                            EntityX = this.GameMemory.ReadFloat(entityEntry + 0x13F0);
                            EntityY = this.GameMemory.ReadFloat(entityEntry + 0x13E4);
                            EntityZ = this.GameMemory.ReadFloat(entityEntry + 0x13E8);
                        }
                        else
                        {
                            // NPC Position //
                            EntityY = this.GameMemory.ReadFloat(entityEntry + 0x3C4);
                            EntityZ = this.GameMemory.ReadFloat(entityEntry + 0x3C8);

                            EntitySpeed = this.GameMemory.ReadFloat(entityEntry + 0x1D8);
                            EntityYaw = this.GameMemory.ReadFloat(entityEntry + 0x1F0);
                        }
                    }
                
                    // found this H1Z1 Reversal to solve car/player issues
                    long entityPositionOffset = this.GameMemory.ReadInt64(entityEntry + 0x198);
                    EntityX = this.GameMemory.ReadFloat(entityPositionOffset + 0x100);
                    EntityY = this.GameMemory.ReadFloat(entityPositionOffset + 0x104)-0.15f;
                    EntityZ = this.GameMemory.ReadFloat(entityPositionOffset + 0x108);

                    
                    // Create New Entity //
                    ENTITY currentEntity = new ENTITY()
                    {
                        Id = EntityId,
                        Type = EntityType,
                        Name = EntityName,
                        Pos = new Vector3(EntityX, EntityY, EntityZ),
                        Distance = Vector3.Distance(new Vector3(EntityX, EntityY, EntityZ), PlayerPosition),
                        Yaw = EntityYaw,
                        Pitch = EntityPitch,
                        Speed = EntitySpeed
                    };

                    
                    // Append New Entity //
                    Entity.Add(currentEntity);
                    Int32 EntityState = this.GameMemory.ReadInt32(entityEntry + 0x5C8); // 自瞄及顯示用
                    

                    // Detect type of Loot (Corpse or Loot) //
                    if (currentEntity.Type == 0x2E && this.GameMemory.ReadByte(entityEntry + 0x1D88) == 0xE4)
                    {
                        IsCorpse = true;
                        currentEntity.Name = "Corpse";
                    }
                    
        /*                          // display EntityType //
                             if (ShowESP) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName + "\n" + "[" + BoneID.ToString("X2") + "]" + "[" + EntityType.ToString("X4") + "]", Color.Red, true, false, false, 2f, EntityYaw, EntityPitch);
                                  break;*/


                    switch (EntityType)
                    {
                        case 0x04/*Player*/:
                        case 0x05/*BR Player*/:
                            /*      case 0x11: // OffRoad
                                  case 0x72: // Pickup
                                  case 0x76: // PoliceCar*/
                            
                            #region // Aiming //

                            Vector3 aimingTo = Vector3.Zero;
                            if (Aimed == true || currentEntity.Distance > 200f || this.GameMemory.ReadByte(entityEntry + 0x139C) != 1)
                            {
                                /* Already aimed, not in range, entity is dead */
                            }
                            else if (ModifierKeys.HasFlag(Keys.Control) == true)
                            {
                                if (AimedEntity != null && AimedEntity.Id == currentEntity.Id)
                                {
                                    if (Convert.ToBoolean(this.GameMemory.ReadByte(entityEntry + 0x139C)) == false) //old 0x137C
                                    {
                                        // Target is dead //
                                        AimedEntity = null;
                                    }
                                    else
                                    {
                                        Aimed = true;
                                        AimedEntity = currentEntity;
                                        Vector3 AIM; float offsetY = 0f;
                                        {
                                                switch (EntityState)
                                                {
                                                    case 0: offsetY = 1.75f; ; break; // Standing [站立]
                                                    case 1: offsetY = 1.05f; ; break; // Crouched [坐著]
                                                    case 2: offsetY = 1.55f; break; // Walking [走路]
                                                    case 3: offsetY = 1.55f; break; // Running [跑步]
                                                    case 4: offsetY = 1.60f; break; // Jumping [跳躍]
                                                    case 5: offsetY = 1.05f; break; // Crouching [蹲著]
                                                    case 6: offsetY = 0.3f; break; // Prone [趴著]
                                                    case 7: offsetY = 0.3f; break; // Crawling [爬行]
                                                }
                                            }


                                        if (WorldToScreen(new Vector3(AimedEntity.Pos.X, AimedEntity.Pos.Y + offsetY, AimedEntity.Pos.Z), out AIM))
                                        {
                                            int moveOffsetX = (int)(Math.Round(AIM.X) - this.GameWindowCenter.X) / AimC;
                                            int moveOffsetY = (int)(Math.Round(AIM.Y) - this.GameWindowCenter.Y) / AimC;
                                            DrawText("Aimed at " + AimedEntity.Name + ": " + moveOffsetX + ", " + moveOffsetY, ref TextRegion, Color.Red);
                                            if (moveOffsetX != 0 || moveOffsetY != 0) Native.mouse_event(0x0001, (short)moveOffsetX, (short)moveOffsetY, 0, 0);
                                        }
                                    }
                                }
                                else if (AimedEntity == null && WorldToScreen(new Vector3(EntityX, EntityY + 1f, EntityZ), out aimingTo)) // EntityY + 1f old
                                {
                                    float distance = Vector2.Distance(new Vector2(aimingTo.X, aimingTo.Y), new Vector2(this.GameWindowCenter.X, this.GameWindowCenter.Y));
                                    if (distance < 100f)
                                    {
                                        AimedEntity = currentEntity; Aimed = true;
                                        float moveOffsetX = aimingTo.X - this.GameWindowCenter.X;
                                        float moveOffsetY = aimingTo.Y - this.GameWindowCenter.Y;
                                        Native.mouse_event(0x0001, (short)moveOffsetX, (short)moveOffsetY, 0, 0);
                                    }
                                }
                            }
                                //  AIM 2   //
                            else if (Convert.ToBoolean(Native.GetAsyncKeyState(Keys.CapsLock) & 0x8000) || Convert.ToBoolean(Native.GetAsyncKeyState(Keys.XButton1) & 0x8000) == true)
                            {
                                if (AimedEntity != null && AimedEntity.Id == currentEntity.Id)
                                {
                                    if (Convert.ToBoolean(this.GameMemory.ReadByte(entityEntry + 0x139C)) == false)
                                    {
                                        // Target is dead //
                                        AimedEntity = null;
                                    }
                                    else
                                    {
                                        Aimed = true;
                                        AimedEntity = currentEntity;
                                        Vector3 AIM; float offsetY = 0f;
                                        {
                                                switch (EntityState)
                                                {
                                                    case 0: offsetY = 1.75f; ; break; // Standing [站立]
                                                    case 1: offsetY = 1.05f; ; break; // Crouched [坐著]
                                                    case 2: offsetY = 1.65f; break; // Walking [走路]
                                                    case 3: offsetY = 1.65f; break; // Running [跑步]
                                                    case 4: offsetY = 1.55f; break; // Jumping [跳躍]
                                                    case 5: offsetY = 1.05f; break; // Crouching [蹲著]
                                                    case 6: offsetY = 0.3f; break; // Prone [趴著]
                                                    case 7: offsetY = 0.3f; break; // Crawling [爬行]
                                                }
                                            }
                                        


                                        if (WorldToScreen(new Vector3(AimedEntity.Pos.X, AimedEntity.Pos.Y + offsetY, AimedEntity.Pos.Z), out AIM))
                                        {
                                            int moveOffsetX = (int)(Math.Round(AIM.X) - this.GameWindowCenter.X) * 2; // /1
                                            int moveOffsetY = (int)(Math.Round(AIM.Y) - this.GameWindowCenter.Y) * 2; // /1
                                            DrawText("Aimed at " + AimedEntity.Name + ": " + moveOffsetX + ", " + moveOffsetY, ref TextRegion, Color.Red);
                                            if (moveOffsetX != 0 || moveOffsetY != 0) Native.mouse_event(0x0001, (short)moveOffsetX, (short)moveOffsetY, 0, 0);
                                        }
                                    }
                                }
                                else if (AimedEntity == null && WorldToScreen(new Vector3(EntityX, EntityY + 1f, EntityZ), out aimingTo)) // EntityY + 1f old
                                {
                                    float distance = Vector2.Distance(new Vector2(aimingTo.X, aimingTo.Y), new Vector2(this.GameWindowCenter.X, this.GameWindowCenter.Y));
                                    if (distance < 50f)
                                    {
                                        AimedEntity = currentEntity; Aimed = true;
                                        float moveOffsetX = aimingTo.X - this.GameWindowCenter.X;
                                        float moveOffsetY = aimingTo.Y - this.GameWindowCenter.Y;
                                        Native.mouse_event(0x0001, (short)moveOffsetX, (short)moveOffsetY, 0, 0);
                                    }
                                }
                            }
                            else
                            {
                                AimedEntity = null;
                            }
                            # endregion */

                            // Player Behavior //
                            if (EntityType == 0x04 || EntityType == 0x05)
                            {
                                switch (EntityState)
                                {
                                    case 0: EntityName += " [站立]"; break; // Standing
                                    case 1: EntityName += " [坐著]"; break; // Crouched
                                    case 2: EntityName += " [走路]"; break; // Walking
                                    case 3: EntityName += " [跑步]"; break; // Running
                                    case 4: EntityName += " [跳躍]"; break; // Jumping
                                    case 5: EntityName += " [蹲著]"; break; // Crouching
                                    case 6: EntityName += " [趴著]"; break; // Prone
                                    case 7: EntityName += " [爬行]"; break; // Crawling
                                }
                            }

                           //* // Show Entity when ESP enabled //
                            if (ShowESP) // && this.GameMemory.ReadFloat(entityEntry + 0x1CC) == 1f)
                            {
                                Byte EntityAlive = this.GameMemory.ReadByte(entityEntry + 0x139C);
                                Byte EntityAlive2 = (this.GameMemory.ReadUInt32(this.GameMemory.ReadInt64(entityEntry + 0x4088L) + 0xB0L) / 100 == 30) && (EntityType == 0x0C || EntityType == 0x5B) ? (byte)0 : (byte)1;
                                if (HideDead == false || Convert.ToBoolean(EntityAlive) == true)
                                {
                                    
                                    // Player //
                                    if (EntityType == 0x04 || EntityType == 0x05)
                                    {
                                        // Show HP
                                        if(ShowESP)
                                        {
                                           long HPoffset = this.GameMemory.ReadInt64(entityEntry + 0x4088L); // old 0x4058L oldold 0x3fa8L

                                            uint playerHP = this.GameMemory.ReadUInt32(HPoffset + 0xb0L) / 100;
                                            {
                                                HPoffset = this.GameMemory.ReadInt64(HPoffset + 0xF8);
                                            }
                                            int Hue = (int)(120f * (float)playerHP / 100f); // Hue  red at 0° green at 120°
                                            Color color = ColorTranslator.FromWin32(ColorHLSToRGB(Hue, 120, 240)); // H,L,S;
                                            string playerNameHP = EntityName + " " + playerHP.ToString() + "%";
                                            
                                         /*   long HPoffset = this.GameMemory.ReadInt64(entityEntry + 0x4068L);
                                            uint eHP = this.GameMemory.ReadUInt32(HPoffset + 0xb0L);
                                            uint maxHP = this.GameMemory.ReadUInt32(HPoffset + 0xb4L);
                                            if (maxHP != 0)
                                            {
                                                uint entityHP = 100 * eHP / maxHP;
                                                EntityName = EntityName + " " + entityHP.ToString() + "%" + " " + "[" + state + "]";
                                            }*/

                                            if (ShowPlayers) this.EntityToScreen(new Vector3(EntityX, EntityY + 1f, EntityZ), playerNameHP, color, true, false, BoxedPlayers, 2f, EntityYaw, EntityPitch);
                                        }
                                        else 
                                        {
                                            if (ShowPlayers) this.EntityToScreen(new Vector3(EntityX, EntityY + 1f, EntityZ), EntityName, Color.SkyBlue, true, false, BoxedPlayers, 2f, EntityYaw, EntityPitch);
                                        }
                                    }
                                    // Aggressive NPC (Wolf, Bear, Zombies) //
                                    else
                                    {
                                        if (ShowAggressive) this.EntityToScreen(new Vector3(EntityX, EntityY + 1f, EntityZ), EntityName, Color.Red, true, false, BoxedAggressive, 2f, EntityYaw, EntityPitch);
                                    }
                                }
                            }
                            break;



                        // Deer or Rabbit //
                        case 0x13: // Deer
                            if (ShowAnimals) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.DarkGreen, true, false, BoxedAnimals, 2f, EntityYaw, EntityPitch);
                            break;

                        case 0x55: // Rabbit
                            if (ShowAnimals) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.DarkGreen, true, false, BoxedAnimals, 2f, EntityYaw, EntityPitch);
                            break;

                        // Aggressive NPC (Wolf, Bear, Zombies) //
                        case 0x0C: // Zombies
                            if (ShowAggressive) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.Thistle, true, false, BoxedAggressive, 2f, EntityYaw, EntityPitch);
                            break;

                        case 0x5b: // Zombies
                            if (ShowAggressive) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.Red, true, false, BoxedAggressive, 2f, EntityYaw, EntityPitch);
                            break;

                        case 0x14: // Wolf
                            if (ShowAggressive) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.Red, true, false, BoxedAggressive, 2f, EntityYaw, EntityPitch);
                            break;

                        case 0x50: // Bear
                            if (ShowAggressive) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.Red, true, false, BoxedAggressive, 2f, EntityYaw, EntityPitch);
                            break;

                        case 0x2E: // Loot
                            if (ShowESP && ShowRoot) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName + "\n" + "[" + EntityType.ToString("X2") + "]" + "[" + EntityType.ToString("X4") + "]", Color.GreenYellow, true, false, BoxedItems, 0.15f, 0.15f, 0.15f);
                            break;

                            /*  if (ShowRoot)
                              {
                              if (IsCorpse == false)
                                  {
                                      if (ShowESP && ShowItems) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.GreenYellow, true, false, BoxedItems, 1f, EntityYaw, EntityPitch);
                                  }
                              else if (ShowCorpse == true)
                                  {
                                      this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), currentEntity.Name, Color.Olive, true, false, BoxedItems, 1f, EntityYaw, EntityPitch);
                                  }
                              }*/
                            break;

                        case 0x1B: // Campfire
                        case 0x6D: // Stash
                        case 0x9C: // Land Mine
                            if (ShowESP && ShowItems && !BRMode) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.SaddleBrown, true, false, BoxedItems, 0.15f, 0.15f, 0.15f);
                            break;

                        case 0x2F: // Furnace //
                        case 0x33: // Storage Container
                        case 0x35: // Animal Trap
                        case 0x36: // Dew Collector
                        case 0x53: // Barbeque
                            if (ShowESP && ShowContainers) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.Gray, true, false, BoxedItems, 0.15f, 0.15f, 0.15f);
                            break;

                        case 0x34: // Weapons
                            if (ShowESP && ShowWeapons)
                            {
                                if (EntityName.Contains("M1911") || EntityName.Contains("AR15") || EntityName.Contains(".308 Hunting Rifle") || EntityName.Contains("12GA Pump Shotgun") || EntityName.Contains("M9") || EntityName.Contains("R380") || EntityName.Contains("Recurve Bow") || EntityName.Contains("Crowbar"))
                                    this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName + "\n" + "[" + EntityType.ToString("X2") + "]", Color.GreenYellow, true, false, BoxedItems, 1f, 0f, 0f);
                            }
                            break;


                        case 0x15: // Ammo
                            if (ShowESP && ShowAmmo)
                            {
                                if (EntityName.Contains(".45 Round") || EntityName.Contains(".308 Round") || EntityName.Contains(".223 Round") || EntityName.Contains("Shotgun Shell") || EntityName.Contains(".380 round") || EntityName.Contains("9mm Round"))
                                {
                                    this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.Orange, true, false, BoxedItems, 1f, 0f, 0f);
                                }
                                else
                                    this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.Moccasin, true, false, BoxedItems, 1f, 0f, 0f);
                            }

                            break;

                        case 0x11: // OffRoad
                        case 0x72: // Pickup
                        case 0x76: // PoliceCar
                            if (ShowESP && ShowVehicles)
                            {
                                if (EntityType == 0x11 || EntityType == 0x72 || EntityType == 0x76)
                                {
                                    if (ShowVehicles) this.EntityToScreen(new Vector3(EntityX, EntityY + 1f, EntityZ), EntityName, Color.HotPink, true, false, BoxedVehicles, 2f, EntityYaw, EntityPitch);
                                }
                            }
                            if (ShowESP && ShowVehicles) this.EntityToScreen(new Vector3(EntityX, EntityY + 1f, EntityZ), EntityName, Color.HotPink, true, false, BoxedVehicles, 2f, 0f, 0f);
                            break;

                        case 0x2C: // Resources, Battary, Turbo, Sparkplugs 
                            if (ShowESP && ShowItems)
                            {
                                if (ShowFirstAid || ShowBackpack || ShowHelmet)
                                {
                                    if (ShowFirstAid && EntityName.Contains("First"))
                                        this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.LimeGreen, true, false, BoxedItems, 0.15f, 0.15f, 0.15f);
                                    if (ShowBackpack && EntityName.Contains("Backpack") || EntityName.Contains("Waist Pack"))
                                        this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.CornflowerBlue, true, false, BoxedItems, 0.15f, 0.15f, 0.15f);
                                    if (ShowHelmet && EntityName.Contains("Helmet") || EntityName.Contains("Body Armor"))  
                                        this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.IndianRed, true, false, BoxedItems, 0.15f, 0.15f, 0.15f);
                                }
                                else
                                {
                                    if (EntityName.Contains("Battery") || EntityName.Contains("Turbo") || EntityName.Contains("Headlights") || EntityName.Contains("Sparkplugs"))
                                    {
                                        this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.Plum, true, false, BoxedItems, 0.15f, 0.15f, 0.15f);
                                    }
                                    else
                                        this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.White, true, false, BoxedItems, 0.15f, 0.15f, 0.15f);
                                }
                            }
                            break;
                            
                        case 0x16: // Dresser
                        case 0x17: // Armoire
                        case 0x19: // World Doors
                        case 0x1D: // Cabinets
                        case 0x1E: // Cabinets
                        case 0x21: // Cabinets
                        case 0x22: // Cabinets
                        case 0x23: // Cabinets
                        case 0x25: // Refrigerator
                        case 0x26: // Garbage Can
                        case 0x28: // Cabinets
                        case 0x29: // Desk
                        case 0x27: // Dumpster
                        case 0x30: // File Cabinet
                        case 0x31: // Tool Cabinet
                        case 0x37: // Recycle Bin (with fire)
                        case 0x38: // Punji Sticks
                        case 0x3D: // Wooded Barricade
                        case 0x3E: // Water Well
                        case 0x3F: // Armoire
                        case 0x40: // Dresser
                        case 0x42: // Chest
                        case 0x44: // Wrecked Sedan
                        case 0x45: // Wrecked Van
                        case 0x46: // Wrecked Truck
                        case 0x49: // Ottoman
                        case 0x4A: // Ottoman
                        case 0x4F: // Designer-placed(?) Door
                        case 0x5D: // File Cabinet
                        case 0x61: // Cabinets
                        case 0x63: // Cabinets
                        case 0x6F: // Locker
                        case 0x70: // Weapon Locker
                        case 0x71: // Glass Cabinet
                        case 0x79: // Designer-placed(?) Door
                        case 0x7A: // Resting (Bed)
                        case 0x7B: // Designer-placed(?) Door
                        case 0x7C: // Designer-placed(?) Door
                        case 0x80: // Cabinets
                        case 0x81: // Cabinets
                        case 0x82: // Cabinets
                        case 0x83: // Cabinets
                        case 0x84: // Cabinets
                        case 0x85: // Cabinets
                        case 0x86: // Cabinets
                        case 0x87: // Cabinets
                        case 0x88: // Cabinets
                        case 0x8D: // Military_Cache
                        case 0x8F: // BR_Military_Cache
                        case 0xA1: // Washing Machine
                        case 0xA2: // Dryer
                        case 0x7D: // IO.FireHydrant
                        case 0x7E: // IO.FireHydrant
                            //this.WorldToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName + "[" + EntityId.ToString("X2") + "]", Color.Gray, true, false, false, 0f, 0f);
                            break;
                        case 0x8E: // 空頭
                            if (ShowESP && ShowItems && !BRMode) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName, Color.SaddleBrown, true, false, BoxedItems, 0.15f, 0.15f, 0.15f);
                            break;
                        case 0x4C: // Shed
                        case 0x5F: // Metal Wall/Gate
                        case 0x62: // Basic Shack Door
                        case 0x6E: // Desk Foundation
                        case 0x9E: // Metal Door
                        case 0xA6: // Large Shelter
                        case 0xA7: // Shed
                            //this.WorldToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName + "[" + EntityId.ToString("X2") + "]", Color.Gray, true, false, false, 0f, 0f);
                            break;
                            /*  // display EntityType //
                            if (ShowESP) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), "\n" + "[" + EntityType + "]" + "[" + EntityType.ToString("X2") + "]", Color.Red, true, false, false, 1f, 0.30f, 0.30f);
                            break;*/
                        case 0x2A: //手銬key
                            if (ShowAmmo)
                            {
                              this.EntityToScreen(new Vector3(EntityX, EntityY + 1f, EntityZ), EntityName, Color.White, true, false, BoxedVehicles, 2f, EntityYaw, EntityPitch);
                            }
                            break;
                         default: // Other Items
                      /*  if (ShowESP && ShowItems && !BRMode) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName + "[" + EntityType.ToString("X2") + "]" + "\n" + "[" + EntityType + "]", Color.White, true, false, false, 0.15f, 0.30f, 0.30f);
                        break; // +"\n"+"["+ EntityType +"]"*/
                        // display EntityType //
                            if (Convert.ToBoolean(Native.GetAsyncKeyState(Keys.XButton2) & 0x8000) == true) this.EntityToScreen(new Vector3(EntityX, EntityY, EntityZ), EntityName + "\n" + "[" + EntityType.ToString("X2") + "]" + "[" + EntityType.ToString("X4") + "]", Color.Red, true, false, false, 2f, EntityYaw, EntityPitch);
                        break;
                        
                    }
                    entityEntry = this.GameMemory.ReadInt64(entityEntry + 0x410);
                }

                if (Aimed == false) AimedEntity = null;

                if (ShowEntityLists)
                {
                    ENTITY[] playerList = Entity.Where(E => E.Type == 0x04 || E.Type == 0x05).OrderBy(E => E.Distance).ToArray();
                    ENTITY[] aggressiveList = Entity.Where(E => E.Type == 0x0C || E.Type == 0x14 || E.Type == 0x50 || E.Type == 0x5b).OrderBy(E => E.Distance).ToArray();
                    ENTITY[] animalsList = Entity.Where(E => E.Type == 0x13 || E.Type == 0x55).OrderBy(E => E.Distance).ToArray();
                    ENTITY[] vehiclesList = Entity.Where(E => E.Type == 0x11 || E.Type == 0x72 || E.Type == 0x76).OrderBy(E => E.Distance).ToArray();
                    ENTITY[] ammoList = Entity.Where(E => E.Type == 0x15).OrderBy(E => E.Distance).ToArray();
                    
                    int itemY = (aggressiveList.Length > 10 ? 150 : aggressiveList.Length * 15);
                    foreach (ENTITY entity in aggressiveList)
                    {
                        DrawText(entity.Name + " [" + Math.Round(entity.Distance).ToString() + " m]", this.GameWindowRect.Left + 20, this.GameWindowRect.Bottom - itemY - 15, Color.Red);
                        itemY -= 15; if (itemY <= 0) break;
                    }

                    itemY = (animalsList.Length > 10 ? 150 : animalsList.Length * 15);
                    foreach (ENTITY entity in animalsList)
                    {
                        DrawText(entity.Name + " [" + Math.Round(entity.Distance).ToString() + " m]", this.GameWindowRect.Left + 120, this.GameWindowRect.Bottom - itemY - 15, Color.Green);
                        itemY -= 15; if (itemY <= 0) break;
                    }

                    itemY = (vehiclesList.Length > 10 ? 150 : vehiclesList.Length * 15);
                    foreach (ENTITY entity in vehiclesList)
                    {
                        DrawText(entity.Name + " [" + Math.Round(entity.Distance).ToString() + " m]", this.GameWindowRect.Left + 220, this.GameWindowRect.Bottom - itemY - 15, Color.HotPink);
                        itemY -= 15; if (itemY <= 0) break;
                    }

                    itemY = (playerList.Length > 10 ? 150 : playerList.Length * 15);
                    foreach (ENTITY entity in playerList)
                    {
                        DrawText(entity.Name + " [" + Math.Round(entity.Distance).ToString() + " m]", this.GameWindowRect.Left + 340, this.GameWindowRect.Bottom - itemY - 15, Color.SkyBlue);
                        itemY -= 15; if (itemY <= 0) break;
                    }
                    itemY = (ammoList.Length > 10 ? 150 : ammoList.Length * 15);
                    foreach (ENTITY entity in ammoList)
                    {
                        DrawText(entity.Name + " [" + Math.Round(entity.Distance).ToString() + " m]", this.GameWindowRect.Left + 440, this.GameWindowRect.Bottom - itemY - 15, Color.Orange);
                        itemY -= 15; if (itemY <= 0) break;
                    }

                }

                /*
                if (ShowRadar)
                {
                    DrawFilledBox(this.GameWindowRect.Right - 225, this.GameWindowRect.Top + 50, 201f, 201f, Color.LightSlateGray, RadarTransparency);
                    DrawBoxAbs(this.GameWindowRect.Right - 225, this.GameWindowRect.Top + 50, 201f, 201f, 1f, Color.Black);
                    DrawLine(this.GameWindowRect.Right - 125, this.GameWindowRect.Top + 50, this.GameWindowRect.Right - 125, this.GameWindowRect.Top + 251, 1f, Color.Black);
                    DrawLine(this.GameWindowRect.Right - 225, this.GameWindowRect.Top + 150, this.GameWindowRect.Right - 24, this.GameWindowRect.Top + 150, 1f, Color.Black);
                    RadarCenter = new Vector2(this.GameWindowRect.Right - 125, this.GameWindowRect.Top + 125 + 25);
                    DrawFilledBox(RadarCenter.X - 1f, RadarCenter.Y - 1f, 3f, 3f, Color.White);
                    if (RadarCenter.Length() > 0f)
                    {
                        foreach (ENTITY entity in Entity)
                        {
                            Vector2 pointToRotate = new Vector2(entity.Pos.X, entity.Pos.Z);
                            Vector2 vector3 = new Vector2(player_X, player_Z);
                            pointToRotate = vector3 - pointToRotate;
                            float num30 = pointToRotate.Length() * 0.5f;
                            num30 = Math.Min(num30, 90f);
                            pointToRotate.Normalize();
                            pointToRotate = (Vector2)(pointToRotate * num30);
                            pointToRotate += RadarCenter;
                            pointToRotate = RotatePoint(pointToRotate, RadarCenter, player_D, true);
                            if ((entity.Type == 0x04 || entity.Type == 0x05) && RadarPlayers)
                            {
                                DrawFilledBox(pointToRotate.X, pointToRotate.Y, 3f, 3f, Color.SkyBlue);
                            }
                            if ((entity.Type == 0x0C || entity.Type == 0x14 || entity.Type == 0x50 || entity.Type == 0x5b) && RadarAggressive)
                            {
                                DrawFilledBox(pointToRotate.X, pointToRotate.Y, 3f, 3f, Color.Red);
                            }
                            if ((entity.Type == 0x13 || entity.Type == 0x55) && RadarAnimals)
                            {
                                DrawFilledBox(pointToRotate.X, pointToRotate.Y, 3f, 3f, Color.LightGreen);
                            }
                            if ((entity.Type == 0x11 || entity.Type == 0x72 || entity.Type == 0x76) && RadarVehicles)
                            {
                                //DrawFilledBox(pointToRotate.X, pointToRotate.Y, 3f, 3f, Color.HotPink);
                                DrawBox(pointToRotate.X, pointToRotate.Y, 3f, 3f, 1f, Color.HotPink);
                            }
                        }
                    }
                }
                */
                if (ShowRadar)
                {
                    if (RadarMap)
                    {
                        int marginRight = 50; int marginTop = 50; // place the radar in the top right (-50px) corner of the screen
                        int radarRadius = 128; // max display distance in [m]
                        float mapScale = 0.5f; // = Texture.Width / 8192f  (if you use image of size 4096x4096 then mapScale = 0.5f, if 2048x2048 then mapScale = 0.25f)

                        if (DXTextureGameMap != null)
                        {
                            Matrix mRT = Matrix.RotationZ(-(player_D - 1.57079632679f)) * Matrix.Translation(-this.Width / 2 + GameWindowRect.Right - marginRight - radarRadius, this.Height / 2 - GameWindowRect.Top - marginTop - radarRadius, 0);
                            Matrix mView = Matrix.Identity;
                            Matrix mProj = Matrix.OrthoLH(this.Width, this.Height, 0f, 1.0f);
                            DXDevice.SetTransform(TransformState.World, mRT);
                            DXDevice.SetTransform(TransformState.View, mView);
                            DXDevice.SetTransform(TransformState.Projection, mProj);

                            // Transform in-game player position to the image map, (x,y) in [-4096,4096]x[-4096,4096]->[0,4096]x[0,4096]
                            float mapX = (4096 + player_Z) * mapScale;
                            float mapY = (4096 - player_X) * mapScale;

                            // and now to texture coordinates [0,4096] -> [0,1]
                            mapX = mapX / (float)4096;
                            mapY = mapY / (float)4096;
                            Vector2 playerPosition = new Vector2(mapX, mapY);
                            float scale = radarRadius / (float)4096;
                            DataStream stream = CircleVertices.Lock(0, 0, LockFlags.None);
                            stream.WriteRange(BuildVertexCircle(Vector2.Zero, playerPosition, radarRadius, scale, circleComplexity));
                            CircleVertices.Unlock();
                            DXDevice.SetStreamSource(0, CircleVertices, 0, TexVertex.SizeBytes);
                            DXDevice.VertexFormat = TexVertex.Format;
                            DXDevice.SetTexture(0, DXTextureGameMap);
                            /* alpha blending not working as expected
                            DXDevice.SetRenderState(RenderState.AlphaBlendEnable, true);
                            DXDevice.SetRenderState(RenderState.SourceBlend, SlimDX.Direct3D9.Blend.BlendFactor);
                            DXDevice.SetRenderState(RenderState.BlendFactor, 0xffffff);
                            */
                            DXDevice.SetSamplerState(0, SamplerState.MinFilter, TextureFilter.Linear);
                            DXDevice.SetSamplerState(0, SamplerState.MagFilter, TextureFilter.Linear);
                            DXDevice.SetSamplerState(0, SamplerState.MipFilter, TextureFilter.Linear);
                            DXDevice.DrawPrimitives(PrimitiveType.TriangleFan, 0, circleComplexity);

                        }
                        else // just paint green background
                        {
                            DrawFilledBox(this.GameWindowRect.Right - marginRight - radarRadius * 2, this.GameWindowRect.Top + marginTop, radarRadius * 2, radarRadius * 2, Color.DarkOliveGreen, RadarTransparency);
                            DrawBoxAbs(this.GameWindowRect.Right - marginRight - radarRadius * 2, this.GameWindowRect.Top + marginTop, radarRadius * 2, radarRadius * 2, 1f, Color.Black);
                        }
                        RadarCenter = new Vector2(this.GameWindowRect.Right - marginRight - radarRadius, this.GameWindowRect.Top + marginTop + radarRadius);
                        if (RadarCenter.Length() > 0f)
                        {
                            // vertical line
                            DrawLine(RadarCenter.X, this.GameWindowRect.Top + marginTop, RadarCenter.X, this.GameWindowRect.Top + marginTop + radarRadius * 2, 1f, Color.Black);
                            // horizontal line
                            DrawLine(this.GameWindowRect.Right - marginRight - radarRadius * 2, RadarCenter.Y, this.GameWindowRect.Right - marginRight, RadarCenter.Y, 1f, Color.Black);
                            // center point
                            DrawFilledBox(RadarCenter.X - 1f, RadarCenter.Y - 1f, 3f, 3f, Color.White);

                            if (RadarLine)
                            {
                                //動物
                                DrawLine(RadarCenter.X - 3, RadarCenter.Y - 10, RadarCenter.X + 3, RadarCenter.Y - 10, 1f, Color.White);
                                DrawLine(RadarCenter.X - 3, RadarCenter.Y + 10, RadarCenter.X + 3, RadarCenter.Y + 10, 1f, Color.White);

                                DrawLine(RadarCenter.X - 10, RadarCenter.Y - 3, RadarCenter.X - 10, RadarCenter.Y + 3, 1f, Color.White);
                                DrawLine(RadarCenter.X + 10, RadarCenter.Y - 3, RadarCenter.X + 10, RadarCenter.Y + 3, 1f, Color.White);

                                //物品
                                DrawLine(RadarCenter.X - 5, RadarCenter.Y - 80, RadarCenter.X + 5, RadarCenter.Y - 80, 1f, Color.White);
                                DrawLine(RadarCenter.X - 5, RadarCenter.Y + 80, RadarCenter.X + 5, RadarCenter.Y + 80, 1f, Color.White);

                                DrawLine(RadarCenter.X - 80, RadarCenter.Y - 5, RadarCenter.X - 80, RadarCenter.Y + 5, 1f, Color.White);
                                DrawLine(RadarCenter.X + 80, RadarCenter.Y - 5, RadarCenter.X + 80, RadarCenter.Y + 5, 1f, Color.White);
                            }



                            //Display each entity in correct relational position
                            foreach (ENTITY entity in Entity)
                            {
                                if (entity.Type == 0x04 || entity.Type == 0x05 || entity.Type == 0x0C || entity.Type == 0x14 || entity.Type == 0x50 || entity.Type == 0x5b || entity.Type == 0x0C || entity.Type == 0x14 || entity.Type == 0x50 || entity.Type == 0x5b || entity.Type == 0x13 || entity.Type == 0x55 || entity.Type == 0x11 || entity.Type == 0x72 || entity.Type == 0x76)
                                {
                                    Vector2 pointToRotate = new Vector2(entity.Pos.X, entity.Pos.Z);
                                    Vector2 playerPosition = new Vector2(player_X, player_Z);

                                    pointToRotate = playerPosition - pointToRotate;
                                    float distance = pointToRotate.Length();
                                    distance = Math.Min(distance, (float)radarRadius * 2);
                                    pointToRotate.Normalize();
                                    pointToRotate = (Vector2)(pointToRotate * distance * mapScale);

                                    pointToRotate += RadarCenter;
                                    pointToRotate = RotatePoint(pointToRotate, RadarCenter, player_D, true);
                                    if ((entity.Type == 0x05 || entity.Type == 0x04) && RadarPlayers)
                                    {
                                        DrawFilledBox(pointToRotate.X, pointToRotate.Y, 4f, 4f, Color.Black);
                                        DrawFilledBox(pointToRotate.X, pointToRotate.Y, 3f, 3f, Color.DeepSkyBlue);
                                    }
                                    if ((entity.Type == 0x0C || entity.Type == 0x14 || entity.Type == 0x50 || entity.Type == 0x5b) && RadarAggressive)
                                    {
                                        DrawFilledBox(pointToRotate.X, pointToRotate.Y, 3f, 3f, Color.Red);
                                    }
                                    if ((entity.Type == 0x13 || entity.Type == 0x55) && RadarAnimals)
                                    {
                                        DrawFilledBox(pointToRotate.X, pointToRotate.Y, 3f, 3f, Color.LightGreen);
                                    }
                                    if ((entity.Type == 0x11 || entity.Type == 0x72 || entity.Type == 0x76) && RadarVehicles)
                                    {
                                        DrawBox(pointToRotate.X, pointToRotate.Y, 4f, 4f, 2f, Color.HotPink);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        DrawFilledBox(this.GameWindowRect.Right - 225, this.GameWindowRect.Top + 50, 201f, 201f, Color.DimGray, RadarTransparency);
                        DrawBoxAbs(this.GameWindowRect.Right - 225, this.GameWindowRect.Top + 50, 201f, 201f, 1f, Color.Black);
                        DrawLine(this.GameWindowRect.Right - 125, this.GameWindowRect.Top + 50, this.GameWindowRect.Right - 125, this.GameWindowRect.Top + 251, 1f, Color.Black);
                        DrawLine(this.GameWindowRect.Right - 225, this.GameWindowRect.Top + 150, this.GameWindowRect.Right - 24, this.GameWindowRect.Top + 150, 1f, Color.Black);
                        RadarCenter = new Vector2(this.GameWindowRect.Right - 125, this.GameWindowRect.Top + 125 + 25);
                        DrawFilledBox(RadarCenter.X - 1f, RadarCenter.Y - 1f, 3f, 3f, Color.White);


                        if (RadarCenter.Length() > 0f)
                        {
                            foreach (ENTITY entity in Entity)
                            {

                                Vector2 pointToRotate = new Vector2(entity.Pos.X, entity.Pos.Z);
                                Vector2 vector3 = new Vector2(player_X, player_Z);
                                pointToRotate = vector3 - pointToRotate;
                                float num30 = pointToRotate.Length() * 0.5f;
                                num30 = Math.Min(num30, 90f);
                                pointToRotate.Normalize();
                                pointToRotate = (Vector2)(pointToRotate * num30);
                                pointToRotate += RadarCenter;
                                pointToRotate = RotatePoint(pointToRotate, RadarCenter, player_D, true);


                                if ((entity.Type == 0x04 || entity.Type == 0x05) && RadarPlayers)
                                {
                                    DrawFilledBox(pointToRotate.X, pointToRotate.Y, 3f, 3f, Color.SkyBlue);
                                }

                                if ((entity.Type == 0x0C || entity.Type == 0x14 || entity.Type == 0x50 || entity.Type == 0x5b) && RadarAggressive)
                                {
                                    DrawFilledBox(pointToRotate.X, pointToRotate.Y, 3f, 3f, Color.Red);
                                }
                                if ((entity.Type == 0x13 || entity.Type == 0x55) && RadarAnimals)
                                {
                                    DrawFilledBox(pointToRotate.X, pointToRotate.Y, 3f, 3f, Color.LightGreen);
                                }
                                if ((entity.Type == 0x11 || entity.Type == 0x72 || entity.Type == 0x76) && RadarVehicles)
                                {
                                    DrawFilledBox(pointToRotate.X, pointToRotate.Y, 3f, 3f, Color.HotPink);
                                }



                            }
                        }
                    }

                }

                if (ShowCities)
                {
                    this.EntityToScreen(new Vector3(-129f, 40f, -1146f), "Pleasant Valley", Color.HotPink, true, false, false, 1f, 0f, 0f);
                    this.EntityToScreen(new Vector3(-1233f, 90f, 1855f), "Cranberry", Color.HotPink, true, false, false, 1f, 0f, 0f);
                    this.EntityToScreen(new Vector3(2003f, 50f, 2221f), "Ranchito", Color.HotPink, true, false, false, 1f, 0f, 0f);
                }

                if (Main.ShowMap && (DXTextrureMap != null || DXTextrureMapLarge != null))
                {
                    DXSprite.Begin(SpriteFlags.AlphaBlend);
                    if (Main.ShowMapLarge && DXTextrureMapLarge != null)
                    {
                        map_pos_x = RemapValue(player_X, 4000f, -4000f, -512f, 512f);
                        map_pos_z = RemapValue(player_Z, -4000f, 4000f, -512f, 512f);
                        DXSprite.Draw(DXTextrureMapLarge, new Vector3(512f, 512f, 0f), new Vector3(this.GameWindowCenter.X, this.GameWindowCenter.Y, 0f), Color.FromArgb(MapTransparency, 0xff, 0xff, 0xff));
                    }
                    else if (DXTextrureMap != null)
                    {
                        map_pos_x = RemapValue(player_X, 4000f, -4000f, -265f, 265f);
                        map_pos_z = RemapValue(player_Z, -4000f, 4000f, -265f, 265f);
                        DXSprite.Draw(DXTextrureMap, new Vector3(256f, 256f, 0f), new Vector3(this.GameWindowCenter.X, this.GameWindowCenter.Y, 0f), Color.FromArgb(MapTransparency, 0xff, 0xff, 0xff));
                    }
                    DXSprite.End();
                    float direction = Main.player_D * -1f;
                    float fromX = (float)((this.GameWindowCenter.X + map_pos_z) + (20.0 * Math.Cos(direction)));
                    float fromY = (float)((this.GameWindowCenter.Y + map_pos_x) + (20.0 * Math.Sin(direction)));
                    DrawFilledBox((this.GameWindowCenter.X + map_pos_z) - 2f, (this.GameWindowCenter.Y + map_pos_x) - 2f, 6f, 6f, Color.Magenta);
                    DrawLine(fromX, fromY, (this.GameWindowCenter.X + map_pos_z) + 1f, (this.GameWindowCenter.Y + map_pos_x) + 1f, 1f, Color.PaleVioletRed);
                }

                DXDevice.EndScene();
                DXDevice.Present();
                Thread.Sleep(1);
            }
            DXDevice.Dispose();
            Application.Exit();
        }

        public void DoAiming()
        {
            while (true)
            {
                if (Aimed == true && AimedEntity != null)
                {

                }
                Thread.Sleep(1);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x312)
            {
                switch ((int)m.WParam)
                {
                    case 0:
                        if (this.Settings != null && this.Settings.Visible)
                        {
                            this.Settings.Close();
                            break;
                        }
                        this.Settings = new Settings(); this.Settings.Show();
                        this.Settings.Location = new Point(this.GameWindowRect.Right - this.Settings.Width - 20, this.GameWindowRect.Top + 200);
                        Native.SetForegroundWindow(this.GameMemory.Process.MainWindowHandle);
                        break;

                    case 1:
                        ShowRadar = !ShowRadar;
                        Main.Ini.IniWriteValue("Radar", "Show", ShowRadar.ToString());
                        break;

                    case 2:
                        ShowMap = !ShowMap;
                        break;

                    case 3:
                        ShowMapLarge = !ShowMapLarge;
                        Main.Ini.IniWriteValue("Map", "LargeMap", Main.ShowMapLarge.ToString());
                        break;

                    case 4:
                        Main.IsRunning = false;
                        break;
                }
            }
            base.WndProc(ref m);
        }

        public static void MoveMouse(int xDelta, int yDelta)
        {
            Native.mouse_event(1, xDelta, yDelta, 0u, 0u);
        }

        public static void MoveMouseTo(int x, int y)
        {
            Native.mouse_event(0x8000, x, y, 0, 0);
            Native.mouse_event(1, x, y, 0, 0);
        }
    }
}     
