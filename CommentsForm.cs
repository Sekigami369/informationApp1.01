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
        int User_Id;
        private void SetUser_Id()
        {
            MainForm mainForm = new MainForm();
            this.User_Id = mainForm.User_Id;

        }
        
        public CommentsForm()
        {
            InitializeComponent();
            comment_Load();
            SetUser_Id();
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
            string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT content FROM comments AS c " +
                    " LEFT JOIN read_history AS rh" +
                    " ON c.comment_Id = rh.comment_Id " +
                    " WHERE rh.comment_Id IS NULL AND " +
                    "userId = @User_Id;";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@User_Id", User_Id);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                }
            }
        }
    }
}
