// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;

//-----------------------------------------------------------------
//Car
//
// Name: David Zientara
// Date: 7-14-2022
// Comments: An exercise in polymorphism
// Added methods per the instructions
//-----------------------------------------------------------------

public class BankAccount
{
    private double Balance { get; set; }
    // Deposit
    // Takes a value and adds it to balance
    // PARAMS: value (double)
    // RETURNS: Nothing; value added to balance
    public void Deposit(double value)
    {
        Balance += value;
    }
    // Withdraw
    // Takes a value and subtracts it from balance,
    // if that's possible
    // PARAMS: value (double)
    // RETURNS: if value > balance, false; otherwise true
    public bool Withdraw(double value)
    {
        if (value > Balance)
            return false;
        Balance -= value;
        return true;
    }
    // GetBalance
    // Returns the balance
    // PARAMS: Nothing
    // Returns: Balance (double)
    public double GetBalance()
    {
        return Balance;
    }
    // BankAccount
    // Constructor for BankAccount
    // PARAMS: balance (double)
    // RETURNS: Nothing; Balance is set
    // equal to balance
    public BankAccount(double balance)
    {
        Balance = balance;
    }
    // BankAccount
    // Constructor for BankAccount
    // PARAMS: Nothing
    // RETURNS: Nothing; Balance set to zero
    public BankAccount()
    {
        Balance = 0;
    }

}
class Program
{ 
    public static void Main()
    {
        BankAccount Account = new BankAccount();
        bool parsegood = false;
        string? str = "";
        // Have a loop which prints the current balance; queries user
        // to deposit, withdraw, or quit:
        do
        {
            Console.WriteLine($"Your current balance is ${Account.GetBalance().ToString("0.00")}");
            Console.WriteLine($"[Deposit] money, or [Withdraw] money, or [Quit]?");
          
            str = Console.ReadLine(); 
            // If it's not an acceptable input, just keep looping:
            if (str != null && (str.ToLower().Equals("deposit") || str.ToLower().Equals("withdraw")))
            {
                Console.WriteLine("Enter amount: ");
                string? amt = Console.ReadLine();
                double val = 0;
                do
                {
                    parsegood = Double.TryParse(amt, out val);
                } while (!parsegood);
                if (str.ToLower().Equals("deposit"))
                    Account.Deposit(val);
                else if (str.ToLower().Equals("withdraw"))
                    if (!Account.Withdraw(val))
                        Console.WriteLine("You can't withdraw more than you have.");

            }
            if (str == null)
                str = "";
        } while (!str.ToLower().Equals("quit"));
    }
}
