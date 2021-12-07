using System;
using System.Windows.Forms;

namespace IF_PRAKTIKA
{
    public partial class Login : Form
    {
        SQL _SQL = new SQL();

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_SQL.User_Exists(TextBox_Username.Text, TexBox_Password.Text))
            {
                int userId = _SQL.Get_User_Id_By_Credentials(TextBox_Username.Text, TexBox_Password.Text);

                if (_SQL.Get_User_Role(TextBox_Username.Text, TexBox_Password.Text) == 1)
                {
                    int groupId = _SQL.Get_Group_Of_Student(TextBox_Username.Text, TexBox_Password.Text);

                    new Panel_Student(groupId, userId).Show();
                }

                if (_SQL.Get_User_Role(TextBox_Username.Text, TexBox_Password.Text) == 2)
                    new Panel_Lecturer(userId).Show();

                if (_SQL.Get_User_Role(TextBox_Username.Text, TexBox_Password.Text) == 3)
                    new Panel_Admin().Show();

                Hide();
            }
            else
                MessageBox.Show("Toks vartotojas neegzistuoja.");
        }

        private void TexBox_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
