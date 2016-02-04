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

        public static CustomerAccount CreateAccount(string custname, int driv_lic, decimal amount, AccountType accountType)
        {
            using (var db = new CarRentalModel())
            {
                CustomerAccount custaccount = new CustomerAccount(custname, amount);
                custaccount.DrivingLicense = driv_lic;
                custaccount.TypeOfAccount = accountType;
                //custaccounts.Add(custaccount);
                db.CustomerAccounts.Add(custaccount);
                db.SaveChanges();
                return custaccount;
            }
        }


        public static IEnumerable<CustomerAccount> GetAllAccountsByDL(int driv_lic)
        {
            var db = new CarRentalModel();
            return db.CustomerAccounts.Where(a => a.DrivingLicense == driv_lic);
        }

        public static decimal PayBalance(int custAccount, decimal amount) /* deposit */
        {
            using (var db = new CarRentalModel())
            {
                var custaccount = db.CustomerAccounts.Where(a => a.CustomerNumber == custAccount).First();
                var originalcopy = custaccount;
                custaccount.PayBalance(amount);
                db.Entry(originalcopy).CurrentValues.SetValues(custaccount);
                var transactionSuccess = CreateTransaction(DateTime.Now, "Deposit", amount, custAccount, TransactionType.Credit);
                if (transactionSuccess)
                {
                    db.SaveChanges();
                }
                return custaccount.Balance;
            }
        }

        public static decimal DisplayBalance(int custAccount, decimal amount) /* withdraw */
        {
            using (var db = new CarRentalModel())
            {
                var custaccount = db.CustomerAccounts.Where(a => a.CustomerNumber == custAccount).First();
                var originalcopy = custaccount;
                custaccount.PayBalance(amount);
                db.Entry(originalcopy).CurrentValues.SetValues(custaccount);
                var transactionSuccess = CreateTransaction(DateTime.Now, "withdrawn", amount, custAccount, TransactionType.Debit);
                if (transactionSuccess)
                {
                    db.SaveChanges();
                }
                return custaccount.Balance;
            }
        }

        private static bool CreateTransaction(DateTime transactionDate,string description, decimal amount, int accountnumber, TransactionType transactionType)
        {
            try
            {
                using (var db = new CarRentalModel())
                {
                    var transaction = new RentalTransaction
                    {
                        CustomerNumber = accountnumber,
                        TransactionDate = transactionDate,
                        Description = description,
                        Debit = (transactionType == TransactionType.Debit)
                        ? amount : 0.0M,
                        Credit = (transactionType == TransactionType.Credit)
                        ? amount : 0.0M
                    };
                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
