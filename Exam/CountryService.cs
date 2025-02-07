namespace Exam;

using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CountryService
{
    public async Task<List<Country>> GetCountriesAsync()
    {
        var client = new RestClient();
        var request = new RestRequest("https://restcountries.com/v3.1/all?fields=name", Method.Get);
        var response = await client.ExecuteAsync<List<Country>>(request);
        return response.Data;
    }
}

