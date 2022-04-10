using HPApiLibrary;
using HPApiLibrary.Helpers;

namespace HP_ApiDemo
{
    internal class Program
    {
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
    }
}