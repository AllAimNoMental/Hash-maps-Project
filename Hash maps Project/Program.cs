using HashMapLesson;
using System.Security.Principal;


public class Program
{
    static void Main()
    {
        // ======================= TESTS(do not change) =======================
        Console.WriteLine("== A2 Summarize ==");
        var s = Summarize(new[] { 84, 62, 98, 75, 90 });
        Console.WriteLine($"{s.Min} {s.Max} {s.Average}");
        var (low, high, avg) = Summarize(new[] { 50 });
        Console.WriteLine($"{low} {high} {avg}");
        Console.WriteLine();
        Console.WriteLine("== B2 HashTable ==");
        var ht = new HashTable();
        ht.Set("nails", 100); ht.Set("tile", 50); ht.Set("lumber", 80);
        ht.Set("bolts", 0); ht.Set("screws", 140);
        Console.WriteLine(ht.ContainsKey("lumber"));
        Console.WriteLine(ht.ContainsKey("glue"));
        Console.WriteLine(ht.TryGet("bolts", out int v1) + " " + v1);
        Console.WriteLine(ht.TryGet("glue", out int v2) + " " + v2);
        Console.WriteLine();
        Console.WriteLine("== B3 MostFrequentWord ==");
        Console.WriteLine(HashTable.MostFrequentWord("the cat and the hat and the bat"));
        Console.WriteLine(HashTable.MostFrequentWord("Red blue RED green red"));
        Console.WriteLine();
        Console.WriteLine("== B3 CommonNames ==");
        var both = HashTable.CommonNames(new[] { "Ava", "Leo", "Maya", "Sam" },
        new[] { "Leo", "Sam", "Zoe" });
        var list = new List<string>(both);
        list.Sort(); // sort only so the output is the same every time
        Console.WriteLine(string.Join(", ", list));
        Console.WriteLine();


        // B1.1 Chaining
        // bucket 0: melon -> null
        // bucket 1: null
        // bucket 2: null
        // bucket 3: apple -> plum -> null
        // bucket 4: kiwi -> null
        // bucket 5: null
        // bucket 6: lime -> null

        // B1.2 Linear Probing
        // bucket  0: melon
        // bucket  1: empty
        // bucket  2: empty
        // bucket  3: apple
        // bucket  4: plum
        // bucket  5: kiwi
        // bucket  6: lime

        //var a = (Name: "Leo", Score: 77);
        //var b = a;
        //b.Score = 88;
        //Console.WriteLine(a.Score);          // Line 1 = 77
        //Console.WriteLine(b.Score);          // Line 2 = 88

        //var c = (First: "Leo", Points: 77);
        //Console.WriteLine(a == c);           // Line 3 = TRUE

        //var d = (Tag: "Lab", Scores: new List<int> { 70, 80 });
        //var e = d;
        //e.Tag = "Exam";
        //e.Scores.Add(90);
        //Console.WriteLine(d.Tag);            // Line 4 = Lab
        //Console.WriteLine(d.Scores.Count);   // Line 5 = 3
    }

    static (int Min, int Max, double Average) Summarize(int[] scores)
    {
        int min = scores[0];
        int max = scores[0];
        double sumOf = 0;
        foreach (int x in scores)
        {
            if (x < min)
            {
                min = x;
            }
            if (x > max)
            {
                max = x;
            }
            sumOf  += x;
        }
        double average = sumOf / scores.Length;
        return (min, max, average);
    }

}


