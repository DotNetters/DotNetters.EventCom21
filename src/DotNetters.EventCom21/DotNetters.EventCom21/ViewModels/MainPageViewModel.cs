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

        private DelegateCommand navigateToConnectedUsersCommand;
        public DelegateCommand NavigateToConnectedUsersCommand =>
            navigateToConnectedUsersCommand ?? (navigateToConnectedUsersCommand = new DelegateCommand(NavigateToConnectedUsers));

        async void NavigateToConnectedUsers()
        {
            //await NavigationService.NavigateAsync("ConnectedUsersPage");
            //await NavigationService.NavigateAsync("ConnectedUsersPage", navParams, false, false);
            var navParams = new NavigationParameters();

            navParams.Add("fromToolbar", true);

            await NavigationService.NavigateAsync("ConnectedUsersPage", navParams);
        }
    }
}
