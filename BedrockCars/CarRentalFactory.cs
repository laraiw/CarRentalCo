using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockCars
{
    public static class CarRentalFactory
        
    {
        public static CustomerAccount CreateAccount(string custname, string driv_lic)
        {
            var custaccount = new CustomerAccount();
            custaccount.CustomerName = custname;
            custaccount.DrivingLicense = driv_lic;
            return custaccount;
        }
    }
}
