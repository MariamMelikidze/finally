using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    public class CardDetails
    {
        public int CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CVC { get; set; }
    }

    public class Transaction
    {
        public string TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public int Amount { get; set; }
        public int AmountUSD { get; set; }
        public int AmountEUR { get; set; }
    }

    public class testclass
    {
        internal object cardDetails;
        internal int amount;

        public int Amount { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public CardDetails CardDetails { get; set; }
        public string Pincode { get; set; }
        public List<Transaction> TransactionHistory { get; set; }
        public int CVC { get; set; }
        public int PIN { get; set; }

        public testclass()
        {
            TransactionHistory = new List<Transaction>();
        }
    }


}
