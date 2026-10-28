using HashMapLesson;
using System.Security.Principal;


public class Program
{
    static void Main()
    {
        HashTable table = new HashTable(7);

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
    }

}


