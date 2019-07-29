using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern2
{
    // Defines the data being observed in this case.
    public class MessageArgs : EventArgs
    {
        public MessageArgs(string message, string reason)
        {
            Message = message;
            Reason = reason;
        }

        public string Message { get; }
        public string Reason { get; }
    }

    // Defines how a message can be observable.
    public interface IMessageObservable
    {
        event EventHandler<MessageArgs> MessageReceived;
    }

    // Defines a message observer.
    public interface IMessageObserver
    {
        void Observe(IMessageObservable observable);
    }

}
