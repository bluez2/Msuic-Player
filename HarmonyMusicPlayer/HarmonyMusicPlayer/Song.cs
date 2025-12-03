using System;

namespace HarmonyMusicPlayer
{
    // Represents a single music track (Chapter 9: Data View)
    public class Song
    {
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public TimeSpan Duration { get; set; }

        // Helper to display song nicely in the ListBox
        public override string ToString()
        {
            return $"{Artist} - {Title} ({Duration:mm\\:ss})";
        }
    }
}