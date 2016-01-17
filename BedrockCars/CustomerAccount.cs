using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockCars
{
    public class CustomerAccount
    {
        #region Variables
        /// <summary
        /// Shared memory for storing the last customer number, and initializing to 0
        /// </summary>
        private static int lastCustomerNumber = 0;
       #endregion

       #region Properties
       /// <summary>
       /// Customer Name
       /// </summary>
       public string CustomerName  { get; set; }

       /// <summary>
       /// Customer number
       /// </summary>
       public int CustomerNumber { get;
            private set; }

       /// <summary>
       /// Customer Balance
       /// </summary>
       public decimal Balance { get;
            private set; }

        public int DrivingLicense { get; set; }
        #endregion


        #region Constructors

        public CustomerAccount()
        {
            CustomerNumber = ++lastCustomerNumber;
        }

        public CustomerAccount(string custname)
            : this()
        {
            CustomerName = custname;
        }

        public CustomerAccount(string custname, decimal totalamount)
            : this(custname)
        {
            DisplayBalance(totalamount);
        }

        #endregion

        #region Methods

        //Other methods to add later - Rent a car& Return a rented car


        /// <summary>
        /// Display balance
        /// </summary>
        /// <param name="totalamount">customer's total bill</param>
        /// <returns>Returns balance</returns>
        public decimal DisplayBalance(decimal totalamount)
        {
            Balance = Balance + totalamount;
            return Balance;
        }

        /// <summary>
        /// Pay customer balance
        /// </summary>
        /// <param name="paidamount">customer's payment towards bill</param>
        /// <returns>Returns balance</returns>
        /// <exception>ArgumentException</exception>
        public decimal PayBalance(decimal paidamount)
        {
            if (paidamount < 0)
            {
                throw new ArgumentException("Your payment must equal to your balance");
            }
         
            if (paidamount >= Balance)
          //  {
          //      throw new ArgumentException("Your payment must equal to your balance, you have overpaid");
          //  }
            Balance = Balance - paidamount;
           return Balance;
         }

    //Retrieve Customer Details
    #endregion
}
}

