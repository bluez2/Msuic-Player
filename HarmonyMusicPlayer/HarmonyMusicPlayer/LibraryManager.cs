using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace HarmonyMusicPlayer
{
    public class LibraryManager
    {
        private const string LIBRARY_FILE = "library.json";
        public List<Song> AllSongs { get; private set; } = new List<Song>();

        // Scan a folder for MP3 files
        public void ScanDirectory(string folderPath)
        {
            if (!Directory.Exists(folderPath)) return;

            string[] files = Directory.GetFiles(folderPath, "*.mp3", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                try
                {
                    // Use TagLib to extract metadata
                    var tfile = TagLib.File.Create(file);

                    var song = new Song
                    {
                        FilePath = file,
                        Title = string.IsNullOrWhiteSpace(tfile.Tag.Title) ? Path.GetFileNameWithoutExtension(file) : tfile.Tag.Title,
                        Artist = string.IsNullOrWhiteSpace(tfile.Tag.FirstPerformer) ? "Unknown Artist" : tfile.Tag.FirstPerformer,
                        Album = tfile.Tag.Album,
                        Genre = tfile.Tag.FirstGenre,
                        Duration = tfile.Properties.Duration
                    };

                    // Avoid duplicates based on file path
                    if (!AllSongs.Any(s => s.FilePath == song.FilePath))
                    {
                        AllSongs.Add(song);
                    }
                }
                catch
                {
                    // Skip corrupted files (Chapter 11: Reliability)
                }
            }
            SaveLibrary();
        }

        public void SaveLibrary()
        {
            string json = JsonConvert.SerializeObject(AllSongs, Formatting.Indented);
            File.WriteAllText(LIBRARY_FILE, json);
        }

        public void LoadLibrary()
        {
            if (File.Exists(LIBRARY_FILE))
            {
                string json = File.ReadAllText(LIBRARY_FILE);
                AllSongs = JsonConvert.DeserializeObject<List<Song>>(json) ?? new List<Song>();
            }
        }

        public List<Song> Search(string query)
        {
            return AllSongs.Where(s =>
                s.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                s.Artist.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
    }
}