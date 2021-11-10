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
    /// Логика взаимодействия для AddAccount.xaml
    /// </summary>
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
            if (Debet.IsChecked==true)
            {
                Client.OpenAccount(Convert.ToInt64(AccountNumber.Text), Convert.ToInt32(Balance.Text), "д");
                this.Close();
            }
            else if (Notdebet.IsChecked==true)
            {
                Client.OpenAccount(Convert.ToInt64(AccountNumber.Text), Convert.ToInt32(Balance.Text), "нд");
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите тип счета","Внимание",MessageBoxButton.OK);
            }                    
        }
        
    }
}
