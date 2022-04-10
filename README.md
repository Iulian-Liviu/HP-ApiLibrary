# HP-ApiLibrary

A simple wrapper made for [HP-API!](https://hp-api.herokuapp.com/) thanks [Edin Beth](https://twitter.com/edinbeth) for the simple api

Is just an library that i made to learn to make wrapper and learn more, if you think i did something wrong make a PR 


## Need Code Reviews 

### Example 

```csharp
public static void Main()
        {
            //Creates the connection 
            HPConnection HpConnection = new HPConnection();

            // Get all Characters from the movie
            var r = HpConnection.GetAllCharactersAsync().Result;

            foreach (var item in r)
            {
                Console.WriteLine(item.Name);
            }
            // Get all characters from a specific house
            var FromHouse = HpConnection.GetCharactersFromHouse(HPHouse.Hufflepuff).Result;

            foreach (var item in FromHouse)
            {
                Console.WriteLine(item.Name);
            }
        }
```	