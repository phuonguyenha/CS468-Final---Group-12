using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CS468
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonHottest_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            string query = "Select * from Songs order by streamCount dsc";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataSet data = new DataSet();
            adapter.Fill(data);

            if (data.Tables.Count > 0)
            {
                dataGridView2.DataSource = data.Tables[0];
            }
            connection.Close();
        }

        private void buttonLastest_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            connection.Open();
            string query = "Select * from Songs order by streamCount dsc";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataSet data = new DataSet();
            adapter.Fill(data);

            if (data.Tables.Count > 0)
            {
                dataGridView2.DataSource = data.Tables[0];
            }
            connection.Close();
        }

    
    }
}
