using System;
namespace Beekeeper
{
	public interface IWordGame
	{
        public bool QualifiedWord(string word);

        public bool SpecialWord(string word);
    }
}

