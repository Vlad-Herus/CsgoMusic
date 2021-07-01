using OverlayPlayer.gl;
using OverlayPlayer.Key;
using OverlayPlayer.MenuItems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverlayPlayer
{
    public partial class Form1 : Form
    {
        Guid mDotHotkeyId;
        glGreenDot mDotManager;
        Menu mMenu = null;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            mVlume_bar.ValueChanged += MVlume_bar_ValueChanged;
            mMenu_txt.Text = ApplicationSettings.MenuFolder;
            mVlume_bar.Value = ApplicationSettings.Volume;
        }

        private void MVlume_bar_ValueChanged(object sender, EventArgs e)
        {
            ApplicationSettings.Volume = mVlume_bar.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mDotHotkeyId = HotKeyManager.RegisterHotKey(Keys.F2, KeyModifiers.Alt, new Action<Keys, KeyModifiers>((key, mod) =>
            {
                if (mDotManager != null)
                    StopDot();
                else
                    StartDot();
            }));

            HotKeyManager.RegisterHotKey(Keys.Q, KeyModifiers.Alt, new Action<Keys, KeyModifiers>((key, mod) =>
              {
                  if (mMenu != null)
                  {
                      mMenu.Dispose();
                      mMenu = null;
                  }
                  else
                  {
                      mMenu = new OverlayPlayer.Menu(new FolderItem(ApplicationSettings.MenuFolder).SubItems);
                  }
              }));
            }

        void StartDot()
        {
            if (mDotManager != null)
                StopDot();

            mDotManager = new glGreenDot();
        }

        void StopDot()
        {
            if (mDotManager != null)
            {
                mDotManager.Dispose();
                mDotManager = null;
            }
        }

        void Log(string line)
        {
            richTextBox1.AppendText($"{DateTime.Now.ToShortTimeString()}  {line}");
        }

        void Log(Exception ex)
        {
            Log(ex.ToString());
        }

        private void mMenu_txt_TextChanged(object sender, EventArgs e)
        {
            ApplicationSettings.MenuFolder = mMenu_txt.Text;
        }
    }
}
