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
    /// Логика взаимодействия для TransactionBetweenYourAccount.xaml
    /// </summary>
    public partial class TransactionBetweenYourAccount : Window
    {
        public Client<long, int> Client;
        public TransactionBetweenYourAccount()
        {
            InitializeComponent();
            Client = new Client<long, int>();
        }

        private void TransactionBetweenYourAccountClick(object sender, RoutedEventArgs e)
        {            
            bool tempFrom=default;           
            bool tempWhere=default;

            for (int i = 0; i < Client.Accounts.Count; i++)
            {
                if (Convert.ToInt64(AccountFrom.Text).Equals(Client.Accounts[i].AccountNumber))
                {
                    tempFrom = true;
                }             
            }
            for (int i = 0; i < Client.Accounts.Count; i++)
            {
                if (Convert.ToInt64(AccountWhere.Text).Equals(Client.Accounts[i].AccountNumber))
                {
                    tempWhere = true;
                }               
            }
            if (tempFrom)
            {
                if (tempWhere)
                {                   
                    Client.TransactionBetweenYourAccounts(Convert.ToInt64(AccountFrom.Text), Convert.ToInt64(AccountWhere.Text), Convert.ToInt32(Sum.Text));
                    Close();
                }
                else MessageBox.Show("Номер счета 'куда' неверный", "Внимание", MessageBoxButton.OK);
            }
            else MessageBox.Show("Номер счета 'откуда' неверный", "Внимание", MessageBoxButton.OK);
            
            
        }
    }
}
