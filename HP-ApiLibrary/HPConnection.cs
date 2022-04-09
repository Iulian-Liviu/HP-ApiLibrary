using HP_ApiLibrary.Model;
using RestSharp;

namespace HP_ApiLibrary
{
    public class HPConnection
    {
        private static readonly HPConnection instance = new();
        private readonly string Base_Url = "https://hp-api.herokuapp.com/api/characters";
        private readonly string Base_Url_Staff = "http://hp-api.herokuapp.com/api/characters/staff";
        private readonly string Base_Url_Students = "http://hp-api.herokuapp.com/api/characters/students";
        private readonly string Base_Url_Houses = "https://hp-api.herokuapp.com/api/characters/house/";

        private HPConnection()
        {

        }

        public static HPConnection getInstance()
        {
            return instance;
        }

        public async Task<List<CharactersResults>> GetAllCharactersAsync()
        {
            using RestClient? client = new(Base_Url);
            RestRequest? request = new();

            RestResponse response = await client.GetAsync(request);

            if (response.IsSuccessful)
            {
                List<CharactersResults> charactersResults = CharactersResults.FromJson(response.Content);
                return charactersResults;
            }
            else
            {
                client.Dispose();
                throw new Exception("Data not found!");
            }
            throw new Exception("Out of service!");
        }
        public async Task<List<CharactersResults>> GetAllStudentsAsync()
        {
            using RestClient? client = new(Base_Url_Students);
            RestRequest? request = new();

            RestResponse response = await client.GetAsync(request);

            if (response.IsSuccessful)
            {
                List<CharactersResults> charactersResults = CharactersResults.FromJson(response.Content);
                return charactersResults;
            }
            else
            {
                client.Dispose();
                throw new Exception("Data not found!");
            }
            throw new Exception("Out of service!");
        }


        public async Task<List<CharactersResults>> GetAllCharactersStaffAsync()
        {
            using RestClient? client = new(Base_Url_Staff);
            RestRequest? request = new();

            RestResponse response = await client.GetAsync(request);

            if (response.IsSuccessful)
            {
                List<CharactersResults> charactersResults = CharactersResults.FromJson(response.Content);
                return charactersResults;
            }
            else
            {
                client.Dispose();
                throw new Exception("Data not found!");
            }
            throw new Exception("Out of service!");
        }
        private async Task<List<CharactersResults>> GetAllCharactersFromHouseAsync(string house)
        {
            using RestClient? client = new(Base_Url_Houses + house);
            RestRequest? request = new();

            RestResponse response = await client.GetAsync(request);

            if (response.IsSuccessful)
            {
                List<CharactersResults> charactersResults = CharactersResults.FromJson(response.Content);
                return charactersResults;
            }
            else
            {
                client.Dispose();
                throw new Exception("Data not found!");
            }
            throw new Exception("Out of service!");
        }

        public async Task<List<CharactersResults>> GetCharactersFromHouse(HP_House House)
        {
            var results = new List<CharactersResults>();

            if (House == HP_House.Hufflepuff)
            {
                results = await GetAllCharactersFromHouseAsync("hufflepuff");
                return results;
            }
            else if (House == HP_House.Slytherin)
            {
                results = await GetAllCharactersFromHouseAsync("slytherin");
                return results;
            }
            else if (House == HP_House.Gryffindor)
            {
                results = await GetAllCharactersFromHouseAsync("gryffindor");
                return results;
            }
            else if (House == HP_House.Slytherin)
            {
                results = await GetAllCharactersFromHouseAsync("slytherin");
                return results;
            }
            ///returing gryffindor by default
            results = await GetAllCharactersFromHouseAsync("gryffindor");
            return results;
        }

    }
}