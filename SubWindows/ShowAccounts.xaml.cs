using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ShowAccounts.xaml
    /// </summary>
    public partial class ShowAccounts : Window
    {
        public ObservableCollection<Deposit<long, int>> deposits;
        public ObservableCollection<NotDeposit<long, int>> notdeposits;
        public ShowAccounts()
        {
            InitializeComponent();
            deposits = new ObservableCollection<Deposit<long, int>>();
            notdeposits = new ObservableCollection<NotDeposit<long, int>>();
        }

        private void ShowDepositAccount_Click(object sender, RoutedEventArgs e)
        {
            dbAccount.ItemsSource = deposits;
        }

        private void ShowNotDepositAccount_Click(object sender, RoutedEventArgs e)
        {
            dbAccount.ItemsSource = notdeposits;
        }

        
    }
}
