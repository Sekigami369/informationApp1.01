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
        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";
        int UserId;

        public PastCommentsList(MainForm mainForm)
        {
            InitializeComponent();
            this.UserId = mainForm.UserId;
            Load_PastComments(UserId);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Load_PastComments(int UserId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT content FROM comments WHERE userId = @UserId;";

                using(SqlCommand command = new SqlCommand(query, connection))
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
    }
}
