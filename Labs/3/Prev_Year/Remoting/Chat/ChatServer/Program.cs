using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;

namespace Chat {
    class Program {
        static void Main() {

            Console.Write("Chat Server Port: ");
            var prps = new Hashtable { { "name", "" }, { "port", Convert.ToInt16(Console.ReadLine()) } };
            var prov = new BinaryServerFormatterSinkProvider() { TypeFilterLevel = TypeFilterLevel.Full };

            TcpServerChannel channel = new TcpServerChannel(prps, prov);
            ChannelServices.RegisterChannel(channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ChatServices), "OptyChatServices", WellKnownObjectMode.Singleton);

            Console.WriteLine("<Enter> -> Exit (...)");
            Console.ReadLine();
            ChannelServices.UnregisterChannel(channel);
        }
    }
}
