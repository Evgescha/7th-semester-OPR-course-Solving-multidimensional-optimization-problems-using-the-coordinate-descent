using System;
namespace WindowsFormsApp1
{
	/// Исключение, если логгер уже настроен
	class LoggerAlreadySetupException : Exception
	{
		public LoggerAlreadySetupException(): base("Логгер уже создан или настроен")
		{
			
		}

		public LoggerAlreadySetupException(string message) : base(message)
		{

		}
	}
}
