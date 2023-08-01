using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data.SqlClient;


namespace informationApp1._01
{
    public partial class MainForm : Form
    {
        public readonly int UserId;
        int UnReadComment;
        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";



        public MainForm(int UserId)
        {
            InitializeComponent();

            this.UserId = UserId;

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



        private void button1_Click(object sender, EventArgs e)
        {
            string contentValue = textBox2.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query = "INSERT INTO comments(content,userId)VALUES(@content, @userId);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", UserId);
                    command.Parameters.AddWithValue("@content", contentValue);

                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("ìoò^äÆóπÇµÇ‹ÇµÇΩ");
                }
            }
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            CommentsForm cf = new CommentsForm(UserId);
            cf.ShowDialog();
        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private int LoadComment()
        {

            int UnReadCount = 0;
            string query = "SELECT COUNT(*) FROM comments AS c" +
                " WHERE c.userId = @userId AND NOT EXISTS (SELECT 1 FROM read_history AS rh WHERE rh.comment_Id = c.comment_Id AND rh.userId = @userId); ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", UserId);
                    connection.Open();
                    UnReadCount = (int)command.ExecuteScalar();

                }
            }
            return UnReadCount;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PastCommentsList pastComments = new PastCommentsList(UserId);
            pastComments.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
