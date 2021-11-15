using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorkWithAccountsInTheBankingSystem
{

    static class DBClients
    {
        public static ObservableCollection<Client<long, int>> clients;
        public static ObservableCollection<MagazineEvent> MagazineEvents;
    }
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {            
            InitializeComponent();
            DBClients.clients = new ObservableCollection<Client<long, int>>();
            DBClients.MagazineEvents = new ObservableCollection<MagazineEvent>();
            Client<long, int>.InformationEvent += AddInMagazin;
        }
        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();           
        }
        int count = 0;
        private void AddClient_Click(object sender, RoutedEventArgs e)
        {           
            AddClient addClient = new AddClient();                      
            addClient.Owner = this;
            addClient.Show();
            dbClient.ItemsSource = DBClients.clients;
                                
        }
        private void AddInMagazin(string Arg)
        {
            count++;
            Debug.WriteLine(count);
            DBClients.MagazineEvents.Add(new MagazineEvent(DateTime.Now,Arg));
            MessageBox.Show(Arg);
            foreach (var item in DBClients.MagazineEvents)
            {
                Debug.WriteLine(item);
            }
            
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            AddAccount addAccount = new AddAccount();
            addAccount.Owner = this;          
            var SelectedClient = (Client<long, int>)Convert.ChangeType(dbClient.SelectedItem, typeof(Client<long, int>));
            if (SelectedClient != null)
            {
                addAccount.Show();
                addAccount.Client = SelectedClient;                             
            }
            else MessageBox.Show("Выберите клиента", "Внимание", MessageBoxButton.OK);
            
        }

        private void ShowAccount_Click(object sender, RoutedEventArgs e)
        {
            ShowAccounts showAccount = new ShowAccounts();
            showAccount.Owner = this;
            var SelectedClient = (Client<long, int>)Convert.ChangeType(dbClient.SelectedItem, typeof(Client<long, int>));
            if (SelectedClient != null)
            {
                for (int i = 0; i < DBClients.clients.Count; i++)
                {
                    if (SelectedClient.Id.Equals(DBClients.clients[i].Id))
                    {
                        showAccount.Show();
                        showAccount.deposits = DBClients.clients[i].Deposits;
                        showAccount.notdeposits = DBClients.clients[i].NotDeposits;
                    }
                }               
            }
            else MessageBox.Show("Выберите клиента", "Внимание", MessageBoxButton.OK);            
        }

        private void CloseAccount_Click(object sender, RoutedEventArgs e)
        {
            CloseAccount closeAccount = new CloseAccount();
            closeAccount.Owner = this;
            
            var SelectedClient = (Client<long, int>)Convert.ChangeType(dbClient.SelectedItem, typeof(Client<long, int>));
            if (SelectedClient != null)
            {
                closeAccount.Show();
                closeAccount.Client = SelectedClient;
            }
            else MessageBox.Show("Выберите клиента", "Внимание", MessageBoxButton.OK);
            
        }

        private void TransactionBetweenYourAccount_Click(object sender, RoutedEventArgs e)
        {
            TransactionBetweenYourAccount transactionBetweenYourAccount = new TransactionBetweenYourAccount();
            transactionBetweenYourAccount.Owner = this;
            var SelectedClient = (Client<long, int>)Convert.ChangeType(dbClient.SelectedItem, typeof(Client<long, int>));
            if (SelectedClient != null)
            {
                for (int i = 0; i < DBClients.clients.Count; i++)
                {
                    if (SelectedClient.Id.Equals(DBClients.clients[i].Id))
                    {
                        transactionBetweenYourAccount.Show();
                        
                        transactionBetweenYourAccount.Client = DBClients.clients[i];
                    }
                }
            }
            else MessageBox.Show("Выберите клиента", "Внимание", MessageBoxButton.OK);
            
        }

        private void Refill_Click(object sender, RoutedEventArgs e)
        {
            Refill refill = new Refill();
            refill.Owner = this;
            var SelectedClient = (Client<long, int>)Convert.ChangeType(dbClient.SelectedItem, typeof(Client<long, int>));
            if (SelectedClient != null)
            {
                refill.Show();
                refill.Client = SelectedClient;
            }
            else MessageBox.Show("Выберите клиента", "Внимание", MessageBoxButton.OK);
            
        }

        private void Transaction_Click(object sender, RoutedEventArgs e)
        {
            Transaction transaction = new Transaction();
            transaction.Owner = this;
            transaction.Show();
        }

        private void ShowMagazine_Click(object sender, RoutedEventArgs e)
        {
            Magazine magazine = new Magazine();
            magazine.Owner = this;
            magazine.dbEvent.ItemsSource = DBClients.MagazineEvents;           
            magazine.Show();
        }
    }
}
