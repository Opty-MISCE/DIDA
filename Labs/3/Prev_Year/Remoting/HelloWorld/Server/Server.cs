using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace HelloWorld {

    class Server {

        static void Main() {

            ChannelServices.RegisterChannel(new TcpChannel(8888), true);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(MyRemoteObject), "MyRemoteObjectName", WellKnownObjectMode.Singleton);

            Console.WriteLine("<Enter> -> Exit (...)");
            Console.ReadLine();
        }
    }
}
