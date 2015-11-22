using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockCars
{
    class RentalRecord
    {
        #region Properties
        /// <summary>
        /// License Plate number
        /// </summary>
        public string LicenseNumber { get; set; }

        /// <summary>
        /// Customer number
        /// </summary>
        public int CustomerNumber { get; set; }

        /// <summary>
        /// Rental record number
        /// </summary>
        public int RecordNumber { get; set; }

        /// <summary>
        /// Rental Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Rental End Date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Number of days rented
        /// </summary>
        public int NumberOfDays { get; set; }

        /// <summary>
        /// RentalBalance
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Car rental Price per day
        /// </summary>
        public decimal DailyRate { get; set; }

        #endregion

        #region Methods
        ///Create a record
        ///Retrieve details

        /// <summary>
        /// Calculate number of days rented        
        /// </summary>
        /// <param name="numofdays">Calculate number of days</param>
        /// <returns>Returns number of days</returns> 
        public int CalculateDays (DateTime StartDate, DateTime EndDate)
        {
            return EndDate.Subtract(StartDate).Days;
        }

        /// <summary>
        /// Calculate record balance        
        /// </summary>
        /// <param name="recordbalance">Calculate record balance</param>
        /// <returns>Returns records balance</returns>
        public decimal CalculateBalance(decimal recordbalance)
        {
            Balance = DailyRate * NumberOfDays;
            return Balance;
        }

        #endregion

    }
}
