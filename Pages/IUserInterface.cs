namespace MP3Manager.NET7.Pages
{
    interface IUserInterface
    {
        void Run(ref MP3Engine mp3Engine);
        void Dispose();
    }
}
