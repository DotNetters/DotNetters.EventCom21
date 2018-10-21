using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetters.EventCom21.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        private DelegateCommand navigateToHelloWorldCommand;
        public DelegateCommand NavigateToHelloWorldCommand =>
            navigateToHelloWorldCommand ?? (navigateToHelloWorldCommand = new DelegateCommand(NavigateToHelloWorld));

        async void NavigateToHelloWorld()
        {
            await NavigationService.NavigateAsync("HelloWorld");
        }
    }
}
