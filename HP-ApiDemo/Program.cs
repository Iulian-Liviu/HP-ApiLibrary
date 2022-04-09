using HP_ApiLibrary;
using HP_ApiLibrary.Model;

namespace HP_ApiDemo
{
    internal class MyClass
    {
        public static void Main()
        {
            HPConnection? client = HPConnection.getInstance();
            var results = client.GetAllCharactersAsync().Result;
            /*
                        Console.WriteLine($"Writing out : {results.Count} characters names");

                        foreach (var ch in results)
                        {
                            Console.WriteLine(ch.Name);
                        }*/

            var gryffindor = client.GetCharactersFromHouse(HP_House.Gryffindor).Result;

            Console.WriteLine($"Listing all characters in the house Gryffindor, Total items : {gryffindor.Count}");
            foreach (var ch in gryffindor)
            {
                Console.WriteLine(ch.Name);
            }
        }
    }
}