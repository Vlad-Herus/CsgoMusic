using System.Windows.Forms;

namespace SLAM
{
    partial class Form1
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
            this.mGameSelector_combo = new System.Windows.Forms.ComboBox();
            this.mGame_lbl = new System.Windows.Forms.Label();
            this.mImport_btn = new System.Windows.Forms.Button();
            this.mTracks_lst = new System.Windows.Forms.ListView();
            this.LoadedCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TrackCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HotKeyCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VolumeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Trimmed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TagsCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mStart_btn = new System.Windows.Forms.Button();
            this.mImportFile_dlg = new System.Windows.Forms.OpenFileDialog();
            this.mStatus_progress = new System.Windows.Forms.ProgressBar();
            this.mImportSong_wrk = new System.ComponentModel.BackgroundWorker();
            this.mPollRelay_wrk = new System.ComponentModel.BackgroundWorker();
            this.mChangeDir_btn = new System.Windows.Forms.Button();
            this.mTrack_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mDelete_mItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mGoTo_mItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mRefresh_mItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mRemoveBind_mItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mRename_mItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSetBind_mItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSetVolume_mItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mTrim_mItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mLoad_mItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mPlayKey_btn = new System.Windows.Forms.Button();
            this.mStatus_lbl = new System.Windows.Forms.Label();
            this.treeViewAdv1 = new Aga.Controls.Tree.TreeViewAdv();
            this.mTrack_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mGameSelector_combo
            // 
            this.mGameSelector_combo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mGameSelector_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mGameSelector_combo.FormattingEnabled = true;
            this.mGameSelector_combo.Location = new System.Drawing.Point(56, 12);
            this.mGameSelector_combo.MaxDropDownItems = 100;
            this.mGameSelector_combo.Name = "mGameSelector_combo";
            this.mGameSelector_combo.Size = new System.Drawing.Size(1146, 21);
            this.mGameSelector_combo.TabIndex = 0;
            // 
            // mGame_lbl
            // 
            this.mGame_lbl.AutoSize = true;
            this.mGame_lbl.Location = new System.Drawing.Point(12, 15);
            this.mGame_lbl.Name = "mGame_lbl";
            this.mGame_lbl.Size = new System.Drawing.Size(38, 13);
            this.mGame_lbl.TabIndex = 1;
            this.mGame_lbl.Text = "Game:";
            // 
            // mImport_btn
            // 
            this.mImport_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mImport_btn.Location = new System.Drawing.Point(15, 667);
            this.mImport_btn.Name = "mImport_btn";
            this.mImport_btn.Size = new System.Drawing.Size(75, 23);
            this.mImport_btn.TabIndex = 3;
            this.mImport_btn.Text = "Import";
            this.mImport_btn.UseVisualStyleBackColor = true;
            // 
            // mTracks_lst
            // 
            this.mTracks_lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTracks_lst.AutoArrange = false;
            this.mTracks_lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LoadedCol,
            this.TrackCol,
            this.HotKeyCol,
            this.VolumeCol,
            this.Trimmed,
            this.TagsCol});
            this.mTracks_lst.FullRowSelect = true;
            this.mTracks_lst.HideSelection = false;
            this.mTracks_lst.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.mTracks_lst.Location = new System.Drawing.Point(15, 39);
            this.mTracks_lst.Name = "mTracks_lst";
            this.mTracks_lst.Size = new System.Drawing.Size(472, 301);
            this.mTracks_lst.TabIndex = 4;
            this.mTracks_lst.UseCompatibleStateImageBehavior = false;
            this.mTracks_lst.View = System.Windows.Forms.View.Details;
            // 
            // LoadedCol
            // 
            this.LoadedCol.Text = "Loaded";
            // 
            // TrackCol
            // 
            this.TrackCol.Text = "Track";
            this.TrackCol.Width = 137;
            // 
            // HotKeyCol
            // 
            this.HotKeyCol.Text = "Bind";
            // 
            // VolumeCol
            // 
            this.VolumeCol.Text = "Volume";
            this.VolumeCol.Width = 100;
            // 
            // Trimmed
            // 
            this.Trimmed.Text = "Trimmed";
            // 
            // TagsCol
            // 
            this.TagsCol.Text = "Tags";
            this.TagsCol.Width = 43;
            // 
            // mStart_btn
            // 
            this.mStart_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mStart_btn.Location = new System.Drawing.Point(96, 667);
            this.mStart_btn.Name = "mStart_btn";
            this.mStart_btn.Size = new System.Drawing.Size(75, 23);
            this.mStart_btn.TabIndex = 5;
            this.mStart_btn.Text = "Start";
            this.mStart_btn.UseVisualStyleBackColor = true;
            // 
            // mImportFile_dlg
            // 
            this.mImportFile_dlg.FileName = "ImportDialog";
            this.mImportFile_dlg.Filter = "Media files|*.mp3;*.wav;*.aac;*.wma;*.m4a;*.mp4;*.wmv;*.avi;*.m4v;*.mov;|Audio fi" +
    "les|*.mp3;*.wav;*.aac;*.wma;*.m4a;|Video files|*.mp4;*.wmv;*.avi;*.m4v;*.mov;|Al" +
    "l files|*.*";
            this.mImportFile_dlg.Multiselect = true;
            // 
            // mStatus_progress
            // 
            this.mStatus_progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mStatus_progress.Location = new System.Drawing.Point(15, 696);
            this.mStatus_progress.Name = "mStatus_progress";
            this.mStatus_progress.Size = new System.Drawing.Size(1268, 23);
            this.mStatus_progress.Step = 1;
            this.mStatus_progress.TabIndex = 6;
            // 
            // mImportSong_wrk
            // 
            this.mImportSong_wrk.WorkerReportsProgress = true;
            // 
            // mPollRelay_wrk
            // 
            this.mPollRelay_wrk.WorkerReportsProgress = true;
            this.mPollRelay_wrk.WorkerSupportsCancellation = true;
            // 
            // mChangeDir_btn
            // 
            this.mChangeDir_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mChangeDir_btn.Location = new System.Drawing.Point(1208, 10);
            this.mChangeDir_btn.Name = "mChangeDir_btn";
            this.mChangeDir_btn.Size = new System.Drawing.Size(75, 23);
            this.mChangeDir_btn.TabIndex = 7;
            this.mChangeDir_btn.Text = "Settings";
            this.mChangeDir_btn.UseVisualStyleBackColor = true;
            // 
            // mTrack_menu
            // 
            this.mTrack_menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mTrack_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDelete_mItem,
            this.mGoTo_mItem,
            this.mRefresh_mItem,
            this.mRemoveBind_mItem,
            this.mRename_mItem,
            this.mSetBind_mItem,
            this.mSetVolume_mItem,
            this.mTrim_mItem,
            this.mLoad_mItem});
            this.mTrack_menu.Name = "TrackContextMenu";
            this.mTrack_menu.Size = new System.Drawing.Size(145, 202);
            // 
            // mDelete_mItem
            // 
            this.mDelete_mItem.Name = "mDelete_mItem";
            this.mDelete_mItem.Size = new System.Drawing.Size(144, 22);
            this.mDelete_mItem.Text = "Delete";
            // 
            // mGoTo_mItem
            // 
            this.mGoTo_mItem.Name = "mGoTo_mItem";
            this.mGoTo_mItem.Size = new System.Drawing.Size(144, 22);
            this.mGoTo_mItem.Text = "Go To";
            // 
            // mRefresh_mItem
            // 
            this.mRefresh_mItem.Name = "mRefresh_mItem";
            this.mRefresh_mItem.Size = new System.Drawing.Size(144, 22);
            this.mRefresh_mItem.Text = "Refresh";
            // 
            // mRemoveBind_mItem
            // 
            this.mRemoveBind_mItem.Name = "mRemoveBind_mItem";
            this.mRemoveBind_mItem.Size = new System.Drawing.Size(144, 22);
            this.mRemoveBind_mItem.Text = "Remove Bind";
            // 
            // mRename_mItem
            // 
            this.mRename_mItem.Name = "mRename_mItem";
            this.mRename_mItem.Size = new System.Drawing.Size(144, 22);
            this.mRename_mItem.Text = "Rename";
            // 
            // mSetBind_mItem
            // 
            this.mSetBind_mItem.Name = "mSetBind_mItem";
            this.mSetBind_mItem.Size = new System.Drawing.Size(144, 22);
            this.mSetBind_mItem.Text = "Set Bind";
            // 
            // mSetVolume_mItem
            // 
            this.mSetVolume_mItem.Name = "mSetVolume_mItem";
            this.mSetVolume_mItem.Size = new System.Drawing.Size(144, 22);
            this.mSetVolume_mItem.Text = "Set Volume";
            // 
            // mTrim_mItem
            // 
            this.mTrim_mItem.Name = "mTrim_mItem";
            this.mTrim_mItem.Size = new System.Drawing.Size(144, 22);
            this.mTrim_mItem.Text = "Trim";
            // 
            // mLoad_mItem
            // 
            this.mLoad_mItem.Name = "mLoad_mItem";
            this.mLoad_mItem.Size = new System.Drawing.Size(144, 22);
            this.mLoad_mItem.Text = "Load";
            // 
            // mPlayKey_btn
            // 
            this.mPlayKey_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mPlayKey_btn.Location = new System.Drawing.Point(1091, 667);
            this.mPlayKey_btn.Name = "mPlayKey_btn";
            this.mPlayKey_btn.Size = new System.Drawing.Size(192, 23);
            this.mPlayKey_btn.TabIndex = 8;
            this.mPlayKey_btn.Text = "Play key: \"\"{0}\"\" (change)";
            this.mPlayKey_btn.UseVisualStyleBackColor = true;
            // 
            // mStatus_lbl
            // 
            this.mStatus_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mStatus_lbl.AutoSize = true;
            this.mStatus_lbl.Location = new System.Drawing.Point(177, 672);
            this.mStatus_lbl.Name = "mStatus_lbl";
            this.mStatus_lbl.Size = new System.Drawing.Size(60, 13);
            this.mStatus_lbl.TabIndex = 9;
            this.mStatus_lbl.Text = "Status: Idle";
            // 
            // treeViewAdv1
            // 
            this.treeViewAdv1.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewAdv1.DefaultToolTipProvider = null;
            this.treeViewAdv1.DragDropMarkColor = System.Drawing.Color.Black;
            this.treeViewAdv1.LineColor = System.Drawing.SystemColors.ControlDark;
            this.treeViewAdv1.Location = new System.Drawing.Point(493, 39);
            this.treeViewAdv1.Model = null;
            this.treeViewAdv1.Name = "treeViewAdv1";
            this.treeViewAdv1.SelectedNode = null;
            this.treeViewAdv1.Size = new System.Drawing.Size(677, 301);
            this.treeViewAdv1.TabIndex = 10;
            this.treeViewAdv1.Text = "treeViewAdv1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 731);
            this.Controls.Add(this.treeViewAdv1);
            this.Controls.Add(this.mStatus_lbl);
            this.Controls.Add(this.mPlayKey_btn);
            this.Controls.Add(this.mChangeDir_btn);
            this.Controls.Add(this.mStatus_progress);
            this.Controls.Add(this.mStart_btn);
            this.Controls.Add(this.mTracks_lst);
            this.Controls.Add(this.mImport_btn);
            this.Controls.Add(this.mGame_lbl);
            this.Controls.Add(this.mGameSelector_combo);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Source Live Audio Mixer";
            this.mTrack_menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.ComboBox mGameSelector_combo;
        internal System.Windows.Forms.Label mGame_lbl;
        internal System.Windows.Forms.Button mImport_btn;
        internal System.Windows.Forms.ListView mTracks_lst;
        internal System.Windows.Forms.ColumnHeader LoadedCol;
        internal System.Windows.Forms.ColumnHeader TrackCol;
        internal System.Windows.Forms.ColumnHeader TagsCol;
        internal System.Windows.Forms.Button mStart_btn;
        internal System.Windows.Forms.OpenFileDialog mImportFile_dlg;
        internal System.Windows.Forms.ProgressBar mStatus_progress;
        internal System.ComponentModel.BackgroundWorker mImportSong_wrk;
        internal System.ComponentModel.BackgroundWorker mPollRelay_wrk;
        internal System.Windows.Forms.Button mChangeDir_btn;
        internal System.Windows.Forms.ContextMenuStrip mTrack_menu;
        internal System.Windows.Forms.ToolStripMenuItem mDelete_mItem;
        internal System.Windows.Forms.ToolStripMenuItem mRefresh_mItem;
        internal System.Windows.Forms.ToolStripMenuItem mSetBind_mItem;
        internal System.Windows.Forms.ColumnHeader HotKeyCol;
        internal System.Windows.Forms.ToolStripMenuItem mRemoveBind_mItem;
        internal System.Windows.Forms.ToolStripMenuItem mGoTo_mItem;
        internal System.Windows.Forms.Button mPlayKey_btn;
        internal System.Windows.Forms.ColumnHeader VolumeCol;
        internal System.Windows.Forms.ToolStripMenuItem mSetVolume_mItem;
        internal System.Windows.Forms.ToolStripMenuItem mTrim_mItem;
        internal System.Windows.Forms.ColumnHeader Trimmed;
        internal System.Windows.Forms.Label mStatus_lbl;
        internal System.Windows.Forms.ToolStripMenuItem mRename_mItem;
        internal ToolStripMenuItem mLoad_mItem;


        #endregion

        private Aga.Controls.Tree.TreeViewAdv treeViewAdv1;
    }
}