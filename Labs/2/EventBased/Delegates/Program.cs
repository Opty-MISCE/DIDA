using System;

namespace EventBased {

    class Program {
        static void Main() {
            MyDelegate a, b, c, d;

            a = new MyDelegate(MyClass.Hello);
            b = new MyDelegate(MyClass.Goodbye);
            c = a + b;
            d = c - a;

            Console.WriteLine("Invoking Delegate A:");
            a("A");
            Console.WriteLine("Invoking Delegate B:");
            b("B");
            Console.WriteLine("Invoking Delegate C:");
            c("C");
            Console.WriteLine("Invoking Delegate D:");
            d("D");
        }
    }
}
