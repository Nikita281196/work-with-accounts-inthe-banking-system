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
    /// Логика взаимодействия для Transaction.xaml
    /// </summary>
    public partial class Transaction : Window
    {
        public Transaction()
        {
            InitializeComponent();
        }

        private void TransactionClick(object sender, RoutedEventArgs e)
        {
            bool tempIDFrom = default;
            bool tempIDWhere = default;
            bool tempAccountFrom = default;
            bool tempAccountWhere = default;
            Client<long, int> clientFrom = default;
            Client<long, int> clientWhere = default;
            for (int i = 0; i < DBClients.clients.Count; i++)
            {
                if (Convert.ToInt32(IDFrom.Text).Equals(DBClients.clients[i].Id))
                {
                    clientFrom = DBClients.clients[i];
                    tempIDFrom = true;
                }
            }
            for (int i = 0; i < clientFrom.Accounts.Count; i++)
            {
                if (Convert.ToInt64(AccountFrom.Text).Equals(clientFrom.Accounts[i].AccountNumber))
                {                  
                    tempAccountFrom = true;
                }
            }
            for (int i = 0; i < DBClients.clients.Count; i++)
            {
                if (Convert.ToInt64(IDWhere.Text).Equals(DBClients.clients[i].Id))
                {
                    clientWhere = DBClients.clients[i];
                    tempIDWhere = true;
                }
            }
            for (int i = 0; i < clientWhere.Accounts.Count; i++)
            {
                if (Convert.ToInt64(AccountWhere.Text).Equals(clientWhere.Accounts[i].AccountNumber))
                {
                    tempAccountWhere = true;
                }
            }
            if (tempIDFrom)
            {
                if (tempIDWhere)
                {
                    if (tempAccountFrom)
                    {
                        if (tempAccountWhere)
                        {
                            TransactionBetweenClient(clientFrom, clientWhere,
                                Convert.ToInt64(AccountFrom.Text),Convert.ToInt64(AccountWhere.Text),
                                Convert.ToInt32(Sum.Text));
                            Close();
                        }
                        else MessageBox.Show("Номер счета 'кому' неверный", "Внимание", MessageBoxButton.OK);
                    }
                    else MessageBox.Show("Номер счета 'от кого' неверный", "Внимание", MessageBoxButton.OK);
                }
                else MessageBox.Show("ID 'кому' неверный", "Внимание", MessageBoxButton.OK);
            }
            else MessageBox.Show("ID 'от кого' неверный", "Внимание", MessageBoxButton.OK);
        }
        static public void TransactionBetweenClient(Client<long, int> accountFromWere, Client<long, int> accountWere, long numberFromWhere, long numberWhere, int sum)
        {

            IAccountTransaction<Client<long, int>, long, int> accountTransaction =
                            new Transactions<Client<long, int>, long, int>();

            accountTransaction.Transaction(accountFromWere, accountWere, numberFromWhere, numberWhere, sum);
        }
    }
}
