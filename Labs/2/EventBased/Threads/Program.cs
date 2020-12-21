using System;
using System.Threading;

namespace Threads {

    class Program {
        static void Main() {

            ThrPool pool = new ThrPool(5, 10);

            int i = 0;

            while (i < 20) {

                A a = new A(i);
                pool.AssyncInvoke(new ThreadStart(a.DoWorkA));
                Console.WriteLine("Invoke Number: {0}!", ++i);

                B b = new B(i);
                pool.AssyncInvoke(new ThreadStart(b.DoWorkB));
                Console.WriteLine("Invoke Number: {0}!", ++i);
            }
        }
    }
}
