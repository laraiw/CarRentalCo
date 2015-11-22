﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockCars
{
    class CustomerAccount
    {
        #region Properties
     /// <summary>
     /// Customer Name
     /// </summary>
    public string CustomerName  { get; set; }

    /// <summary>
    /// Customer number
    /// </summary>
    public int CustomerNumber { get; set; }

    /// <summary>
    /// Customer Balance
    /// </summary>
    public decimal Balance { get; set; }
        #endregion

        #region Methods
        
        //Rent a car
        //Return a rented car


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
        public decimal PayBalance(decimal paidamount)
        {
           Balance = Balance - paidamount;
           return Balance;
         }

    //Retrieve Customer Details
    #endregion
}
}
