using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            RunCoroutine(10000);
            Console.ReadLine();
        }

        private static void RunCoroutine(int timeOutMs)
        {
            var coroutine = new MessageCoroutine();

            var working = true;
            var stopWatch = Stopwatch.StartNew();

            while (working)
            {
                if (stopWatch.ElapsedMilliseconds >= timeOutMs)
                {
                    stopWatch.Stop();
                    throw new TimeoutException($"The coroutine timed out. Time elapsed {stopWatch.ElapsedMilliseconds}.");
                }
                working = coroutine.Update();
            }

            stopWatch.Stop();
        }
    }

}
