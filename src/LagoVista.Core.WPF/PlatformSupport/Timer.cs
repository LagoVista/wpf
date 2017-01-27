﻿using LagoVista.Core.IOC;
using LagoVista.Core.PlatformSupport;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            lock (this)
            {
                if (_timer != null)
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
                Object objDispatcher;

                if (SLWIOC.TryResolve(typeof(IDispatcherServices), out objDispatcher))
                {
                    var dispatcher = objDispatcher as IDispatcherServices;
                    dispatcher.Invoke(() => Tick?.Invoke(this, null));
                }
                else
                {
                    throw new Exception("To invoke timer on UI thread you must register a type for IDispatcherService for your current platform.  This is usually done by calling [Platform]Serivces.Init(Dispatcher) for you platform.");
                }
            }
            else
            {
                Tick?.Invoke(this, null); 
            }
        }

        public void Start()
        {
            _timer = new System.Threading.Timer(Timer_Elapsed, null, 0, Convert.ToInt32(Interval.TotalMilliseconds));
        }

        public void Stop()
        {
            _timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            Dispose();
        }
    }
}