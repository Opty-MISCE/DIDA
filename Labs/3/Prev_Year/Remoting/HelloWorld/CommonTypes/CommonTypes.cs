using System;

namespace HelloWorld {

    public class MyRemoteObject : MarshalByRefObject {

        public string Greeting() {

            return "Hello World!";
        }
    }
}
