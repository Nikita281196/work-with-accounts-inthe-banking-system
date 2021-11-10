using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorkWithAccountsInTheBankingSystem
{
    /// <summary>
    /// Логика взаимодействия для CloseAccount.xaml
    /// </summary>
    public partial class CloseAccount : Window
    {
        public Client<long, int> Client;
        public CloseAccount()
        {
            InitializeComponent();
            Client = new Client<long, int>();
        }

        private void CloseAccountClick(object sender, RoutedEventArgs e)
        {
            long tempAccountNumber = Convert.ToInt64(AccountNumber.Text);
            bool temp = false;
            for (int i = 0; i < Client.Accounts.Count; i++)
            {
                if (tempAccountNumber.Equals(Client.Accounts[i].AccountNumber))
                {
                    temp = true;
                }
                else temp = false;               
            }
            if (temp)
            {
                Client.CloseAccount(Convert.ToInt64(tempAccountNumber));
                this.Close();
            }
            else MessageBox.Show("Такого номера счета не существует", "Внимание", MessageBoxButton.OK);

        }
    }
}
