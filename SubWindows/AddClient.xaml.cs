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
  
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();           
        }
        
        

        public void AddClientClick(object sender, RoutedEventArgs e)
        {
            DBClients.clients.Add(new Client<long, int>(Surname.Text, NameClient.Text, Patronimyc.Text));
            
            this.Close();
        }
        
    }
}
