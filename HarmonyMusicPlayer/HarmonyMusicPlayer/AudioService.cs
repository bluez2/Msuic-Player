using NAudio.Wave;
using System;

namespace HarmonyMusicPlayer
{
    public class AudioService
    {
        private IWavePlayer _waveOutDevice;
        private AudioFileReader _audioFileReader;

        public event Action PlaybackStopped;

        public void LoadFile(string filePath)
        {
            Stop(); // Stop current if any

            try
            {
                _audioFileReader = new AudioFileReader(filePath);
                _waveOutDevice = new WaveOutEvent();
                _waveOutDevice.Init(_audioFileReader);
                _waveOutDevice.PlaybackStopped += OnPlaybackStopped;
            }
            catch (Exception ex)
            {
                // Simple error handling as per Chapter 11
                System.Windows.Forms.MessageBox.Show($"Error loading file: {ex.Message}");
            }
        }

        public void Play()
        {
            if (_waveOutDevice != null && _waveOutDevice.PlaybackState != PlaybackState.Playing)
            {
                _waveOutDevice.Play();
            }
        }

        public void Pause()
        {
            if (_waveOutDevice != null && _waveOutDevice.PlaybackState == PlaybackState.Playing)
            {
                _waveOutDevice.Pause();
            }
        }

        public void Stop()
        {
            if (_waveOutDevice != null)
            {
                _waveOutDevice.Stop();
                _waveOutDevice.Dispose();
                _waveOutDevice = null;
            }
            if (_audioFileReader != null)
            {
                _audioFileReader.Dispose();
                _audioFileReader = null;
            }
        }

        public void SetVolume(float volume)
        {
            // Volume is 0.0 to 1.0
            if (_audioFileReader != null)
            {
                _audioFileReader.Volume = volume;
            }
        }

        public void Seek(double seconds)
        {
            if (_audioFileReader != null)
            {
                _audioFileReader.CurrentTime = TimeSpan.FromSeconds(seconds);
            }
        }

        public TimeSpan GetCurrentTime()
        {
            return _audioFileReader?.CurrentTime ?? TimeSpan.Zero;
        }

        public TimeSpan GetTotalTime()
        {
            return _audioFileReader?.TotalTime ?? TimeSpan.Zero;
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            PlaybackStopped?.Invoke();
        }
    }
}