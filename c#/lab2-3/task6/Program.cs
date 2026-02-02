using System;

public class BankAccount
{
    private string accountNumber;
    private double balance;
    private string ownerName;

    public BankAccount(string name, string number, double initialBalance)
    {
        ownerName = name;
        accountNumber = number;
        balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
        }
    }

    public void Transfer(BankAccount targetAccount, double amount)
    {
        if (amount <= balance)
        {
            this.Withdraw(amount);
            targetAccount.Deposit(amount);
        }
    }

    public double GetBalance()
    {
        return balance;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Owner: {ownerName}, Account: {accountNumber}, Balance: ${balance}");
    }
}

public class Program
{
    public static void Main()
    {
        BankAccount account1 = new BankAccount("Ahmed", "A101", 5000);
        BankAccount account2 = new BankAccount("Sara", "S202", 3000);

        account1.Deposit(1000);
        account1.Withdraw(500);
        
        account1.Transfer(account2, 2000);

        account1.DisplayInfo();
        account2.DisplayInfo();

        Console.ReadKey();
    }
}