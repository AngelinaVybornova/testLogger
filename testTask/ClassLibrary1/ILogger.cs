namespace Logger
{
	public interface ILogger
	{
		/// Записать сообщение в журнал
		/// level - уровень важности сообщения
		/// message - текст сообщения
		void Log(LogLevel level, string message);
	}
	/// Уровень важности сообщения в журнале
	public enum LogLevel
	{
		Information,
		Warning,
		Error
	}

}