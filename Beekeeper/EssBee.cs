using System;
namespace Beekeeper
{
	public class EssBee : IWordGame
	{
		private const int minimumLength = 4;

		public EssBee(IEnumerable<char> letters, char requiredLetter)
		{
			Letters = new();
			foreach (char letter in letters)
			{
				Letters.Add(char.ToUpper(letter));
			}
			
			RequiredLetter = char.ToUpper(requiredLetter);
		}

		public HashSet<char> Letters { get; set; }

		public char RequiredLetter { get; set; }

		public bool QualifiedWord(string word)
		{			
			if (word.Length < minimumLength)
			{
				return false;
			}

            if (!word.Contains(RequiredLetter))
			{
				return false;
			}

			foreach (char letter in word)
			{
				if (!Letters.Contains(letter))
				{
					return false;
				}
			}

			return true;
		}

        bool IWordGame.SpecialWord(string word)
        {
			foreach (char letter in Letters)
			{
				if (!word.Contains(letter))
				{
					return false;
				}
			}

			return true;
        }
    }
}

