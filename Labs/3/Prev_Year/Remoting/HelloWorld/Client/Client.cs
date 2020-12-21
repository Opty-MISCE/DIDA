using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net.Sockets;

namespace HelloWorld {

    class Client {

        static void Main() {

            ChannelServices.RegisterChannel(new TcpChannel(), true);

            var MyRemoteObjectURI = "tcp://localhost:8888/MyRemoteObjectName";

            MyRemoteObject obj = (MyRemoteObject)Activator.GetObject(typeof(MyRemoteObject), MyRemoteObjectURI);

            try {
                Console.WriteLine(obj.Greeting());

            } catch (SocketException) {

                Console.WriteLine("Couldn't Locate Server!");
            }
        }
    }
}
