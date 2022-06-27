using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ulugbek_csharp {
    public partial class RegistrationScreen : Form {
        public RegistrationScreen() {
            InitializeComponent();
            login_field.Text = "Username";
            email_field.Text = "Email";
            password_field.Text = "Password";
            confirmation.Text = "Confirmation";
            login_field.ForeColor = Color.DarkGray;
            email_field.ForeColor = Color.DarkGray;
            password_field.ForeColor = Color.DarkGray;
            confirmation.ForeColor = Color.DarkGray;
        }

        private async void register_button_Click(object sender, EventArgs e) {
            if (password_field.Text != confirmation.Text)
            {
                MessageBox.Show("Password does not match!");
            }
            else
            {
                DB db = new DB();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @ur", db.getConnection());
                command.Parameters.Add("@ur", MySqlDbType.VarChar).Value = login_field.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("User with this username is already exists");
                }
                else 
                { 
                    DB db2 = new DB();

                    //add new field 
                    MySqlCommand command2 = new MySqlCommand("INSERT INTO `users` (`username`, `password`,  `email`, `id`) VALUES (@ur, @ps, @em, NULL)", db2.getConnection());
                    command2.Parameters.Add("@ur", MySqlDbType.VarChar).Value = login_field.Text;
                    command2.Parameters.Add("@em", MySqlDbType.VarChar).Value = email_field.Text;
                    command2.Parameters.Add("@ps", MySqlDbType.VarChar).Value = password_field.Text;

                    db2.openConnection();

                    if (command2.ExecuteNonQuery() == 1)
                    {

                        MessageBox.Show("Success");
                        this.Hide();

                        MainMenuScreen menu = new MainMenuScreen();

                        menu.user_login_label.Text = login_field.Text;
                        menu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }

                    db2.closeConnection();
                    db.closeConnection();
                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.Hide();
            { };
        }

        private void exit_link_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            Form1 form_s = new Form1();


            form_s.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void login_field_Enter(object sender, EventArgs e)
        {
            if(login_field.Text == "Username")
            {
                login_field.Text = "";
                login_field.ForeColor = Color.Black;
            }

        }
        private void password_field_Enter(object sender, EventArgs e)
        {
            if (password_field.Text == "Password")
            {
                password_field.Text = "";
                password_field.ForeColor = Color.Black;
            }

        }
        private void email_field_Enter(object sender, EventArgs e)
        {
            if (email_field.Text == "Email")
            {
                email_field.Text = "";
                email_field.ForeColor = Color.Black;
            }

        }
        private void confirmation_Enter(object sender, EventArgs e)
        {
            if(confirmation.Text == "Confirmation")
            {
                confirmation.Text = "";
                confirmation.ForeColor = Color.Black;   
            }
        }


    }
}
