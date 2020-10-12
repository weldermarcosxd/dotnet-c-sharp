using GoogleBooksApplication.Interfaces;
using GoogleBooksApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleBooksApplication.Services
{

    public class GoogleBooksService : IGoogleBooksService
    {
        private readonly HttpClient _client;

        public GoogleBooksService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://www.googleapis.com/books/v1/");
        }

        public async Task<IEnumerable<BookModel>> GetGoogleBooks(string query, int maxResults = 20)
        {
            var response = await _client.GetAsync($"volumes?q={query}&maxResults={maxResults}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                GoogleResponse googleResponse = JsonConvert.DeserializeObject<GoogleResponse>(jsonString);

                return googleResponse.Items;
            }

            throw new HttpRequestException();
        }

        public async Task<BookModel> GetGoogleBookById(string id)
        {
            var response = await _client.GetAsync($"volumes/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                BookModel book = JsonConvert.DeserializeObject<BookModel>(jsonString);

                return book;
            }

            throw new HttpRequestException();
        }
    }
}
