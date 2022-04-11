# HP-ApiLibrary

A simple wrapper made for [HP-API!](https://hp-api.herokuapp.com/) thanks [Edin Beth](https://twitter.com/edinbeth) for the simple api

Is just an library that i made to learn to make wrapper and learn more, if you think i did something wrong make a PR 

Note : Depends on Newtonsoft.Json to work! 

I designed the first time the library with .NET 6 but i realized it won't work on Xamarin Forms
so I switched to .NET Standard 2.1, the version 1.0.3 will support only .NET Standard

## Need Code Reviews 

Tweet me at [Twitter](https://twitter.com/ICotcariu)

### Nuget

It's on Nuget Version 1.0.2 .NET 6 [Get It](https://www.nuget.org/packages/HP-ApiLibrary/1.0.2) and this means no support

.NET Standard [.NET Standard](https://www.nuget.org/packages/HP-ApiLibrary/)

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