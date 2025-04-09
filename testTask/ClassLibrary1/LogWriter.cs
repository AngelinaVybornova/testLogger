using System.IO;

namespace Logger
{
	public class LogWriter
	{
		private readonly string _path;
		private readonly LoggerOptions _options;

		public LogWriter(string path, LoggerOptions options)
		{
			_path = path;
			_options = options;
		}

		public void Write(string message)
		{
			Directory.CreateDirectory(Path.GetDirectoryName(_path));
			using (StreamWriter writer = new StreamWriter(_path, true, _options.encoding))
			{
				writer.WriteLine(message);
			}
		}
	}
}
