using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace informationApp1._01
{
    public partial class LoginForm : Form
    {
        int UserId;
        string Password;

        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";


        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            string passWord = textBox2.Text;

            if(!int.TryParse(input, out UserId))
            {
                MessageBox.Show("4桁の数字を入力してください。");
            }


            if (!ValidCheck(passWord))
            {
                MessageBox.Show("パスワードを入力してください。");
                return;
            }

            if (!IsAlphaNumeric(passWord))
            {
                MessageBox.Show("半角英数字で入力してください。");
                return;
            }
                    
            if (IdAndPassCheck(UserId, passWord))
            {
                 MainForm form1 = new MainForm(UserId);
                 form1.ShowDialog();
                 this.Close();
            }
            else
            {
                MessageBox.Show("IDもしくはパスワードが間違っています。");
                return;
            }
                
            
        }

        private bool IsAlphaNumeric(string PassWord)
        {
            string pattern = @"[^\x00-\x7F]"; //半角英数字以外を検出する正規表現

            if (Regex.IsMatch(PassWord, pattern))
            {
                return　false;
            }
            return true;
        }

        private bool ValidCheck(string PassWord)
        {
            if(string.IsNullOrWhiteSpace(PassWord))
            {
                return false;
            }
            return true;
        }

        private bool IdAndPassCheck(int UserId, string PassWord)
        {
            string query = "SELECT COUNT(*) FROM idPass WHERE id = @UserId AND pass = @pass;";
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@pass", PassWord);

                    connection.Open();
                    count = (int)command.ExecuteScalar();

                }
            }
            if (count > 0)
            {
                return true;
            }
            return false;
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
