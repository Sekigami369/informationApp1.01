using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace informationApp1._01
{
    public partial class PastCommentsList : Form
    {
        int UserId;
        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";
        private MainForm mainForm;

        public PastCommentsList(MainForm mainForm)
        {
            InitializeComponent();
            this.UserId = mainForm.UserId;
            LoadPastComments(UserId);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommentsForm commentsForm = new CommentsForm(mainForm);
            commentsForm.IsReadComments(UserId);  //既読テーブルにUserIdを登録する  
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadPastComments(int UserId)
        {

            using(SqlConnection connection  = new SqlConnection(connectionString))
            {
                string query = "SELECT content FROM comments WHERE userId = @UserId;";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            
        }
    }
}
