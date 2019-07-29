using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern2
{
    // This is the observer implementation.
    public class ObservableMessage : IMessageObservable
    {
        public event EventHandler<MessageArgs> MessageReceived;

        // This function allows worker classes to write something that can be signaled to observers.
        public void SendMessage(string message, string reason)
        {
            // Here we can perform some tests before sending the message
            if (string.IsNullOrEmpty(reason))
            {
                throw new ArgumentNullException(nameof(reason));
            }

            if (MessageReceived == null)
            {
                return;
            }

            var printMessageArgs = new MessageArgs(message, reason);

            OnMessageReceived(printMessageArgs);
        }

        protected virtual void OnMessageReceived(MessageArgs e)
        {
            // This raises our event observers listen to.
            MessageReceived?.Invoke(this, e);
        }

        public override string ToString()
        {
            // We use this just for the example to print the 'sender'.
            return "Observable Message.";
        }
    }

}
