using System;
using System.Collections.Generic;
using System.Text;


namespace InternProject
{
	/// <summary>
	/// Интерфейс логгера
	/// </summary>
	public interface ILogger
	{
		/// <summary>
		/// Запись в лог
		/// </summary>
		/// <param name="message">Сообщение</param>
		void Log(string message);
	}
}

