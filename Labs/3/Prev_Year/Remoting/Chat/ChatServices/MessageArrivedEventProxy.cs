using System;

namespace Chat {
    public class MessageArrivedEventProxy : MarshalByRefObject {

        public event MessageArrived MessageArrivedEvent;

        public override object InitializeLifetimeService() {
            return null;
        }

        public void MessageArrivedProxy(string msg) {
            MessageArrivedEvent?.Invoke(msg);
        }
    }
}
