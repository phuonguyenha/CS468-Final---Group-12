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
            activeButton1 = buttonHottest;
        }

        private Button activeButton1 = null; // hottest or lastest
        private Button activeButton2 = null; // genre
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clearDataGridView()
        {
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Rows.Clear();
        }

        private void buttonHottest_Click(object sender, EventArgs e)
        {
            if (activeButton1 != buttonHottest)
            {
                activeButton1.BackColor = Color.PaleTurquoise;
                activeButton1 = buttonHottest;
                activeButton1.BackColor = Color.DarkTurquoise;
            }
            SqlConnection connection = null;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
            SqlParameter playlistid = new SqlParameter("@playlistid", SqlDbType.Int);
            playlistid.Value = 1;
            SqlParameter genre = new SqlParameter("@genre", SqlDbType.NVarChar);
            genre.Value = "Pop";
            string query = "sp_selectMoiNhat";

            clearDataGridView();
            try
            {
                DataSet data = Program.ExecuteQuery(connection, query, connectionString, CommandType.StoredProcedure,  playlistid, genre);
                dataGridView2.DataSource = data.Tables[0];
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonLastest_Click(object sender, EventArgs e)
        {
            if (activeButton1 != buttonLastest)
            {
                activeButton1.BackColor = Color.PaleTurquoise;
                activeButton1 = buttonLastest;
                activeButton1.BackColor = Color.DarkTurquoise;
            }
            SqlConnection connection = null;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
            SqlParameter playlistid = new SqlParameter("@playlistid", SqlDbType.Int);
            playlistid.Value = 1;
            SqlParameter genre = new SqlParameter("@genre", SqlDbType.NVarChar);
            string query = "sp_selectMoiNhat";

            clearDataGridView();
            try
            {
                DataSet data = Program.ExecuteQuery(connection, query, connectionString, CommandType.StoredProcedure, playlistid, genre);
                dataGridView2.DataSource = data.Tables[0];
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /**
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
        */


    }
}
