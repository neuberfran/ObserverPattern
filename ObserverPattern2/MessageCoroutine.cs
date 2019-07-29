using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern2
{
    public class MessageCoroutine : Coroutine
    {
        protected IEnumerator PassedControl(ObservableMessage observer)
        {
            observer.SendMessage("Hello", "Testing coroutines. Waiting one second.");
            yield return WaitFor(1000);
            Console.WriteLine("Passed Control Complete");
        }

        protected override IEnumerator OnUpdate()
        {
            // Register our observer.
            var messagePrinter = new ObservableMessage();
            var messagePrinterObservers = new MessageObserver();
            messagePrinterObservers.Observe(messagePrinter);
            // Use our IEnumerator to raise the event being observed.
            yield return PassedControl(messagePrinter);
            // Now do some work here.
            Console.WriteLine("Waiting one second from the main OnUpdate now.");
            yield return WaitFor(1000);
            messagePrinter.SendMessage("Updating", "Updating the test to wait another 2 seconds.");
            yield return WaitFor(2000);
            messagePrinter.SendMessage("Bye", "The test has been complete.");
        }
    }

}
