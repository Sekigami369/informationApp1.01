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

            //既読テーブルの値がnull のものを表示するようにする

            UnReadComment = LoadComment();
            if (UnReadComment >= 1)
            {
                string message = UnReadComment + "件の未読コメントがあります";
                listBox1.Items.Add(message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //既読テーブルの値がnullの物を表示するよに改良する    

            UnReadComment = LoadComment();
            if (UnReadComment >= 1)
            {
                string message = UnReadComment + "件の未読コメントがあります";
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
            string contentValue = textBox2.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query = "INSERT INTO comments(content,userId)VALUES(@content, @userId);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userIdValue);
                    command.Parameters.AddWithValue("@content", contentValue);
                    
                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("登録完了しました");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private int LoadComment()
        {
            //既読テーブルからデータをとってくるように改良する  

            int UnReadCount = 0;
            string query = "SELECT COUNT(*) AS UnRead FROM usersComment WHERE isUnRead = 1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    UnReadCount = (int)command.ExecuteScalar();

                }
            }
            return UnReadCount;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
