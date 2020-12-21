using System;
using System.Threading;
using System.Windows.Forms;
using Grpc.Core;
using Grpc.Net.Client;

namespace ChatClient {

    public partial class Form : System.Windows.Forms.Form {

        private GrpcChannel channel = null;
        private ChatServices.ChatServicesClient client = null;
        private CancellationTokenSource cts = null;

        public Form() {
            InitializeComponent();

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        }

        private void ConnectButton_Click(object sender, EventArgs _) {

            if (client != null) {
                MessageBox.Show("Already Connected to a Chat Server!");
                return;
            }

            if (IPTB.TextLength == 0 || PortTB.TextLength == 0 || UserNameTB.TextLength == 0) {
                MessageBox.Show("Incomplete Binding!");
                return;
            }

            var ChatServicesURL = $"http://{IPTB.Text}:{PortTB.Text}";

            try {
                channel = GrpcChannel.ForAddress(ChatServicesURL);
                client = new ChatServices.ChatServicesClient(channel);
                cts = new CancellationTokenSource();
                RecvMessage(client.Join(new JoinRequest() { Un = UserNameTB.Text }));

            } catch (Exception ex) {
                LeaveChat();
                MessageBox.Show(ex.Message);
            }
        }

        private async void RecvMessage(AsyncServerStreamingCall<Message> ssc) {

            try {
                await foreach (var msg in ssc.ResponseStream.ReadAllAsync(cts.Token)) ChatTB.AppendText(msg.M);

            } catch (RpcException ex) when (ex.Status.StatusCode == StatusCode.Cancelled) {
                // Stream Cancelled!

            } catch (Exception ex) {
                LeaveChat();
                MessageBox.Show(ex.Message);
            }
        }

        private void SendButton_Click(object sender, EventArgs _) {

            if (client == null) {
                MessageBox.Show("Connect to a Chat Server!");
                return;
            }

            if (MessageTB.Text.Length == 0) {
                MessageBox.Show("Invalid Message (Len == 0)!");
                return;
            }

            try {
                client.SendMessage(new SendMessageRequest() { Un = UserNameTB.Text, M = MessageTB.Text });
                MessageTB.Clear();

            } catch (Exception ex) {
                LeaveChat();
                MessageBox.Show(ex.Message);
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs _) {

            if (client == null) {
                MessageBox.Show("No Chat Server Prior Connected!");
                return;
            }

            LeaveChat();
            MessageBox.Show("Disconnected!");
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs _) {
            LeaveChat();
        }

        private void LeaveChat() {

            if (cts != null) cts.Cancel();
            if (channel != null) channel.Dispose();

            ChatTB.Clear();
            channel = null;
            client = null;
            cts = null;
        }
    }
}
