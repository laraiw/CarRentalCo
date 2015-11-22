using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockCars
{
    class CarDetails
    {
        #region Properties
        /// <summary>
        /// License Plate number
        /// </summary>
        public string LicenseNumber { get; set; }

        // <summary>
        // Car Size - Small, Mid-sized or large
        // </summary>
        // public string CarSize { get; set; }

        /// <summary>
        /// Car rental Price per day
        /// </summary>
        public decimal DailyRate { get; set; }

        /// <summary>
        /// Car availability
        /// </summary>
        public Boolean CarAvailable { get; set; }

        #endregion

        #region Methods

        // Rent out a car
        // Return a rented car   
        // Retrieve car details

        /// <summary>
        /// Check is car is available to rent
        /// </summary>
        /// <param name="available">Is this car available for rent?</param>
        /// <returns>Returns availability</returns>
        public Boolean CheckAvailability (Boolean available)
        {
            CarAvailable = available;
            return CarAvailable;
        }

        #endregion
    }
}
