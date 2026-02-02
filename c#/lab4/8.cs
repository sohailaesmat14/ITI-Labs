using System;

public interface IPrintable
{
    void PrintDetails();
}

public interface ITransactable
{
    void Deposit(double amount);
    bool Withdraw(double amount);
}

public abstract class Account : IPrintable, ITransactable
{
    public string AccountNumber { get; }
    public string OwnerName { get; set; }
    public double Balance { get; protected set; }

    public Account(string accountNumber, string ownerName, double initialBalance)
    {
        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = initialBalance;
    }

    public abstract void CalculateInterest();

    public virtual void Deposit(double amount)
    {
        Balance += amount;
    }

    public virtual bool Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    public abstract void PrintDetails();
}

public class SavingsAccount : Account
{
    private double interestRate;

    public SavingsAccount(string accNum, string name, double bal, double rate)
        : base(accNum, name, bal)
    {
        interestRate = rate;
    }

    public override void CalculateInterest()
    {
        double interest = Balance * (interestRate / 100);
        Deposit(interest);
    }

    public override void PrintDetails()
    {
        Console.WriteLine($"[Savings] Owner: {OwnerName}, Acc: {AccountNumber}, Balance: {Balance}, Rate: {interestRate}%");
    }
}

public class CheckingAccount : Account
{
    private double overdraftLimit;

    public CheckingAccount(string accNum, string name, double bal, double limit)
        : base(accNum, name, bal)
    {
        overdraftLimit = limit;
    }

    public override void CalculateInterest()
    {}

    public override bool Withdraw(double amount)
    {
        if (amount <= Balance + overdraftLimit)
        {
            return true;
        }
        return false;
    }

    public override void PrintDetails()
    {
        Console.WriteLine($"[Checking] Owner: {OwnerName}, Acc: {AccountNumber}, Balance: {Balance}, Limit: {overdraftLimit}");
    }
}

class Program8
{
    static void Main()
    {
        Account[] accounts = new Account[2];
        accounts[0] = new SavingsAccount("S123", "Ahmed", 1000, 5);
        accounts[1] = new CheckingAccount("C456", "Mona", 500, 200);

        foreach (var acc in accounts)
        {
            acc.Deposit(500);
            acc.CalculateInterest();
            acc.PrintDetails();
        }
    }
}