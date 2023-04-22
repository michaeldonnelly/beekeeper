using Beekeeper;

IWordGame game;

List<char> letters = new()
{
    'T',
    'R',
    'I',
    'V',
    'A',
    'L',
    'U'
};
char requiredLetter = 'I';
game = new EssBee(letters, requiredLetter);
List<string> validWords = new();
List<string> specialWords = new();

//using (IDictionaryFile dictionaryFile = new LinuxDictionaryFile())
using (IDictionaryFile dictionaryFile = new Brute())
{
    string? word = dictionaryFile.NextWord();
    while (word is not null)
    {
        word = word.ToUpper();
        if (game.QualifiedWord(word))
        {
            validWords.Add(word);
            if (game.SpecialWord(word))
            {
                specialWords.Add(word);
            }
        }
        word = dictionaryFile.NextWord();
    }
}

Console.WriteLine($"Valid Words: {validWords.Count}");
foreach (string word in validWords)
{
    Console.WriteLine(word);
}

Console.WriteLine("");
Console.WriteLine($"Special Words: {specialWords.Count}");
foreach (string word in specialWords)
{
    Console.WriteLine(word);
}

Console.ReadKey();
