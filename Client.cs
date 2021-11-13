using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WorkWithAccountsInTheBankingSystem
{
    /// <summary>
    /// Интерфейс контрвариантности
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TAccountNumber"></typeparam>
    /// <typeparam name="TBalance"></typeparam>
    interface IAccountTransaction<in T, TAccountNumber, TBalance>
       where T : Client<TAccountNumber, TBalance>
    {
        void Transaction(T accountFromWere, T accountWhere, TAccountNumber numberFromWhere, TAccountNumber numberWhere, TBalance sum);
    }
    /// <summary>
    /// Класс реализующий интерфейс контрвариантности
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TAccountNumber"></typeparam>
    /// <typeparam name="TBalance"></typeparam>
    class Transactions<T, TAccountNumber, TBalance> : IAccountTransaction<T, TAccountNumber, TBalance>
        where T : Client<TAccountNumber, TBalance>
    {
        public void Transaction(T accountFromWhere, T accountWhere, TAccountNumber numberFromWhere, TAccountNumber numberWhere, TBalance sum)
        {

            for (int i = 0; i < accountFromWhere.Accounts.Count; i++)
            {
                if (numberFromWhere.Equals(accountFromWhere.Accounts[i].AccountNumber))
                {
                    int balanceAccountFromWhere = Convert.ToInt32(accountFromWhere.Accounts[i].Balance) - Convert.ToInt32(sum);
                    accountFromWhere.Accounts[i].Balance = (TBalance)Convert.ChangeType(balanceAccountFromWhere, typeof(TBalance));
                }
            }
            for (int i = 0; i < accountWhere.Accounts.Count; i++)
            {
                if (numberWhere.Equals(accountWhere.Accounts[i].AccountNumber))
                {
                    int balanceAccountWhere = Convert.ToInt32(accountWhere.Accounts[i].Balance) + Convert.ToInt32(sum);
                    accountWhere.Accounts[i].Balance = (TBalance)Convert.ChangeType(balanceAccountWhere, typeof(TBalance));
                }
            }
            for (int i = 0; i < accountFromWhere.Deposits.Count; i++)
            {
                if (numberFromWhere.Equals(accountFromWhere.Deposits[i].AccountNumber))
                {
                    int balanceAccountFromWhere = Convert.ToInt32(accountFromWhere.Deposits[i].Balance) - Convert.ToInt32(sum);
                    accountFromWhere.Deposits[i].Balance = (TBalance)Convert.ChangeType(balanceAccountFromWhere, typeof(TBalance));
                }
            }
            for (int i = 0; i < accountWhere.Deposits.Count; i++)
            {
                if (numberWhere.Equals(accountWhere.Deposits[i].AccountNumber))
                {
                    int balanceAccountWhere = Convert.ToInt32(accountWhere.Deposits[i].Balance) + Convert.ToInt32(sum);
                    accountWhere.Deposits[i].Balance = (TBalance)Convert.ChangeType(balanceAccountWhere, typeof(TBalance));
                }
            }
            for (int i = 0; i < accountFromWhere.NotDeposits.Count; i++)
            {
                if (numberFromWhere.Equals(accountFromWhere.NotDeposits[i].AccountNumber))
                {
                    int balanceAccountFromWhere = Convert.ToInt32(accountFromWhere.NotDeposits[i].Balance) - Convert.ToInt32(sum);
                    accountFromWhere.NotDeposits[i].Balance = (TBalance)Convert.ChangeType(balanceAccountFromWhere, typeof(TBalance));
                }
            }
            for (int i = 0; i < accountWhere.NotDeposits.Count; i++)
            {
                if (numberWhere.Equals(accountWhere.NotDeposits[i].AccountNumber))
                {
                    int balanceAccountWhere = Convert.ToInt32(accountWhere.NotDeposits[i].Balance) + Convert.ToInt32(sum);
                    accountWhere.NotDeposits[i].Balance = (TBalance)Convert.ChangeType(balanceAccountWhere, typeof(TBalance));
                }
            }

        }
    }

    public class Client<TAccount, TBalance>
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimyc { get; set; }
        public ObservableCollection<Deposit<TAccount, TBalance>> Deposits { get; set; }
        public ObservableCollection<NotDeposit<TAccount, TBalance>> NotDeposits { get; set; }
        public ObservableCollection<Account<TAccount, TBalance>> Accounts { get; set; }

        IBank<Account<TAccount, TBalance>, TAccount, TBalance> bank;
        IBank<Deposit<TAccount, TBalance>, TAccount, TBalance> bankDeposit;
        IBank<NotDeposit<TAccount, TBalance>, TAccount, TBalance> bankNotDeposit;

        private static int staticId;
        static Client()
        {
            staticId = 0;
        }
        private static int NextId()
        {
            staticId++;
            return staticId;
        }
        public Client()
        {
            staticId = 0;
            this.Surname = String.Empty;
            this.Name = String.Empty;
            this.Patronimyc = String.Empty;
            this.Accounts = new ObservableCollection<Account<TAccount, TBalance>>();
            this.Deposits = new ObservableCollection<Deposit<TAccount, TBalance>>();
            this.NotDeposits = new ObservableCollection<NotDeposit<TAccount, TBalance>>();

        }
        public Client(string Surname, string Name, string Patronimyc)
        {
            this.Id = Client<TAccount, TBalance>.NextId();
            this.Surname = Surname;
            this.Name = Name;
            this.Patronimyc = Patronimyc;
            this.Accounts = new ObservableCollection<Account<TAccount, TBalance>>();
            this.Deposits = new ObservableCollection<Deposit<TAccount, TBalance>>();
            this.NotDeposits = new ObservableCollection<NotDeposit<TAccount, TBalance>>();
        }
        /// <summary>
        /// Метод открытия счета
        /// </summary>
        /// <param name="number">Номер счета</param>
        /// <param name="balance">Баланс на данном счете</param>
        /// <param name="choise">Выбор типа счета: депозит/не депозит</param>
        public void OpenAccount(TAccount number, TBalance balance, string choise)
        {
            switch (choise)
            {
                case "д":

                    bank = new Bank<Deposit<TAccount, TBalance>, TAccount, TBalance>();
                    Account<TAccount, TBalance> depositAccount = bank.Create(number, balance);
                    Accounts.Add(depositAccount);

                    bankDeposit = new Bank<Deposit<TAccount, TBalance>, TAccount, TBalance>();
                    Deposit<TAccount, TBalance> bankdepositAccount = bankDeposit.Create(number, balance);
                    Deposits.Add(bankdepositAccount);

                    break;
                case "нд":

                    bank = new Bank<NotDeposit<TAccount, TBalance>, TAccount, TBalance>();
                    Account<TAccount, TBalance> notDepositAccount = bank.Create(number, balance);
                    Accounts.Add(notDepositAccount);

                    bankNotDeposit = new Bank<NotDeposit<TAccount, TBalance>, TAccount, TBalance>();
                    NotDeposit<TAccount, TBalance> banknotdepositAccount = bankNotDeposit.Create(number, balance);
                    NotDeposits.Add(banknotdepositAccount);
                    break;
            }
        }

        /// <summary>
        /// Метод пополнения баланса счета
        /// </summary>
        /// <param name="Number">Номер счета</param>
        /// <param name="balance">Баланс счета</param>
        /// <param name="Sum">Сумма для пополнения</param>
        /// <param name="choise">Выбор типа счета: депозитный/не депозитный</param>
        public void Refill(TAccount Number, TBalance balance, TBalance Sum, string choise)
        {
            switch (choise)
            {
                case "д":
                    for (int i = 0; i < Accounts.Count; i++)
                    {
                        if (Number.Equals(Accounts[i].AccountNumber))
                        {
                            bank = new Bank<Deposit<TAccount, TBalance>, TAccount, TBalance>();
                            Account<TAccount, TBalance> DepositAccount = bank.Refill(Number, balance, Sum);
                            Accounts[i] = DepositAccount;
                        }
                    }
                    for (int i = 0; i < Deposits.Count; i++)
                    {
                        if (Number.Equals(Deposits[i].AccountNumber))
                        {
                            bankDeposit = new Bank<Deposit<TAccount, TBalance>, TAccount, TBalance>();
                            Deposit<TAccount, TBalance> DepositAccount = bankDeposit.Refill(Number, balance, Sum);
                            Deposits[i] = DepositAccount;
                        }
                    }
                    break;
                case "нд":
                    for (int i = 0; i < Accounts.Count; i++)
                    {
                        if (Number.Equals(Accounts[i].AccountNumber))
                        {
                            bank = new Bank<NotDeposit<TAccount, TBalance>, TAccount, TBalance>();
                            Account<TAccount, TBalance> NotDepositAccount = bank.Refill(Number, balance, Sum);
                            Accounts[i] = NotDepositAccount;
                        }
                    }
                    for (int i = 0; i < NotDeposits.Count; i++)
                    {
                        if (Number.Equals(NotDeposits[i].AccountNumber))
                        {
                            bankNotDeposit = new Bank<NotDeposit<TAccount, TBalance>, TAccount, TBalance>();
                            NotDeposit<TAccount, TBalance> DepositAccount = bankNotDeposit.Refill(Number, balance, Sum);
                            NotDeposits[i] = DepositAccount;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Метод закрытия счета
        /// </summary>
        /// <param name="Number">Номер счета, который необходимо закрыть</param>
        public void CloseAccount(TAccount Number)
        {           
            for (int i = 0; i < Accounts.Count; i++)
            {
                if (Number.Equals(Accounts[i].AccountNumber))
                {
                    Accounts.RemoveAt(i);                   
                }               
            }
            for (int i = 0; i < Deposits.Count; i++)
            {
                if (Number.Equals(Deposits[i].AccountNumber))
                {
                    Deposits.RemoveAt(i);
                }
            }
            for (int i = 0; i < NotDeposits.Count; i++)
            {
                if (Number.Equals(NotDeposits[i].AccountNumber))
                {
                    NotDeposits.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Метод перевода между своими счетами
        /// </summary>
        /// <param name="AccountFromWhere">Номер счета, откуда надо перевести</param>
        /// <param name="AccountWhere">Номер счета, куда надо перевести</param>
        /// <param name="Sum">Сумма</param>
        public void TransactionBetweenYourAccounts(TAccount AccountFromWhere, TAccount AccountWhere, TBalance Sum)
        {
            for (int i = 0; i < Accounts.Count; i++)
            {
                if (AccountWhere.Equals(this.Accounts[i].AccountNumber))
                {
                    int balanceAccountWhere = Convert.ToInt32(Accounts[i].Balance) + Convert.ToInt32(Sum);
                    Accounts[i].Balance = (TBalance)Convert.ChangeType(balanceAccountWhere, typeof(TBalance));
                }
                else if (AccountFromWhere.Equals(this.Accounts[i].AccountNumber))
                {
                    int balanceAccountFromWhere = Convert.ToInt32(Accounts[i].Balance) - Convert.ToInt32(Sum);
                    Accounts[i].Balance = (TBalance)Convert.ChangeType(balanceAccountFromWhere, typeof(TBalance));
                }
            }
            for (int i = 0; i < Deposits.Count; i++)
            {
                if (AccountWhere.Equals(this.Deposits[i].AccountNumber))
                {
                    int balanceAccountWhere = Convert.ToInt32(Deposits[i].Balance) + Convert.ToInt32(Sum);
                    Deposits[i].Balance = (TBalance)Convert.ChangeType(balanceAccountWhere, typeof(TBalance));
                }
                else if (AccountFromWhere.Equals(this.Deposits[i].AccountNumber))
                {
                    int balanceAccountFromWhere = Convert.ToInt32(Deposits[i].Balance) - Convert.ToInt32(Sum);
                    Deposits[i].Balance = (TBalance)Convert.ChangeType(balanceAccountFromWhere, typeof(TBalance));
                }
            }
            for (int i = 0; i < NotDeposits.Count; i++)
            {
                if (AccountWhere.Equals(this.NotDeposits[i].AccountNumber))
                {
                    int balanceAccountWhere = Convert.ToInt32(NotDeposits[i].Balance) + Convert.ToInt32(Sum);
                    NotDeposits[i].Balance = (TBalance)Convert.ChangeType(balanceAccountWhere, typeof(TBalance));
                }
                else if (AccountFromWhere.Equals(this.NotDeposits[i].AccountNumber))
                {
                    int balanceAccountFromWhere = Convert.ToInt32(NotDeposits[i].Balance) - Convert.ToInt32(Sum);
                    NotDeposits[i].Balance = (TBalance)Convert.ChangeType(balanceAccountFromWhere, typeof(TBalance));
                }
            }
        }


        public void Print()
        {

            for (int i = 0; i < Accounts.Count; i++)
            {
                Console.WriteLine($"{Id} {Surname } {Name} {Patronimyc} {Accounts[i].AccountNumber} {Accounts[i].Balance}");
            }
        }

    }
}
