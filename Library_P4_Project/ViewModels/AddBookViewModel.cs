using Library_P4_Project.Model;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library_P4_Project.ViewModels
{
    public class AddBookViewModel : ViewModelBase
    {
        private MainWindowViewModel _mainWindowViewModel;
        private string _title;
        private string _description;
        private string _author;
        private int _categoryId;
        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }
        public string Author
        {
            get => _author;
            set => this.RaiseAndSetIfChanged(ref _author, value);
        }
        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }
        public int CategoryID
        {
            get => _categoryId;
            set => this.RaiseAndSetIfChanged(ref _categoryId, value);
        }
        public ICommand ApplyCommand { get; }
        public ICommand BackCommand { get; }

        public AddBookViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            ApplyCommand = ReactiveCommand.Create(Apply);
            BackCommand = ReactiveCommand.Create(Back);
        }

        public async void Apply()
        {
            var cat = _mainWindowViewModel.AppDbContext.BookCategories.Where(x=>x.Id == _categoryId).FirstOrDefault();
            var addBook = new Books()
            {
                Title = _title,
                Description = _description,
                Author = _author,
                CategoryId = _categoryId,
                Category = cat
            };
            await _mainWindowViewModel.BookService.Add(addBook);
            Back();
        }
        public void Back()
        {
            _mainWindowViewModel.CurrentView = new CatViewModel(_mainWindowViewModel);
        }
    }
}
