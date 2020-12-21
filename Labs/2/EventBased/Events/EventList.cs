using System;
using System.Collections;

namespace Events {

    class EventList : ArrayList {

        public event Action<EventList, OnChangedArgs> OnChangedHandler;

        protected virtual void OnChanged(OnChangedArgs e) {

            if (OnChangedHandler != null) {
                OnChangedHandler(this, e);
                return;
            }

            Console.WriteLine("No Subscribers!");
        }

        public override int Add(object prod) {

            int i = base.Add(prod);
            OnChanged(new OnChangedArgs() { Type = OnChangedType.Added });
            return i;
        }

        public override void Clear() {

            base.Clear();
            OnChanged(new OnChangedArgs() { Type = OnChangedType.Cleared });
        }

        public override object this[int i] {

            set {
                base[i] = value;
                OnChanged(new OnChangedArgs() { Type = OnChangedType.Changed });
            }
        }
    }
}
