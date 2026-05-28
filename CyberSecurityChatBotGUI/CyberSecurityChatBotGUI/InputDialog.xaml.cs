using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace CyberSecurityChatBotGUI
{
    public partial class InputDialog : Window
    {
        public string UserName { get; private set; }

        public InputDialog()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.BorderBrush = System.Windows.Media.Brushes.Red;
                return;
            }
            UserName = txtName.Text.Trim();
            DialogResult = true;
            Close();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnStart_Click(sender, null);
        }
    }
}
      