using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject
{
    /// <summary>
    /// Интерфейс загрузчика
    /// </summary>
    public interface IDownloader
    {
        /// <summary>
        /// Загрузка страницы
        /// </summary>
        /// <param name="url">Ссылка на страницу сайта</param>
        /// <param name="path">Путь сохранения файла</param>
        /// <returns>Успешно ли завершена загрузка</returns>
        bool DownloadPage(string url, string path);
    }
}
