﻿using System;

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

            if (downloader.DownloadPage(args[0], name))
            {
                //smth
            }
        }
    }
}
