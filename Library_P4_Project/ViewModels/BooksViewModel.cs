using Library_P4_Project.Model;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Library_P4_Project.ViewModels
{
    public class BooksViewModel : ViewModelBase
    {
        private MainWindowViewModel _mainWindowViewModel;

        private Books _selectedBook;

        public Books SelectedBook
        {
            get => _selectedBook;
            set => this.RaiseAndSetIfChanged(ref _selectedBook, value);
        }
        private string _reader;
        public string Reader
        {
            get => _reader;
            set => this.RaiseAndSetIfChanged(ref _reader, value);
        }
        private string _phone;
        public string Phone
        {
            get=> _phone;
            set => this.RaiseAndSetIfChanged(ref _phone, value);
        }
        
        public ObservableCollection<Books> Books { get; set; }
        public ReactiveCommand<Unit, Unit> CheckoutCommand { get; }
        public ReactiveCommand<Unit, Unit> BackCommand { get; }
        public BooksViewModel(MainWindowViewModel mainWindowViewModel)
        {
            Books = new ObservableCollection<Books>();
            _mainWindowViewModel = mainWindowViewModel;
            CheckoutCommand = ReactiveCommand.Create(ExecuteCheckoutCommand);
            BackCommand = ReactiveCommand.Create(OnBack);
            LoadBooks();
        }
        private void LoadBooks()
        {
            var books = _mainWindowViewModel.BookService.GetAll();
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }
        private void Reload()
        {
            Books.Clear();
            LoadBooks();
        }
        private async void ExecuteCheckoutCommand()
        {
            var checkOut = new CheckOuts()
            {
                Reader = _reader,
                Phone = _phone,
                CheckInDate = DateTime.Now.AddMonths(1),
                CheckOutDate = DateTime.Now,
                Book = _selectedBook,
                BookId = _selectedBook.Id
            };
            await _mainWindowViewModel.CheckOutService.Add(checkOut);
            Reload();
            OnBack();
        }
        private void OnBack()
        {
            _mainWindowViewModel.CurrentView = new MenuViewModel(_mainWindowViewModel);
        }
    }
}
