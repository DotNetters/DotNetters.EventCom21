using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetters.EventCom21.ViewModels
{
	public class ConversationPageViewModel : ViewModel
	{
        public ConversationPageViewModel(INavigationService navigationService) : base(navigationService)
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

            navParams.Add("fromToolbar", false);

            await NavigationService.NavigateAsync("ConnectedUsersPage", navParams);
        }
    }
}
