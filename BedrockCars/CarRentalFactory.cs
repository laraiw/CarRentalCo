using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockCars
{
    public static class CarRentalFactory
        
    {
        private static List<CustomerAccount> custaccounts = new List<CustomerAccount>();
        public static CustomerAccount CreateAccount(string custname, int driv_lic)
        {
            var custaccount = new CustomerAccount(custname);
            custaccount.DrivingLicense = driv_lic;
            custaccounts.Add(custaccount);     
            return custaccount;
        }

        public static CustomerAccount CreateAccount(string custname, int driv_lic, decimal totalamount, AccountType accountType)
        {
            var custaccount = new CustomerAccount(custname, totalamount);
            custaccount.DrivingLicense = driv_lic;
            custaccount.TypeOfAccount = accountType;
            custaccounts.Add(custaccount);
            return custaccount;

        }
        public static IEnumerable<CustomerAccount> GetAllAccountsByDL(int driv_lic)
        {
            return custaccounts.Where(a => a.DrivingLicense == driv_lic);
        }

    }
}
