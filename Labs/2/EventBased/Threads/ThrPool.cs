using System;
using System.Collections.Generic;
using System.Threading;

namespace Threads {

    delegate void ThrWork();

    class ThrPool {

        private int thrCount;
        private readonly object thrCountLock = new object();
        private readonly LinkedList<ThreadStart> reqBuf;
        private readonly int thrMax;
        private readonly int reqMax;

        public ThrPool(int thrMax, int reqMax) {
            thrCount = 0;
            reqBuf = new LinkedList<ThreadStart>();
            this.thrMax = thrMax;
            this.reqMax = reqMax;
            new Thread(InvokeMonitor) { IsBackground = true }.Start();
        }

        void InvokeMonitor() {

            while (true) {

                Monitor.Enter(thrCountLock);
                while (thrCount == thrMax) Monitor.Wait(thrCountLock);
                thrCount++;
                Monitor.Exit(thrCountLock);

                Monitor.Enter(reqBuf);
                while (reqBuf.Count == 0) Monitor.Wait(reqBuf);
                ThreadStart act = reqBuf.First.Value;
                reqBuf.RemoveFirst();
                Monitor.PulseAll(reqBuf);
                Monitor.Exit(reqBuf);

                act += () => {
                    Monitor.Enter(thrCountLock);
                    thrCount--;
                    Monitor.PulseAll(thrCountLock);
                    Monitor.Exit(thrCountLock);
                };
                new Thread(act).Start();
            }
        }

        public void AssyncInvoke(ThreadStart act) {

            Monitor.Enter(reqBuf);
            while (reqBuf.Count == reqMax) Monitor.Wait(reqBuf);
            reqBuf.AddLast(act);
            Monitor.PulseAll(reqBuf);
            Monitor.Exit(reqBuf);
        }
    }
}
