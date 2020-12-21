using System.Windows.Forms;

namespace WindowsFormsApp {
    public partial class UIFormList : Form {
        private ElemList elemList = new ElemList();

        public UIFormList() {
            InitializeComponent();
            MessageBox.Show("Hello World!");
        }

        private void buttonInsert_MouseClick(object sender, MouseEventArgs e) {
            elemList.Insert(textBoxInput.Text);
            textBoxInput.Text = "";
        }

        private void buttonShow_MouseClick(object sender, MouseEventArgs e) {
            textBoxOutput.Text = elemList.Show();
        }

        private void buttonClear_MouseClick(object sender, MouseEventArgs e) {
            textBoxOutput.Text = "";
            elemList.Clear();
        }

        private void buttonSave_MouseClick(object sender, MouseEventArgs e) {
            elemList.Save();
            MessageBox.Show("Save Succeed!");
        }
    }
}
