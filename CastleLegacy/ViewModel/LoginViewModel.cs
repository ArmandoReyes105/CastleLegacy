using CastleLegacy.Helpers;
using CastleLegacy.View;
using CastleLegacy.Model; 
using System;
using System.Globalization;
using System.Security;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using log4net;

namespace CastleLegacy.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LoginViewModel));

        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private string _language; 

        //Properties
        public string Username 
        { 
            get => _username; 
            set 
            { 
                _username = value; 
                OnPropertyChanged(nameof(Username)); 
            } 
        }

        public SecureString Password 
        { 
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public string Language
        {
            get => _language;
            set
            {
                _language = value;
                OnPropertyChanged(nameof(Language));
            }
        }

        //Commands
        public ICommand LoginCommand { get; } 
        public ICommand CreateAccountCommand { get; }
        public ICommand ChangePasswordCommand { get; }
        public ICommand SetSpanishCommand { get; }
        public ICommand SetEnglishCommand { get; }
        


        //Constructor
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            CreateAccountCommand = new RelayCommand(ExecuteCreateAccountCommand);
            ChangePasswordCommand = new RelayCommand(ExecuteChangePasswordCommand);
            SetSpanishCommand = new RelayCommand(ExecuteSetSpanishCommand);
            SetEnglishCommand = new RelayCommand(ExecuteSetEnglishCommand); 

            SetLanguageLabel(); 
        }

        //CommandsImplementation

        private void ExecuteLoginCommand(object obj)
        {
            try
            {
                var account = AccountRepository.AuthenticateAccount(Username, Password);

                if(account != null)
                {
                    NavigationManager.Instance.NavigateTo(new MenuView());
                    SoundManager.PlayClickSound();
                }
                else
                {
                    ErrorMessage = Properties.Resources.IncorrectAccount; 
                }       
            }
            catch(Exception ex)
            {
                log.Error("Ha ocurrido un error: ", ex);
                ErrorMessage = Properties.Resources.ServerError; 
            }
             
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool canExecute = true;

            if (string.IsNullOrWhiteSpace(Username) || Password == null || Password.Length < 1)
            {
                canExecute = false;
            }

            return canExecute; 
        }

        private void ExecuteCreateAccountCommand(object obj)
        {
            NavigationManager.Instance.NavigateTo(new SignupView());
            SoundManager.PlayClickSound(); 
        }

        private void ExecuteChangePasswordCommand(object obj)
        {
            NavigationManager.Instance.ShowModalWindow(new ChangePasswordView());
            SoundManager.PlayClickSound();
        }

        private void ExecuteSetSpanishCommand(object obj)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");
            NavigationManager.Instance.NavigateTo(new LoginView());
            SoundManager.PlayClickSound();
        }

        private void ExecuteSetEnglishCommand(object obj)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            NavigationManager.Instance.NavigateTo(new LoginView());
            SoundManager.PlayClickSound();
        }

        //Methods
        public void SetLanguageLabel()
        {
            CultureInfo currentUICulture = CultureInfo.CurrentUICulture;
            Language = currentUICulture.Name.ToUpper();
        }

    }
}
