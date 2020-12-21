using System;

namespace Events {

    enum OnChangedType { Added, Cleared, Changed }

    class OnChangedArgs : EventArgs {

        public OnChangedType Type { get; set; }
    }
}
