using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace HarmonyMusicPlayer
{
    public partial class Form1 : Form
    {
        private AudioService _audioService;
        private LibraryManager _libraryManager;
        private Timer _playbackTimer;
        private Song _currentSong;

        public Form1()
        {
            InitializeComponent();

            // Initialize Services
            _audioService = new AudioService();
            _libraryManager = new LibraryManager();

            // Setup Timer for updating the seek bar
            _playbackTimer = new Timer();
            _playbackTimer.Interval = 1000; // Update every second
            _playbackTimer.Tick += PlaybackTimer_Tick;

            // Load saved library on startup
            _libraryManager.LoadLibrary();
            RefreshSongList(_libraryManager.AllSongs);

            // Hook up audio events
            _audioService.PlaybackStopped += OnPlaybackStopped;
        }

        // --- Event Handlers ---

        private void btnLoadFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    _libraryManager.ScanDirectory(fbd.SelectedPath);
                    RefreshSongList(_libraryManager.AllSongs);
                    MessageBox.Show($"Loaded {_libraryManager.AllSongs.Count} songs!");
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (lstSongs.SelectedItem is Song selectedSong)
            {
                // If picking a new song
                if (_currentSong != selectedSong)
                {
                    _currentSong = selectedSong;
                    _audioService.LoadFile(_currentSong.FilePath);
                    lblNowPlaying.Text = $"Playing: {_currentSong.Title}";
                    trackProgress.Maximum = (int)_currentSong.Duration.TotalSeconds;
                    trackProgress.Value = 0;
                }

                _audioService.Play();
                _playbackTimer.Start();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            _audioService.Pause();
            _playbackTimer.Stop();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _audioService.Stop();
            _playbackTimer.Stop();
            trackProgress.Value = 0;
            lblNowPlaying.Text = "Stopped";
        }

        private void trackVolume_Scroll(object sender, EventArgs e)
        {
            // Convert 0-100 to 0.0-1.0
            float vol = trackVolume.Value / 100f;
            _audioService.SetVolume(vol);
        }

        private void trackProgress_Scroll(object sender, EventArgs e)
        {
            // User dragged seek bar
            _audioService.Seek(trackProgress.Value);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var results = _libraryManager.Search(txtSearch.Text);
            RefreshSongList(results);
        }

        private void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            if (_currentSong != null)
            {
                var current = _audioService.GetCurrentTime();
                // Update trackbar without triggering the Scroll event loop
                if (current.TotalSeconds <= trackProgress.Maximum)
                {
                    trackProgress.Value = (int)current.TotalSeconds;
                }
            }
        }

        private void OnPlaybackStopped()
        {
            // Auto-play next song logic could go here
            _playbackTimer.Stop();

            // To update UI from a non-UI thread (NAudio event), use Invoke
            this.Invoke(new Action(() =>
            {
                trackProgress.Value = 0;
                lblNowPlaying.Text = "Stopped";
            }));
        }

        // --- Helper Methods ---

        private void RefreshSongList(List<Song> songs)
        {
            lstSongs.DataSource = null;
            lstSongs.DataSource = songs;
        }

        private void lstSongs_Click(object sender, EventArgs e)
        {

        }

        private void lblNowPlaying_Click(object sender, EventArgs e)
        {

        }
    }
}