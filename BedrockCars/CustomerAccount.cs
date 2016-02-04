using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockCars
{
    public enum AccountType
    {
        Commercial,
        Private
    }

    public class CustomerAccount
    {
        #region Variables
        /// <summary
        /// Shared memory for storing the last customer number and initializing to zero
        /// </summary>
        ///private static int lastCustomerNumber = 0;
       #endregion

       #region Properties
       /// <summary>
       /// Customer Name
       /// </summary>
       public string CustomerName  { get; set; }

       /// <summary>
       /// Customer number
       /// </summary>
       /// 
       [Key]
       public int CustomerNumber { get;
            private set; }

       /// <summary>
       /// Customer Balance
       /// </summary>
       public decimal Balance { get;
            private set; }

       public int DrivingLicense { get; set; }

        public AccountType TypeOfAccount { get; set; }

        public virtual ICollection<RentalTransaction> Transactions { get; set; }

        #endregion


        #region Constructors

        public CustomerAccount()
        {
        
        }

        public CustomerAccount(string custname)
            : this()
        {
            CustomerName = custname;
        }

        public CustomerAccount(string custname, decimal amount)
            : this(custname)
        {
            DisplayBalance(amount);
        }

        #endregion

        #region Methods

        //Other methods to add later - Rent a car& Return a rented car


        /// <summary>
        /// Display balance
        /// </summary>
        /// <param name="amount">customer's total bill</param>
        /// <returns>Returns balance</returns>
        public decimal DisplayBalance(decimal amount)
        {
            Balance = Balance + amount;
            return Balance;
        }

        /// <summary>
        /// Pay customer balance
        /// </summary>
        /// <param name="paidamount">customer's payment towards bill</param>
        /// <returns>Returns balance</returns>
        /// <exception>ArgumentException</exception>
        public decimal PayBalance(decimal amount)
        {
            //if (amount < 0)
            //{
            //    throw new ArgumentException("Your payment must equal to your balance");
            //}

            //if (amount >= Balance)
            //  {
            //      throw new ArgumentException("Your payment must equal to your balance, you have overpaid");
            //  }
            Balance -= amount;
            return Balance;
         }

    //Retrieve Customer Details
    #endregion
}
}

