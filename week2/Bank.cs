using System;   // Imports System namespace to use Console and Convert classes

class Bank
{
    // Stores account holder name
    static string accountHolder;

    // Stores account balance (initially 0)
    static double balance = 0;

    // Stores PIN for account security
    static int pin;

    // Flag to check whether user is authenticated
    static bool isAuthenticated = false;

    // Method to create a new bank account
    public static void CreateAccount()
    {
        // Ask user to enter account holder name
        Console.Write("Enter Account Holder Name: ");
        accountHolder = Console.ReadLine();

        // Ask user to set a PIN
        Console.Write("Set a 4-digit PIN: ");
        pin = Convert.ToInt32(Console.ReadLine());

        // Initialize balance to zero
        balance = 0;

        // Confirm account creation
        Console.WriteLine("Account created successfully!");
    }

    // Method to authenticate user using PIN
    static bool VerifyPin()
    {
        // Ask user to enter PIN
        Console.Write("Enter PIN: ");
        int enteredPin = Convert.ToInt32(Console.ReadLine());

        // Check if entered PIN matches stored PIN
        if (enteredPin == pin)
        {
            return true; // PIN correct
        }
        else
        {
            Console.WriteLine("Incorrect PIN!");
            return false; // PIN incorrect
        }
    }

    // Method to deposit money into account
    public static void Deposit()
    {
        // Verify PIN before allowing deposit
        if (!VerifyPin()) return;

        // Ask user for deposit amount
        Console.Write("Enter amount to deposit: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        // Add amount to balance
        balance += amount;

        // Confirm deposit
        Console.WriteLine("Amount deposited successfully.");
    }

    // Method to withdraw money from account
    public static void Withdraw()
    {
        // Verify PIN before allowing withdrawal
        if (!VerifyPin()) return;

        // Ask user for withdrawal amount
        Console.Write("Enter amount to withdraw: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        // Check if balance is sufficient
        if (amount > balance)
        {
            Console.WriteLine("Insufficient balance!");
        }
        else
        {
            // Deduct amount from balance
            balance -= amount;
            Console.WriteLine("Withdrawal successful.");
        }
    }

    // Method to display account balance
    public static void CheckBalance()
    {
        // Verify PIN before showing balance
        if (!VerifyPin()) return;

        // Display account holder name
        Console.WriteLine($"Account Holder: {accountHolder}");

        // Display current balance
        Console.WriteLine($"Current Balance: {balance}");
    }
}
