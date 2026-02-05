using System;

namespace Task2
{
    public delegate void NotifyHandler(string message);

    class Program2
    {
        static void Main(string[] args)
        {
            NotifyHandler notify = SendEmail;
            notify += SendSMS;
            notify += LogToFile;

            notify("Order confirmed!");

            Console.WriteLine();

            notify -= SendSMS;

            notify("Shipped!");
        }

        public static void SendEmail(string message)
        {
            Console.WriteLine("Email sent: " + message);
        }

        public static void SendSMS(string message)
        {
            Console.WriteLine("SMS sent: " + message);
        }

        public static void LogToFile(string message)
        {
            Console.WriteLine("Logged: " + message);
        }
    }
}