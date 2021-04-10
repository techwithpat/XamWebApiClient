using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using XamWebApiClient.Models;

namespace XamWebApiClient.Services
{
    public class ApiBookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public ApiBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var response = await _httpClient.GetAsync("Books");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Book>>(responseAsString);
        }

        public async Task<Book> GetBook(int id)
        {
            var response = await _httpClient.GetAsync($"Books/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Book>(responseAsString);
        }

        public async Task AddBook(Book book)
        {
            var response = await _httpClient.PostAsync("Books", 
                new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBook(Book book)
        {
            var response = await _httpClient.DeleteAsync($"Books/{book.Id}");

            response.EnsureSuccessStatusCode();
        }      

        public async Task SaveBook(Book book)
        {
            var response = await _httpClient.PutAsync($"Books?id={book.Id}",
                new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}
