using PoolCalc.ViewModels.Interfaces;
using ReactiveUI;

namespace PoolCalc.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        IHomeViewModelFactory homeFactory = new HomeViewModelFactory();

        public MainWindowViewModel()
        {
            content = Content = homeFactory.Create();
        }

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public void GetHomePage()
        {
            Content = homeFactory.Create();
        }
    }
}
