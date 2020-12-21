using System;
using Grpc.Core;

namespace ChatServer {
    class Program {

        static readonly string host = "localhost";
        static int port;

        static void Main() {

            Console.Write("Chat Server Port: ");
            port = Convert.ToInt16(Console.ReadLine());

            Server s = new Server {
                Services = { ChatServices.BindService(new ChatServicesImpl()) },
                Ports = { new ServerPort(host, port, ServerCredentials.Insecure) }
            };
            s.Start();

            Console.WriteLine("Chat Server Listening on {0}:{1}!", host, port);
            Console.WriteLine("<Enter> -> Stop Chat Server (...)");
            Console.ReadLine();
            s.ShutdownAsync().Wait();
        }
    }
}
