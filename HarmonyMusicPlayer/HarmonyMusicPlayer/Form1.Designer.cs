namespace HarmonyMusicPlayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstSongs = new ListBox();
            btnLoadFolder = new Button();
            btnPlay = new Button();
            btnPause = new Button();
            btnStop = new Button();
            trackVolume = new TrackBar();
            trackProgress = new TrackBar();
            txtSearch = new TextBox();
            lblNowPlaying = new Label();
            ((System.ComponentModel.ISupportInitialize)trackVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackProgress).BeginInit();
            SuspendLayout();
            // 
            // lstSongs
            // 
            lstSongs.FormattingEnabled = true;
            lstSongs.Location = new Point(39, 109);
            lstSongs.Name = "lstSongs";
            lstSongs.Size = new Size(226, 244);
            lstSongs.TabIndex = 0;
            lstSongs.Click += lstSongs_Click;
            // 
            // btnLoadFolder
            // 
            btnLoadFolder.Location = new Point(271, 123);
            btnLoadFolder.Name = "btnLoadFolder";
            btnLoadFolder.Size = new Size(94, 29);
            btnLoadFolder.TabIndex = 1;
            btnLoadFolder.Text = "Load Folder";
            btnLoadFolder.UseVisualStyleBackColor = true;
            btnLoadFolder.Click += btnLoadFolder_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(286, 308);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(94, 29);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(432, 308);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(94, 29);
            btnPause.TabIndex = 3;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(587, 311);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 29);
            btnStop.TabIndex = 4;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // trackVolume
            // 
            trackVolume.Location = new Point(235, 357);
            trackVolume.Maximum = 100;
            trackVolume.Name = "trackVolume";
            trackVolume.Size = new Size(130, 56);
            trackVolume.TabIndex = 5;
            trackVolume.Value = 50;
            trackVolume.Scroll += trackVolume_Scroll;
            // 
            // trackProgress
            // 
            trackProgress.Location = new Point(371, 246);
            trackProgress.Maximum = 100;
            trackProgress.Name = "trackProgress";
            trackProgress.Size = new Size(130, 56);
            trackProgress.TabIndex = 6;
            trackProgress.Scroll += trackProgress_Scroll;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(39, 61);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 27);
            txtSearch.TabIndex = 7;
            txtSearch.Text = "Search...";
            txtSearch.Click += txtSearch_TextChanged;
            // 
            // lblNowPlaying
            // 
            lblNowPlaying.AutoSize = true;
            lblNowPlaying.Location = new Point(563, 393);
            lblNowPlaying.Name = "lblNowPlaying";
            lblNowPlaying.Size = new Size(66, 20);
            lblNowPlaying.TabIndex = 8;
            lblNowPlaying.Text = "Stopped";
            lblNowPlaying.Click += lblNowPlaying_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNowPlaying);
            Controls.Add(txtSearch);
            Controls.Add(trackProgress);
            Controls.Add(trackVolume);
            Controls.Add(btnStop);
            Controls.Add(btnPause);
            Controls.Add(btnPlay);
            Controls.Add(btnLoadFolder);
            Controls.Add(lstSongs);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)trackVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackProgress).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstSongs;
        private Button btnLoadFolder;
        private Button btnPlay;
        private Button btnPause;
        private Button btnStop;
        private TrackBar trackVolume;
        private TrackBar trackProgress;
        private TextBox txtSearch;
        private Label lblNowPlaying;
    }
}
