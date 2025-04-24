using Library_P4_Project.Model;
using Library_P4_Project.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library_P4_Project.ViewModels
{
    public class CatViewModel : ViewModelBase
    {
        private MainWindowViewModel _mainWindowViewModel;
        public ObservableCollection<Books> Books { get; }
        public ObservableCollection<BookCategories> Categories { get; }

        private Books _selectedBook;
        public Books SelectedBook
        {
            get => _selectedBook;
            set => this.RaiseAndSetIfChanged(ref _selectedBook, value);
        }

        private BookCategories _selectedCategory;
        public BookCategories SelectedCategory
        {
            get => _selectedCategory;
            set => this.RaiseAndSetIfChanged(ref _selectedCategory, value);
        }
        public ICommand CreateBookCommand { get; }
        public ICommand DeleteBookCommand { get; }
        public ICommand CreateCategoryCommand { get; }
        public ICommand DeleteCategoryCommand { get; }
        public ICommand BackCommand { get; }

        public CatViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            Books = new ObservableCollection<Books>();
            Categories = new ObservableCollection<BookCategories>();
            CreateBookCommand = ReactiveCommand.Create(CreateBook);
            DeleteBookCommand = ReactiveCommand.Create(DeleteBook);
            CreateCategoryCommand = ReactiveCommand.Create(CreateCategory);
            DeleteCategoryCommand = ReactiveCommand.Create(DeleteCategory);
            BackCommand = ReactiveCommand.Create(OnBack);
            Loading();
        }

        private void OnBack()
        {
            _mainWindowViewModel.CurrentView = new MenuViewModel(_mainWindowViewModel);
        }
        private void Loading()
        {
            LoadBooks();
            LoadCategories();
        }
        private void LoadBooks()
        {
            var books = _mainWindowViewModel.BookService.GetAll();
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }
        private void LoadCategories()
        {
            var cat = _mainWindowViewModel.BookCategoryService.GetAll();
            foreach (var item in cat)
            {
                Categories.Add(item);
            }
        }
        private void Realod()
        {
            Books.Clear();
            Categories.Clear();
            LoadBooks();
            LoadCategories();
        }
        private void CreateCategory()
        {
            _mainWindowViewModel.CurrentView = new AddCategoryViewModel(_mainWindowViewModel);
        }

        private async void DeleteCategory()
        {
            await _mainWindowViewModel.BookCategoryService.Remove(SelectedCategory);
            Realod();
        }

        private void CreateBook()
        {
            _mainWindowViewModel.CurrentView = new AddBookViewModel(_mainWindowViewModel);
        }

        private async void DeleteBook()
        {
            await _mainWindowViewModel.BookService.Remove(SelectedBook);
            Realod();
        }
    }
}
