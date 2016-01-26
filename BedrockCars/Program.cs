using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockCars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO BEDROCK CAR RENTAL!!!");
            Console.WriteLine("PLEASE ENTER YOUR DRIVER'S LICENSE NUMBER:");
            var driv_lic = Console.ReadLine();
            int convertedDrivingLicense;
            if (int.TryParse(driv_lic, out convertedDrivingLicense) == true)
                {
                var custaccounts = CarRentalFactory.GetAllAccountsByDL(convertedDrivingLicense);
                if (custaccounts == null)
                {
                    Console.WriteLine("No accounts found. One will be created");
                    var custaccount = CarRentalFactory.CreateAccount("Dummy", convertedDrivingLicense);
                    CarRentalFactory.PayBalance(custaccount.CustomerNumber, 100);
                }
                else
                {
                    foreach (var custaccount in custaccounts)
                    {
                        Console.WriteLine("CustomerNumber: {0}, Balance: {1:c}", custaccount.CustomerNumber, custaccount.Balance);
                    }
                }
            }

            //var custaccount = CarRentalFactory.CreateAccount("Larai Wush", 123456);
            ////Create and instance of an account == object
            ////var custaccount = new CustomerAccount();
            ////custaccount.CustomerName = "Larai Wush";
            ////custaccount.DisplayBalance(150);
            //Console.WriteLine("CustomerName: {0}, CustomerNumber: {1}, Balance {2}",
            //   custaccount.CustomerName, custaccount.CustomerNumber, custaccount.Balance
            //    );

            ////Exception Handling
            //try
            //{
            //    custaccount.PayBalance(150);
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine("Oops something is wrong {0}", ex.Message);
            //}
            //catch(Exception)
            //{
            //    Console.WriteLine("Something is wrong!");
            //}
            //Console.WriteLine(
            //    "CustomerName: {0}, CustomerNumber: {1}, Balance {2}",
            //   custaccount.CustomerName, custaccount.CustomerNumber, custaccount.Balance
            //    );

            ////comment out the next 4 lines
            ////Console.WriteLine("Customer Balance is " + custaccount.Balance);
            ////Console.WriteLine("Customer Name is " + custaccount.CustomerName);
            //Console.WriteLine("PRESS ENTER TO EXIT");
            //Console.ReadLine();
        }
    }
}
