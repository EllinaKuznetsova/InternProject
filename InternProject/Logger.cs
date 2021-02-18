using System;
using System.IO;

namespace InternProject
{ 
	/// <summary>
	/// Логгер
	/// </summary>
	public class Logger : ILogger
	{
		private DateTime _startTime;
		private static Logger _instance;

		/// <summary>
		/// Экземпляр логгера
		/// </summary>
		public static Logger Instance
		{
			get
			{
				if (_instance == null)
					_instance = new Logger();
				return _instance;
			}
		}

		private Logger()
		{
			_startTime = DateTime.Now;
		}

		/// <summary>
		/// Вывод в лог
		/// </summary>
		/// <param name="message">Сообщение</param>
		public void Log(string message)
		{
			File.AppendAllText($"log_{_startTime:yyyy_MM_dd_hh_mm_ss}.txt", $"{DateTime.Now}\t{message}");
		}
	}
}
