using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern2
{
    public static class DateTimeExtensions
    {
        public static long MSecToNow(this DateTime date)
        {
            return (DateTime.Now.Ticks - date.Ticks) / TimeSpan.TicksPerMillisecond;
        }
    }

    public abstract class Coroutine
    {
        private IEnumerator _enumerator;
        private bool _started;
        private bool _completed;

        public virtual void Start()
        {
            _started = true;
            _enumerator = OnUpdate();
        }

        public virtual bool Update()
        {
            if (!_started)
                Start();

            var result = Process(_enumerator);

            if (result || _completed)
                return result;

            _completed = true;
            OnComplete();

            return false;
        }


        protected abstract IEnumerator OnUpdate();

        protected virtual void OnComplete()
        {

        }

        protected IEnumerator WaitFor(int waitTimeMs)
        {
            var startedWaiting = DateTime.Now;
            while (startedWaiting.MSecToNow() < waitTimeMs)
            {
                yield return true;
            }
        }

        private static bool Process(IEnumerator enumerator)
        {
            bool result;
            if (enumerator == null) return false;
            var subEnumerator = enumerator.Current as IEnumerator;
            if (subEnumerator != null)
            {
                result = Process(subEnumerator);
                if (!result)
                {
                    result = enumerator.MoveNext();
                }
            }
            else
            {
                result = enumerator.MoveNext();
            }

            return result;
        }
    }

}
