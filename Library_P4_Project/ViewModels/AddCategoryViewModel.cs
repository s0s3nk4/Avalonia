using Library_P4_Project.Model;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library_P4_Project.ViewModels
{
    public class AddCategoryViewModel : ViewModelBase
    {
        private MainWindowViewModel _mainWindowViewModel;
        private int _id;
        private string _name;
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        public int CategoryID
        {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }
        public ICommand ApplyCommand { get; }
        public ICommand BackCommand { get; }
        public AddCategoryViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            ApplyCommand = ReactiveCommand.Create(Apply);
            BackCommand = ReactiveCommand.Create(Back);
        }
        public async void Apply()
        {
            var addCategory = new BookCategories()
            {
                Name = _name,
                Id = _id,
            };
            await _mainWindowViewModel.BookCategoryService.Add(addCategory);
            Back();
        }
        public void Back()
        {
            _mainWindowViewModel.CurrentView = new CatViewModel(_mainWindowViewModel);
        }
    }
}
