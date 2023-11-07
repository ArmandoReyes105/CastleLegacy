using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.ServiceModel.Description;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using CastleLegacy.Helpers;
using CastleLegacy.Model;
using CastleLegacy.ServerServices;
using CastleLegacy.View;

namespace CastleLegacy.ViewModel
{
    public class SignUpViewModel : ViewModelBase
    {

        //Fields
        private string _username;
        private string _email;
        private string _errorMessage;
        private string _generalErrorMessage; 
        private SecureString _password;
        private SecureString _confirmPassword;

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

        public string Email 
        { 
            get => _email;
            set
            { 
                _email = value;
                OnPropertyChanged(nameof(Email));
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

        public string GeneralErrorMessage
        {
            get => _generalErrorMessage;
            set
            {
                _generalErrorMessage = value;
                OnPropertyChanged(nameof(GeneralErrorMessage));
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

        public SecureString ConfirmPassword 
        { 
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        //Commands
        public ICommand CreateAccountCommand { get; }
        public ICommand ReturnToLoginCommand { get; }

        //Constructor
        public SignUpViewModel()
        {
            CreateAccountCommand = new RelayCommand(ExecuteCreateAccountCommand, CanExecuteCreateAccountCommand);
            ReturnToLoginCommand = new RelayCommand(ExecuteReturnToLoginCommand);
        }

        //CommandsImplementation
        private bool CanExecuteCreateAccountCommand(object obj)
        {
            bool result = true;

            if (!AreFieldsComplete())
            {
                ErrorMessage = "Todos los campos deben estar llenos";
                result = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(Email) && !Regex.IsMatch(Email, @"^\w+@gmail\.com$"))
                {
                    ErrorMessage = "El correo electrónico debe ser una dirección de Gmail válida.";
                    result = false;
                }
                else if (string.IsNullOrEmpty(Username) || Username.Length < 3 || Username.Length > 20 || !Regex.IsMatch(Username, "^[a-zA-Z0-9]+$"))
                {
                    ErrorMessage = "El nombre de usuario debe tener entre 3 y 20 caracteres \ny contener solo letras y números.";
                    result = false;
                }
                else if (Password.Length < 6 || Password.Length > 12)
                {
                    ErrorMessage = "La contraseña debe ser entre 6 y 12 caracteres";
                    result = false;
                }
                else if (!AccountRepository.AreSamePassword(Password, ConfirmPassword))
                {
                    ErrorMessage = "La contraseña debe ser la misma"; 
                    result = false;
                }
                else
                {
                    ErrorMessage = "";
                }
            }

            return result;
        }

        private void ExecuteCreateAccountCommand(object obj)
        {
            try
            {
                int operationResult = AccountRepository.CreateAccount(Email, Username, Password, ConfirmPassword);
                if(operationResult == 1)
                {
                    NavigationManager.Instance.NavigateTo(new LoginView());
                    SoundManager.PlayClickSound();
                }
                else
                {
                    GeneralErrorMessage = "Ocurrio un error al intentar crear su cuenta"; 
                }
            }catch (Exception ex)
            {
                GeneralErrorMessage = Properties.Resources.ServerError; 
                Console.WriteLine(ex.Message);
            }
            
        }

        private void ExecuteReturnToLoginCommand(object obj)
        {
            NavigationManager.Instance.NavigateTo(new LoginView());
            SoundManager.PlayClickSound(); 
        }

        //Methods 
        public void addAccount(Account account)
        {

            try
            {
                AccountClient client = new AccountClient();
                client.AddAccount(account);
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la cuenta: {ex.Message}");
            }

        }

        private bool AreFieldsComplete()
        {
            bool result = true;

            if(string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Username))
            {
                result = false;
            }

            if(Password == null || Password.Length < 1 || ConfirmPassword == null || ConfirmPassword.Length < 1)
            {
                result = false; 
            }

            return result; 
        }
    }
}
