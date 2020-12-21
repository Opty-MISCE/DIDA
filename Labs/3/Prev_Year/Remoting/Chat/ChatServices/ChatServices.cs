using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Chat {

    public delegate void MessageArrived(string m);

    public class ChatServices : MarshalByRefObject {

        private readonly object MessageArrivedEventLock = new object();

        public event MessageArrived MessageArrivedEvent;

        public override object InitializeLifetimeService() {
            return null;
        }

        public void Join(string un, MessageArrived callback) {

            Monitor.Enter(MessageArrivedEventLock);
            MessageArrivedEvent += callback;
            Monitor.Exit(MessageArrivedEventLock);
            SendMessage(un, "Joined!");
        }

        public void Leave(string un, MessageArrived callback) {

            Monitor.Enter(MessageArrivedEventLock);
            MessageArrivedEvent -= callback;
            Monitor.Exit(MessageArrivedEventLock);
            SendMessage(un, "Left!");
        }

        public void SendMessage(string un, string m) {

            Monitor.Enter(MessageArrivedEventLock);

            if (MessageArrivedEvent == null) {
                Monitor.Exit(MessageArrivedEventLock);
                return;
            }

            IEnumerable<MessageArrived> cbs = MessageArrivedEvent.GetInvocationList().Cast<MessageArrived>();

            Monitor.Exit(MessageArrivedEventLock);

            foreach (MessageArrived cb in cbs) {

                try {
                    cb?.Invoke($"{un}: {m}\r\n");

                } catch (Exception) {
                    Leave(un, cb);
                }
            }
        }
    }
}
