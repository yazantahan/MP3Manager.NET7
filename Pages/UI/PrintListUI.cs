using MP3Manager.NET7.Pages.UI;
using System;

namespace MP3Manager.NET7.Pages.UI
{
    class PrintListUI : IUserInterface
    {
        private static PrintListUI printListUI;
        private PrintListUI()
        {

        }

        public static PrintListUI start()
        {
            if (printListUI == null)
            {
                printListUI = new PrintListUI();
            }

            return printListUI;
        }

        public void Run(ref MP3Engine mp3Engine)
        {
            Console.Clear();

            if (mp3Engine.getMP3FilesSize() != 0)
            {
                while (true)
                {
                    mp3Engine.printAllMP3Files();
                    Console.WriteLine($"\n--------------------------------------\n\nPress {mp3Engine.getMP3FilesSize() + 1} to go back.\nchoose any Song you would like to it\'s information");
                    int index;

                    try
                    {
                        index = Prog.input();
                    } catch (Exception e)
                    {
                        Prog.setWarningMessage("Select any key from above to continue.");
                        continue;
                    }

                    if (index != mp3Engine.getMP3FilesSize() + 1 && !(index <= 0 || index > mp3Engine.getMP3FilesSize() + 1))
                    {
                        Prog.isAsync = false;
                        SongInfoUI songInfoUI = SongInfoUI.start(index);
                        songInfoUI.Run(ref mp3Engine);
                        songInfoUI.Dispose();
                        Prog.isAsync = true;
                        continue;
                    }

                    break;
                }
            }
            else
            {
                Console.WriteLine("This file is empty, Press any key to go back.");
            }

            Console.Clear();
        }

        public void Dispose()
        {
            printListUI = null;
        }
    }
}
