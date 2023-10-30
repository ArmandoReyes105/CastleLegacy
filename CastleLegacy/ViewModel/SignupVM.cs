using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CastleLegacy.ServerServices;

namespace CastleLegacy.ViewModel
{
    public class SignupVM
    {

        public void addAccount(Account account)
        {

            try
            {
                ServerServices.AccountClient client = new ServerServices.AccountClient();
                client.AddAccount(account);
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la cuenta: {ex.Message}");
            }

        }

    }
}
