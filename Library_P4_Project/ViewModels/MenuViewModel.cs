using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library_P4_Project.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private MainWindowViewModel _mainWindowViewModel;
        public ReactiveCommand<Unit, Unit> LendCommand { get; }
        public ReactiveCommand<Unit, Unit> CategoryCommand { get; }
        public ReactiveCommand<Unit, Unit> CheckOutsCommand { get; }
        public ReactiveCommand<Unit, Unit> ExitCommand { get; }


        public MenuViewModel(MainWindowViewModel mainWindowViewModel)
        {
            LendCommand = ReactiveCommand.Create(LendBooks);
            CategoryCommand = ReactiveCommand.Create(BooksAndCategories);
            CheckOutsCommand = ReactiveCommand.Create(CheckOutOpen);
            ExitCommand = ReactiveCommand.Create(Exit);
            _mainWindowViewModel = mainWindowViewModel;
        }
        private void Exit()
        {
            Environment.Exit(0);
        }
        private void BooksAndCategories()
        {
            _mainWindowViewModel.CurrentView = new CatViewModel(_mainWindowViewModel);
        }
        private void LendBooks()
        {
            _mainWindowViewModel.CurrentView = new BooksViewModel(_mainWindowViewModel);
        }
        private void CheckOutOpen()
        {
            _mainWindowViewModel.CurrentView = new CheckOutViewModel(_mainWindowViewModel);
        }
    }
}
