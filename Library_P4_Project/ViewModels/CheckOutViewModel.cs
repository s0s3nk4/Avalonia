using Library_P4_Project.Model;
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
    public class CheckOutViewModel : ViewModelBase
    {
        private MainWindowViewModel _mainWindowViewModel;
        private CheckOuts _selectedCheckOut;
        public CheckOuts SelectedCheckOut
        {
            get => _selectedCheckOut;
            set => this.RaiseAndSetIfChanged(ref _selectedCheckOut, value); 
        }
        public ICommand CheckInCommand { get; }
        public ICommand BackCommand { get; }
        public ObservableCollection<CheckOuts> CheckOuts { get; }

        public CheckOutViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            CheckInCommand = ReactiveCommand.Create(CheckIn);
            BackCommand = ReactiveCommand.Create(Back);
            CheckOuts = new ObservableCollection<CheckOuts>();
            LoadCheckOuts();
        }

        private void LoadCheckOuts()
        {
            var check = _mainWindowViewModel.CheckOutService.GetAll();
            if(check != null)
            {
                foreach (var item in check)
                {
                    CheckOuts.Add(item);
                }
            }
        }
        private void Realod()
        {
            CheckOuts.Clear();
            LoadCheckOuts();
        }
        private void Back()
        {
            _mainWindowViewModel.CurrentView = new MenuViewModel(_mainWindowViewModel);
        }
        private async void CheckIn()
        {
            await _mainWindowViewModel.CheckOutService.Remove(_selectedCheckOut);
            Realod();
        }
    }
}
