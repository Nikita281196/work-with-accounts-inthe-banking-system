using System;
using System.Windows;
using BankSystem;

namespace WorkWithAccountsInTheBankingSystem
{   
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
            try
            {
                if (IsNumberContains(AccountFrom.Text)|| IsNumberContains(AccountWhere.Text)|| IsNumberContains(Sum.Text))
                {
                    throw new SymbolException("Номер счета и сумма перевода не может содержать буквы");
                }
                bool tempFrom = default;
                bool tempWhere = default;

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
                        Client.TransactionBetweenYourAccounts(Convert.ToInt64(AccountFrom.Text), 
                            Convert.ToInt64(AccountWhere.Text), Convert.ToInt32(Sum.Text));
                        Close();
                    }
                    else MessageBox.Show("Номер счета 'куда' неверный", "Внимание", MessageBoxButton.OK);
                }
                else MessageBox.Show("Номер счета 'откуда' неверный", "Внимание", MessageBoxButton.OK);
            }
            catch (SymbolException error)
            {
                MessageBox.Show(error.Message);
                throw;
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
