using Library_P4_Project.Model;
using Library_P4_Project.Persistence;
using Library_P4_Project.Service;
using ReactiveUI;

namespace Library_P4_Project.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public object _currentView;
        private AppDbContext _appDbContext;
        private CategoryService _bookCategoryService;
        private CheckOutService _checkOutService;
        private BookService _bookService;
        
        public object CurrentView
        {
            get => _currentView;
            set => this.RaiseAndSetIfChanged(ref _currentView, value);
        }
        public AppDbContext AppDbContext
        {
            get => _appDbContext;
        }
        public CategoryService BookCategoryService
        {
            get => _bookCategoryService;
        }
        public BookService BookService
        {
            get => _bookService;
        }
        public CheckOutService CheckOutService
        {
            get => _checkOutService;
        }

        public MainWindowViewModel()
        {
            _appDbContext = new AppDbContext("PLACEHOLDER");
            _bookService = new BookService(_appDbContext);
            _bookCategoryService = new CategoryService(_appDbContext);
            _checkOutService = new CheckOutService(_appDbContext);
            CurrentView = new MenuViewModel(this);
        }
    }
}
