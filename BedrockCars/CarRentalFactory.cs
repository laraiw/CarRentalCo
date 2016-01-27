using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockCars
{
    public static class CarRentalFactory

    {
        //private static List<CustomerAccount> custaccounts = new List<CustomerAccount>();

        public static CustomerAccount CreateAccount(string custname, int driv_lic)
        {
            using (var db = new CarRentalModel())
            {

                var custaccount = new CustomerAccount(custname);
                custaccount.DrivingLicense = driv_lic;
                //custaccounts.Add(custaccount);

                //adds a row to the database, or entry to the table
                db.CustomerAccounts.Add(custaccount);
                db.SaveChanges();
                return custaccount;
            }
        }

        public static CustomerAccount CreateAccount(string custname, int driv_lic, decimal totalamount, AccountType accountType)
        {
            using (var db = new CarRentalModel())
            {
                var custaccount = new CustomerAccount(custname, totalamount);
                custaccount.DrivingLicense = driv_lic;
                custaccount.TypeOfAccount = accountType;
                //custaccounts.Add(custaccount);
                db.CustomerAccounts.Add(custaccount);
                db.SaveChanges();
                return custaccount;
            }
        }

        //public static void PayBalance()

        public static IEnumerable<CustomerAccount> GetAllAccountsByDL(int driv_lic)
        {
            var db = new CarRentalModel();
            return db.CustomerAccounts.Where(a => a.DrivingLicense == driv_lic);
        }
    
    }
}
