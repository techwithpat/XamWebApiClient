using System.Collections.Generic;
using System.Threading.Tasks;
using XamWebApiClient.Models;

namespace XamWebApiClient.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task AddBook(Book book);
        Task SaveBook(Book book);
        Task DeleteBook(Book book);      
    }
}
