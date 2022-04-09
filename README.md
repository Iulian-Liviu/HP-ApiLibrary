# HP-ApiLibrary

	A simple wrapper made for [HP-API!](https://hp-api.herokuapp.com/) thanks [Edin Beth](https://twitter.com/edinbeth) for the simple api

	Is just an library that i made to learn to make wrapper and learn more, if you think i did something wrong make a PR 


## Need Code Reviews 

### Example 

	```
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
	```