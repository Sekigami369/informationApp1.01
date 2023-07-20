using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data.SqlClient;


namespace informationApp1._01
{
    public partial class Form1 : Form
    {
        int UnReadComment;
        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";
        public Form1()
        {
            InitializeComponent();
            UnReadComment = LoadComment();
            if (UnReadComment >= 1)
            {
                string message = UnReadComment + "åèÇÃñ¢ì«ÉRÉÅÉìÉgÇ™Ç†ÇËÇ‹Ç∑";
                listBox1.Items.Add(message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userIdValue = textBox1.Text;
            string userNameValue = textBox2.Text;
            string commentValue = textBox3.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query = "INSERT INTO usersComment(userId, userName, comment)VALUES(@userId, @userName, @comment);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@userId",userIdValue);
                    command.Parameters.AddWithValue("@userName", userNameValue);
                    command.Parameters.AddWithValue("@comment", commentValue);
                    
                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("ìoò^äÆóπÇµÇ‹ÇµÇΩ");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private int LoadComment()
        {
            int UnReadCount = 0;
            string query = "SELECT COUNT(*) AS UnRead FROM usersComment WHERE isUnRead = 1;";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    UnReadCount = (int)command.ExecuteScalar();                   

                }
            }
            return UnReadCount;
        }
    }
}
