using Logger;

Console.WriteLine("Hello, World!");
var logger = new Logger.Logger("log.txt");
var logger2 = new Logger.Logger("log.txt", new LoggerOptions {
	DateTimePattern = "[date] at [TIME]",
	LongTimePattern = "mm:ss/hh",
	ShortDatePattern = "yyy.d.MM",

	ErrorType = ErrorWords.E,
	WarningType = WarningWords.W,
	InformationType = InformationWords.I
});

logger.Log(LogLevel.Information, "test info");
logger.Log(LogLevel.Warning, "test warning");
logger.Log(LogLevel.Error, "test error");

logger2.Log(LogLevel.Information, "test info2");
logger2.Log(LogLevel.Warning, "test warning2");
logger2.Log(LogLevel.Error, "test error2");