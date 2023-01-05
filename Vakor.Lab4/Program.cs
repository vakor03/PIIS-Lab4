// See https://aka.ms/new-console-template for more information

using Vakor.Lab4.DijkstraAlgorithm;
using Vakor.Lab4.KarpRabinAlgorithm;
using Vakor.Lab4.PrimAlgorithm;

Console.WriteLine("Hello, World!");

// Karp-Rabin (hash == %12)

#region Karp-Rabin

KarpRabinAlgo karpRabinAlgo = new KarpRabinAlgo();

string pattern = "suffer";
string fullText = "Why we still here? -Just to suffer. I will add 'sufffer' one more time." +
                  "SUFFER suffer SuFfEr. Suffer or not to suffer, that is the question";

bool found = karpRabinAlgo.FindPatternInText(pattern, fullText, FindHash, out List<int> indexes);

// if (found)
// {
//     Console.WriteLine($"Found pattern '{pattern}' {indexes.Count} times on these indexes:");
//     Console.WriteLine(String.Join(", ", indexes));
// }
// else
// {
//     Console.WriteLine($"Pattern '{pattern}' not found!");
// }


int FindHash((string fullText, int startIndex, int length) bundle)
{
    int sum = 0;
    
    string lowerText = bundle.fullText.ToLower();
    
    for (int i = 0; i < bundle.length; i++)
    {
        sum += lowerText[bundle.startIndex + i];
    }

    return sum % 12;
}

#endregion

// Dijkstra

#region Dijkstra

DijkstraAlgorithm dijkstraAlgorithm = new DijkstraAlgorithm();

int[,] matrix = {
    { 0, 1, 2},
    { 1, 0, 4},
    { 2, 4, 0},
};

//int[,] matrix = CreateMatrixFromString(5, "21=4, 32=5");
int nodeIndex = 0;

var result = dijkstraAlgorithm.FindDistanceToAll(nodeIndex, matrix);

// Console.WriteLine($"Distance from node {nodeIndex} to all nodes:");
// Console.WriteLine(String.Join(", ", result.Select(el => el==int.MaxValue ? "Nan" : $"{el}")));

// 21=4, 32=5
static int[,] CreateMatrixFromString(int nodeCount, string inputString)
{
    int[,] matrix = new int[nodeCount, nodeCount];

    string[] lexemes = inputString.Split(',', StringSplitOptions.TrimEntries);
    foreach (var lexeme in lexemes)
    {
        int result = int.Parse(lexeme.Substring(3));
        int startIndex = int.Parse(lexeme[0].ToString());
        int endIndex = int.Parse(lexeme[1].ToString());
        
        matrix[startIndex, endIndex] = result;
    }

    return matrix;
}

#endregion

// Prim

#region Prim

PrimAlgorithm primAlgorithm = new PrimAlgorithm();
var minOctTree = primAlgorithm.FindMinOctTree(matrix);

#endregion