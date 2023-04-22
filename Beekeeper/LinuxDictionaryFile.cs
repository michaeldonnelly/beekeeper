using System;
namespace Beekeeper
{
	public class LinuxDictionaryFile : IDictionaryFile
	{
		private const string filePath = "/usr/share/dict/words";
		private StreamReader streamReader;

        public LinuxDictionaryFile()
		{
			streamReader = new(filePath);
		}

		public string? NextWord()
		{
			string? word;

			do
			{
				word = streamReader.ReadLine();
				if (word is null)
				{
					return null;
				}

			}
			while(char.IsUpper(word[0]));

			return (word.ToUpper());
		}

        void IDisposable.Dispose()
        {
			streamReader.Dispose();
        }
    }
}

