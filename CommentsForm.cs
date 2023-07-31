using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace informationApp1._01
{
    
    public partial class CommentsForm : Form
    {
        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";
        int UserId;

        public CommentsForm(MainForm mainForm)
        {
            InitializeComponent();
            this.UserId = mainForm.UserId;
            comment_Load();
            IsReadComments(UserId);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void comment_Load()
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int UnReadCount = 0;
                string query = "SELECT c.content AS 'コメント' FROM comments AS c" +
                    " WHERE c.userId = @userId AND NOT EXISTS (SELECT 1 FROM read_history AS rh WHERE rh.comment_Id = c.comment_Id AND rh.userId = @userId); ";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                }
            }
        }


        public async Task IsReadComments(int UserId)  //未接続メソッド
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO read_history (comment_id, userId) " +
                               " SELECT comment_id, @UserId " +
                               " FROM comments AS C " +
                               " WHERE NOT EXISTS ( SELECT 1 " +
                               " FROM read_history AS rh " +
                               " WHERE rh.comment_id = c.comment_id AND rh.userId = @UserId);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

