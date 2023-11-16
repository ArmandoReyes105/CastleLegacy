using CastleLegacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Security;

namespace CastleLegacy.ViewModel
{
    public class ChangePasswordViewModel : ViewModelBase
    {

        //Fields
        private string _username;
        private string _email;
        private string _verificationCode;
        private SecureString _password;
        private SecureString _confirmPassword;

        //Panels
        private Visibility _insertUsernameAndEmail;
        private Visibility _insertVerificationCode;
        private Visibility _insertNewPassword;
        private Visibility _passwordChanged;
        private Visibility _errorMessage;

        //Variables
        private int verificationCodeGenerated;

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

        public string VerificationCode
        {
            get => _verificationCode;
            set
            {
                _verificationCode = value;
                OnPropertyChanged(nameof(VerificationCode));
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

        public Visibility InsertUsernameAndEmail
        {
            get => _insertUsernameAndEmail;
            set
            {
                _insertUsernameAndEmail = value;
                OnPropertyChanged(nameof(InsertUsernameAndEmail));
            }
        }

        public Visibility InsertVerificationCode
        {
            get => _insertVerificationCode;
            set
            {
                _insertVerificationCode = value;
                OnPropertyChanged(nameof(InsertVerificationCode));
            }
        }

        public Visibility InsertNewPassword
        {
            get => _insertNewPassword;
            set
            {
                _insertNewPassword = value;
                OnPropertyChanged(nameof(InsertNewPassword));
            }
        }

        public Visibility PasswordChanged
        {
            get => _passwordChanged;
            set
            {
                _passwordChanged = value;
                OnPropertyChanged(nameof(PasswordChanged));
            }
        }

        public Visibility ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        //Commands
        public ICommand GetVerificationCodeCommand {  get; }
        public ICommand ValidateVerificationCodeCommand { get; }
        public ICommand ChangePasswordCommand { get; }
        public ICommand CloseChangePasswordWindowCommand { get; }

        //Constructor
        public ChangePasswordViewModel()
        {
            InsertVerificationCode = Visibility.Collapsed;
            InsertNewPassword = Visibility.Collapsed;
            PasswordChanged = Visibility.Collapsed;
            ErrorMessage = Visibility.Collapsed;

            GetVerificationCodeCommand = new RelayCommand(ExecuteGetVerificationCodeCommand);
            ValidateVerificationCodeCommand = new RelayCommand(ExecuteValidateVerificationCodeCommand);
            ChangePasswordCommand = new RelayCommand(ExecuteChangePasswordCommand);
            CloseChangePasswordWindowCommand = new RelayCommand(ExecuteCloseChangePasswordWindowCommand);
        }

        //CommandsImplementation
        private void ExecuteGetVerificationCodeCommand (object obj)
        {
            try
            {
                verificationCodeGenerated = AccountRepository.GetVerificationCode(Username, Email);
            } 
            catch (Exception ex) 
            {
                Console.WriteLine("El error fue: " + ex.Message);
            }

            if (verificationCodeGenerated >= 100000 &&  verificationCodeGenerated <= 999999)
            {
                InsertUsernameAndEmail = Visibility.Collapsed;
                InsertVerificationCode = Visibility.Visible;
            } else
            {
                ErrorMessage = Visibility.Visible;
            }

        }

        private void ExecuteValidateVerificationCodeCommand (Object obj)
        {

            bool result = AccountRepository.ValidateVerificationCode(VerificationCode, verificationCodeGenerated);
            if (result)
            {
                InsertVerificationCode = Visibility.Hidden;
                InsertNewPassword = Visibility.Visible;
            } 

        }

        private void ExecuteChangePasswordCommand (Object obj)
        {
            bool result = AccountRepository.AreSamePassword(Password, ConfirmPassword);
            if (result)
            {
                try
                {
                    int resultChangePassword = AccountRepository.ChangePassword(Username, Password);
                    if (resultChangePassword == 1)
                    {
                        InsertNewPassword = Visibility.Hidden;
                        PasswordChanged = Visibility.Visible;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("El error fue: " + ex.Message);
                }
            }
            
        }

        private void ExecuteCloseChangePasswordWindowCommand(Object obj)
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();
        }

    }
}
