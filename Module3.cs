using System;

namespace Module3Demo
{
    // .txt class Test
    public class Test
    {
        public const string Message = "Demo by Nayobe: Polymorphism Example with Notifications";
    }

    // Base Notification class
    public abstract class Notification
    {
        public string Recipient;
        public abstract void Send();
    }

    // subclass Email Notification
    public class EmailNotification : Notification
    {
        public override void Send()
        {
            Console.WriteLine($"Sending Email to {Recipient} - Subject: Group Meeting");
        }
    }

    // Subclass SMS Notification
    public class SmsNotification : Notification
    {
        public override void Send()
        {
            Console.WriteLine($"Sending SMS to {Recipient} - Message: Group meeting at at 19:30!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Test.Message);
            Console.WriteLine();

            // Base type references different subclass objects
            Notification email = new EmailNotification { Recipient = "user@example.com" };
            Notification sms = new SmsNotification { Recipient = "+1234567890" };

            
            email.Send();
            sms.Send();

            
            SendAlert(email);
            SendAlert(sms);
        }

        static void SendAlert(Notification n)
        {
            Console.WriteLine($"Alert sent to {n.Recipient}");
        }
    }
}
