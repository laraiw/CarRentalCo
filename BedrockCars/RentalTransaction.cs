using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockCars
{
    public enum TransactionType
    {
        Credit, Debit
    }

    public class RentalTransaction
    {
        [Key]
        public int TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public int CustomerNumber { get; set; }
        public virtual CustomerAccount CustomerAccount { get; set; }

   
    }
}
