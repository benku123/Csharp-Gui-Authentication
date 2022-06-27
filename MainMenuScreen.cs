using System;

using System.Windows.Forms;

namespace ulugbek_csharp {
    public partial class MainMenuScreen : Form {
        public MainMenuScreen() {
            InitializeComponent();
        }

        private void MainMenuScreen_Load(object sender, EventArgs e)
        {

        }

        private void X_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
