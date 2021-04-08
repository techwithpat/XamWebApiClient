using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamWebApiClient.Models;
using XamWebApiClient.Services;

namespace XamWebApiClient.ViewModels
{
    [QueryProperty(nameof(BookId), nameof(BookId))]
    public class BookDetailsViewModel : BaseViewModel
    {
        private string bookId;
        private string title;
        private string author;
        private string description;
        private readonly IBookService _bookService;

        public BookDetailsViewModel(IBookService bookService)
        {
            _bookService = bookService;

            SaveBookCommand = new Command(async () =>
            {
                await SaveBook();
            });
        }

        private async Task SaveBook()
        {
            try
            {
                var book = new Book
                {
                    Id = int.Parse(BookId),
                    Title = Title,
                    Author = Author,
                    Description = Description
                };

                await _bookService.SaveBook(book);

                MessagingCenter.Send(this, Constants.UpdateBooks);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void LoadBook(string bookId)
        {
            try
            {
                var book = await _bookService.GetBook(int.Parse(bookId));
                if(bookId != null)
                {
                    Title = book.Title;
                    Author = book.Author;
                    Description = book.Description;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string BookId
        {
            get => bookId; 
            set
            {
                bookId = value;
                LoadBook(bookId);
            }
        }

        public string Title
        {
            get => title; 
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Author
        {
            get => author; 
            set
            {
                author = value;
                OnPropertyChanged(nameof(Author));
            }
        }
        public string Description
        {
            get => description; 
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ICommand SaveBookCommand { get; }
    }
}
