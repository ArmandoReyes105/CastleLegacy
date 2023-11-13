using CastleLegacy.ServerServices;
using System.Runtime.InteropServices;
using System;
using System.Security;
using System.Collections.Generic;
using System.Xml.XPath;

namespace CastleLegacy.Model
{
    public static class AccountRepository
    {

        public static AccountData AuthenticateAccount(string username, SecureString password)
        {
            AccountClient client = new AccountClient();
            var account = client.GetAccountByUsername(username);
            client.Close();

            AccountData result;

            if (account != null)
            {
                if (account.Password == ConvertSecureStringToString(password))
                {
                    result = account;
                }
                else
                {
                    result = null;
                }
            }
            else
            {
                result = null;
            }

            return result;
        }

        public static int CreateAccount(string email, string username, SecureString password, SecureString confirmPassword)
        {
            string accountPassword = ConvertSecureStringToString(password);
            int operationResult;

            Account account = new Account();
            account.Email = email;
            account.Username = username;
            account.Password = accountPassword;
            account.AccountStatus = "Online";


            AccountClient client = new AccountClient();
            operationResult = client.AddAccount(account);
            client.Close();

            return operationResult;
        }

        private static string ConvertSecureStringToString(SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public static bool AreSamePassword(SecureString password, SecureString confirmPassword)
        {
            bool result = false;

            string accountPassword = ConvertSecureStringToString(password);
            string passwordConfirmation = ConvertSecureStringToString(confirmPassword);

            result = accountPassword == passwordConfirmation;

            return result;

        }

        public static int GetVerificationCode(string username, string email)
        {
            int result = 0;

            AccountClient client = new AccountClient();
            result = client.GetVerificationCode(username, email);
            client.Close();

            return result;
        }

        public static bool ValidateVerificationCode(string verificationCodeProvided, int verificationCodeGenerated)
        {
            bool result = false;

            if (int.Parse(verificationCodeProvided) == verificationCodeGenerated)
            {
                result = true;
            }

            return result;
        }

        public static int ChangePassword(string username, SecureString password)
        {
            int result = 0;

            AccountClient client = new AccountClient();
            result = client.ChangePassword(username, ConvertSecureStringToString(password));
            client.Close();

            return result;
        }

    }
}
