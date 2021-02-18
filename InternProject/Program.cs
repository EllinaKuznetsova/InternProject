using System;
using System.IO;
using System.Text;

namespace InternProject
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length != 1)
            {
                throw new Exception("Неверное количество аргументов");
            }

            if (string.IsNullOrEmpty(args[0]))
            {
                throw new Exception("Неверный формат строки");
            }

            IDownloader downloader = new Downloader();

            string name = "downloadedFile.txt";

            try
            {
                if (downloader.DownloadPage(args[0], name))
                {
                    IParser parser = new Parser();
                    var analyzer = new Analyzer();
                    var printer = new Printer();

                    string path = Path.GetFullPath(name);
                    var words = parser.Parse(File.Open(path, FileMode.Open));
                    var wordsWithCounters = analyzer.Analyze(words);

                    printer.Print(wordsWithCounters);
                }
            }
            catch (Exception e)
            {
                Logger.Instance.Log(e.Message);
                Logger.Instance.Log(e.StackTrace);
                throw;
            }
        }
    }
}
