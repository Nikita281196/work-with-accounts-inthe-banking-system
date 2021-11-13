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
    /// Логика взаимодействия для Refill.xaml
    /// </summary>
    public partial class Refill : Window
    {
        public Client<long, int> Client;
        public Refill()
        {
            InitializeComponent();
            Client = new Client<long, int>();
        }

        private void RefillClick(object sender, RoutedEventArgs e)
        {
            long tempAccountNumber = Convert.ToInt64(AccountNumber.Text);
            //bool temp = false;
            int tmp = 0;
            //string tmpType = "";
            for (int i = 0; i < DBClients.clients.Count; i++)
            {
                if (DBClients.clients[i].Equals(Client))
                {
                    for (int j = 0; j < DBClients.clients[i].Accounts.Count; j++)
                    {
                        if (tempAccountNumber.Equals(DBClients.clients[i].Accounts[j].AccountNumber))
                        {
                            //temp = true;
                            tmp = DBClients.clients[i].Accounts[j].Balance;
                            for (int k = 0; k < DBClients.clients[i].Deposits.Count; k++)
                            {
                                if (DBClients.clients[i].Accounts[j].AccountNumber.Equals(DBClients.clients[i].Deposits[k].AccountNumber))
                                {
                                    //tmpType = "д";
                                    DBClients.clients[i].Refill(Convert.ToInt64(tempAccountNumber), tmp, Convert.ToInt32(Sum.Text), "д");
                                }
                                else DBClients.clients[i].Refill(Convert.ToInt64(tempAccountNumber), tmp, Convert.ToInt32(Sum.Text), "нд");
                            }

                        }
                        //else temp = false;
                    }
                }
            }
            
            //if (temp)
            //{
                
            //    Client.Refill(Convert.ToInt64(tempAccountNumber),tmp,Convert.ToInt32(Sum.Text),tmpType);
            //    this.Close();
            //}
            //else MessageBox.Show("Такого номера счета не существует", "Внимание", MessageBoxButton.OK);
        }
    }
}
