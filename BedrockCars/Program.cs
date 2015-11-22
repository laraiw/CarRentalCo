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
            //Create and instance of an account == object
            var custaccount = new CustomerAccount();
            custaccount.CustomerNumber = 001;
            custaccount.CustomerName = "Florence Nightingale";
            custaccount.DisplayBalance(500);
            Console.WriteLine("Customer Balance is " + custaccount.Balance);
            Console.WriteLine("Customer Name is " + custaccount.CustomerName);
            Console.WriteLine("PRESS ENTER TO EXIT");
            Console.ReadLine();
        }
    }
}
