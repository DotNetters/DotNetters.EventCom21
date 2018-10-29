using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DotNetters.EventCom21.ViewModels
{
	public class UserConfigurationPageViewModel : ViewModel
	{
        public UserConfigurationPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            UserName = Preferences.Get("EventCom.UserName", string.Empty);
        }

        void SetUserInPreferences()
        {
            Preferences.Set("EventCom.UserName", UserName);
            MessagingCenter.Send(this, "UserConfigured", UserName);
        }

        string userName;
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                SetProperty(ref userName, value);
                SetUserInPreferences();
            }
        }
    }
}
