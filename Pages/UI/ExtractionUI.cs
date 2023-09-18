using System;
using System.Threading;

namespace MP3Manager.NET7.Pages.UI
{
    class ExtractionUI : IUserInterface
    {
        private static ExtractionUI extractionUI;

        private ExtractionUI()
        {

        }

        public static ExtractionUI start()
        {
            if (extractionUI == null)
            {
                extractionUI = new ExtractionUI();
            }

            return extractionUI;
        }

        public void Run(ref MP3Engine mp3Engine)
        {
            Console.Clear();

            if (mp3Engine.checkFolders())
            {
                Console.WriteLine("Are you sure you want to extract all the .mp3 files from the subfolders? (Type Y if you want)");

                if (Prog.isYes())
                {
                    Prog.isAsync = false;
                    Prog.Logger.Info("Starting to extract .mp3 files");
                    //mp3Engine.extractMP3Files();

                    Console.WriteLine("Checking for subfolders (1/3)");
                    Thread.Sleep(1000);

                    mp3Engine.CollectSubFolders();

                    Console.WriteLine("Checked!");
                    Thread.Sleep(50);
                    Console.WriteLine("Checking for .mp3 files (2/3)");
                    Thread.Sleep(1000);

                    mp3Engine.addMP3Files();

                    Console.WriteLine("Checked!");
                    Thread.Sleep(500);
                    Console.WriteLine("Extracting all The .mp3 files (3/3)" +
                        "\nProcessing to extract all the .mp3 files");
                    Thread.Sleep(1000);

                    Console.Clear();

                    for (int i = 0; i < mp3Engine.getMP3FilesSubFolders(); i++)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Moving the filename named -> " + mp3Engine.getMP3FileInfoSubFolder(i));

                        mp3Engine.extractMP3FilesfromSubFolder(i);
                        Thread.Sleep(50);
                    }

                    Console.WriteLine("All the .mp3 files has ben extracted successfully!" +
                                "\nWould you like to delete all the subfolders? (Type Y if you want)");

                    if (Prog.isYes())
                    {
                        mp3Engine.DeleteSubFolders();
                    }

                    mp3Engine.refreshList();
                    mp3Engine.Deletion();

                    Console.WriteLine("All the .mp3 files has been extracted successfully!\nPress any key to continue.");
                    Console.ReadKey();
                    Console.WriteLine();

                    Prog.isAsync = true;
                }
            }
            else
            {
                Prog.Logger.Warn("No folders are available.");
                Console.WriteLine("You\'re unable to use this feature because there\'s no folders in this selected directory.\nPress any key to go back.");
                Console.ReadKey();
            }

            Console.Clear();
        }

        public void Dispose()
        {
            extractionUI = null;
            
        }
    }
}
