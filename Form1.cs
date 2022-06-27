using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ulugbek_csharp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            login_field.Text = "Username";
            password_field.Text = "Password";
            login_field.ForeColor = Color.DarkGray;
            password_field.ForeColor = Color.DarkGray; 
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.Hide();
            RegistrationScreen rs = new RegistrationScreen();
            rs.Show();
        }

        private MainMenuScreen main_menu = new MainMenuScreen();

        public void GetOtherFormTextBox() {
            main_menu.user_login_label.Text = login_field.Text;
        }

        private void enter_button_Click(object sender, EventArgs e) {
            String loginUser = login_field.Text;
            String passUser = password_field.Text;

            DB db = new DB();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //search of username and password which user entered, by the command of request to database
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @ul AND `password` = @up", db.getConnection());

            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.openConnection();

            if (table.Rows.Count > 0) {
                MessageBox.Show("Successful authorization");
                this.Hide();
                MainMenuScreen menu = new MainMenuScreen();
                menu.user_login_label.Text = login_field.Text;
                menu.Show();
            } else {
                MessageBox.Show("Error");
            }
            db.closeConnection();
        }

        private void exit_link_label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            RegistrationScreen register = new RegistrationScreen();


            register.Show();
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
        private void login_field_Leave(object sender, EventArgs e)
        {
            if(login_field.Text == "")
            {
                login_field.Text = "Username";
                login_field.ForeColor = Color.DarkGray;
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
        private void password_field_Leave(object sender, EventArgs e)
        {
            if (password_field.Text == "")
            {
                password_field.Text = "Password";
                password_field.ForeColor = Color.DarkGray;

            }
        }


    }
}
