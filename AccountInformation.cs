using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithAccountsInTheBankingSystem
{
    /// <summary>
    /// Интерфейс ковариантности
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TAccountNumber"></typeparam>
    /// <typeparam name="TBalance"></typeparam>
    interface IBank<out T, TAccountNumber, TBalance>
        where T : Account<TAccountNumber, TBalance>
    {
        T Create(TAccountNumber accountNumber, TBalance balance);
        T Refill(TAccountNumber account, TBalance balance, TBalance sum);
    }

    /// <summary>
    /// Класс реализующий ковариантность
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TAccountNumber"></typeparam>
    /// <typeparam name="TBalance"></typeparam>
    class Bank<T, TAccountNumber, TBalance> : IBank<T, TAccountNumber, TBalance>
        where T : Account<TAccountNumber, TBalance>, new()
    {
        /// <summary>
        /// Метод создания счета
        /// </summary>
        /// <param name="accountNumber">Номер счета</param>
        /// <param name="balance">Баланс</param>
        /// <returns></returns>
        public T Create(TAccountNumber accountNumber, TBalance balance)
        {
            T accountCreate = new T();
            accountCreate.Create(accountNumber, balance);
            return accountCreate;
        }
        /// <summary>
        /// Метод пополнения счета
        /// </summary>
        /// <param name="account">Номер счета</param>
        /// <param name="balance">Баланс</param>
        /// <param name="sum">Сумма, которую необходимо внести</param>
        /// <returns></returns>
        public T Refill(TAccountNumber account, TBalance balance, TBalance sum)
        {
            T accountRefill = new T();
            accountRefill.Refill(account, balance, sum);
            return accountRefill;
        }
    }


    public class Account<TAccountNumber, TBalance> : Client<TAccountNumber, TBalance>
    {
        #region Поля
        public TAccountNumber AccountNumber { get; set; }
        public TBalance Balance { get; set; }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Инициализация 
        /// </summary>
        public Account()

        {
            this.AccountNumber = default;
            this.Balance = default;
        }
        #endregion
        /// <summary>
        /// Метод создания счета
        /// </summary>
        /// <param name="accountNumber">Номер счета</param>
        /// <param name="balance">Баланс</param>
        public void Create(TAccountNumber accountNumber, TBalance balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }
        /// <summary>
        /// Метод пополнения счета
        /// </summary>
        /// <param name="accountNumber">Номер счета</param>
        /// <param name="balance">Баланс</param>
        /// <param name="sum">Сумма, которую необходимо внести</param>
        public void Refill(TAccountNumber accountNumber, TBalance balance, TBalance sum)
        {
            this.AccountNumber = accountNumber;
            int temp = Convert.ToInt32(balance) + Convert.ToInt32(sum);
            this.Balance = (TBalance)Convert.ChangeType(temp, typeof(TBalance));
        }
    }

    public class Deposit<TAccountNumber, TBalance> :
        Account<TAccountNumber, TBalance>
    {

    }

    public class NotDeposit<TAccountNumber, TBalance> :
        Account<TAccountNumber, TBalance>
    {

    }
}
