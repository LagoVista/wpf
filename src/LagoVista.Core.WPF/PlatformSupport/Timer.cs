using LagoVista.Core.IOC;
using LagoVista.Core.PlatformSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.Core.WPF.PlatformSupport
{
    public class Timer : ITimer
    {
        System.Threading.Timer _timer;

        public TimeSpan Interval { get; set; }

        public bool InvokeOnUIThread { get; set; } = false;

        public object State { get; set; }

        public event EventHandler Tick;

        public void Dispose()
        {
            lock(this)
            {
                if(_timer != null)
                {
                    _timer.Dispose();
                    _timer = null;
                }
            }
        }

        private void Timer_Elapsed(object state)
        {
            if(InvokeOnUIThread)
            {
                SLWIOC.Get<IDispatcherServices>().Invoke(() => Tick?.Invoke(this, null));
            }
            else
            {
                Tick?.Invoke(this, null); 
            }
        }

        public void Start()
        {
            _timer = new System.Threading.Timer(Timer_Elapsed,null, 0, Interval.Milliseconds);
        }

        public void Stop()
        {
            _timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            Dispose();
        }
    }
}
