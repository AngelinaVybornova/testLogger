using Logger;

Console.WriteLine("Файл лога будет находится в bin\\log папке проекта");

//логгер с настройками по умолчанию
var logger = new Logger.Logger("..\\..\\log\\log.txt");

logger.Log(LogLevel.Information, "test info");
logger.Log(LogLevel.Warning, "test warning");
logger.Log(LogLevel.Error, "test error");

//логгер с заданными паттернами даты, времени и их положения,
//с использованием предварительно заданных обозначений для уровней
var logger2 = new Logger.Logger("..\\..\\log\\log.txt", new LoggerOptions {
	DateTimePattern = "[date] at [time]",
	LongTimePattern = "mm:ss/hh",
	ShortDatePattern = "yyy.d.MM",

	ErrorType = ErrorWords.E,
	WarningType = WarningWords.W,
	InformationType = InformationWords.I
});

logger2.Log(LogLevel.Information, "test info 2");
logger2.Log(LogLevel.Warning, "test warning 2");
logger2.Log(LogLevel.Error, "test error 2");

//логгер с заданным паттерном положения даты и времени, с уникальными обозначениями уровней
var logger3 = new Logger.Logger("..\\..\\log\\log.txt", new LoggerOptions
{
	DateTimePattern = "дата: [DATE], время: [TIME]",

	ErrorWord = "ОШИБКА",
	WarningWord = "ПРЕДУПРЕЖДЕНИЕ",
	InformationWord = "ИНФОРМАЦИЯ"
});

logger3.Log(LogLevel.Information, "тест информация 3");
logger3.Log(LogLevel.Warning, "тест предупреждение 3");
logger3.Log(LogLevel.Error, "тест ошибка 3");