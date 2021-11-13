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
            //bool temp = false;
            for (int i = 0; i < DBClients.clients.Count; i++)
            {
                if (DBClients.clients[i].Equals(Client))
                {
                    for (int j = 0; j < DBClients.clients[i].Accounts.Count; j++)
                    {
                        if (tempAccountNumber.Equals(DBClients.clients[i].Accounts[j].AccountNumber))
                        {
                            DBClients.clients[i].CloseAccount(Convert.ToInt64(tempAccountNumber));
                            
                        }                       
                    }
                }
            }
            
            //if (temp)
            //{
            //    Client.CloseAccount(Convert.ToInt64(tempAccountNumber));
            //    this.Close();
            //}
            //else MessageBox.Show("Такого номера счета не существует", "Внимание", MessageBoxButton.OK);

        }
    }
}
