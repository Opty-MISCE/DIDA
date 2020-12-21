using System;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Collections;

namespace Chat {

    public partial class Form : System.Windows.Forms.Form {

        private readonly TcpChannel channel;
        private readonly MessageArrivedEventProxy proxy;
        private ChatServices services = null;

        public Form() {
            InitializeComponent();

            var prps = new Hashtable { { "name", "" }, { "port", 0 } };
            var cProv = new BinaryClientFormatterSinkProvider();
            var sProv = new BinaryServerFormatterSinkProvider() { TypeFilterLevel = TypeFilterLevel.Full };

            channel = new TcpChannel(prps, cProv, sProv);

            proxy = new MessageArrivedEventProxy();
            proxy.MessageArrivedEvent += new MessageArrived(RecvMessage);
        }

        private void ConnectButton_Click(object sender, EventArgs e) {

            if (services != null) {
                MessageBox.Show("Already Connected to a Chat Server!");
                return;
            }

            if (IPTB.TextLength == 0 || PortTB.TextLength == 0 || UserNameTB.TextLength == 0) {
                MessageBox.Show("Incomplete Binding!");
                return;
            }

            var ChatServicesURL = $"tcp://{IPTB.Text}:{PortTB.Text}/OptyChatServices";

            try {
                ChannelServices.RegisterChannel(channel, false);
                services = (ChatServices)Activator.GetObject(typeof(ChatServices), ChatServicesURL);
                services.Join(UserNameTB.Text, proxy.MessageArrivedProxy);

            } catch (Exception ex) {

                services = null;
                ChannelServices.UnregisterChannel(channel);
                MessageBox.Show(ex.Message);
            }
        }

        private void SendButton_Click(object sender, EventArgs e) {

            if (services == null) {
                MessageBox.Show("Connect to a Chat Server!");
                return;
            }

            if (MessageTB.Text.Length == 0) {
                MessageBox.Show("Invalid Message (Len == 0)!");
                return;
            }

            try {
                services.SendMessage(UserNameTB.Text, MessageTB.Text);
                MessageTB.Clear();

            } catch (Exception ex) {

                services = null;
                ChannelServices.UnregisterChannel(channel);
                MessageBox.Show(ex.Message);
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e) {

            if (services == null) {
                MessageBox.Show("No Chat Server Prior Connected!");
                return;
            }

            LeaveChat();
            MessageBox.Show("Disconnected!");
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e) {
            LeaveChat();
        }

        private void RecvMessage(string m) {

            if (ChatTB.InvokeRequired) {
                ChatTB.BeginInvoke(new MessageArrived(RecvMessage), new object[] { m });

            } else {
                ChatTB.AppendText(m);
            }
        }

        private void LeaveChat() {

            if (services != null) {
                services.Leave(UserNameTB.Text, proxy.MessageArrivedProxy);
                services = null;
                ChannelServices.UnregisterChannel(channel);
            }
        }
    }
}
