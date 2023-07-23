using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data.SqlClient;


namespace informationApp1._01
{
    public partial class Form1 : Form
    {
        public readonly int User_Id;
        int UnReadComment;
        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";


        public Form1()
        {

        }

        public Form1(int UserId)
        {
            InitializeComponent();

            this.User_Id = UserId;

            UnReadComment = LoadComment();
            if (UnReadComment >= 1)
            {
                string message = UnReadComment + "���̖��ǃR�����g������܂�";
                listBox1.Items.Add(message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            UnReadComment = LoadComment();
            if (UnReadComment >= 1)
            {
                string message = UnReadComment + "���̖��ǃR�����g������܂�";
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
                    command.Parameters.AddWithValue("@userId", User_Id);
                    command.Parameters.AddWithValue("@content", contentValue);

                    connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("�o�^�������܂���");
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


        private int LoadComment()
        {

            int UnReadCount = 0;
            string query = "SELECT COUNT(c.comment_Id) AS count FROM comments AS c" +
                " LEFT JOIN read_history AS rh " +
                "ON c.comment_Id = rh.comment_Id" +  //���̂�����ɃG���[����
                " WHERE rh.comment_Id IS NULL;";

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
        
        
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
