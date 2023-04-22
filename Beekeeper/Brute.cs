using System;
namespace Beekeeper
{
	public class Brute : IDictionaryFile
	{
        private char[] Letters;
        private int length;
        private int stable;
        private string starter;
        private string? word;

		public Brute()
		{
            Letters = new[] { 'T', 'R', 'I', 'V', 'A', 'L', 'U' };
            length = 5;
            starter = "RA";
            stable = starter.Length;
        }

        public string? NextWord()
        {
            if (word is null)
            {
                word = starter;
                for (int i=stable; i < length; i++)
                {
                    word += Letters[0];
                }
                return word;
            }
            else
            {
                for (int i=length - 1; i > stable; i--)
                {
                    char letter = word[i];
                    int index = Array.FindIndex(Letters, l => l == letter);
                    if (index + 1 < Letters.Count())
                    {
                        word = string.Concat(word.Take(i));
                        //word = string.Concat(Letters[index + 1]);
                        word += Letters[index + 1];
                        for (int j = i+1; j < length; j++)
                        {
                            word += Letters[0];
                        }
                        return word;
                    }
                }
            }
            return null;
        }

        public void Dispose() {}

    }
}

