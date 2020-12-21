using System;
using System.Threading;

namespace Threads {

    class B {
        private readonly int id;

        public B(int id) {
            this.id = id;
        }

        public void DoWorkB() {
            Console.WriteLine("Turning On B-{0}!", id);
            Thread.Sleep(5000);
            Console.WriteLine("Shutting Down B-{0}!", id);
        }
    }
}
