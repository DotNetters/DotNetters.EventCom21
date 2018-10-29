using DotNetters.EventCom21.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DotNetters.EventCom21.ViewModels
{
    public class ConversationPageViewModel : ViewModel
	{
        IMessageSender MessageSender { get; set; } = null;

        IPageDialogService PageDialogService { get; set; } = null;

        public ConversationPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IMessageSender messageSender) : base(navigationService)
        {
            MessageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
            PageDialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            ReadUserConfiguration();
            MessagingCenter.Subscribe<UserConfigurationPageViewModel, string>(this, "UserConfigured", (sender, arg) => {
                UserName = arg;
                if (string.IsNullOrWhiteSpace(UserName))
                {
                    UserConfigured = false;
                }
                else
                {
                    UserConfigured = true;
                }
            });
        }

        void ReadUserConfiguration()
        {
            var usrName = Preferences.Get("EventCom.UserName", string.Empty);
            if (string.IsNullOrWhiteSpace(usrName))
            {
                UserConfigured = false;
            }
            else
            {
                UserConfigured = true;
            }
            UserName = usrName;
        }

        private DelegateCommand navigateToConnectedUsersCommand;
        public DelegateCommand NavigateToConnectedUsersCommand =>
            navigateToConnectedUsersCommand ?? (navigateToConnectedUsersCommand = new DelegateCommand(NavigateToConnectedUsersAsync));

        async void NavigateToConnectedUsersAsync()
        {
            var navParams = new NavigationParameters();

            navParams.Add("fromToolbar", false);

            await NavigationService.NavigateAsync("ConnectedUsersPage", navParams);
        }

        private DelegateCommand sendCommand;
        public DelegateCommand SendCommand =>
            sendCommand ?? (sendCommand = new DelegateCommand(SendAsync));

        async void SendAsync()
        {
            if (!UserConfigured)
            {
                await PageDialogService.DisplayAlertAsync("Error", "No has configurado tu nick. Ve a la pestaña config, e indícalo para poder hacer preguntas o enviar sugerencias", "Cerrar");
            }
            else
            {
                StatusInfo = "Enviando mensaje...";
                var result = await MessageSender.SendAsync(UserName, Message);
                StatusInfo = result.message;
                if (result.success)
                    Clear();
            }
        }

        string userName;
        /// <summary>
        /// Nombre del usuario actual
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
            }
        }

        bool userConfigured;
        /// <summary>
        /// Indica si el usuario ha sido configurado
        /// </summary>
        public bool UserConfigured
        {
            get
            {
                return userConfigured;
            }
            set
            {
                SetProperty(ref userConfigured, value);
            }
        }

        string message;
        /// <summary>
        /// Mensaje a enviar
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                SetProperty(ref message, value);
                if (value != string.Empty)
                    StatusInfo = string.Empty;
            }
        }

        string statusInfo;
        /// <summary>
        /// Información de estado
        /// </summary>
        public string StatusInfo
        {
            get
            {
                return statusInfo;
            }
            set
            {
                SetProperty(ref statusInfo, value);
            }
        }

        /// <summary>
        /// Descripción del error si se ha producido
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Pone en estado inicial la pantalla
        /// </summary>
        public void Clear()
        {
            Message = string.Empty;
        }
    }
}
