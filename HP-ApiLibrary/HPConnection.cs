using HPApiLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HPApiLibrary
{
    public class HPConnection
    {
        // Private fields for Api Urls
        private static class HpApiUris
        {
            public static readonly Uri CharactersUri = new Uri("https://hp-api.herokuapp.com/api/characters");
            public static readonly Uri StaffUri = new Uri("http://hp-api.herokuapp.com/api/characters/staff");
            public static readonly Uri StudentsUri = new Uri("http://hp-api.herokuapp.com/api/characters/students");
        }

        // Private fields for Houses
        private static class HpApiHouseUri
        {
            public static readonly Uri Gryffindor = new Uri("https://hp-api.herokuapp.com/api/characters/house/gryffindor");
            public static readonly Uri Hufflepuff = new Uri("https://hp-api.herokuapp.com/api/characters/house/hufflepuff");
            public static readonly Uri Slytherin = new Uri("https://hp-api.herokuapp.com/api/characters/house/slytherin");
            public static readonly Uri Ravenclaw = new Uri("https://hp-api.herokuapp.com/api/characters/house/ravenclaw");

        }

        // No more RestSharp
        private readonly HttpClient httpClient = new HttpClient();
        /// <summary>
        /// Takes an Uri and returns results if is an error throws and Exception
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<List<CharactersResults>> GetResults(Uri uri)
        {
            try
            {
                string json = await httpClient.GetStringAsync(uri);
                return CharactersResults.FromJson(json);
            }
            catch (HttpRequestException e)
            {
                // It good to throw here ?
                throw new Exception("The following error has been catched : " + e.Message);
            }
        }

        private async Task<List<CharactersResults>> GetAllCharactersFromHouseAsync(Uri houseUri)
        {
            return await GetResults(houseUri);
        }

        /// <summary>
        /// Get all characters async 
        /// </summary>
        /// <returns>List<CharactersResults></returns>
        public async Task<List<CharactersResults>> GetAllCharactersAsync()
        {
            return await GetResults(HpApiUris.CharactersUri);
        }
        /// <summary>
        /// Get the students async 
        /// </summary>
        /// <returns>List<CharactersResults></returns>
        public async Task<List<CharactersResults>> GetAllStudentsAsync()
        {
            return await GetResults(HpApiUris.StudentsUri);
        }
        /// <summary>
        /// Get the staffs async 
        /// </summary>
        /// <returns>List<CharactersResults></returns>
        public async Task<List<CharactersResults>> GetAllCharactersStaffAsync()
        {
            return await GetResults(HpApiUris.StaffUri);
        }
        /// <summary>
        /// Get characters based on their House 
        /// </summary>
        /// <param name="House"></param>
        /// <returns></returns>
        public async Task<List<CharactersResults>> GetCharactersFromHouse(HPHouse House)
        {
            List<CharactersResults> results = new List<CharactersResults>();

            if (House == HPHouse.Hufflepuff)
            {
                return await GetAllCharactersFromHouseAsync(HpApiHouseUri.Hufflepuff);
            }
            else if (House == HPHouse.Ravenclaw)
            {
                results = await GetAllCharactersFromHouseAsync(HpApiHouseUri.Ravenclaw);
                return results;
            }
            else if (House == HPHouse.Gryffindor)
            {
                results = await GetAllCharactersFromHouseAsync(HpApiHouseUri.Gryffindor);
                return results;
            }
            else if (House == HPHouse.Slytherin)
            {
                results = await GetAllCharactersFromHouseAsync(HpApiHouseUri.Slytherin);
                return results;
            }
            else
            {
                return new List<CharactersResults>();
            }
        }

    }
}