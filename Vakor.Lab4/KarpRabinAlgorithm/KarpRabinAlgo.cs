namespace Vakor.Lab4.KarpRabinAlgorithm;

public class KarpRabinAlgo
{
    public bool FindPatternInText(string pattern, string fullText, Func<(string text, int startIndex, int length), int> hashFunction, out List<int> indexes)
    {
        int patternLength = pattern.Length;
        int patternHash = hashFunction((pattern, 0, patternLength));

        pattern = pattern.ToLower();
        fullText = fullText.ToLower();
        
        indexes = new List<int>();

        for (int i = 0; i < fullText.Length - patternLength + 1; i++)
        {
            if (hashFunction((fullText, i, patternLength)) == patternHash)
            {
                bool matchPattern = true;
                for (int j = 0; j < patternLength; j++)
                {
                    if (pattern[j] != fullText[i+j])
                    {
                        matchPattern = false;
                    }
                }

                if (matchPattern)
                {
                    indexes.Add(i);
                    i += patternLength-1;
                }
            }
        }

        return indexes.Count != 0;
    }
}