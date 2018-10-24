using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetters.EventCom21.ViewModels
{
	public class ConnectedUsersPageViewModel : ViewModel
	{
        public ConnectedUsersPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            FromToolbar = (bool)parameters["fromToolbar"];
        }

        private bool fromToolbar;
        public bool FromToolbar
        {
            get { return fromToolbar; }
            set { SetProperty(ref fromToolbar, value); }
        }
    }
}
