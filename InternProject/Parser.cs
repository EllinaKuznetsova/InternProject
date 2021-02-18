using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace InternProject
{
    /// <summary>
    /// Парсер
    /// </summary>
    public class Parser : IParser
    {
        readonly char[] separatingChars = { ' ', ',', '.', '!', '?', '\"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };
        
        /// <summary>
        /// Парсинг потока данных
        /// </summary>
        /// <param name="stream">Поток данных</param>
        /// <returns>Перечисление строк</returns>
        public IEnumerable<string> Parse(Stream stream)
        {
            if (stream is null)
            {
                throw new ArgumentNullException($"Аргумент {nameof(stream)} равен null");
            }

            long fileLength = stream.Length;
            long bytesReaded = 0;

            int offset = 0;
            int bufferSize = 2048;
            var buffer = new byte[bufferSize];

            var words = new List<string>();

            string lastWord = null;
            int maxIterations = Convert.ToInt32(Math.Ceiling(fileLength / (double)bufferSize));
            int currentIteration = 1;
            bool lastWordHasDelimiter = false;


            while (bytesReaded < fileLength)
            {
                int n = stream.Read(buffer, offset, bufferSize);

                if (n == 0)
                    break;

                bytesReaded += n;

                string str = Encoding.UTF8.GetString(n == bufferSize ? buffer : buffer.Take(n).ToArray());

                var splittedStrings = SplitByDelimiters(str);

                //Если в строке нет подстрок
                if (splittedStrings.Length == 0)
                {
                    //Строка состоит из разделителей
                    if (StringIsDelimiter(str))
                        lastWordHasDelimiter = true;

                    currentIteration++;
                    continue;
                }

                string firstWord = splittedStrings[0];
                bool firstWordHasDelimiter = CharIsDelimiter(str[0]);
                bool currentLastWordHasDelimiter = CharIsDelimiter(str[str.Length - 1]);

                if (currentIteration > 1)
                {
                    if (!lastWordHasDelimiter && !firstWordHasDelimiter) //если нет разделителей - объединяем
                    {
                        if (currentLastWordHasDelimiter) //Если текущая строка имеет разделитель
                        {
                            words.Add(lastWord + firstWord);
                        }
                        else //Если не имеет, объединяем предыдущую строку (нужно если текущая строка состоит из разделителей)
                        {
                            lastWord += firstWord;
                        }
                        splittedStrings = splittedStrings.Skip(1).ToArray();
                    }
                    else
                    {
                        words.Add(lastWord);
                    }
                }

                words.AddRange(splittedStrings.Take(splittedStrings.Length - 1));

                //Если предыдущая строка состояла из разделителей
                if (currentIteration == maxIterations && splittedStrings.Length - 1 == 0)
                {
                    words.Add(lastWord);
                }

                //Обновляем последнее слово
                if (splittedStrings.Length != 0)
                {
                    lastWord = splittedStrings[splittedStrings.Length - 1];
                    lastWordHasDelimiter = currentLastWordHasDelimiter;
                }

                //Если последняя итерация, то добавляем последнее слово
                if (currentIteration == maxIterations)
                {
                    words.Add(lastWord);
                }

                currentIteration++;
            }

            return words;
        }

        /// <summary>
        /// Является ли символ нормальным или разделителем
        /// </summary>
        /// <param name="ch">Символ</param>
        /// <returns>true - разделитель, false - нормальный символ</returns>
        bool CharIsDelimiter(char ch)
        {
            return separatingChars.Contains(ch);
        }

        /// <summary>
        /// Разделение строки с помощью разделителей
        /// </summary>
        /// <param name="text">Строка</param>
        /// <returns>Массив строк</returns>
        string[] SplitByDelimiters(string text)
        {
            if (text is null)
            {
                throw new ArgumentNullException($"Аргумент {nameof(text)} равен null");
            }

            return text.Split(separatingChars, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Строка состоит только из разделителей
        /// </summary>
        /// <param name="text">Строка</param>
        /// <returns>Является ли строка разделителем</returns>
        bool StringIsDelimiter(string text)
        {
            if (text is null)
            {
                throw new ArgumentNullException($"Аргумент {nameof(text)} равен null");
            }

            return text.Any(x => CharIsDelimiter(x));
        }
    }
}
