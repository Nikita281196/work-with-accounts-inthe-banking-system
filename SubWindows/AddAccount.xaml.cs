using System;
using System.Windows;
using BankSystem;

namespace WorkWithAccountsInTheBankingSystem
{
    
    public partial class AddAccount : Window
    {
        public Client<long, int> Client;
       
        public AddAccount()
        {
            InitializeComponent();
            Client = new Client<long, int>();
        }

        private void AddAccountClick(object sender, RoutedEventArgs e)
        {           
            try
            {
                if (IsNumberContains(AccountNumber.Text)||IsNumberContains(Balance.Text))
                {
                    throw new SymbolException("Номер счета и баланс не могут содержать буквы");
                }
                if (AccountNumber.Text.Length != 16)
                {
                    throw new SymbolException("Количество символов в номере счета должно быть 16");
                }
                if (Debet.IsChecked == true)
                {
                    for (int i = 0; i < DBClients.clients.Count; i++)
                    {
                        if (Client.Equals(DBClients.clients[i]))
                        {
                            DBClients.clients[i].OpenAccount(Convert.ToInt64(AccountNumber.Text), Convert.ToInt32(Balance.Text), "д");
                            this.Close();
                        }
                    }
                }
                else if (Notdebet.IsChecked == true)
                {
                    for (int i = 0; i < DBClients.clients.Count; i++)
                    {
                        if (Client.Equals(DBClients.clients[i]))
                        {
                            DBClients.clients[i].OpenAccount(Convert.ToInt64(AccountNumber.Text), Convert.ToInt32(Balance.Text), "нд");
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите тип счета", "Внимание", MessageBoxButton.OK);
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
