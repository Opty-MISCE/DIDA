using Grpc.Core;
using Grpc.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer {
    class ChatServicesImpl : ChatServices.ChatServicesBase {

        private readonly List<Message> msgs = new List<Message>();

        private readonly Action<object> Lock = (o) => { Monitor.Enter(o); };
        private readonly Action<object> Wait = (o) => { Monitor.Wait(o, 500); };
        private readonly Action<object> Drop = (o) => { Monitor.Pulse(o); Monitor.Exit(o); };

        public override async Task Join(JoinRequest req, IServerStreamWriter<Message> ssw, ServerCallContext scc) {

            var v = 0;

            Lock(msgs);
            msgs.Add(new Message() { M = $"{req.Un}: Joined!\r\n" });

            while (true) {
                while (v == msgs.Count) {
                    if (scc.CancellationToken.IsCancellationRequested) {

                        msgs.Add(new Message() { M = $"{req.Un}: Left!\r\n" });
                        Drop(msgs);
                        return;
                    }
                    Wait(msgs);
                }

                IEnumerable<Message> pend = msgs.Skip(v);
                v = msgs.Count;

                Drop(msgs);
                await ssw.WriteAllAsync(pend);
                Lock(msgs);
            }
        }

        public override Task<Empty> SendMessage(SendMessageRequest req, ServerCallContext _) {

            Lock(msgs);
            msgs.Add(new Message() { M = $"{req.Un}: {req.M}\r\n" });
            Drop(msgs);
            return Task.FromResult(new Empty());
        }
    }
}
