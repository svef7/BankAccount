using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {

            List<CDAccount> AccountsList = new List<CDAccount>();
            AccountsList.Add(new CDAccount(0138999920, 2.7869M, 1205678, new DateTime(2021, 12, 09)));
            ulong accId;
            decimal interest;
            double balance;
            DateTime term;
            while (true)
            {
                Console.WriteLine("If you want to create a new account enter Yes\nOtherwise type any character:\n");
                string ans = Console.ReadLine();
                if (ans == "Yes" || ans == "yes")
                {
                    try
                    {
                        Console.WriteLine("Enter account ID: ");
                        accId = Convert.ToUInt64(Console.ReadLine());
                        Console.WriteLine("Enter interest rate: ");
                        interest = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter account balance: ");
                        balance = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter deposit term: ");
                        term = Convert.ToDateTime(Console.ReadLine());
                        AccountsList.Add(new CDAccount(accId, interest, balance, term));
                        Console.WriteLine("if you want to end this proccess enter: END\nif you want to check your account enter: MYACC\nif you want to continue enter any character:\n");
                        string ans1 = Console.ReadLine();
                        if (ans1 == "END") break;
                        else if (ans1 == "MYACC") goto MYACC;
                        else continue;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter proper values!\n");
                        continue;
                    }
                }

                else goto MYACC;
            }

        MYACC:
            Console.WriteLine("If you already have an account, enter your Account Id in order to perform desirable actions:");
            ulong id = Convert.ToUInt64(Console.ReadLine());
            foreach (var acc in AccountsList)
                while (true)
                {
                    if (id == acc.AccountId)
                    {
                        Console.WriteLine(acc.ToString());
                        CDAccount currAcc = acc;

                        Console.WriteLine("Choose prefered action:\nWithdraw\nDeposit\nExit\n");
                        string ans2 = Console.ReadLine();
                        if (ans2 == "Withdraw" || ans2 == "withdraw")
                        {
                            Console.WriteLine("Enter desirable amount\n");
                            double money = Convert.ToDouble(Console.ReadLine());
                            currAcc.Withdraw(money);
                            Console.WriteLine(currAcc.ToString());
                            Console.WriteLine("If you want to continue enter:Yes\n Otherwise enter any character");
                            string ans3 = Console.ReadLine();
                            if (ans3 == "yes" || ans3 == "Yes") continue;
                            else break;
                        }
                        else if (ans2 == "Deposit" || ans2 == "deposit")
                        {
                            Console.WriteLine("Enter desirable amount\n");
                            double money = Convert.ToDouble(Console.ReadLine());
                            currAcc.Deposit(money);
                            Console.WriteLine(currAcc.ToString());
                            Console.WriteLine("If you want to continue enter:Yes\n Otherwise enter any character");
                            string ans3 = Console.ReadLine();
                            if (ans3 == "yes" || ans3 == "Yes") continue;
                            else break;
                        }
                        else break;
                    }
                    break;
                }
            Console.WriteLine("Current accounts sorted by a balance:\n");
            AccountsList.Sort((x, y) => x.AccountBalance.CompareTo(y.AccountBalance));
            foreach (var m in AccountsList)
                Console.WriteLine(m.ToString());
        }
    }
    public class SavingAccount
    {
        public ulong AccountId { get; set; }
        public decimal InterestRate { get; set; }
        public double AccountBalance { get; set; }
        public SavingAccount() { }
        public SavingAccount(ulong accountid, double accountbalance, decimal interestrate = 2.75M)
        {
            this.AccountId = accountid;
            this.InterestRate = interestrate;
            this.AccountBalance = accountbalance;

        }
        public double Withdraw(double request)
        {
            if (request < 0)
            {
                return 0;
            }
            if (request > AccountBalance)
            {
                Console.WriteLine("You don't have enough money!");
                return 0;
            }
            AccountBalance -= request;
            return AccountBalance;
        }

        public double Deposit(double request)
        {
            if (request < 0)
            {
                return 0;
            }
            AccountBalance += request;
            return AccountBalance;
        }
    }
    public class CDAccount : SavingAccount
    {
        public DateTime DepositTerm { get; set; }
        public CDAccount() { }
        public CDAccount(ulong accountid, decimal interestrate, double accountbalance, DateTime depositTerm)
        {
            this.AccountId = accountid;
            this.InterestRate = interestrate;
            this.AccountBalance = accountbalance;
            this.DepositTerm = depositTerm;

        }
        public override string ToString()
        {
            return "Account Id: " + this.AccountId + "\nInterest Rate: "
                + this.InterestRate + "\nAccount Balance: " + this.AccountBalance
                + "\nDeposit Term " + this.DepositTerm + "\n\n";
        }
    }
}

