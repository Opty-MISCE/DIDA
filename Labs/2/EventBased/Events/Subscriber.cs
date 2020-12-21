using System;

namespace Events {

    class Subscriber {

        public string Name { get; set; }

        private readonly EventList pub;

        public Subscriber(EventList pub) {

            this.pub = pub;
            SubscribePub();
        }

        void OnChanged(EventList src, OnChangedArgs e) {

            switch (e.Type) {
                case OnChangedType.Added: Console.WriteLine("{0} Notified: Product Added!", Name); break;
                case OnChangedType.Cleared: Console.WriteLine("{0} Notified: List Cleared!", Name); break;
                case OnChangedType.Changed: Console.WriteLine("{0} Notified: Product Changed!", Name); break;
            }
        }

        public void SubscribePub() {

            pub.OnChangedHandler += OnChanged;
        }

        public void UnsubscribePub() {

            pub.OnChangedHandler -= OnChanged;
        }
    }
}
