using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace InternProject
{
    /// <summary>
    /// Загрузчик
    /// </summary>
    public class Downloader : IDownloader
    {
        /// <summary>
        /// Загрузка страницы
        /// </summary>
        /// <param name="url">Ссылка на страницу сайта</param>
        /// <param name="path">Путь сохранения файла</param>
        /// <returns>Успешно ли завершена загрузка</returns>
        public bool DownloadPage(string url, string path)
        {
            WebClient client = new WebClient();
            try
            {
                client.DownloadFile(url, path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Страница не скачана {ex.Message}");
                return false;
            }
            
            return true; 
        }
    }
}
