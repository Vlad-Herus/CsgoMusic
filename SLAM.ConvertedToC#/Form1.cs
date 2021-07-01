using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using NAudio;
//Modified Version which does not write "extraSize"
using NAudio.Wave;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Management;
using System.Net.Http;
using SLAM;
using System.Windows.Forms;
using static SLAM.SourceGame;
using System.Linq;

namespace SLAM
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        List<SourceGame> Games = new List<SourceGame>();
        bool running = false;
        bool ClosePending = false;
        string SteamAppsPath;

        int status = IDLE;
        const int IDLE = -1;
        const int SEARCHING = -2;

        const int WORKING = -3;

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
            FormClosing += Form1_FormClosing;
            mGameSelector_combo.SelectedIndexChanged += GameSelector_SelectedIndexChanged;
            mImport_btn.Click += ImportButton_Click;
            mStart_btn.Click += StartButton_Click;
            mTracks_lst.MouseClick += TrackList_MouseClick;
            mRefresh_mItem.Click += ContextRefresh_Click;
            mDelete_mItem.Click += ContextDelete_Click;
            mSetBind_mItem.Click += ContextHotKey_Click;
            mRemoveBind_mItem.Click += RemoveHotkeyToolStripMenuItem_Click;
            mGoTo_mItem.Click += GoToToolStripMenuItem_Click;
            mSetVolume_mItem.Click += SetVolumeToolStripMenuItem_Click;
            mTrim_mItem.Click += TrimToolStripMenuItem_Click;
            mRename_mItem.Click += RenameToolStripMenuItem_Click;
            mPlayKey_btn.Click += PlayKeyButton_Click;
            mLoad_mItem.Click += LoadToolStripMenuItem_Click;
            mChangeDir_btn.Click += ChangeDirButton_Click;

            mImportSong_wrk.DoWork += WavWorker_DoWork;
            mImportSong_wrk.ProgressChanged += WavWorker_ProgressChanged;
            mImportSong_wrk.RunWorkerCompleted += WavWorker_RunWorkerCompleted;

            mPollRelay_wrk.DoWork += PollRelayWorker_DoWork;
            mPollRelay_wrk.ProgressChanged += PollRelayWorker_ProgressChanged;
            mPollRelay_wrk.RunWorkerCompleted += PollRelayWorker_RunWorkerCompleted;
        }

        #region Events

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshPlayKey();
            if (SLAM.Properties.Settings.Default.PlayKey == SLAM.Properties.Settings.Default.RelayKey)
            {
                SLAM.Properties.Settings.Default.RelayKey = "=";
                SLAM.Properties.Settings.Default.Save();
            }

            SourceGame csgo = new SourceGame();
            csgo.Name = "Counter-Strike: Global Offensive";
            csgo.Id = 730;
            csgo.Directory = "common\\Counter-Strike Global Offensive\\";
            csgo.ToCfg = "csgo\\cfg\\";
            csgo.Libraryname = "csgo\\";
            csgo.Exename = "csgo";
            csgo.Samplerate = 22050;
            csgo.Blacklist.AddRange(new string[]{
            "drop",
            "buy",
            "go",
            "fallback",
            "sticktog",
            "holdpos",
            "followme",
            "coverme",
            "regroup",
            "roger",
            "negative",
            "cheer",
            "compliment",
            "thanks",
            "enemydown",
            "reportingin",
            "enemyspot",
            "takepoint",
            "sectorclear",
            "inposition",
            "takingfire",
            "report",
            "getout"

        });
            csgo.VoiceFadeOut = false;
            Games.Add(csgo);

            SourceGame css = new SourceGame();
            css.Name = "Counter-Strike: Source";
            css.Directory = "common\\Counter-Strike Source\\";
            css.ToCfg = "cstrike\\cfg\\";
            css.Libraryname = "css\\";
            Games.Add(css);

            SourceGame tf2 = new SourceGame();
            tf2.Name = "Team Fortress 2";
            tf2.Directory = "common\\Team Fortress 2\\";
            tf2.ToCfg = "tf\\cfg\\";
            tf2.Libraryname = "tf2\\";
            tf2.Samplerate = 22050;
            Games.Add(tf2);

            SourceGame gmod = new SourceGame();
            gmod.Name = "Garry's Mod";
            gmod.Directory = "common\\GarrysMod\\";
            gmod.ToCfg = "garrysmod\\cfg\\";
            gmod.Libraryname = "gmod\\";
            Games.Add(gmod);

            SourceGame hl2dm = new SourceGame();
            hl2dm.Name = "Half-Life 2 Deathmatch";
            hl2dm.Directory = "common\\half-life 2 deathmatch\\";
            hl2dm.ToCfg = "hl2mp\\cfg\\";
            hl2dm.Libraryname = "hl2dm\\";
            Games.Add(hl2dm);

            SourceGame l4d = new SourceGame();
            l4d.Name = "Left 4 Dead";
            l4d.Directory = "common\\Left 4 Dead\\";
            l4d.ToCfg = "left4dead\\cfg\\";
            l4d.Libraryname = "l4d\\";
            l4d.Exename = "left4dead";
            Games.Add(l4d);

            SourceGame l4d2 = new SourceGame();
            l4d2.Name = "Left 4 Dead 2";
            l4d2.Directory = "common\\Left 4 Dead 2\\";
            l4d2.ToCfg = "left4dead2\\cfg\\";
            l4d2.Libraryname = "l4d2\\";
            l4d2.Exename = "left4dead2";
            l4d2.VoiceFadeOut = false;
            Games.Add(l4d2);

            SourceGame dods = new SourceGame();
            dods.Name = "Day of Defeat Source";
            dods.Directory = "common\\day of defeat source\\";
            dods.ToCfg = "dod\\cfg\\";
            dods.Libraryname = "dods\\";
            Games.Add(dods);

            //NEEDS EXENAME!!!
            //Dim goldeye As New SourceGame
            //goldeye.name = "Goldeneye Source"
            //goldeye.directory = "sourcemods\"
            //goldeye.ToCfg = "gesource\cfg\"
            //goldeye.libraryname = "goldeye\"
            //Games.Add(goldeye)

            SourceGame insurg = new SourceGame();
            insurg.Name = "Insurgency";
            insurg.Directory = "common\\insurgency2\\";
            insurg.ToCfg = "insurgency\\cfg\\";
            insurg.Libraryname = "insurgen\\";
            insurg.Exename = "insurgency";
            Games.Add(insurg);

            foreach (var Game in Games)
            {
                mGameSelector_combo.Items.Add(Game.Name);
            }

            if (mGameSelector_combo.Items.Contains(SLAM.Properties.Settings.Default.LastGame))
            {
                mGameSelector_combo.Text = mGameSelector_combo.Items[mGameSelector_combo.Items.IndexOf(SLAM.Properties.Settings.Default.LastGame)].ToString();
            }
            else
            {
                mGameSelector_combo.Text = mGameSelector_combo.Items[0].ToString();
            }

            ReloadTracks(GetCurrentGame());
            RefreshTrackList();

            if (SLAM.Properties.Settings.Default.StartEnabled)
            {
                StartPoll();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (running)
            {
                StopPoll();
                ClosePending = true;
                e.Cancel = true;
            }
        }

        private void GameSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadTracks(GetCurrentGame());
            RefreshTrackList();
            SLAM.Properties.Settings.Default.LastGame = mGameSelector_combo.Text;
            SLAM.Properties.Settings.Default.Save();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (File.Exists("NAudio.dll"))
            {
                DisableInterface();
                if (mImportFile_dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    mStatus_progress.Maximum = mImportFile_dlg.FileNames.Count();
                    object[] WorkerPassthrough = {
                    GetCurrentGame(),
                    mImportFile_dlg.FileNames
                };
                    mImportSong_wrk.RunWorkerAsync(WorkerPassthrough);
                }
                else
                {
                    EnableInterface();
                }

            }
            else
            {
                MessageBox.Show("You are missing NAudio.dll! Cannot import without it!", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (running)
            {
                StopPoll();
            }
            else
            {
                StartPoll();
                if (!SLAM.Properties.Settings.Default.NoHint)
                {
                    if (MessageBox.Show("Don't forget to type \"exec slam\" in console! Click \"Cancel\" if you don't ever want to see this message again.", "SLAM", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        SLAM.Properties.Settings.Default.NoHint = true;
                        SLAM.Properties.Settings.Default.Save();
                    }
                }
            }
        }

        private void TrackList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                if (mTracks_lst.FocusedItem.Bounds.Contains(e.Location))
                {
                    //everything invisible
                    foreach (ToolStripMenuItem item in mTrack_menu.Items)
                        item.Visible = false;

                    mSetVolume_mItem.Visible = true;
                    //always visible
                    mRefresh_mItem.Visible = true;

                    if (mTracks_lst.SelectedItems.Count > 1)
                    {
                        //visible when multiple selected AND is not running
                        if (!running)
                        {
                            mDelete_mItem.Visible = true;
                        }

                    }
                    else
                    {
                        if (running)
                        {
                            mTrim_mItem.Visible = true;
                            //visible when only one selected AND is running
                            if (status == WORKING)
                            {
                                mLoad_mItem.Visible = true;
                            }
                        }
                        else
                        {
                            //visible when only one selected AND is not running (all)
                            foreach (ToolStripMenuItem item in mTrack_menu.Items)
                                item.Visible = true;

                            mLoad_mItem.Visible = false;
                        }

                    }
                    //Maybe I should have used a case... Maybe...

                }



                mTrack_menu.Show(Cursor.Position);
            }
        }

        private void ContextRefresh_Click(object sender, EventArgs e)
        {
            ReloadTracks(GetCurrentGame());
            RefreshTrackList();
        }

        private void ContextDelete_Click(object sender, EventArgs e)
        {
            SourceGame game = GetCurrentGame();

            List<string> SelectedNames = new List<string>();
            foreach (ListViewItem item in mTracks_lst.SelectedItems)
                SelectedNames.Add(item.SubItems[1].Text);


            if (MessageBox.Show(string.Format("Are you sure you want to delete {0}?", string.Join(", ", SelectedNames)), "Delete Track?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var item in SelectedNames)
                {
                    string FilePath = Path.Combine(game.Libraryname, item + game.FileExtension);

                    if (File.Exists(FilePath))
                    {
                        try
                        {
                            File.Delete(FilePath);
                        }
                        catch (Exception ex)
                        {
                            LogError(ex);
                            Interaction.MsgBox(string.Format("Failed to delete {0}.", FilePath));
                        }
                    }
                }

            }

            ReloadTracks(GetCurrentGame());
            RefreshTrackList();
        }

        private void ContextHotKey_Click(object sender, EventArgs e)
        {
            SelectKey SelectKeyDialog = new SelectKey();
            var SelectedIndex = mTracks_lst.SelectedItems[0].Index;
            if (SelectKeyDialog.ShowDialog() == DialogResult.OK)
            {
                var Game = GetCurrentGame();

                bool KeyIsFree = true;
                foreach (var track in Game.Tracks)
                {
                    //Checking to see if any other track is already using this key
                    if (track.Hotkey == SelectKeyDialog.ChosenKey)
                    {
                        KeyIsFree = false;
                    }
                }

                if (KeyIsFree)
                {
                    Game.Tracks[SelectedIndex].Hotkey = SelectKeyDialog.ChosenKey;
                    SaveTrackKeys(GetCurrentGame());
                    ReloadTracks(GetCurrentGame());
                    RefreshTrackList();
                }
                else
                {
                    MessageBox.Show(string.Format("\"{0}\" has already been assigned!", SelectKeyDialog.ChosenKey), "Invalid Key");
                }


            }
        }

        private void RemoveHotkeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem SelectedIndex in mTracks_lst.SelectedItems)
            {
                var Game = GetCurrentGame();
                Game.Tracks[SelectedIndex.Index].Hotkey = Constants.vbNullString;
                SaveTrackKeys(GetCurrentGame());
                ReloadTracks(GetCurrentGame());

            }
            RefreshTrackList();
        }

        private void GoToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SourceGame Games = GetCurrentGame();
            string FilePath = Path.Combine(Games.Libraryname, Games.Tracks[mTracks_lst.SelectedItems[0].Index].Name + Games.FileExtension);


            string Args = string.Format("/Select, \"{0}\"", FilePath);
            ProcessStartInfo pfi = new ProcessStartInfo("Explorer.exe", Args);

            System.Diagnostics.Process.Start(pfi);
        }

        private void SetVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetVolume SetVolumeDialog = new SetVolume();


            if (SetVolumeDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (int index in mTracks_lst.SelectedIndices)
                {
                    GetCurrentGame().Tracks[index].Volume = SetVolumeDialog.Volume;
                }
                SaveTrackKeys(GetCurrentGame());
                ReloadTracks(GetCurrentGame());
                RefreshTrackList();

            }

        }

        private void TrimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SourceGame Game = GetCurrentGame();
            TrimForm TrimDialog = new TrimForm();

            TrimDialog.WavFile = Path.Combine(Game.Libraryname, Game.Tracks[mTracks_lst.SelectedIndices[0]].Name + Game.FileExtension);
            TrimDialog.startpos = Game.Tracks[mTracks_lst.SelectedIndices[0]].Startpos;
            TrimDialog.endpos = Game.Tracks[mTracks_lst.SelectedIndices[0]].Endpos;


            if (TrimDialog.ShowDialog() == DialogResult.OK)
            {
                Game.Tracks[mTracks_lst.SelectedIndices[0]].Startpos = TrimDialog.startpos;
                Game.Tracks[mTracks_lst.SelectedIndices[0]].Endpos = TrimDialog.endpos;
                SaveTrackKeys(GetCurrentGame());
                ReloadTracks(GetCurrentGame());
                RefreshTrackList();
            }
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SourceGame Game = GetCurrentGame();
            RenameForm RenameDialog = new RenameForm();
            SourceGame.Track SelectedTrack = GetCurrentGame().Tracks[mTracks_lst.SelectedIndices[0]];

            RenameDialog.filename = SelectedTrack.Name;

            if (RenameDialog.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    FileSystem.Rename(Game.Libraryname + SelectedTrack.Name + Game.FileExtension, Game.Libraryname + RenameDialog.filename + Game.FileExtension);
                    GetCurrentGame().Tracks[mTracks_lst.SelectedIndices[0]].Name = RenameDialog.filename;

                    SaveTrackKeys(GetCurrentGame());
                    ReloadTracks(GetCurrentGame());
                    RefreshTrackList();

                }
                catch (Exception ex)
                {
                    switch (ex.HResult)
                    {
                        case -2147024809:
                            MessageBox.Show("\"" + RenameDialog.filename + "\" contains invalid characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;
                        case -2146232800:
                            MessageBox.Show("A track with that name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;
                        default:
                            MessageBox.Show(ex.Message + " See errorlog.txt for more info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }

                }
            }
        }

        private void PlayKeyButton_Click(object sender, EventArgs e)
        {
            SelectKey SelectKeyDialog = new SelectKey();
            if (SelectKeyDialog.ShowDialog() == DialogResult.OK)
            {
                if (!(SelectKeyDialog.ChosenKey == SLAM.Properties.Settings.Default.RelayKey))
                {
                    SLAM.Properties.Settings.Default.PlayKey = SelectKeyDialog.ChosenKey;
                    SLAM.Properties.Settings.Default.Save();
                    RefreshPlayKey();
                }
                else
                {
                    MessageBox.Show("Play key and relay key can not be the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadTrack(GetCurrentGame(), mTracks_lst.SelectedItems[0].Index);
            DisplayLoaded(mTracks_lst.SelectedItems[0].Index);
        }

        private void ChangeDirButton_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        #endregion

        #region Background Workers

        private void WavWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SourceGame Game = (e.Argument as object[])[0] as SourceGame;
            string[] Files = (e.Argument as object[])[1] as string[];
            List<string> FailedFiles = new List<string>();

            foreach (var File in Files)
            {
                try
                {
                    string OutFile = Path.Combine(Game.Libraryname, Path.GetFileNameWithoutExtension(File) + ".wav");
                    WaveCreator(File, OutFile, Game);

                }
                catch (Exception ex)
                {
                    LogError(ex);
                    FailedFiles.Add(File);
                }
                mImportSong_wrk.ReportProgress(0);
            }

            e.Result = FailedFiles;

        }

        private void WavWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            mStatus_progress.PerformStep();
            ReloadTracks(GetCurrentGame());
            RefreshTrackList();
        }

        private void WavWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            mStatus_progress.Value = 0;
            string MsgBoxText = "Conversion complete!";
            List<string> failedFiles = new List<string>();

            foreach (var filePath in (e.Result as List<string>))
                failedFiles.Add(Path.GetFileName(filePath));

            if (failedFiles.Count > 0)
            {
                MsgBoxText = MsgBoxText + " However, the following files failed to convert: " + string.Join(", ", failedFiles);
            }

            ReloadTracks(GetCurrentGame());
            RefreshTrackList();
            Interaction.MsgBox(MsgBoxText);
            EnableInterface();
        }

        private void PollRelayWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            mPollRelay_wrk.ReportProgress(SEARCHING);
            //Report that SLAM is searching.

            SourceGame Game = e.Argument as SourceGame;
            string GameDir = Game.Directory + Game.Exename + ".exe";

            SteamAppsPath = Constants.vbNullString;
            string UserDataPath = Constants.vbNullString;

            try
            {

                if (!SLAM.Properties.Settings.Default.OverrideFolders)
                {

                    while (!mPollRelay_wrk.CancellationPending)
                    {
                        string GameProcess = GetFilepath(Game.Exename);
                        if (!string.IsNullOrEmpty(GameProcess) && GameProcess.EndsWith(GameDir))
                        {
                            SteamAppsPath = GameProcess.Remove(GameProcess.Length - GameDir.Length);
                        }

                        string SteamProcess = GetFilepath("Steam");
                        if (!string.IsNullOrEmpty(SteamProcess))
                        {
                            UserDataPath = SteamProcess.Remove(SteamProcess.Length - "Steam.exe".Length) + "userdata\\";
                        }

                        if (System.IO.Directory.Exists(SteamAppsPath))
                        {

                            if (!(Game.Id == 0))
                            {
                                if (System.IO.Directory.Exists(UserDataPath))
                                {
                                    break; // TODO: might not be correct. Was : Exit Do
                                }

                            }
                            else
                            {
                                break; // TODO: might not be correct. Was : Exit Do
                            }
                        }

                        Thread.Sleep(Game.PollInterval);
                    }

                }
                else
                {
                    SteamAppsPath = SLAM.Properties.Settings.Default.steamapps;
                    if (System.IO.Directory.Exists(SLAM.Properties.Settings.Default.userdata))
                    {
                        UserDataPath = SLAM.Properties.Settings.Default.userdata;
                    }
                    else
                    {
                        throw new System.Exception("Userdata folder does not exist. Disable \"override folder detection\", or select a correct folder.");
                    }
                }

                if (!string.IsNullOrEmpty(SteamAppsPath))
                {
                    CreateCfgFiles(Game, SteamAppsPath);
                }

            }
            catch (Exception ex)
            {
                LogError(ex);
                e.Result = ex;
                return;
            }


            mPollRelay_wrk.ReportProgress(WORKING);
            //Report that SLAM is working.

            while (!mPollRelay_wrk.CancellationPending)
            {
                try
                {
                    string GameFolder = Path.Combine(SteamAppsPath, Game.Directory);
                    string GameCfg = Path.Combine(GameFolder, Game.ToCfg) + "slam_relay.cfg";

                    if (!(Game.Id == 0))
                    {
                        GameCfg = UserDataCFG(Game, UserDataPath);
                    }

                    if (File.Exists(GameCfg))
                    {
                        string RelayCfg = null;
                        using (StreamReader reader = new StreamReader(GameCfg))
                        {
                            RelayCfg = reader.ReadToEnd();
                        }

                        string command = recog(RelayCfg, string.Format("bind \"{0}\" \"(.*?)\"", SLAM.Properties.Settings.Default.RelayKey));
                        if (!string.IsNullOrEmpty(command))
                        {
                            //load audiofile
                            if (Information.IsNumeric(command))
                            {
                                if (LoadTrack(Game, Convert.ToInt32(command) - 1))
                                {
                                    mPollRelay_wrk.ReportProgress(Convert.ToInt32(command) - 1);
                                }
                            }
                            File.Delete(GameCfg);
                        }
                    }

                    Thread.Sleep(Game.PollInterval);

                }
                catch (Exception ex)
                {
                    //-2147024864 = "System.IO.IOException: The process cannot access the file because it is being used by another process."
                    if (!(ex.HResult == -2147024864))
                    {
                        LogError(ex);
                        e.Result = ex;
                        return;
                    }
                }
            }

            if (!string.IsNullOrEmpty(SteamAppsPath))
            {
                DeleteCFGs(Game, SteamAppsPath);
            }

        }

        private void PollRelayWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case SEARCHING:
                    status = SEARCHING;
                    mStatus_lbl.Text = "Status: Searching...";
                    break;
                case WORKING:
                    status = WORKING;
                    mStatus_lbl.Text = "Status: Working.";
                    break;
                default:
                    DisplayLoaded(e.ProgressPercentage);
                    break;
            }

        }

        private void PollRelayWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (running)
            {
                StopPoll();
            }

            status = IDLE;
            mStatus_lbl.Text = "Status: Idle.";

            //Result is always an exception
            if ((e.Result != null))
            {
                MessageBox.Show((e.Result as Exception).Message + " See errorlog.txt for more info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (ClosePending)
            {
                this.Close();
            }
        }

        #endregion 

        private void WaveCreator(string File, string outputFile, SourceGame Game)
        {
            MediaFoundationReader reader = new MediaFoundationReader(File);

            var outFormat = new WaveFormat(Game.Samplerate, Game.Bits, Game.Channels);

            var resampler = new MediaFoundationResampler(reader, outFormat);

            resampler.ResamplerQuality = 60;

            WaveFileWriter.CreateWaveFile(outputFile, resampler);

            resampler.Dispose();
        }

        private SourceGame GetCurrentGame()
        {
            foreach (var Game in Games)
            {
                if (Game.Name == mGameSelector_combo.SelectedItem.ToString())
                {
                    return Game;
                }
            }
            return null;
            //Null if nothing found
        }

        private void ReloadTracks(SourceGame Game)
        {

            if (System.IO.Directory.Exists(Game.Libraryname))
            {
                Game.Tracks.Clear();

                foreach (var File in System.IO.Directory.GetFiles(Game.Libraryname))
                {
                    if (Game.FileExtension == Path.GetExtension(File))
                    {
                        Track track1 = new Track();
                        track1.Name = Path.GetFileNameWithoutExtension(File);
                        Game.Tracks.Add(track1);
                    }

                }

                CreateTags(Game);
                LoadTrackKeys(Game);
                SaveTrackKeys(Game);
                //To prune hotkeys from non-existing tracks

            }
            else
            {
                System.IO.Directory.CreateDirectory(Game.Libraryname);
            }
        }

        private void RefreshTrackList()
        {
            mTracks_lst.Items.Clear();

            SourceGame Game = GetCurrentGame();


            foreach (var Track in Game.Tracks)
            {
                string trimmed = "";
                if (Track.Endpos > 0)
                {
                    trimmed = "Yes";
                }

                mTracks_lst.Items.Add(new ListViewItem(new string[]{
                "False",
                Track.Name,
                Track.Hotkey,
                Track.Volume + "%",
                trimmed,
                "\"" + string.Join("\", \"", Track.Tags) + "\""
            }));
            }


            mTracks_lst.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            mTracks_lst.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            mTracks_lst.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
            mTracks_lst.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
            mTracks_lst.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
            mTracks_lst.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void StartPoll()
        {
            running = true;
            mStart_btn.Text = "Stop";
            DisableInterface();
            mStart_btn.Enabled = true;
            mTracks_lst.Enabled = true;
            mSetVolume_mItem.Enabled = true;
            mPollRelay_wrk.RunWorkerAsync(GetCurrentGame());
        }

        private void StopPoll()
        {
            running = false;
            mStart_btn.Text = "Start";
            EnableInterface();
            mPollRelay_wrk.CancelAsync();
        }

        private void CreateCfgFiles(SourceGame Game, string SteamappsPath)
        {
            string GameDir = Path.Combine(SteamappsPath, Game.Directory);
            string GameCfgFolder = Path.Combine(GameDir, Game.ToCfg);

            if (!System.IO.Directory.Exists(GameCfgFolder))
            {
                throw new System.Exception("Steamapps folder is incorrect. Disable \"override folder detection\", or select a correct folder.");
            }

            //slam.cfg
            using (StreamWriter slam_cfg = new StreamWriter(GameCfgFolder + "slam.cfg"))
            {
                slam_cfg.WriteLine("alias slam_listtracks \"exec slam_tracklist.cfg\"");
                slam_cfg.WriteLine("alias list slam_listtracks");
                slam_cfg.WriteLine("alias tracks slam_listtracks");
                slam_cfg.WriteLine("alias la slam_listtracks");
                slam_cfg.WriteLine("alias slam_play slam_play_on");
                slam_cfg.WriteLine("alias slam_play_on \"alias slam_play slam_play_off; voice_inputfromfile 1; voice_loopback 1; +voicerecord\"");
                slam_cfg.WriteLine("alias slam_play_off \"-voicerecord; voice_inputfromfile 0; voice_loopback 0; alias slam_play slam_play_on\"");
                slam_cfg.WriteLine("alias slam_updatecfg \"host_writeconfig slam_relay\"");
                if (SLAM.Properties.Settings.Default.HoldToPlay)
                {
                    slam_cfg.WriteLine("alias +slam_hold_play slam_play_on");
                    slam_cfg.WriteLine("alias -slam_hold_play slam_play_off");
                    slam_cfg.WriteLine("bind {0} +slam_hold_play", SLAM.Properties.Settings.Default.PlayKey);
                }
                else
                {
                    slam_cfg.WriteLine("bind {0} slam_play", SLAM.Properties.Settings.Default.PlayKey);
                }
                slam_cfg.WriteLine("alias slam_curtrack \"exec slam_curtrack.cfg\"");
                slam_cfg.WriteLine("alias slam_saycurtrack \"exec slam_saycurtrack.cfg\"");
                slam_cfg.WriteLine("alias slam_sayteamcurtrack \"exec slam_sayteamcurtrack.cfg\"");

                foreach (var Track in Game.Tracks)
                {
                    int index = Game.Tracks.IndexOf(Track);
                    slam_cfg.WriteLine("alias {0} \"bind {1} {0}; slam_updatecfg; echo Loaded: {2}\"", index + 1, SLAM.Properties.Settings.Default.RelayKey, Track.Name);

                    foreach (var TrackTag in Track.Tags)
                    {
                        slam_cfg.WriteLine("alias {0} \"bind {1} {2}; slam_updatecfg; echo Loaded: {3}\"", TrackTag, SLAM.Properties.Settings.Default.RelayKey, index + 1, Track.Name);
                    }

                    if (!string.IsNullOrEmpty(Track.Hotkey))
                    {
                        slam_cfg.WriteLine("bind {0} \"bind {1} {2}; slam_updatecfg; echo Loaded: {3}\"", Track.Hotkey, SLAM.Properties.Settings.Default.RelayKey, index + 1, Track.Name);
                    }
                }

                string CfgData = null;
                CfgData = "voice_enable 1; voice_modenable 1; voice_forcemicrecord 0; con_enable 1";

                if (Game.VoiceFadeOut)
                {
                    CfgData = CfgData + "; voice_fadeouttime 0.0";
                }

                slam_cfg.WriteLine(CfgData);

            }

            //slam_tracklist.cfg
            using (StreamWriter slam_tracklist_cfg = new StreamWriter(GameCfgFolder + "slam_tracklist.cfg"))
            {
                slam_tracklist_cfg.WriteLine("echo \"You can select tracks either by typing a tag, or their track number.\"");
                slam_tracklist_cfg.WriteLine("echo \"--------------------Tracks--------------------\"");
                foreach (var Track in Game.Tracks)
                {
                    int index = Game.Tracks.IndexOf(Track);
                    if (SLAM.Properties.Settings.Default.WriteTags)
                    {
                        slam_tracklist_cfg.WriteLine("echo \"{0}. {1} [{2}]\"", index + 1, Track.Name, "'" + string.Join("', '", Track.Tags) + "'");
                    }
                    else
                    {
                        slam_tracklist_cfg.WriteLine("echo \"{0}. {1}\"", index + 1, Track.Name);
                    }
                }
                slam_tracklist_cfg.WriteLine("echo \"----------------------------------------------\"");
            }

        }

        private bool LoadTrack(SourceGame Game, int index)
        {
            Track Track = default(Track);
            if (Game.Tracks.Count > index)
            {
                Track = Game.Tracks[index];
                string voicefile = Path.Combine(SteamAppsPath, Game.Directory) + "voice_input.wav";
                try
                {
                    if (File.Exists(voicefile))
                    {
                        File.Delete(voicefile);
                    }

                    string trackfile = Game.Libraryname + Track.Name + Game.FileExtension;

                    if (File.Exists(trackfile))
                    {
                        if (Track.Volume == 100 & Track.Startpos == -1 & Track.Endpos == -1)
                        {
                            File.Copy(trackfile, voicefile);

                        }
                        else
                        {
                            WaveChannel32 WaveFloat = new WaveChannel32(new WaveFileReader(trackfile));

                            if (!(Track.Volume == 100))
                            {
                                WaveFloat.Volume = (float)Math.Pow((Track.Volume / 100), 6);
                            }

                            if (!(Track.Startpos == Track.Endpos) & Track.Endpos > 0)
                            {
                                byte[] bytes = new byte[(Track.Endpos - Track.Startpos) * 4 + 1];

                                WaveFloat.Position = Track.Startpos * 4;
                                WaveFloat.Read(bytes, 0, (Track.Endpos - Track.Startpos) * 4);

                                WaveFloat = new WaveChannel32(new RawSourceWaveStream(new MemoryStream(bytes), WaveFloat.WaveFormat));
                            }

                            WaveFloat.PadWithZeroes = false;
                            var outFormat = new WaveFormat(Game.Samplerate, Game.Bits, Game.Channels);
                            var resampler = new MediaFoundationResampler(WaveFloat, outFormat);
                            resampler.ResamplerQuality = 60;
                            WaveFileWriter.CreateWaveFile(voicefile, resampler);

                            resampler.Dispose();
                            WaveFloat.Dispose();

                        }

                        string GameCfgFolder = Path.Combine(SteamAppsPath, Game.Directory, Game.ToCfg);
                        using (StreamWriter slam_curtrack = new StreamWriter(GameCfgFolder + "slam_curtrack.cfg"))
                        {
                            slam_curtrack.WriteLine("echo \"[SLAM] Track name: {0}\"", Track.Name);
                        }
                        using (StreamWriter slam_saycurtrack = new StreamWriter(GameCfgFolder + "slam_saycurtrack.cfg"))
                        {
                            slam_saycurtrack.WriteLine("say \"[SLAM] Track name: {0}\"", Track.Name);
                        }
                        using (StreamWriter slam_sayteamcurtrack = new StreamWriter(GameCfgFolder + "slam_sayteamcurtrack.cfg"))
                        {
                            slam_sayteamcurtrack.WriteLine("say_team \"[SLAM] Track name: {0}\"", Track.Name);
                        }


                    }

                }
                catch (Exception ex)
                {
                    LogError(ex);
                    return false;
                }

            }
            else
            {
                return false;
            }

            return true;
        }

        private string recog(string str, string reg)
        {
            Match keyd = Regex.Match(str, reg);
            return (keyd.Groups[1].ToString());
        }

        public string UserDataCFG(SourceGame Game, string UserdataPath)
        {
            if (System.IO.Directory.Exists(UserdataPath))
            {
                foreach (string userdir in System.IO.Directory.GetDirectories(UserdataPath))
                {
                    string CFGPath = Path.Combine(userdir, Game.Id.ToString()) + "\\local\\cfg\\slam_relay.cfg";
                    if (File.Exists(CFGPath))
                    {
                        return CFGPath;
                    }
                }
            }
            return Constants.vbNullString;
        }

        private string GetFilepath(string ProcessName)
        {

            string wmiQueryString = "Select * from Win32_Process Where Name = \"" + ProcessName + ".exe\"";

            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using (var results = searcher.Get())
                {

                    ManagementObject Process = results.Cast<ManagementObject>().FirstOrDefault();
                    if (Process != null && !string.IsNullOrEmpty(Process["ExecutablePath"].ToString()))
                    {
                        return Process["ExecutablePath"].ToString();
                    }

                }
            }

            return null;
        }

        private void CreateTags(SourceGame Game)
        {
            Dictionary<string, int> NameWords = new Dictionary<string, int>();

            int index = 0;
            foreach (var Track in Game.Tracks)
            {
                List<string> Words = Track.Name.Split(new char[]{
                    ' ',
				'.',
				'-',
				'_'
    
            }).ToList();


                foreach (var Word in Words)
                {
                    if (!Information.IsNumeric(Word) & !Game.Blacklist.Contains(Word.ToLower()) & Word.Length < 32)
                    {
                        if (NameWords.ContainsKey(Word))
                        {
                            NameWords.Remove(Word);
                        }
                        else
                        {
                            NameWords.Add(Word, index);
                        }
                    }

                }
                index += 1;
            }

            foreach (KeyValuePair<string, int> Tag in NameWords)
            {
                Game.Tracks.ElementAt(Tag.Value).Tags.Add(Tag.Key);
            }
        }

        private void EnableInterface()
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = true;
            }
        }

        private void DisableInterface()
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
            }
        }

        private void DisplayLoaded(int track)
        {
            for (int i = 0; i <= mTracks_lst.Items.Count - 1; i++)
            {
                mTracks_lst.Items[i].SubItems[0].Text = "False";
            }
            mTracks_lst.Items[track].SubItems[0].Text = "True";
        }

        private void LoadTrackKeys(SourceGame Game)
        {
            List<Track> SettingsList = new List<Track>();
            string SettingsFile = Path.Combine(Game.Libraryname, "TrackSettings.xml");

            if (File.Exists(SettingsFile))
            {
                string XmlFile = null;
                using (StreamReader reader = new StreamReader(SettingsFile))
                {
                    XmlFile = reader.ReadToEnd();
                }
                SettingsList = XmlSerialization.Deserialize<List<Track>>(XmlFile);
            }


            foreach (var Track in Game.Tracks)
            {
                foreach (var SetTrack in SettingsList)
                {
                    if (Track.Name == SetTrack.Name)
                    {
                        //Please tell me that there is a better way to do the following...
                        Track.Hotkey = SetTrack.Hotkey;
                        Track.Volume = SetTrack.Volume;
                        Track.Startpos = SetTrack.Startpos;
                        Track.Endpos = SetTrack.Endpos;
                    }
                }
            }

        }

        private void SaveTrackKeys(SourceGame Game)
        {
            List<Track> SettingsList = new List<Track>();
            string SettingsFile = Path.Combine(Game.Libraryname, "TrackSettings.xml");

            foreach (var Track in Game.Tracks)
            {
                if (!string.IsNullOrEmpty(Track.Hotkey) | !(Track.Volume == 100) | Track.Endpos > 0)
                {
                    SettingsList.Add(Track);

                }
            }

            if (SettingsList.Count > 0)
            {
                using (StreamWriter writer = new StreamWriter(SettingsFile))
                {
                    writer.Write(XmlSerialization.Serialize(SettingsList));
                }
            }
            else
            {
                if (File.Exists(SettingsFile))
                {
                    File.Delete(SettingsFile);
                }
            }

        }

        private void RefreshPlayKey()
        {
            mPlayKey_btn.Text = string.Format("Play key: \"{0}\" (change)", SLAM.Properties.Settings.Default.PlayKey);
        }

        private void LogError(Exception ex)
        {
            if (SLAM.Properties.Settings.Default.LogError)
            {
                using (StreamWriter log = new StreamWriter("errorlog.txt", true))
                {
                    log.WriteLine("--------------------{0} UTC--------------------", DateTime.Now.ToUniversalTime());
                    log.WriteLine(ex.ToString());
                }
            }
        }

        private void DeleteCFGs(SourceGame Game, string SteamappsPath)
        {
            string GameDir = Path.Combine(SteamappsPath, Game.Directory);
            string GameCfgFolder = Path.Combine(GameDir, Game.ToCfg);
            string[] SlamFiles = {
            "slam.cfg",
            "slam_tracklist.cfg",
            "slam_relay.cfg",
            "slam_curtrack.cfg",
            "slam_saycurtrack.cfg",
            "slam_sayteamcurtrack.cfg"
        };
            string voicefile = Path.Combine(SteamappsPath, Game.Directory) + "voice_input.wav";


            try
            {
                if (File.Exists(voicefile))
                {
                    File.Delete(voicefile);
                }


                foreach (var FileName in SlamFiles)
                {
                    if (File.Exists(GameCfgFolder + FileName))
                    {
                        File.Delete(GameCfgFolder + FileName);
                    }

                }

            }
            catch (Exception ex)
            {
                LogError(ex);
            }

        }

    }
}