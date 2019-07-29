using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern2
{
    // This is the observer implementation.
    public class MessageObserver : IMessageObserver
    {
        public void Observe(IMessageObservable observable)
        {
            observable.MessageReceived += PrinterOnMessageReceived;
        }

        private static void PrinterOnMessageReceived(object sender, MessageArgs messageArgs)
        {
            Console.WriteLine($"Sender: {sender}{Environment.NewLine}" +
                              $"Message: {messageArgs.Message}{Environment.NewLine}" +
                              $"Reason: {messageArgs.Reason}{Environment.NewLine} ");
        }
    }
}


