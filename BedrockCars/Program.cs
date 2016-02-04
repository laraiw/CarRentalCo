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
            var userLoginAttempts = 3;
            var loginSuccessful = false;
            Console.WriteLine("WELCOME TO BEDROCK CAR RENTAL!!!");
            while (userLoginAttempts > 0 && !loginSuccessful)
            {
                userLoginAttempts--;
                Console.WriteLine("PLEASE ENTER YOUR DRIVER'S LICENSE NUMBER:");
                var driv_lic = Console.ReadLine();
                int convertedDrivingLicense;
                if (int.TryParse(driv_lic, out convertedDrivingLicense) == true)
                {
                    loginSuccessful = true;
                    var custaccounts = CarRentalFactory.GetAllAccountsByDL(convertedDrivingLicense);
                    if (custaccounts.Count() == 0)
                    {
                        Console.WriteLine("No accounts found for the driver's license number: {0}", driv_lic);
                        Console.Write("Do you want to create one? (y/n)");
                        var choice = Console.Read();
                        if (choice == 89 || choice == 121)
                        {
                            Console.ReadLine();
                            Console.Write("Please Enter Your Name: ");
                            var custname = Console.ReadLine();
                            var custaccount = CarRentalFactory.CreateAccount(custname, convertedDrivingLicense);
                            var balance = CarRentalFactory.DisplayBalance(custaccount.CustomerNumber, 100);
                            Console.WriteLine("Your account has been successfully created and credited with  get $100.");
                            Console.WriteLine("Here are you account details - Account number: {0}, Current Balance: {1:c}", custaccount, custaccount.Balance);
                            Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        foreach (var custaccount in custaccounts)
                        {
                            Console.WriteLine("CustomerNumber: {0}, Balance: {1:c}, press any key to continue", custaccount.CustomerNumber, custaccount.Balance);
                            Console.ReadLine();
                        }
                        Console.WriteLine("1. Deposit");
                        Console.WriteLine("2. Withdraw");
                        Console.WriteLine("0. Exit");
                        var choice = Console.Read();
                        if (choice == 49 || choice == 50)
                        {
                            Console.ReadLine();
                            Console.Write("Please Enter your Customer Account number: ");
                            var custAccountNo = Console.ReadLine();
                            Console.Write("Amount to deposit/withdraw: ");
                            var amount = Console.ReadLine();
                            int convertedCustAccountNo;
                            if (int.TryParse(custAccountNo, out convertedCustAccountNo))
                            {
                                var foundcustAccount = custaccounts.Where(a => a.CustomerNumber == convertedCustAccountNo).FirstOrDefault();
                                if (foundcustAccount == null)
                                {
                                    Console.WriteLine("Invalid account number. Exiting...");
                                    return;
                                }


                                decimal convertedAmount;
                                if (decimal.TryParse(amount, out convertedAmount))
                                {
                                    try
                                    {
                                        var newBalance = (choice == 49) ?
                                         CarRentalFactory.DisplayBalance(convertedCustAccountNo, convertedAmount) :
                                         CarRentalFactory.PayBalance(convertedCustAccountNo, convertedAmount);
                                        Console.WriteLine("Transaction was successful. New balance in the account {0} is {1:c}", convertedCustAccountNo, newBalance);
                                    }
                                    catch (ArgumentNullException argnullx)
                                    {
                                        Console.WriteLine("Transaction failed - {0} ", argnullx.Message);
                                    }
                                    catch (ArgumentException argx)
                                    {
                                        Console.WriteLine("Transaction failed - {0} ", argx.Message);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Something went wrong.");
                                    }
                                }
                            }
                        }
                        else
                            return;
                    
                    }
                }
            }
        }
    }
}
                    