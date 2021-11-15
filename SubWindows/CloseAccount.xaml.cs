using BankSystem;
using System;
using System.Windows;

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
            try
            {
                if (IsNumberContains(AccountNumber.Text))
                {
                    throw new SymbolException("Номер счета не может содержать буквы");
                }
                for (int i = 0; i < DBClients.clients.Count; i++)
                {
                    if (DBClients.clients[i].Equals(Client))
                    {
                        for (int j = 0; j < DBClients.clients[i].Accounts.Count; j++)
                        {
                            if (AccountNumber.Text.Equals(DBClients.clients[i].Accounts[j].AccountNumber))
                            {
                                DBClients.clients[i].CloseAccount(Convert.ToInt64(AccountNumber.Text));
                            }
                        }
                    }
                }
            }
            catch (SymbolException error)
            {
                MessageBox.Show(error.Message);
            }
            
        }
        static bool IsNumberContains(string input)
        {
            foreach (char c in input)
                if (Char.IsLetter(c))
                    return true;
            return false;
        }
    }
}
