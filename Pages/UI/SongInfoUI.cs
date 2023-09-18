using MP3Manager.NET7;
using MP3Manager.NET7.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MP3Manager.NET7.Pages.UI
{
    internal class SongInfoUI : IUserInterface
    {
        private static SongInfoUI songInfoUI;
        private int index;
        private int choice = 0;
        private string filename = "";
        private SongInfoUI(int index) { this.index = index; }

        public static SongInfoUI start(int index)
        {
            if (songInfoUI == null)
            {
                songInfoUI = new SongInfoUI(index);
            }

            return songInfoUI;
        }
        public void Run(ref MP3Engine mp3Engine)
        {
            string filename = mp3Engine.GetMP3FileDetails(index);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Song Info.\n--------------------------------------------------");

                Console.WriteLine(filename);

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Press 1 to play the song\nPress 2 to return to the page");

                choice = Prog.input();

                if (choice == 1)
                {
                    mp3Engine.PlayMP3File(index);
                    break;
                } else if (choice == 2)
                {
                    break;
                }

                Console.Clear();
                Prog.setWarningMessage("You have to enter a number in order to continue.");
            }
            Console.Clear();
        }

        public void Dispose()
        {
            filename = "";
            choice = 0;
            songInfoUI = null;
        }

    }
}
