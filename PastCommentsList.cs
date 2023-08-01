using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace informationApp1._01
{
    public partial class PastCommentsList : Form
    {
        int UserId;
        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";


        public PastCommentsList(int UserId)
        {
            InitializeComponent();
            this.UserId = UserId;
            Load_PastComments(UserId);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommentsForm commentsForm = new CommentsForm(UserId);
            commentsForm.IsReadComments(UserId);  //既読テーブルにUserIdを登録する  
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Load_PastComments(int UserId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT content FROM comments WHERE userId = @UserId;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
