using System;
using System.Text.RegularExpressions;

namespace Logger
{
	public class Logger : ILogger
	{
		private readonly string _path;

		private static readonly Regex DateTimePatternRegex = new Regex(
            @"\[(date|time)\]", 
            RegexOptions.IgnoreCase | RegexOptions.Compiled
        );
		private static readonly Regex LogStringPatternRegex = new Regex(
			@"\[(timestamp|level|message)\]",
			RegexOptions.IgnoreCase | RegexOptions.Compiled
		);

		private readonly LogWriter _writer;

		public LoggerOptions _options;

		public Logger(string path, LoggerOptions initializer)
		{
			_path = path;
			_options = initializer;
			_writer = new LogWriter(path, _options);
		}

		public Logger(string path) : this(path, new LoggerOptions()) {}

		public void Log(LogLevel level, string message)
		{
			_writer.Write(BuildLogString(level, message));
		}

		private string BuildLogString(LogLevel level, string message)
		{
			var timestamp = GetDateTime();
			var levelString = GetLevelWord(level);
			return LogStringPatternRegex.Replace(_options.LogStringPattern, match =>
			{
				var placeholder = match.Groups[1].Value.ToLower();

				if (placeholder == "timestamp")
					return timestamp;
				else if (placeholder == "level")
					return levelString;
				else if (placeholder == "message")
					return message;

				return match.Value;
			});
		}

		private string GetLevelWord(LogLevel level)
		{
			switch (level) {
				case LogLevel.Warning:
					return _options.WarningWord;
				case LogLevel.Error:
					return _options.ErrorWord;
				default:
					return _options.InformationWord;
			}
		}

		private string GetDateTime()
		{
			return DateTimePatternRegex.Replace(_options.DateTimePattern, match =>
			{
				var now = DateTime.Now;
				var placeholder = match.Groups[1].Value.ToLower();

				if (placeholder == "date")
					return now.ToString(_options.ShortDatePattern);
				else if (placeholder == "time")
					return now.ToString(_options.LongTimePattern);

				return match.Value;
			});
		}
	}
}
