using System;
using System.Threading;

namespace Threads {

    class A {
        private readonly int id;

        public A(int id) {
            this.id = id;
        }

        public void DoWorkA() {
            Console.WriteLine("Turning On A-{0}!", id);
            Thread.Sleep(5000);
            Console.WriteLine("Shutting Down A-{0}!", id);
        }
    }
}
