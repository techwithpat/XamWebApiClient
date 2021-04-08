using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamWebApiClient.Models;

namespace XamWebApiClient.Services
{
    public class InMemoryBookService : IBookService
    {
        private readonly List<Book> _books = new List<Book>();
        public InMemoryBookService()
        {
            _books.Add(new Book { Id = 1, Title = "Clean code", Author = "Robert C Martin", Description = "A book about good code" });
            _books.Add(new Book { Id = 2, Title = "The pragmatic programmer", Author = "Andy hunt", Description = "All about pragmatism" });
            _books.Add(new Book { Id = 3, Title = "Refactoring", Author = "Kent Beck", Description = "Working with legacy code" });
        }

        public Task AddBook(Book book)
        {
            _books.Add(book);
            return Task.CompletedTask;
        }

        public Task DeleteBook(Book book)
        {
            _books.Remove(book);
            return Task.CompletedTask;
        }

        public Task<Book> GetBook(int id)
        {
            var book = _books.SingleOrDefault(b => b.Id == id);
            return Task.FromResult(book);
        }

        public Task<IEnumerable<Book>> GetBooks()
        {
            return Task.FromResult( _books.AsEnumerable());
        }

        public Task SaveBook(Book book)
        {
            _books.Add(book);

            _books[_books.FindIndex(b => b.Id == book.Id)] = book;
            return Task.CompletedTask;
        }
    }
}
