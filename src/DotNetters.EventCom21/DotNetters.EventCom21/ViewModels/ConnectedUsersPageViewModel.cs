using DotNetters.EventCom21.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DotNetters.EventCom21.ViewModels
{
	public class ConnectedUsersPageViewModel : ViewModel
	{
        IUsersManager UsersManager { get; set; } = null;

        public ConnectedUsersPageViewModel(INavigationService navigationService, IUsersManager usersManager) : base(navigationService)
        {
            UsersManager = usersManager ?? throw new ArgumentNullException(nameof(usersManager));
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var users = await UsersManager.GetConnectedUsers();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public ObservableCollection<string> Users { get; set; } = new ObservableCollection<string>();
    }
}
