using System;
using System.Windows;
using BankSystem;

namespace WorkWithAccountsInTheBankingSystem
{
  
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();           
        }
        


        public void AddClientClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Surname.Text==String.Empty || NameClient.Text == String.Empty || Patronimyc.Text== String.Empty)
                {
                    throw new SymbolException("Заполните поля");
                }
                if (IsNumberContains(Surname.Text)|| IsNumberContains(NameClient.Text)|| IsNumberContains(Patronimyc.Text))
                {
                    throw new SymbolException("ФИО не может содержать цифры");
                }
                
                DBClients.clients.Add(new Client<long, int>(Surname.Text, NameClient.Text, Patronimyc.Text));
                this.Close();
            }
            catch (SymbolException error)
            {
                MessageBox.Show(error.Message);                
            }            
        }
        static bool IsNumberContains(string input)
        {
            foreach (char c in input)
                if (Char.IsNumber(c))
                    return true;
            return false;
        }


    }
}
