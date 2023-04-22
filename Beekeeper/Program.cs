using Beekeeper;

string dictionaryFile = "/usr/share/dict/words";
//string dictionaryFile = "/Users/donnelly/Projects/beekeeper/foo.txt";
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

using (StreamReader dictionary = new(dictionaryFile))
{
    string? word = dictionary.ReadLine();
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
        word = dictionary.ReadLine();
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
