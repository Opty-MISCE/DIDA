using System;

namespace EventBased {

    delegate void MyDelegate(string s);

    class MyClass {
        public static void Hello(string s) {
            Console.WriteLine("Hello, {0}!", s);
        }

        public static void Goodbye(string s) {
            Console.WriteLine("Goodbye, {0}!", s);
        }
    }
}
