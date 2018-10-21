using DotNetters.EventCom21.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetters.EventCom21.ViewModels
{
	public class HelloWorldViewModel : ViewModel
	{
        IGreeter Greeter { get; set; } = null;

        public HelloWorldViewModel(INavigationService navigationService, IGreeter greeter) : base(navigationService)
        {
            Greeter = greeter;
            Greeting = Greeter.ComposeGreeting();
        }

        private string greeting;
        public string Greeting
        {
            get { return greeting; }
            set
            {
                SetProperty(ref greeting, value);
            }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                SetProperty(ref userName, value);
                if (string.IsNullOrWhiteSpace(userName))
                    UserNameTyped = false;
                else
                    UserNameTyped = true;
                RefreshGreeting();
            }
        }

        private bool userNameTyped = false;
        public bool UserNameTyped
        {
            get { return userNameTyped; }
            set { SetProperty(ref userNameTyped, value); }
        }

        void RefreshGreeting()
        {
            if (string.IsNullOrWhiteSpace(userName))
                Greeting = Greeter.ComposeGreeting();
            else
                Greeting = Greeter.ComposeGreeting(UserName);
        }
    }
}
