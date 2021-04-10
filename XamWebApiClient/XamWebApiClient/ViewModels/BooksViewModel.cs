using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamWebApiClient.Models;
using XamWebApiClient.Services;
using XamWebApiClient.Views;

namespace XamWebApiClient.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {
        private ObservableCollection<Book> books;
        private Book selectedBook;
        private readonly IBookService _bookService;

        public BooksViewModel(IBookService bookService)
        {
            _bookService = bookService;

            Books = new ObservableCollection<Book>();

            DeleteBookCommand = new Command<Book>(async b => await DeleteBook(b));

            AddNewBookCommand = new Command(async () => await GoToAddbookView());
        }

        private async Task DeleteBook(Book b)
        {
            await _bookService.DeleteBook(b);

            PopulateBooks();
        }

        private async Task GoToAddbookView() 
            => await Shell.Current.GoToAsync(nameof(AddBook));

        public async void PopulateBooks()
        {
            try
            {
                Books.Clear();

                var books = await _bookService.GetBooks();
                foreach (var book in books)
                {
                    Books.Add(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async void OnBookSelected(Book book)
        {
            if (book == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(BookDetails)}?{nameof(BookDetailsViewModel.BookId)}={book.Id}");
        }

        public ObservableCollection<Book> Books
        {
            get => books;
            set
            {
                books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        public Book SelectedBook
        {
            get => selectedBook;
            set
            {
                if(selectedBook != value)
                {
                    selectedBook = value;

                    OnBookSelected(SelectedBook);
                }
            }
        }

        public ICommand DeleteBookCommand { get; }

        public ICommand AddNewBookCommand { get; }
    }
}
