using System.Globalization;

namespace Logger
{
	public class LoggerOptions
	{
		public readonly System.Text.Encoding encoding = System.Text.Encoding.UTF8;

		public string ErrorWord { get; set; } = "ERR";
		public string WarningWord { get; set; } = "WARN";
		public string InformationWord { get; set; } = "INFO";

		public string ShortDatePattern { get; set; } = CultureInfo.InstalledUICulture.DateTimeFormat.ShortDatePattern;
		public string LongTimePattern { get; set; } = CultureInfo.InstalledUICulture.DateTimeFormat.LongTimePattern;
		public string DateTimePattern { get; set; } = "[date] | [time]";
		public string LogStringPattern { get; } = "[timestamp] [level] [message]";

		public ErrorWords ErrorType
		{ 
			set {
				ErrorWord = value.ToString();
			} 
		}

		public WarningWords WarningType
		{
			set
			{
				WarningWord = value.ToString();
			}
		}

		public InformationWords InformationType
		{
			set
			{
				InformationWord = value.ToString();
			}
		}
	}

	public enum ErrorWords
	{
		E,
		ERR,
		ERROR
	}

	public enum WarningWords
	{
		W,
		WARN,
		WARNING
	}

	public enum InformationWords
	{
		I,
		INFO,
		INFORMATION
	}
}
